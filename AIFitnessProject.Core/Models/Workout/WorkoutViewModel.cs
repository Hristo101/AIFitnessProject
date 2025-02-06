using AIFitnessProject.Core.Models.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Workout
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public string ImageUrl { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; } = new List<ExerciseViewModel>();
    }
}
