using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Logging;

namespace nkay_fabs_backend.Services
{
    /// <summary>
    /// Handles all email communication for the Nkay Fabs application using MailKit.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Base method for sending emails via SMTP using MailKit.
        /// </summary>
        /// <param name="toEmail">Recipient email address</param>
        /// <param name="subject">Email subject line</param>
        /// <param name="body">HTML email body</param>
        /// <returns>True if email was sent successfully, false otherwise</returns>
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                // Get SMTP settings from configuration
                var smtpHost = _configuration["Email:SmtpHost"];
                var smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
                var smtpUser = _configuration["Email:SmtpUser"];
                var smtpPassword = _configuration["Email:SmtpPassword"];
                var fromName = _configuration["Email:FromName"] ?? "Nkay Fabs";
                var fromEmail = _configuration["Email:FromEmail"] ?? smtpUser;

                // Build the email message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromName, fromEmail));
                message.To.Add(new MailboxAddress(toEmail, toEmail));
                message.Subject = subject;

                // Set HTML body
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using var client = new SmtpClient();

                _logger.LogInformation("Connecting to SMTP server {Host}:{Port}", smtpHost, smtpPort);
                await client.ConnectAsync(smtpHost, smtpPort, false);

                // Authenticate with SMTP credentials
                await client.AuthenticateAsync(smtpUser, smtpPassword);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation("Email sent successfully to {Email}", toEmail);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", toEmail);
                return false;
            }
        }

        /// <summary>
        /// Sends an email verification link to a newly registered user.
        /// The token is valid for 24 hours.
        /// </summary>
        public async Task<bool> SendVerificationEmailAsync(string toEmail, string username, string token)
        {
            var baseUrl = _configuration["App:BaseUrl"] ?? "https://localhost:7269";
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

        /// <summary>
        /// Sends a password reset link to the user's email.
        /// The reset token is valid for 1 hour.
        /// </summary>
        public async Task<bool> SendPasswordResetEmailAsync(string toEmail, string username, string token)
        {
            var baseUrl = _configuration["App:BaseUrl"] ?? "https://localhost:7269";
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