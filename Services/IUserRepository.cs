using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
        Task<bool> SaveChangesAsync();
        Task<User?> GetAdminAsync();
    }
}