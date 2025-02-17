using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.ExerciseFeedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Workout
{
    public class WorkoutViewModelForRejectedTrainingPlan
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
        public List<ExerciseFeedbackViewModel> Exercises { get; set; } = new List<ExerciseFeedbackViewModel>();
    }
}
