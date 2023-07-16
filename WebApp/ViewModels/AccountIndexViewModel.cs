using WebApp.Models.Entities;
using WebApp.Models;

namespace WebApp.ViewModels;

public class AccountIndexViewModel
{
    public string? Title { get; set; }
    public UserProfileEntity UserProfile { get; set; } = null!;
    public UserModel User { get; set; } = null!;
}
