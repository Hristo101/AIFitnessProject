using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class MealFeedback
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; } = null!;

        [Required]
        public int DietId { get; set; }
        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Feedback { get; set; } = string.Empty;

        public bool IsAnswered { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
