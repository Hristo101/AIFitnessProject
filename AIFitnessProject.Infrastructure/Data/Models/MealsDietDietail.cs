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
        public int DietDetailsId { get; set; }

        [ForeignKey(nameof(DietDetailsId))]
        public DietDetail DietDetails { get; set; }

        [Required]
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; }
    }
}
