using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModeloNet6.Data;
using ModeloNet6.Models;
using ModeloNet6.ViewModels;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModeloNet6.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Guid userID = Guid
                    .Parse(User
                        .FindFirst(ClaimTypes.NameIdentifier).Value);

                Item item = new Item
                {
                    Description = viewModel.Description,
                    UserId = userID,
                    CreateAt = DateTime.Now,
                };

                _context.Item.Add(item);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View("../Item/Add", viewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Item item = _context.Item.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            Guid userID = Guid
                    .Parse(User
                        .FindFirst(ClaimTypes.NameIdentifier).Value);

            if (item.UserId != userID)
            {
                return NotFound();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
