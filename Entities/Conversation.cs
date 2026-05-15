using nkay_fabs_backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nkay_fabs_backend.Entities
{
    public class Conversation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        public int AdminId { get; set; }

        [ForeignKey("AdminId")]
        public User Admin { get; set; } = null!;

        public DateTime LastMessageAt { get; set; } = TimeHelper.NowWAT();
        public DateTime CreatedAt { get; set; } = TimeHelper.NowWAT();

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}