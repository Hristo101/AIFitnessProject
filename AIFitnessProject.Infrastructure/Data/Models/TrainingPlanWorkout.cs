using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class TrainingPlanWorkout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TrainingPlanId { get; set; }
        [ForeignKey("TrainingPlanId")]
        public TrainingPlan TrainingPlan { get; set; }

        [Required]
        public int WorkoutId { get; set; }
        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
    }
}
