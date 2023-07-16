﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class UserProfileEntity
{
    [Key, ForeignKey("User")]
    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    //public string? StreetName { get; set; } = null!;
    //public string? PostalCode { get; set; } = null!;
    //public string? City { get; set; } = null!;

    //Optional
    public string? CompanyName { get; set; }
    public string? ProfileImage { get; set; }



    public IdentityUser User { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}
