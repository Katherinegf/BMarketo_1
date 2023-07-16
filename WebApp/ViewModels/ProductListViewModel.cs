using WebApp.Models;

namespace WebApp.ViewModels;

public class ProductListViewModel
{
    public string? Title { get; set; }
    public IEnumerable<ProductModel> Products { get; set; } = null!;

    public int ProductId { get; set; }
}
