using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Meal;
namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Meal Table")]
    public class Meal
    {
        [Key]
        [Comment("Meal Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Comment("Meal Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxRecipeLength)]
        [Comment("Meal Recipe")]
        public string Recipe { get; set; } = string.Empty;


        [Required]
        [Comment("Daily Diet Plan MealTime")]
        public string MealTime { get; set; } = string.Empty;

        [Required]
        [Comment("Meal ImageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Meal VideoUrl")]
        public string VideoUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Meal Dificulty Level")]
        public string DificultyLevel { get; set; } = string.Empty;

        [Required]
        [Comment("Meal Calories")]
        public int Calories { get; set; }

        [Required]
        [Comment("Meal Creator Identifier")]
        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public Dietitian Dietitian { get; set; } = null!;

        public ICollection<MealsDailyDietPlan> MealsDailyDietPlans { get; set; } = new List<MealsDailyDietPlan>();
        public ICollection<MealFeedback> MealFeedbacks { get; set; } = new List<MealFeedback>();
    }
}
