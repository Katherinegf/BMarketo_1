using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Cart";
            return View();
        }
    }
}
