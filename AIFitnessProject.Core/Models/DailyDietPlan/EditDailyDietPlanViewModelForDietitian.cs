using AIFitnessProject.Core.Models.Meal;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.DailyDietPlan;

namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class EditDailyDietPlanViewModelForDietitian
    {
        public int Id { get; set; }

        public int? DietId { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа.")]
        public string Title { get; set; }

        public string DayOfWeek { get; set; }

        public string DifficultyLevel { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? NewImageUrl { get; set; }

        public int MealCount { get; set; }

        public bool IsEdit { get; set; } = false;

        public ICollection<MealViewModel> Meals { get; set; } = new List<MealViewModel>();

        public ICollection<MealViewModel> AllMeals { get; set; } = new List<MealViewModel>();
    }
}
