using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class CalendarMeal
    {
        [Key]
        public int EventId { get; set; }
        public int MealId { get; set; }
        [ForeignKey("MealId")]
        public Meal Meal { get; set; }

        public int CalendarId { get; set; }
        [ForeignKey("CalendarId")]
        public Calendar Calendar { get; set; }

        public DateOnly DateOnly { get; set; }
        public TimeOnly StartEventTime { get; set; }
        public TimeOnly EndEventTime { get; set; }
    }
}
