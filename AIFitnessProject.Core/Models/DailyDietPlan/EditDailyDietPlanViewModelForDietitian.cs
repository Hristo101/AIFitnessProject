using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class EditDailyDietPlanViewModelForDietitian
    {
        public int Id { get; set; }
        public int? DietId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public string DifficultyLevel { get; set; }
        public string ImageUrl { get; set; }
        public int MealCount { get; set; }
        public bool IsEdit { get; set; } = false;
        public ICollection<MealViewModel> Meals { get; set; } = new List<MealViewModel>();
        public ICollection<MealViewModel> AllMeals { get; set; } = new List<MealViewModel>();
    }
}
