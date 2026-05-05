using System.ComponentModel.DataAnnotations;

namespace nkay_fabs_backend.Models.Dtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Fabric name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Description must be at most 250 characters.")]
        public string Description { get; set; } = string.Empty;
    }
}
