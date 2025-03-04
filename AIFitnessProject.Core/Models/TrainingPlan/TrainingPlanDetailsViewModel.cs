using AIFitnessProject.Core.Models.Workout;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class TrainingPlanDetailsViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public bool isInCalendar { get; set; }
        public List<WorkoutViewModel> Workouts { get; set; } = new List<WorkoutViewModel>();
    }
}
