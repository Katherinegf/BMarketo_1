using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class AccountLoginViewModel
{
    public string? Title { get; set; }

    [Display(Name = "E-mail*")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please enter your E-mail.")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password*")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter your Password.")]
    public string Password { get; set; } = null!;
    public bool KeepLoggedIn { get; set; } = false;
}

