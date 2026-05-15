using nkay_fabs_backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nkay_fabs_backend.Entities
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Delivered,
        Cancelled
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string OrderNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [MaxLength(300)]
        public string? ShippingAddress { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = TimeHelper.NowWAT();
        public DateTime UpdatedAt { get; set; } = TimeHelper.NowWAT();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}