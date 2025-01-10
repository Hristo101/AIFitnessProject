using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Diet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public string CreatedBy { get; set; }
        public Dietitian User { get; set; }

        public ICollection<DietDetail> DietDetails { get; set; }
        public ICollection<PlanAssignment> PlanAssignments { get; set; }
    }
}
