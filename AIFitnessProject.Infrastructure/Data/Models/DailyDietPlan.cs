using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("DailyDietPlan Table")]
    public class DailyDietPlan
    {
        [Comment("Daily Diet Plan Identifier")]
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Daily Diet Plan Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Daily Diet Plan Image Url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Daily Diet Plan Day Of Week")]
        public string DayOfWeel { get; set; } = string.Empty;

        [Required]
        [Comment("Daily Diet Plan Creator Identifier")]
        public int CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public Dietitian Dietitian { get; set; } = null!;

        
        [Comment("Daily Diet Plan Diet Identifier")]
        public int? DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; } = null!;

        [Required]
        [Comment("Daily Diet Plan Dificulty Level")]
        public string DificultyLevel { get; set; } = string.Empty;

        public ICollection<MealsDailyDietPlan> MealsDailyDietPlans { get; set; } = new List<MealsDailyDietPlan>();
    }
}