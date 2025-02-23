using AIFitnessProject.Core.Models.DailyDietPlan;

namespace AIFitnessProject.Core.Models.Diet
{
    public class DietDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsInCalendar { get; set; }

        public List<DailyDietPlanViewModel> DailyDietPlans { get; set; } = new List<DailyDietPlanViewModel>();
    }
}
