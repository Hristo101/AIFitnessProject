using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Meal;

namespace AIFitnessProject.Core.Models.Meal
{
    public class EditMealFromDailyDietPlanViewModel
    {
        public int Id { get; set; }

        public int DailyDietPlanId { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Името трябва да е между {2} и {1} символа.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(MaxRecipeLength, MinimumLength = MinRecipeLength, ErrorMessage = "Рецептата трябва да е между {2} и {1} символа.")]
        public string Recipe { get; set; } = string.Empty;

        public string? ExistingImageUrl { get; set; }

        public IFormFile? NewImage { get; set; }

        [Required(ErrorMessage = "Видео линкът е задължителен.")]
        [Url(ErrorMessage = "Моля, въведете валиден URL адрес.")]
        public string VideoUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Времето за хранене е задължително.")]
        [StringLength(MaxMealTimeLength, MinimumLength = MinMealTimeLength, ErrorMessage = "Времето за хранене трябва да е между {2} и {1} символа.")]
        public string MealTime { get; set; } = string.Empty;

        [Range(MinCaloriesLength, MaxCaloriesLength, ErrorMessage = "Калориите трябва да бъдат между {1} и {2}.")]
        public int Calories { get; set; }


        [Required(ErrorMessage = "Изберете ниво на трудност.")]
        [StringLength(MaxDificultyLevelLength, MinimumLength = MinDificultyLevelLength, ErrorMessage = "Нивото на трудност трябва да е между {2} и {1} символа.")]
        public string DificultyLevel { get; set; } = string.Empty;
    }
}
