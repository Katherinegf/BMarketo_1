namespace WebApp.ViewModels;

public class RelatedProductsViewModel
{
    public string Heading { get; set; } = "Related Products";
    public IEnumerable<GridCollectionCardViewModel> GridCards { get; set; } = null!;
}