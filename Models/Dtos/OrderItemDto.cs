namespace nkay_fabs_backend.Models.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int FabricId { get; set; }
        public string FabricName { get; set; } = string.Empty;
        public string? FabricImageUrl { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}