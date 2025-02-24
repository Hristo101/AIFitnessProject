using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class CalendarDiet
    {
        [Key]
        public int EventId { get; set; }
        public int DietId { get; set; }
        [ForeignKey("WorkoutId")]
        public Diet Diet { get; set; }

        public int CalendarId { get; set; }
        [ForeignKey("CalendarId")]
        public Calendar Calendar { get; set; }

        public DateOnly DateOnly { get; set; }
        public TimeOnly StartEventTime { get; set; }
        public TimeOnly EndEventTime { get; set; }
    }
}
