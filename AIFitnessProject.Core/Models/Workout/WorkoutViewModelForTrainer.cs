using AIFitnessProject.Core.Models.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Workout
{
    public class WorkoutViewModelForTrainer
    {
        public int Id { get; set; }
        public int? TrainingPlanId { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public string MuscleGroup {  get; set; }
        public string DifficultyLevel { get; set; }
        public string ImageUrl { get; set; }
        public int ExerciseCount { get; set; }
        public bool IsEdit { get; set; } = false;
    }
}
