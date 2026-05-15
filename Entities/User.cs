using nkay_fabs_backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nkay_fabs_backend.Entities
{
    public enum UserRole
    {
        User,
        Admin
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        public UserRole Role { get; set; } = UserRole.User;

        public bool IsEmailVerified { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = TimeHelper.NowWAT();
        public DateTime UpdatedAt { get; set; } = TimeHelper.NowWAT();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();
        public ICollection<EmailVerification> EmailVerifications { get; set; } = new List<EmailVerification>();
        public ICollection<OtpVerification> OtpVerifications { get; set; } = new List<OtpVerification>();
    }
}