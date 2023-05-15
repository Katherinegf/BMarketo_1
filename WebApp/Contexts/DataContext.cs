using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class DataContext : DbContext
{
    public DbSet<ProfileEntity> ProfileEntities { get; set; }
    public DbSet<UserEntity> UserEntities { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
