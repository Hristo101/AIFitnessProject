using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Meals Dily Diet Plan Table")]
    public class MealsDailyDietPlan
    {
        [Key]
        [Comment("Meals Dily Diet Plan Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Dily Diet Plan Identifier")]
        public int DailyDietPlansId { get; set; }

        [ForeignKey(nameof(DailyDietPlansId))]
        public DailyDietPlan DailyDietPlans { get; set; } = null!;

        [Required]
        [Comment("Meal Identifier")]
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; } = null!;
    }
}
