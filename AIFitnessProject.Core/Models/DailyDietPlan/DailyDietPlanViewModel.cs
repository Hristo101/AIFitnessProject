using AIFitnessProject.Core.Models.Meal;

namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class DailyDietPlanViewModel
    {
        public int Id { get; set; }

        public int DietId { get; set; }

        public string Title { get; set; }

        public string DayOfWeek { get; set; }

        public string ImageUrl { get; set; }

        public string DificultyLevel { get; set; }

        public List<MealViewModel> Meals { get; set; } = new List<MealViewModel>();
    }
}
