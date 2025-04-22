using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModeloNet6.Data;
using ModeloNet6.Helpers;
using ModeloNet6.ViewModels;
using System.Security.Claims;

namespace ModeloNet6.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthSaltHash _authSalt;

        public ProfileController(ApplicationDbContext context, AuthSaltHash authSalt)
        {
            _context = context;
            _authSalt = authSalt;
        }
        public IActionResult Index()
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = _context.Usuarios.Find(userID);

            var viewModel = new ProfileViewModel
            {
                usuario = user.nome,
                perfil = user.perfil
            };

            return View(viewModel);
        }
        public IActionResult UsuariosLista()
        {
            //var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var users = _context.Usuarios.ToList();
            var listUsers = new List<UsuariosViewModel>();
            users.ForEach(x =>
            {
                listUsers.Add(new UsuariosViewModel
                {
                    usuario = x.nome,
                    perfil = x.perfil
                });
            });
            //List<Item> items = user.Items;
            return View("ListaUsuario", listUsers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var user = _context.Usuarios.Find(userID);

                user.nome = viewModel.usuario;

                if (!String.IsNullOrEmpty(viewModel.senha))
                {
                    user.senha = Hash.Create(viewModel.senha, _authSalt.auth_salt);
                }
                if (!String.IsNullOrEmpty(viewModel.perfil) && !user.perfil.Equals(viewModel.perfil))
                {
                    user.perfil = viewModel.perfil;
                }
                _context.Usuarios.Update(user);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage = "Sucesso Atualização Updated";
            }

            return View("../Profile/Index", viewModel);
        }
    }
}