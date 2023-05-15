using Microsoft.AspNetCore.Mvc;

namespace WebApp.Views.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
