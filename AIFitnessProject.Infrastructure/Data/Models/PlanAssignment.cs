using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Plan Assignment Table")]
    public class PlanAssignment
    {
        [Key]
        [Comment("Plan Assignment Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Plan Assignment User Id")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Plan Assignment Diet Id")]
        public int DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; } = null!;

        [Required]
        [Comment("Plan Assignment Training Plan Id")]
        public int TrainingPlanId { get; set; }

        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlan { get; set; } = null!;

        [Required]
        [Comment("Start Date And Time Of Plan Assignment")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("End Date And Time Of Plan Assignment")]
        public DateTime EndDate { get; set; }
    }
}