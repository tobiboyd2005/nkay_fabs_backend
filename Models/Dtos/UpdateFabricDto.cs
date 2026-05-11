using System.ComponentModel.DataAnnotations;

namespace nkay_fabs_backend.Models.Dtos
{
    public class UpdateFabricDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal PricePerYard { get; set; }

        [Range(0, int.MaxValue)]
        public int StockYards { get; set; }
    }
}
