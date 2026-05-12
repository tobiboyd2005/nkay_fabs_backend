namespace nkay_fabs_backend.Models.Dtos
{
    public class FabricDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal PricePerYard { get; set; }
        public decimal StockYards { get; set; }
        public bool IsInStock { get; set; }
        public CategoryDto Category { get; set; } = new CategoryDto();
        public ColorDto Color { get; set; } = new ColorDto();
    }
}