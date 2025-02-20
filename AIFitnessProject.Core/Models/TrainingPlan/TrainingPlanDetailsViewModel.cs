using AIFitnessProject.Core.Models.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class TrainingPlanDetailsViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool isInCalendar { get; set; }
        public List<WorkoutViewModel> Workouts { get; set; } = new List<WorkoutViewModel>();
    }
}
