using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;
using WebApp.Models;
using WebApp.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly RoleService _roleService;

    public UserService(IdentityContext identityContext, RoleService roleService)
    {
        _identityContext = identityContext;
        _roleService = roleService;
    }

    public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
    {
        var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).Include(x => x.Address).FirstOrDefaultAsync(x => x.UserId == userId);
        return userProfileEntity!;
    }

    public async Task<IdentityUser> GetIdentityUserAsync(string email)
    {
        var identityUser = await _identityContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        return identityUser!;
    }

    public async Task<IEnumerable<UserModel>> GetAllUserModelAsync()
    {
        var userModels = new List<UserModel>();
        var userProfileEntities = await _identityContext.UserProfiles.Include(x => x.User).ToListAsync();

        var roles = await _roleService.GetUserRolesAsync();

        foreach (var user in userProfileEntities)
        {

            UserModel userModel = user;

            var foundRole = roles.FirstOrDefault(x => x.Id == userModel.Id);

            userModel.Role = foundRole!.RoleName;

            userModels.Add(userModel);
        }

        return userModels!;
    }
}
