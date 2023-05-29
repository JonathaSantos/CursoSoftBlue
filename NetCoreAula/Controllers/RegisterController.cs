using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NetCoreAula.Data;
using NetCoreAula.Helpers;
using NetCoreAula.Models;
using NetCoreAula.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ToDo.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //try
            //{
            var t = Environment.GetEnvironmentVariable("AUTH_SALT");
            var user = _context.User.OrderBy(u => u.CreateAt).ToList();
            return View();

            //}
            //catch (Exception ex)
            //{
            //    ViewData["Title"] = $"Erro {ex.Message}";

            //    return new JavaScriptResult(sb.ToString());
            //}
        }
        [HttpPost]
        public async Task<IActionResult> DoRegistrantion(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = registerViewModel.Name,
                    Email = registerViewModel.Email,
                    Password = Hash.Create(registerViewModel.Password, "Hztr1;2PfFT6~k/|}&c?$HRDaM)X,2HBBgc-%(,.8TE!/4BIY?_}:eTrca1N#56("),
                    CreateAt = DateTime.Now

                };
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Authentication, "ADM"),
                    new Claim(ClaimTypes.Role, "ADM")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            return View("../Register/Index", registerViewModel);
        }


    }
}
