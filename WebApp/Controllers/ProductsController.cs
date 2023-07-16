using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApp.Models;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly CheckboxOptionService _checkBoxOptionService;
    private readonly GridCollectionCardService _gridCollectionCardService;

    public ProductsController(ProductService productService, CheckboxOptionService checkBoxOptionService, GridCollectionCardService gridCollectionCardService)
    {
        _productService = productService;
        _checkBoxOptionService = checkBoxOptionService;
        _gridCollectionCardService = gridCollectionCardService;
    }
    //INDEX
    public async Task<IActionResult> Index()
    {

        var viewModel = new ProductsIndexViewModel
        {
            Title = "Products",
            All = new GridCollectionViewModel
            {
                Title = "All Products",
                GridCards = await _gridCollectionCardService.PopulateCardsWithAllProductsAsync(),

                LoadMore = false
            }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    //DETAILS
    public async Task<IActionResult> Details(int id)
    {
        if (id == 0) { return RedirectToAction("index", "home"); }

        var viewModel = new ProductsDetailsViewModel
        {
            Title = "Product Details",
            ShopHero = new HeroModel
            {
                Heading = "SHOP",
                Subheading = "HOME. PRODUCT DETAILS",
                BackgroundImg = "/images/header.jpg"
            },
            Related = new RelatedProductsViewModel
            {
             
                GridCards = new List<GridCollectionCardViewModel>
                {
                    new GridCollectionCardViewModel{ Id = 1, Title = "PLACEHOLDER", Price = 10, ImageUrl = "product.jpg" },
                    new GridCollectionCardViewModel{ Id = 2, Title = "PLACEHOLDER", Price = 20, ImageUrl = "product.jpg" },
                    new GridCollectionCardViewModel{ Id = 3, Title = "PLACEHOLDER", Price = 30, ImageUrl = "product.jpg" },
                    new GridCollectionCardViewModel{ Id = 4, Title = "PLACEHOLDER", Price = 40, ImageUrl = "product.jpg" },
                }
            },
        };

        if (await _productService.GetAsync(x => x.Id == id) == null) { return RedirectToAction("index", "home"); }

        viewModel.Product = await _productService.GetAsync(x => x.Id == id);

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    //PRODUCT LIST
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> List()
    {
        var viewModel = new ProductListViewModel
        {
            Title = "Product List",
            Products = await _productService.GetAllAsync()
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> List(ProductListViewModel viewModel)
    {
        viewModel.Products = await _productService.GetAllAsync();

        if (ModelState.IsValid)
        {
            try
            {
                if (await _productService.RemoveAsync(viewModel.ProductId))
                    return RedirectToAction("list", "products");
                else
                    ModelState.AddModelError("", "An error occurred while removing the product, and it could not be removed.");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while removing the product, and it could not be removed");
            }

        }

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }


    //REGISTER PRODUCT
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Register()
    {

        var viewModel = new ProductRegisterViewModel
        {
            Title = "Register Product",
            Checkboxes = await _checkBoxOptionService.PopulateCategoryCheckBoxesAsync()
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Register(ProductRegisterViewModel viewModel)
    {

        viewModel.Title = "Register Product";

        if (ModelState.IsValid)
        {
            try
            {
                if (viewModel.CheckboxCategoryId.Count == 0)
                {
                    ModelState.AddModelError("", "Please enter at least one product category.");

                    viewModel.Checkboxes = await _checkBoxOptionService.PopulateCategoryCheckBoxesAsync();
                    ViewData["Title"] = viewModel.Title;

                    return View(viewModel);
                }

                if (await _productService.RegisterAsync(viewModel))
                    return RedirectToAction("register", "products");
                else
                    ModelState.AddModelError("", "Something went wrong while creating the product.");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong while creating the product.");
            }

        }

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}

