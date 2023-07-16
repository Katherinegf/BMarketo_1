namespace WebApp.ViewModels
{
    public class GridCollectionViewModel
    {
        public string Title { get; set; } = "";

        public IEnumerable<string>? Categories { get; set; } = null!;
        public IEnumerable<GridCollectionCardViewModel> GridCards { get; set; } = null!;

        public bool LoadMore { get; set; } = false;
    }
}
