using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }



    public IActionResult Register()
    {
       
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
       if (ModelState.IsValid)
        {
            try
            {
                if (!await _context.Users.AnyAsync(x => x.Email == registerViewModel.Email))
                {

                    // convert to userEntity and profileEntity from registrationform
                    UserEntity userEntity = registerViewModel;
                    ProfileEntity profileEntity = registerViewModel;

                    // create user
                    _context.Users.Add(userEntity);
                    await _context.SaveChangesAsync();

                    //create user profile
                    profileEntity.UserId = userEntity.Id;
                    _context.Profiles.Add(profileEntity);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Det finns redan en användare med samma e-postadress");
            }
            catch 
            {
                ModelState.AddModelError("", "Något gick fel när användaren skulle skapas");
            }
        }
        return View(registerViewModel);
    }













    public IActionResult Index()
    {
        return View();
    }
}
