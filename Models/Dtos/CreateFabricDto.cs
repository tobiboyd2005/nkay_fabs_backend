using System.ComponentModel.DataAnnotations;

namespace nkay_fabs_backend.Models.Dtos
{
    public class CreateFabricDto
    {
        [Required(ErrorMessage = "Fabric name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Url(ErrorMessage = "Image URL must be a valid URL.")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price per yard is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        public decimal PricePerYard { get; set; }

        [Required(ErrorMessage = "Stock yards is required.")]
        [Range(0, 100000, ErrorMessage = "Stock yards must be between 0 and 100,000.")]
        public decimal StockYards { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "A valid category must be selected.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "A valid color must be selected.")]
        public int ColorId { get; set; }
    }
}