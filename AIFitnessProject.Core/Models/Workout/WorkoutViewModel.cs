using AIFitnessProject.Core.Models.Exercise;

namespace AIFitnessProject.Core.Models.Workout
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public string ImageUrl { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; } = new List<ExerciseViewModel>();
    }
}
