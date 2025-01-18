using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Opinion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1200)]
        [Comment("User Opinion Content")]
        public string Content { get; set; }
        public int Rating { get; set; }

        [Required]
        [Comment("User Opinion Sender Id")]
        public string SenderId { get; set; } = string.Empty;

        [ForeignKey(nameof(SenderId))]
        public ApplicationUser Sender { get; set; } = null!;
    }
}
