using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaMenu.Data;
using PizzaMenu.Models;

namespace PizzaMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext ctx)
        {
            _context = ctx;
        }

        public IActionResult Index(string searchString)
        {
            var menuItems = from d in _context.MenuItems
                                       select d;
            if(!String.IsNullOrWhiteSpace(searchString))
                menuItems = menuItems.Where(d => d.Name.Contains(searchString));
            return View(menuItems.ToList());
        }

        public IActionResult Details(int id)
        {
            MenuItem? menuItem = _context.MenuItems
                .Include(mi => mi.ItemIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefault(x => x.Id == id);
            return View(menuItem);
        }
    }
}
