using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Dietitian;

namespace AIFitnessProject.Infrastructure.Data.Models
{


    [Comment("Dietitian Table")]
    public class Dietitian
    {
        [Key]
        [Comment("Dietitian Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxImageUrlLength)]
        [Comment("Dietitian ImageUrl")]

        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxSpecializationLength)]
        [Comment("Dietitian Specialization")]
        public string Specialization { get; set; } = string.Empty;

        public int Experience { get; set; }
        [Required]
        [MaxLength(MaxSertificationDetailsLength)]
        [Comment("Dietitian SertificationDetails")]
        public string SertificationDetails { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    }
}
