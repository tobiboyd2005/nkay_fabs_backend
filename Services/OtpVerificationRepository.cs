using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public class OtpVerificationRepository : IOtpVerificationRepository
    {
        private readonly FabricsDbContext _context;

        public OtpVerificationRepository(FabricsDbContext context)
        {
            _context = context;
        }

        public async Task<OtpVerification> CreateAsync(OtpVerification otp)
        {
            _context.OtpVerifications.Add(otp);
            await _context.SaveChangesAsync();
            return otp;
        }

        public async Task<OtpVerification?> GetValidOtpAsync(int userId, string otpCode)
        {
            return await _context.OtpVerifications
                .Where(o => o.UserId == userId && o.OtpCode == otpCode && !o.IsUsed && o.ExpiresAt > DateTime.UtcNow)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}