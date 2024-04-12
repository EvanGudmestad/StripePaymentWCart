using Microsoft.AspNetCore.Mvc;
using PizzaMenu.Models;
using PizzaMenu.Utilities;
using Stripe.Checkout;

namespace PizzaMenu.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Success()
        {
            HttpContext.Session.Set("MyCart", new List<CartItem>());
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
