using nkay_fabs_backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nkay_fabs_backend.Entities
{
    public class Fabric
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string ImageUrl { get; set; } = string.Empty;

        // Pricing and Stock
        public decimal PricePerYard { get; set; }
        public decimal StockYards { get; set; }
        public bool IsInStock => StockYards > 0;



        // Visibility
        public bool IsActive { get; set; } = true;

        // Audit
        public DateTime CreatedAt { get; set; } = TimeHelper.NowWAT();
        public DateTime UpdatedAt { get; set; } = TimeHelper.NowWAT();


        //Relationships
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; } = null!;
    }
}
