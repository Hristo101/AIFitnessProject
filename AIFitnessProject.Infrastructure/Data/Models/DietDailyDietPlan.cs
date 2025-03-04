using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class DietDailyDietPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DietId { get; set; }

        [ForeignKey("DietId")]
        public Diet Diet { get; set; } = null!;

        [Required]
        public int DailyDietPlanId { get; set; }

        [ForeignKey("DailyDietPlanId")]
        public DailyDietPlan DailyDietPlan { get; set; } = null!;
    }
}
