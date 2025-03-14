namespace AIFitnessProject.Core.DTOs.Calendar
{
    public class AddEventViewModel
    {
        public int CalendarId { get; set; }
        public string UserId { get; set; }
        public int WorkoutId { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
