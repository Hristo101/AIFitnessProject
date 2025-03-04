using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Calendar
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public int? TrainerId { get; set; }
        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }

        public int? DietitianId { get; set; }
        [ForeignKey(nameof(DietitianId))]
        public Dietitian Dietitian { get; set; }

        public ICollection<CalendarWorkout> CalendarWorkouts { get; set; } = new List<CalendarWorkout>();
        public ICollection<CalendarMeal> CalendarMeals { get; set; } = new List<CalendarMeal>();
    }
}
