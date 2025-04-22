using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ModeloNet6.Data;
using ModeloNet6.Helpers;
using ModeloNet6.ViewModels;
using ModeloNet6.Interface;
using Microsoft.AspNetCore.Authorization;

namespace ModeloNet6.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthSaltHash _authSalt;

        public LoginController(ApplicationDbContext context, AuthSaltHash authSalt)
        {
            _context = context;
            _authSalt = authSalt;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Erro(string msg)
        {
            ViewBag.ErrorMessage = "usuários sem permissão!";
            return View("Index");
        }

        public IActionResult DoLogin()
        {
            return View("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoLogin(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios.Where(u => u.nome == viewModel.usuario).FirstOrDefault();

                if (user == null || !Hash.Validate(viewModel.senha, _authSalt.auth_salt, user.senha))
                {
                    ViewBag.ErrorMessage = "usuários inválido";
                    ModelState.AddModelError("Usuario", "Invalid credentials");
                    return View("../Login/Index", viewModel);
                }

                List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    new Claim(ClaimTypes.Name, user.nome),
                    new Claim(ClaimTypes.Role, user.perfil),
                    new Claim(ClaimTypes.Role, "OutrosPerfil ou lista"),
                    new Claim("ID", user.id.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            return View("../Login/Index", viewModel);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}