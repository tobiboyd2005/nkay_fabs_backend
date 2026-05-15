using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int userId);
        Task<int> GetUnreadCountAsync(int userId);
        Task<Notification> CreateNotificationAsync(Notification notification);
        Task MarkAsReadAsync(IEnumerable<int> notificationIds, int userId);
        Task<bool> SaveChangesAsync();
    }
}