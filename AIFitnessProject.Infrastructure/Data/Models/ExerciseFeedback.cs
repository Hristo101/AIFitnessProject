using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class ExerciseFeedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }

        [Required]
        public int TrainingPlanId { get; set; }
        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlan { get; set; }

        [Required]
        [MaxLength(500)]
        public string Feedback { get; set; }

        public bool IsAnswered { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
