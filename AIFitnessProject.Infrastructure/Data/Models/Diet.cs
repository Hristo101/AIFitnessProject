using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [ForeignKey(nameof(CreatedById))]
        public int CreatedById { get; set; }
        public Dietitian User { get; set; } = null!;

        public ICollection<DietDetail> DietDetails { get; set; } = new List<DietDetail>();
        public ICollection<PlanAssignment> PlanAssignments { get; set; } = new List<PlanAssignment>();            
    }
}
