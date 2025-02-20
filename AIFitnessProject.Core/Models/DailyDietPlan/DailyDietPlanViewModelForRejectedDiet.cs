using AIFitnessProject.Core.Models.MealFeedback;

namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class DailyDietPlanViewModelForRejectedDiet
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
        public List<MealFeedbackViewModel> Meals { get; set; } = new List<MealFeedbackViewModel>();
    }
}
