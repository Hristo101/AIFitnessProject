using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Workout
{
    public class AllWorkoutViewModelForTrainer
    {
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public ICollection<AllWorkoutViewModel> Workouts { get; set; } = new List<AllWorkoutViewModel>();
    }
}
