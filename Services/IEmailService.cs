namespace nkay_fabs_backend.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string body);
        Task<bool> SendVerificationEmailAsync(string toEmail, string username, string token);
        Task<bool> SendPasswordResetEmailAsync(string toEmail, string username, string token);
    }
}