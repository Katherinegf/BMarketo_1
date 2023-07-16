using WebApp.Models;

namespace WebApp.Services
{
    public class ShowcaseService
    {
        private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "SHOP SHOP SHOP",
            Title = "Mighty golden throne Collection.",
            Button = new LinkButtonModel()
            {
                Url = "/products",
                Content = "SHOP NOW"
            },
            ImageUrl = "./images/chair.jpg"
        },
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection.",
            Button = new LinkButtonModel()
            {
                Url = "/products",
                Content = "SHOP NOW"
            },
            ImageUrl = "./images/chair.jpg"
        }
    };

        public ShowcaseModel GetLatest()
        {
            return _showcases.LastOrDefault()!;
        }


        //Get just one
        private readonly ShowcaseModel showcase = new()
        {
            Ingress = "SHOP SHOP SHOP SHOP SHOP",
            Title = "Mighty golden throne Collection.",
            Button = new LinkButtonModel()
            {
                Url = "/products",
                Content = "SHOP NOW"
            },
            ImageUrl = "./images/chair.jpg"
        };

        public ShowcaseModel GetShowcase()
        {
            return showcase;
        }
    }
}

