using Microsoft.AspNetCore.Mvc;
using PizzaMenu.Utilities;
using PizzaMenu.Data;
using PizzaMenu.Models;
using System.Xml.Linq;
using Stripe.Checkout;

namespace PizzaMenu.Controllers
{
    public class ShoppingCartController : Controller
    {
        const string SESSION_KEY = "MyCart";

        private readonly AppDbContext _context;

        public ShoppingCartController(AppDbContext ctx)
        {
            _context = ctx;
        }

        [HttpPost]
        public IActionResult AddToCart(int id, int numItems)
        {
            MenuItem? addedItem = _context.MenuItems.Find(id);

            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();

            CartItem? existingItem = cartItems.FirstOrDefault(b => b.MenuItem.Id == id);

            if (existingItem != null)
            {
                existingItem.Amount += numItems;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    MenuItem = addedItem,
                    Amount = numItems,
                });
            }

            HttpContext.Session.Set(SESSION_KEY, cartItems);

            TempData["CartMessage"] = $"Added {addedItem.Name} to Cart";
            
            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();

            return View(new ShoppingCartVM()
            {
                CartItems = cartItems,
                TotalAmount = cartItems.Count,
                TotalPrice = cartItems.Sum(c => c.MenuItem.Price * c.Amount)
            });
        }
        public IActionResult RemoveFromCart(int id)
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();
            CartItem? itemToRemove = cartItems.FirstOrDefault(b => b.MenuItem.Id == id);

            if (itemToRemove != null)
            {
                if (itemToRemove.Amount > 1)
                {
                    itemToRemove.Amount -= 1;
                }
                else
                {
                    cartItems.Remove(itemToRemove);
                }
                TempData["CartMessage"] = $"Removed {itemToRemove.MenuItem.Name} from Cart";
            }

            HttpContext.Session.Set(SESSION_KEY, cartItems);
            return RedirectToAction("ViewCart");
        }

        public IActionResult Checkout()
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();
            var domain = "https://localhost:7109";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "",
            };
            foreach(CartItem item in cartItems)
            {
                SessionLineItemOptions sessionLine = new()
                {
                    Price = item.MenuItem.PriceId,
                    Quantity = item.Amount
                };
                options.LineItems.Add(sessionLine);
            }
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
