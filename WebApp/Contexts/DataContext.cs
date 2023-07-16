using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class DataContext : DbContext
{
    public DbSet<ProfileEntity> Profiles { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
