﻿namespace WebApp.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public GridCollectionViewModel BestCollection { get; set; } = null!;
    public GridCollectionViewModel NewCollection { get; set; } = null!;
    public GridCollectionViewModel TopSellingCollection { get; set; } = null!;
    public SpotlightViewModel LampSpotlight { get; set; } = null!;
}