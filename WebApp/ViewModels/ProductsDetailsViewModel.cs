using WebApp.Models;

namespace WebApp.ViewModels;

public class ProductsDetailsViewModel
{
    public string? Title { get; set; } = "Product";
    public HeroModel ShopHero { get; set; } = null!;
    public RelatedProductsViewModel Related { get; set; } = null!;

    public ProductModel Product { get; set; } = null!;
}
