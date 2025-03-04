using AIFitnessProject.Core.Models.ExerciseFeedback;

namespace AIFitnessProject.Core.Models.Workout
{
    public class WorkoutViewModelForRejectedTrainingPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
        public List<ExerciseFeedbackViewModel> Exercises { get; set; } = new List<ExerciseFeedbackViewModel>();
    }
}
