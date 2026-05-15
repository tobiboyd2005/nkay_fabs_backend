using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Models.Dtos;

namespace nkay_fabs_backend.Services
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<Order?> GetOrderByIdWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<(IEnumerable<Order>, PaginationMetadata)> GetOrdersAsync(string? status, int pageNumber, int pageSize);
        Task<Order> CreateOrderAsync(Order order);
        Task<bool> SaveChangesAsync();
    }
}