using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities
{
    public class ProductCategoryEntity
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public CategoryEntity Category { get; set; } = null!;
    }
}
