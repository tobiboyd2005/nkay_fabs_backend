using Microsoft.Extensions.Logging;

namespace nkay_fabs_backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                _logger.LogInformation("Sending email to {Email} with subject: {Subject}", toEmail, subject);
                _logger.LogInformation("Email Body: {Body}", body);
                
                await Task.CompletedTask;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", toEmail);
                return false;
            }
        }

        public async Task<bool> SendVerificationEmailAsync(string toEmail, string username, string token)
        {
            var baseUrl = _configuration["App:BaseUrl"] ?? "http://localhost:7269";
            var verificationUrl = $"{baseUrl}/api/auth/verify-email?token={token}";
            
            var subject = "Verify Your Email - Nkay Fabs";
            var body = $@"
                <html>
                <body>
                    <h2>Welcome to Nkay Fabs, {username}!</h2>
                    <p>Thank you for registering. Please verify your email address by clicking the link below:</p>
                    <p><a href=""{verificationUrl}"" style=""background-color: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;"">Verify Email</a></p>
                    <p>Or copy and paste this link: {verificationUrl}</p>
                    <p>This link will expire in 24 hours.</p>
                    <p>If you did not register, please ignore this email.</p>
                </body>
                </html>";

            return await SendEmailAsync(toEmail, subject, body);
        }

        public async Task<bool> SendPasswordResetEmailAsync(string toEmail, string username, string token)
        {
            var baseUrl = _configuration["App:BaseUrl"] ?? "http://localhost:7269";
            var resetUrl = $"{baseUrl}/api/auth/reset-password?token={token}";
            
            var subject = "Reset Your Password - Nkay Fabs";
            var body = $@"
                <html>
                <body>
                    <h2>Password Reset Request, {username}</h2>
                    <p>We received a request to reset your password. Click the link below to reset it:</p>
                    <p><a href=""{resetUrl}"" style=""background-color: #008CBA; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;"">Reset Password</a></p>
                    <p>Or copy and paste this link: {resetUrl}</p>
                    <p>This link will expire in 1 hour.</p>
                    <p>If you did not request a password reset, please ignore this email or contact support.</p>
                </body>
                </html>";

            return await SendEmailAsync(toEmail, subject, body);
        }
    }
}