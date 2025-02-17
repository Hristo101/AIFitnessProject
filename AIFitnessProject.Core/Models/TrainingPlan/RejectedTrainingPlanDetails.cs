using AIFitnessProject.Core.Models.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class RejectedTrainingPlanDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<WorkoutViewModelForRejectedTrainingPlan> Workouts { get; set; } = new List<WorkoutViewModelForRejectedTrainingPlan>();
    }

}
