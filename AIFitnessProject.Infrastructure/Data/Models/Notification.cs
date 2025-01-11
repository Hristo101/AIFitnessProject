using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Notification;
namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Notification Table")]
    public class Notification
    {
        [Key]
        [Comment("Notification Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Notification User Id")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Notification Trainer Id")]
        public int TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; } = null!;

        [Required]
        [MaxLength(MaxMessageLength)]
        [Comment("Notification Message")]
        public string Message { get; set; } = string.Empty;

        [Required]
        [Comment("Date And Time Of Notification")]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public bool ReadStatus { get; set; }


    }
}
