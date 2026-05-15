using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;

namespace nkay_fabs_backend.Services
{
    public class EmailVerificationRepository : IEmailVerificationRepository
    {
        private readonly FabricsDbContext _context;

        public EmailVerificationRepository(FabricsDbContext context)
        {
            _context = context;
        }

        public async Task<EmailVerification> CreateAsync(EmailVerification verification)
        {
            _context.EmailVerifications.Add(verification);
            await _context.SaveChangesAsync();
            return verification;
        }

        public async Task<EmailVerification?> GetByTokenAsync(string token)
        {
            return await _context.EmailVerifications
                .Where(e => e.Token == token && !e.IsUsed && e.ExpiresAt > DateTime.UtcNow)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}