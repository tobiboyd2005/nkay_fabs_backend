namespace nkay_fabs_backend.Services
{
    public interface IOtpService
    {
        string GenerateOtp();
        Task<bool> SendOtpAsync(string toEmail, string otp);
    }
}