using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    public IActionResult Register()
    {
       
        return View();
    }
    [HttpPost]
    public IActionResult Register(RegisterViewModel registerViewModel)
    {
       if (ModelState.IsValid)
        {
            UserEntity userEntity = registerViewModel;

            ProfileEntity profileEntity = registerViewModel;
            profileEntity.ProfileId = userEntity.Id;


        }
        return View(registerViewModel);
    }













    public IActionResult Index()
    {
        return View();
    }
}
