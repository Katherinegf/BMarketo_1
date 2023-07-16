using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Search";
            return View();
        }
    }
}
