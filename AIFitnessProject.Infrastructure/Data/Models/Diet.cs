using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Diet;
namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Diet Table")]
    public class Diet
    {
        [Key]
        [Comment("Diet Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        [Comment("Diet Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(MaxDescriptionLength)]
        [Comment("Diet Name")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Diet Image Url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Diet Creator Id")]
        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public Dietitian User { get; set; } = null!;

        public ICollection<MealsDietDietail> MealsDietDietails { get; set; } = new List<MealsDietDietail>();
        public ICollection<PlanAssignment> PlanAssignments { get; set; } = new List<PlanAssignment>();            
    }
}
