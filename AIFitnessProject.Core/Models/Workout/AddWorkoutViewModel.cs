using AIFitnessProject.Core.Models.Exercise;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Workout
{
    public class AddWorkoutViewModel
    {
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public int OrderInWorkout { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public string MuscleGroup { get; set; }
        public string DifficultyLevel { get; set; }
        public string SelectedWorkoutIds { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; } = new List<ExerciseViewModel>();
    }
}
