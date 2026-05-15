using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public interface IEmailVerificationRepository
    {
        Task Verification(EmailVerification verification);
        Task<EmailVerification?> GetByTokenAsync(string token);
        Task<bool> SaveChangesAsync();
    }
}