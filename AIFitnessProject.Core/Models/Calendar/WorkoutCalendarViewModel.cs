﻿namespace AIFitnessProject.Core.Models.Calendar
{
    public class WorkoutCalendarViewModel
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int EventId { get; set; }
        public bool IsMine { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ExerciseCount { get; set; }
        public string MuscleGroup { get; set; }
        public DateOnly Date { get; set; } 
        public TimeOnly StartEventTime { get; set; } 
        public TimeOnly EndEventTime { get; set; }
        public int CalendarId { get; set; } 
    }
}
