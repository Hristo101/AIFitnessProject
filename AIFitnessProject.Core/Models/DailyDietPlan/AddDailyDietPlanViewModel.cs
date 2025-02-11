using AIFitnessProject.Core.Models.Meal;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.DailyDietPlan;
namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class AddDailyDietPlanViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(MaxDayOfWeekLength, MinimumLength = MinDayOfWeekLength, ErrorMessage = "Деня от седмицата трябва да е между {2} и {1} символа.")]
        public string DayOfWeek { get; set; } = string.Empty;

        public IFormFile? ImageUrl { get; set; }

        [Required(ErrorMessage = "Нивото на трудност е задължително.")]
        [StringLength(MaxDifficultyLevelLength, MinimumLength = MinDifficultyLevelLength, ErrorMessage = "Нивото на трудност трябва да е между {2} и {1} символа.")]
        public string DificultyLevel { get; set; } = string.Empty;

        public int DietId { get; set; }

        public string SelectedMealIds { get; set; }

        public List<MealViewModel> Meals { get; set; } = new List<MealViewModel>();


    }
}
