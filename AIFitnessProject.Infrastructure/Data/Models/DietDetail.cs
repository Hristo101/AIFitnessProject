using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("DietDetail Table")]
    public class DietDetail
    {
        [Comment("DietDetail Table")]
        [Key]
        public int Id { get; set; }

        public int DietId { get; set; }
        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; } = null!;

        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; } = null!;
        [Required]
        [Comment("DietDetail MealTime")]
        public string MealTime { get; set; } = string.Empty;
        [Required]
        [Comment("DietDetail MealTime")]
        public string DayOfWeel { get; set; } = string.Empty;
    }
}