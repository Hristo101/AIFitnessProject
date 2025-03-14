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
        public string SenderId { get; set; } = string.Empty;

        [ForeignKey(nameof(SenderId))]
        public ApplicationUser Sender { get; set; } = null!;

        [Required]
        [Comment("Notification Trainer Id")]
        public string RecieverId { get; set; }

        [ForeignKey(nameof(RecieverId))]
        public ApplicationUser Reciever { get; set; } = null!;

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
