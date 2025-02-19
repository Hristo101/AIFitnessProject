using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.DTOs
{
    public class SwapExerciseRequest
    {
        public int TrainingPlanId { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int NewExerciseId { get; set; }
    }
}
