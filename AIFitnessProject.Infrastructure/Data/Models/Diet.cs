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
        [Comment("Diet User Id")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Diet Creator Id")]
        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public Dietitian Dietitian { get; set; } = null!;

        public bool IsActive { get; set; } = false;


        public bool IsEdit { get; set; } = false;

        public bool IsInCalendar { get; set; } = false;


        public ICollection<DietDailyDietPlan> DietDailyDietPlans { get; set; } = new List<DietDailyDietPlan>();
        public ICollection<MealFeedback> MealFeedbacks { get; set; } = new List<MealFeedback>();
        public ICollection<CalendarDiet> CalendarDiet { get; set; } = new List<CalendarDiet>();
    }
}
