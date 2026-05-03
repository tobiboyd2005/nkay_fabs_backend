namespace nkay_fabs_backend.Models.Entities
{
    public class Fabric
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        // Pricing and Stock
        public decimal PricePerYard { get; set; }
        public decimal StockYards { get; set; }
        public bool IsInStock => StockYards > 0;



        // Visibility
        public bool IsActive { get; set; } = true;

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        //Relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
    }
}
