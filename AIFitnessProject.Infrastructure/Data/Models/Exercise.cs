using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Exercise;
namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Exercise
    {
        [Key]
        [Comment("Comment Identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Exercise Name")]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Comment("Exercise Description")]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        [Comment("Exercise ImageUrl")]
        [MaxLength(MaxImageUrlLength)]
        public string ImageUrl { get; set; }
        [Required]
        [Comment("Exercise VideoUrl")]
        [MaxLength(MaxVideoUrlLength)]
        public string VideoUrl { get; set; }
        [Required]
        [Comment("Exercise MuscleGroup")]
        [MaxLength(MaxMuscleGroupLength)]
        public string MuscleGroup{ get; set; }
        [Required]
        [Comment("Exercise DifficultyLevel")]
        [MaxLength(100)]
        public string DifficultyLevel { get; set; }

        public ICollection<Workout> Workouts { get; set; }

    }
}
