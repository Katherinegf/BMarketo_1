using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin - Dashboard";
            return View();
        }
    }
}
