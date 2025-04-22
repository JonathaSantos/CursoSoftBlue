using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModeloNet6.Data;
using ModeloNet6.Helpers;
using ModeloNet6.Models;
using ModeloNet6.ViewModels;
using System.Security.Claims;

namespace ModeloNet6.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthSaltHash _authSalt;

        public RegisterController(ApplicationDbContext context, AuthSaltHash authSalt)
        {
            _context = context;
            _authSalt = authSalt;
        }
        [Authorize(Roles = "ADM,ADM_SUPER")]
        public IActionResult Index()
        {
            if (!User.IsInRole("ADM_SUPER"))
            {
                ViewBag.ErrorMessage = $"{User.FindFirst(ClaimTypes.NameIdentifier).Value} Usuário sem permissão no sistema.";
                return View("../Home/Index");
            }
            return View();
        }

        [Authorize(Roles = "ADM,ADM_SUPER")]
        public async Task<IActionResult> DoRegistrantion(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios.Where(u => u.nome == viewModel.usuario).FirstOrDefault();
                try
                {
                    if (user != null)
                    {
                        ModelState.AddModelError("Usuario", "Usuário já existe no sistema");
                        return View("../Register/Index", viewModel);
                    }
                    var usuario = new Usuario
                    {
                        nome = viewModel.usuario,
                        senha = Hash.Create(viewModel.senha, _authSalt.auth_salt),
                        perfil = viewModel.perfil
                    };

                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();
                    ViewBag.SuccessMessage = $"Sucesso ao incluir no Sistema. {usuario.nome}";
                    return RedirectToAction("Index", "Register");
                }
                catch (System.Exception ex)
                {
                    ViewBag.ErrorMessage = $"Erro no sistema. {ex.Message}";
                    ModelState.AddModelError("Usuario", $"Erro no sistema. {ex.Message}");
                    return View("../Login/Index", viewModel);
                }

            }

            return View("../Register/Index");
        }


    }
}
