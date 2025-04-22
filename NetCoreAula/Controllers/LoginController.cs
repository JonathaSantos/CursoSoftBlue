using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ModeloNet6.Data;
using ModeloNet6.Helpers;
using ModeloNet6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModeloNet6.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoLogin(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.Where(u => u.Email == viewModel.Email).FirstOrDefault();

                if (user == null || !Hash.Validate(viewModel.Password, "Hztr1;2PfFT6~k/|}&c?$HRDaM)X,2HBBgc-%(,.8TE!/4BIY?_}:eTrca1N#56(", user.Password))
                {
                    ModelState.AddModelError("Email", "Invalid credentials");
                    return View("../Login/Index", viewModel);
                }

                List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    //new Claim(ClaimTypes.Actor, "ADM"),
                    //new Claim(ClaimTypes.Authentication, "ADM"),
                    new Claim(ClaimTypes.Role, "ADM"),
                    new Claim(ClaimTypes.Role, "SEC")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            return View("../Login/Index", viewModel);
        }
    }
}
