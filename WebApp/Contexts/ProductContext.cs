using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;


public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>().HasData(
            new { Id = 1, Name = "new" },
            new { Id = 2, Name = "popular" },
            new { Id = 3, Name = "featured" }
        );

        modelBuilder.Entity<ProductCategoryEntity>()
            .HasKey(pce => pce.Id);
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductCategoryEntity> ProductsCategories { get; set; }

}

