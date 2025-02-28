using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Calendar
{
    public class UserCalendarViewModelForDietitianArea
    {
        public int Id { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string FullName { get; set; }

        public List<MealCalendarViewModel> Meals { get; set; }

        public List<MealCalendarViewModel> DietMeal { get; set; }

        public string Email { get; set; }

        public int CalendarId { get; set; }
    }
}
