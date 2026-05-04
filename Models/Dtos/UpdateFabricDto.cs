namespace nkay_fabs_backend.Models.Dtos
{
    public class UpdateFabricDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal PricePerYard { get; set; }
        public decimal StockYards { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
    }
}
