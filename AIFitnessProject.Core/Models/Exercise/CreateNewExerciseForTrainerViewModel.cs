using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Exercise;

namespace AIFitnessProject.Core.Models.Exercise
{
    public class CreateNewExerciseForTrainerViewModel
    {
        public int Id { get; set; }
        [Required]
        [Comment("Exercise Name")]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Comment("Exercise Description")]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public IFormFile ImageUrl { get; set; }
        [Required]
        [Comment("Exercise VideoUrl")]
        [MaxLength(MaxVideoUrlLength)]
        public string VideoUrl { get; set; }
        [Required]
        [Comment("Exercise MuscleGroup")]
        [MaxLength(MaxMuscleGroupLength)]
        public string MuscleGroup { get; set; }
        [Required]
        [Comment("Exercise DifficultyLevel")]
        [MaxLength(100)]
        public string DifficultyLevel { get; set; }
        public int TrainingPlanId { get; set; }
        public int Repetitions { get; set; }
        public int Series { get; set; }

        public string UserId { get; set; }
        public int WorkoutId { get; set; }
    }
}
