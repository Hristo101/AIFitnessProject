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

        [Required]
        [Comment("DietDetail MealTime")]
        public string MealTime { get; set; } = string.Empty;
        [Required]
        [Comment("DietDetail MealTime")]
        public string DayOfWeel { get; set; } = string.Empty;

        [Required]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Dietitian Dietitian { get; set; }

        public ICollection<MealsDietDietail> MealsDietDietails { get; set; } = new List<MealsDietDietail>();
    }
}