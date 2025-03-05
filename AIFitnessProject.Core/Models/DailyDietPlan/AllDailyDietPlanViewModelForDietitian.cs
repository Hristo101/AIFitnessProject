using AIFitnessProject.Core.Models.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class AllDailyDietPlanViewModelForDietitian
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
