﻿using Microsoft.EntityFrameworkCore;
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
        [MaxLength(MaxSpecializationLength)]
        [Comment("Dietitian Specialization")]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [Comment("Dietitian Experience")]
        public int Experience { get; set; }

        [Required]
        [Comment("Dietitian Sertification Image")]
        public string SertificateImage { get; set; } = null!;

        [Required]
        [MaxLength(MaxSertificationDetailsLength)]
        [Comment("Dietitian SertificationDetails")]
        public string SertificationDetails { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxBioLength)]
        [Comment("Dietitian Bio")]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxPhoneNumberLength)]
        [Comment("Dietitian Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Dietitian User Id")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public ICollection<RequestToDietitian> RequestToDietitians { get; set; } = new List<RequestToDietitian>();
        public ICollection<DailyDietPlan> DailyDietPlans { get; set; } = new List<DailyDietPlan>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();

    }
}
