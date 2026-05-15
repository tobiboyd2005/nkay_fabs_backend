using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public interface IOtpVerificationRepository
    {
        Task<OtpVerification> CreateAsync(OtpVerification otp);
        Task<OtpVerification?> GetValidOtpAsync(int userId, string otpCode);
        Task<bool> SaveChangesAsync();
    }
}