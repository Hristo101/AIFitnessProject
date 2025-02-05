using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.TrainingPlan;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Training Plan Table")]
    public class TrainingPlan
    {
        [Key]
        [Comment("Training Plan Identifier")]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        [Comment("Training Plan Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        [Comment("Training Plan Description")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Comment("Training Plan  User Id")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Training Plan Creator Id")]
        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public Trainer Trainer { get; set; } = null!;

        public bool IsActive { get; set; } = false;

        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
        public ICollection<PlanAssignment> PlanAssignments { get; set; } = new List<PlanAssignment>();
    }
}
