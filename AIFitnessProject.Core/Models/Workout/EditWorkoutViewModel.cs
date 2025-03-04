using Microsoft.AspNetCore.Http;

namespace AIFitnessProject.Core.Models.Workout
{
    public class EditWorkoutViewModel
    {
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? NewImageUrl { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public int OrderInWorkout { get; set; }
        public string DifficultyLevel { get; set; }
        public string MuscleGroup { get; set; }
    }
}
