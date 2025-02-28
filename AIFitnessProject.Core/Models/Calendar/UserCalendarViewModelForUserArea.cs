using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Calendar
{
    public class UserCalendarViewModelForUserArea
    {
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public List<WorkoutCalendarViewModel> Workouts { get; set; }
        public List<MealCalendarViewModel> Meals { get; set; }
        public string Email { get; set; }
        public int CalendarId { get; set; }
    }
}
