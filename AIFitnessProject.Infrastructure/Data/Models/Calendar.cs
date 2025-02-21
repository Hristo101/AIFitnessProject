using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Calendar
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        [Required]
        public int? TrainerId { get; set; }
        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }

        public int? DietitianId { get; set; }
        [ForeignKey(nameof(DietitianId))]
        public Dietitian Dietitian { get; set; }

        public ICollection<CalendarWorkout> CalendarWorkouts { get; set; }
    }
}
