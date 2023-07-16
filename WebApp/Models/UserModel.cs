using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;

namespace WebApp.Models;

public class UserModel
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Role { get; set; } = null!;
    public string? ProfileImage { get; set; }

    #region implicit operators

    public static implicit operator UserModel(UserProfileEntity entity)
    {
        return new UserModel
        {
            Id = entity.User.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.User.Email!,
            PhoneNumber = entity.User.PhoneNumber,
            ProfileImage = entity.ProfileImage
        };
    }
       public static implicit operator UserModel(IdentityUser entity)
    {
        return new UserModel
        {
            Id = entity.Id,
            Email = entity.Email!,
            PhoneNumber = entity.PhoneNumber
        };
    }
    #endregion


}

