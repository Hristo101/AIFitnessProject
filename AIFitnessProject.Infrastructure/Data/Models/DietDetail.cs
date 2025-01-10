using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class DietDetail
    {
        public int Id { get; set; }

        public int DietId { get; set; }
        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; }

        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; }
        
        public string MealTime { get; set; }

        public string DayOfWeel { get; set; }
    }
}