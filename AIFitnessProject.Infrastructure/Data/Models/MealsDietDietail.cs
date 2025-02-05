using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class MealsDietDietail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DietId { get; set; }
        [ForeignKey(nameof(DietId))]
        public Diet Diet { get; set; }

        [Required]
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; }
    }
}
