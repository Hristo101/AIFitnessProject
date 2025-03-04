using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Workout;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class RejectedTrainingPlanDetails
    {
        public int Id { get; set; }
        public string UserProfilePicture { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public List<WorkoutViewModelForRejectedTrainingPlan> Workouts { get; set; } = new List<WorkoutViewModelForRejectedTrainingPlan>();
        public List<ExerciseViewModel> AvailableExercises { get; set; } = new List<ExerciseViewModel>();
    }

}
