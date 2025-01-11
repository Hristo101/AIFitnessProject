using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Workout;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Workout Table")]
    public class Workout
    {
        [Key]
        [Comment("Workout Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Workout Training Plan Id")]
        public int TrainingPlanId { get; set; }

        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlans { get; set; } = null!;

        [Required]
        [Comment("Workout Exercise Id")]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; } = null!;

        [Required]
        [MaxLength(MaxDayOfWeekLength)]
        [Comment("Workout Day Of Week")]
        public string DayOfWeek { get; set; } = string.Empty;

        [Required]
        [Comment("Workout Order In Workout")]
        public int OrderInWorkout {  get; set; }
    }
}
