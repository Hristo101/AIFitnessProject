using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Meal;
namespace AIFitnessProject.Core.Models.Meal
{
    public class CreateMealViewModelFromEditDailyDietPlan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Името трябва да е между {2} и {1} символа.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(MaxRecipeLength, MinimumLength = MinRecipeLength, ErrorMessage = "Рецептата трябва да е между {2} и {1} символа.")]
        public string Recipe { get; set; } = string.Empty;


        [Required(ErrorMessage = "Снимката е задължителна.")]
        public IFormFile ImageUrl { get; set; }

        [Required(ErrorMessage = "Видео линкът е задължителен.")]
        [Url(ErrorMessage = "Моля, въведете валиден URL адрес.")]
        public string VideoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Времето за хранене е задължително.")]
        [StringLength(MaxMealTimeLength, MinimumLength = MinMealTimeLength, ErrorMessage = "Времето за хранене трябва да е между {2} и {1} символа.")]
        public string MealTime { get; set; } = string.Empty;

        [Required]
        [Range(MinCaloriesLength, MaxCaloriesLength, ErrorMessage = "Калориите трябва да бъдат между {1} и {2}.")]
        public int Calories { get; set; }


        [Required(ErrorMessage = "Нивото на трудност е задължително.")]
        [StringLength(MaxDificultyLevelLength, MinimumLength = MinDificultyLevelLength, ErrorMessage = "Нивото на трудност трябва да е между {2} и {1} символа.")]
        public string DificultyLevel { get; set; } = string.Empty;

        public int DailyDietPlanId { get; set; }

        public string UserId { get; set; }
    }
}
