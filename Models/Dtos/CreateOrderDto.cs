using System.ComponentModel.DataAnnotations;

namespace nkay_fabs_backend.Models.Dtos
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Order items are required.")]
        [MinLength(1, ErrorMessage = "At least one order item is required.")]
        public List<CreateOrderItemDto> Items { get; set; } = new();

        [StringLength(300, ErrorMessage = "Shipping address cannot exceed 300 characters.")]
        public string? ShippingAddress { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }
    }

    public class CreateOrderItemDto
    {
        [Required(ErrorMessage = "Fabric ID is required.")]
        public int FabricId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0.01, 10000, ErrorMessage = "Quantity must be between 0.01 and 10,000.")]
        public decimal Quantity { get; set; }
    }
}