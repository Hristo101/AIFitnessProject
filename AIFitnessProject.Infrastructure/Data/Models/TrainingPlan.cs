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
        [Comment("Training Plan Creator Id")]
        public string CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public Trainer User { get; set; } = null!;

        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
        public ICollection<PlanAssignment> PlanAssignments { get; set; } = new List<PlanAssignment>();
    }
}
