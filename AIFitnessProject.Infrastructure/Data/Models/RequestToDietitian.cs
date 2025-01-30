using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Request To Dietitian Table")]
    public class RequestToDietitian
    {
        [Key]
        [Comment("Request To Dietitian Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Comment("User Target")]
        public string Target { get; set; } = string.Empty;

        [Required]
        [Comment("User Pictures")]
        public List<string> UserPictures { get; set; } = new List<string>();


        [Required]
        [MaxLength(200)]
        [Comment("User Diet Background")]
        public string DietBackground { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Health Issues")]
        public string HealthIssues { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Foods Allergies")]
        public string FoodAllergies { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Favourite Food")]
        public string FavouriteFoods { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Meal Preparation Preference")]
        public string MealPreparationPreference { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Preffered Meals Per Day")]
        public string PreferredMealsPerDay { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Disliked Foods")]
        public string DislikedFoods { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Comment("User Used Supplements")]
        public string SupplementsUsed { get; set; } = string.Empty;

        [Required]
        [Comment("Has the request been answered?")]
        public bool IsAnswered { get; set; }

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Dietitian Identifier")]
        public int DietitianId { get; set; }

        [ForeignKey(nameof(DietitianId))]
        public Dietitian Dietitian { get; set; } = null!;
    }
}
