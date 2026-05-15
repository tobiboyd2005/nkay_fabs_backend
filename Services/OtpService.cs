using Microsoft.Extensions.Logging;

namespace nkay_fabs_backend.Services
{
    public class OtpService : IOtpService
    {
        private readonly ILogger<OtpService> _logger;
        private readonly IEmailService _emailService;

        public OtpService(ILogger<OtpService> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public async Task<bool> SendOtpAsync(string toEmail, string otp)
        {
            var subject = "Your OTP Code - Nkay Fabs";
            var body = $@"
                <html>
                <body>
                    <h2>Your One-Time Password (OTP)</h2>
                    <p>Your OTP code is: <strong style=""font-size: 24px; color: #4CAF50;"">{otp}</strong></p>
                    <p>This code will expire in 10 minutes.</p>
                    <p>If you did not request this, please ignore this email.</p>
                </body>
                </html>";

            return await _emailService.SendEmailAsync(toEmail, subject, body);
        }
    }
}