using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Meal;

namespace AIFitnessProject.Core.Models.Diet
{
    public class RejectedDietDetails
    {
        public int Id { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserEmail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; }

        public List<DailyDietPlanViewModelForRejectedDiet> DailyDietPlans { get; set; } = new List<DailyDietPlanViewModelForRejectedDiet>();

        public List<MealViewModel> AvailableMeals { get; set; } = new List<MealViewModel>();
    }
}
