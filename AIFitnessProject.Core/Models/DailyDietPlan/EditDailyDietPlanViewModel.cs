using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.DailyDietPlan;
namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class EditDailyDietPlanViewModel
    {
   
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(MaxDayOfWeekLength, MinimumLength = MinDayOfWeekLength, ErrorMessage = "Деня от седмицата трябва да е между {2} и {1} символа.")]
        public string DayOfWeek { get; set; } = string.Empty;


        public string? ExistingImageUrl { get; set; }

        public IFormFile? NewImage { get; set; }

        [Required(ErrorMessage = "Нивото на трудност е задължително.")]
        [StringLength(MaxDifficultyLevelLength, MinimumLength = MinDifficultyLevelLength, ErrorMessage = "Нивото на трудност трябва да е между {2} и {1} символа.")]
        public string DificultyLevel { get; set; } = string.Empty;


    }
}
