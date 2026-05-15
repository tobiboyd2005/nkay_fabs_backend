using System.ComponentModel.DataAnnotations;

namespace nkay_fabs_backend.Models.Dtos
{
    public class VerifyEmailRequestDto
    {
        [Required(ErrorMessage = "Verification token is required.")]
        public string Token { get; set; } = string.Empty;
    }
}