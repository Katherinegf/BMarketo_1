using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApp.Models.Entities;
using WebApp.ViewModels;
using WebApp.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _identityContext;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
    }

    //User registration
    public async Task<bool> RegisterAsync(AccountRegisterViewModel viewModel)
    {
        try
        {
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            IdentityUser identityUser = viewModel;
            await _userManager.CreateAsync(identityUser, viewModel.Password);

            await _userManager.AddToRoleAsync(identityUser, roleName);

            UserProfileEntity userProfileEntity = viewModel;
            userProfileEntity.UserId = identityUser.Id;

            AddressEntity addressEntity = viewModel;

            //Checks if there is any matching address in the db.
            var addressInDb = await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == viewModel.StreetName);
            if (addressInDb != null)
            {
                userProfileEntity.AddressId = addressInDb.Id;
            }
            else
            {
                _identityContext.Addresses.Add(addressEntity);
                await _identityContext.SaveChangesAsync();
                userProfileEntity.AddressId = addressEntity.Id;
            }

            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch {
            throw;
            return false;
        }
    }

    //User registration in back-office
    public async Task<bool> RegisterAsync(UsersRegisterViewModel viewModel)
    {
        try
        {
            IdentityUser identityUser = viewModel;
            await _userManager.CreateAsync(identityUser, viewModel.Password);

            if (viewModel.Role != null)
                await _userManager.AddToRoleAsync(identityUser, viewModel.Role);

            UserProfileEntity userProfileEntity = viewModel;
            userProfileEntity.UserId = identityUser.Id;

            AddressEntity addressEntity = viewModel;

            //Checks if there is any matching address in the db.
            var addressInDb = await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == viewModel.StreetName);
            if (addressInDb != null)
            {
                userProfileEntity.AddressId = addressInDb.Id;
            }
            else
            {
                _identityContext.Addresses.Add(addressEntity);
                await _identityContext.SaveChangesAsync();
                userProfileEntity.AddressId = addressEntity.Id;
            }

            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch {
            throw;
            return false; }
    }

    public async Task<bool> LoginAsync(AccountLoginViewModel viewModel)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.KeepLoggedIn, false);

            return result.Succeeded;
        }
        catch { return false; }
    }

    public async Task<bool> LogoutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();

        return _signInManager.IsSignedIn(user);
    }
}