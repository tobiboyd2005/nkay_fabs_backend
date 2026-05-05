using System.ComponentModel.DataAnnotations;

namespace nkay_fabs_backend.Models.Dtos
{
    public class CreateColorDto
    {
        [Required(ErrorMessage = "Color name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Hex code is required.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Hex code must be exactly 7 characters (e.g., #000000).")]
        public string HexCode { get; set; } = string.Empty;
    }
}
