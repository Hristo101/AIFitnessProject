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
        [Comment("Workout Image")]
        public string ImageUrl { get; set; }
        [Comment("Workout Title")]
        public string Title { get; set; }

        [Required]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Trainer Trainer { get; set; }

        [Required]
        [Comment("Workout Training Plan Id")]
        public int TrainingPlanId { get; set; }

        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlans { get; set; } = null!;

        [Required]
        [MaxLength(MaxDayOfWeekLength)]
        [Comment("Workout Day Of Week")]
        public string DayOfWeek { get; set; } = string.Empty;

        [Required]
        [Comment("Workout Order In Workout")]
        public int OrderInWorkout {  get; set; }

        public ICollection<WorkoutsExercise> WorkoutsExercises { get; set; } = new List<WorkoutsExercise>();
    }
}
