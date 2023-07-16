using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly AuthService _auth;
    private readonly UserService _userService;
    private readonly RoleService _roleService;


    public AccountController(SignInManager<IdentityUser> signInManager, AuthService auth, UserService userService, RoleService roleService)
    {
        _signInManager = signInManager;
        _auth = auth;
        _userService = userService;
        _roleService = roleService;
    }

    //INDEX
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var _identityUser = await _userService.GetIdentityUserAsync(User!.Identity!.Name!);

        var viewModel = new AccountIndexViewModel
        {
            Title = "My Account",
            UserProfile = await _userService.GetUserProfileAsync(_identityUser.Id),
            User = await _userService.GetIdentityUserAsync(User!.Identity!.Name!)
        };

        var roleModel = await _roleService.GetSpecificUserRolesAsync(_identityUser.Id);

        //This also makes the first letter in roleModel.RoleName to be capitalized:
        viewModel.User.Role = char.ToUpper(roleModel.RoleName[0]) + roleModel.RoleName.Substring(1);

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    //REGISTER
    public IActionResult Register()
    {
        ViewData["Title"] = "Register Account";

        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("index", "account");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountRegisterViewModel viewModel)
    {
        ViewData["Title"] = "Register Account";

        if (ModelState.IsValid)
        {
            if (await _auth.RegisterAsync(viewModel))
                return RedirectToAction("login", "account");

            ModelState.AddModelError("", "A user with that e-mail already exists.");
        }

        return View(viewModel);
    }

    //LOGIN
    public IActionResult Login()
    {
        ViewData["Title"] = "Login";

        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("index", "account");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AccountLoginViewModel viewModel)
    {
        ViewData["Title"] = "Try again";

        if (ModelState.IsValid)
        {
            if (await _auth.LoginAsync(viewModel))
                return RedirectToAction("index", "account");

            ModelState.AddModelError("", "Incorrect e-mail or password.");
        }

        return View(viewModel);
    }

    //LOGOUT
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        if (await _auth.LogoutAsync(User))
        {
            return RedirectToAction("index", "home");
        }

        return RedirectToAction("login", "account");
    }

    //ACCESS DENIED
    [Authorize]
    public IActionResult AccessDenied()
    {
        ViewData["Title"] = "Access Denied";
        return View();
    }

    //NEW PASSWORD
    public IActionResult NewPassword()
    {
        ViewData["Title"] = "New Password";
        return View();
    }
}