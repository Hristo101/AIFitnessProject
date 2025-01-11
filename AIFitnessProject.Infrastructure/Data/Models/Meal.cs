using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Meal;
namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Meal Table")]
    public class Meal
    {
        [Key]
        [Comment("Meal Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Comment("Meal Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxRecipeLength)]
        [Comment("Meal Recipe")]
        public string Recipe { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxImageUrlLength)]
        [Comment("Meal ImageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxVideoUrlLength)]
        [Comment("Meal VideoUrl")]
        public string VideoUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxCaloriesLength)]
        [Comment("Meal Calories")]
        public int Calories { get; set; }

        public ICollection<DietDetail> DietDetails { get; set; } = new List<DietDetail>();
    }
}
