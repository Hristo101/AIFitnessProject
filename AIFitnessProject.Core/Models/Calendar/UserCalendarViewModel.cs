using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Calendar
{
    public class UserCalendarViewModel
    {
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public List<WorkoutCalendarViewModel> Workouts { get; set; }
        public List<WorkoutCalendarViewModel> TrainingPlanWorkouts { get; set; }
        public string Email { get; set; }
        public int CalendarId { get; set; }
    }
}
