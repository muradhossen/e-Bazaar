using System.ComponentModel.DataAnnotations;

namespace e_Bazaar.Client.ViewModels
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Slug is required")]
        [StringLength(100, ErrorMessage = "Slug cannot exceed 100 characters")]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        public DateTime? DiscountStart { get; set; }

        public DateTime? DiscountEnd { get; set; }
        public int Percentage { get; set; }

    }
}
