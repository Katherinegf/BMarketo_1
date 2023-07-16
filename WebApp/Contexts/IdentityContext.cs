using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class IdentityContext:  IdentityDbContext<IdentityUser>
{
   public IdentityContext(DbContextOptions<IdentityContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
      
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575", Name = "admin", NormalizedName = "ADMIN" });
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "c08b0750-b989-4e8c-9fa6-27d8a60d1b3d", Name ="user", NormalizedName ="USER" });
        
        builder.Entity<AddressEntity>()
           .HasIndex(x => x.StreetName)
           .IsUnique();
    }
    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<AddressEntity>Addresses { get; set; }
}
