using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models;

namespace WebApp.ViewModels;

public class ProductRegisterViewModel
{

    public string? Title { get; set; }

    [Display(Name = "Product Name*")]
    [Required(ErrorMessage = "Please enter the product name.")]
    public string Name { get; set; } = null!;


    [Display(Name = "Product Description*")]
    [Required(ErrorMessage = "Please enter the product description.")]
    public string Description { get; set; } = null!;


    [Display(Name = "Product Price*")]
    [Required(ErrorMessage = "Please enter the product price.")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Large Product Image (optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageLg { get; set; }

    [Display(Name = "Small Product Image (optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageSm { get; set; }

    public List<CheckboxOptionModel> Checkboxes { get; set; } = new();

    public List<int> CheckboxCategoryId { get; set; } = new();


    #region implicit operators

    public static implicit operator ProductEntity(ProductRegisterViewModel viewModel)
    {
        var productEntity = new ProductEntity
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price
        };

        if (viewModel.ImageLg != null)
        {
            productEntity.LgImgUrl = $"{Guid.NewGuid()}_{viewModel.ImageLg.FileName}";
        }

        if (viewModel.ImageSm != null)
        {
            productEntity.SmImgUrl = $"{Guid.NewGuid()}_{viewModel.ImageSm.FileName}";
        }

        return productEntity;
    }

    #endregion
}
