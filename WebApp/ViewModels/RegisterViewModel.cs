using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage ="Du måste ange ett förnamn")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
    [Display(Name = "Förnamn")]
    public string Firstname { get; set; } = null!;


    [Required(ErrorMessage ="Du måste ange ett efternamn")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
    [Display(Name = "Efternamn")]
    
    public string Lastname { get; set; } = null!;


    [Required(ErrorMessage ="Du måste ange ett e-postadress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="Du måste ange en giltig e-postadress")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E -postadress")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage ="Du måste ange ett läsenord")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$",ErrorMessage ="Du måste ange ett giltigt lösenord")]
    [DataType(DataType.Password)]
    [Display(Name = "Lösenord")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage ="Du måste bekräfta lösenordet")]
    [Compare(nameof(Password), ErrorMessage ="Lösenordet matchar inte")]
    [DataType(DataType.Password)]
    [Display(Name = "Bekröfta lösenord")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "gatunamn")]
    public string? StreetName { get; set; }


    [Display(Name = "Postnummer")]
    public string? PostalCode { get; set; }


    [Display(Name = "Stad")]
    public string? City { get; set; }


    public static implicit operator UserEntity(RegisterViewModel registerViewModel)
    {
        var userEntity = new UserEntity { Email = registerViewModel.Email, };
        userEntity.GenerateSecurePassword(registerViewModel.Password);
        return userEntity;
    }

    public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
    {
        return new ProfileEntity
        {
            FirstName = registerViewModel.Firstname,
            LastName = registerViewModel.Lastname,
            StreetName = registerViewModel.StreetName,
            PostalCode = registerViewModel.PostalCode,
            City = registerViewModel.City,
        };
    }
}
