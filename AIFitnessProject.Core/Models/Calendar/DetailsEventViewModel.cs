using AIFitnessProject.Core.Models.Exercise;

namespace AIFitnessProject.Core.Models.Calendar
{
    public class DetailsEventViewModel
    {
        public string EventTitle { get; set; }
        public string DateOnly { get; set; }
        public string StartEventTime { get; set; }
        public string EndEventTime { get; set; }
        public string WorkoutTitle { get; set; }
        public string WorkoutImage { get; set; }
        public string WorkoutMuscleGroup { get; set; }
        public string WorkoutDifficultyLevel { get; set; }
        public string WorkoutDayOfWeek { get; set; }
        public int ExerciseCount { get; set; }
        public ICollection<ExerciseViewModel> Exercises { get; set; }
        
    }
}
