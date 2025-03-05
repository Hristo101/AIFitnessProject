using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.DailyDietPlan
{
    public class AllDailyDietPlanViewModel
    {
        public int Id { get; set; }

        public int DietId { get; set; }
        public ICollection<AllDailyDietPlanViewModelForDietitian> DailyDietPlans { get; set; } = new List<AllDailyDietPlanViewModelForDietitian>();
    }
}
