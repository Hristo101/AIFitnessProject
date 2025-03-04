namespace AIFitnessProject.Core.Models.Calendar
{
    public class UserCalendarViewModel
    {
        public string UserId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public List<WorkoutCalendarViewModel> Workouts { get; set; }
        public List<MealCalendarViewModel> Meals { get; set; }
        public List<WorkoutCalendarViewModel> TrainingPlanWorkouts { get; set; }
        public string Email { get; set; }
        public int CalendarId { get; set; }
    }
}
