using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.UserComment;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("User Comment Table")]
    public class UserComment
    {
        [Key]
        [Comment("User Comment Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User Comment Rating")]
        public int Rating { get; set; }

        [Required]
        [MaxLength(MaxContentLength)]
        [Comment("User Comment Content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("User Comment Receiver Id")]
        public string ReceiverId { get; set; } = string.Empty;

        [ForeignKey(nameof(ReceiverId))]
        public ApplicationUser Receiver { get; set; } = null!;

        [Required]
        [Comment("User Comment Sender Id")]
        public string SenderId { get; set; } = string.Empty;

        [ForeignKey(nameof(SenderId))]
        public ApplicationUser Sender { get; set; } = null!;

    }
}
