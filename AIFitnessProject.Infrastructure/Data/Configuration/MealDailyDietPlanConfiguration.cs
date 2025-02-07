using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class MealDailyDietPlanConfiguration : IEntityTypeConfiguration<MealsDailyDietPlan>
    {
        public void Configure(EntityTypeBuilder<MealsDailyDietPlan> builder)
        {
            builder.HasData(SeedMealsDailyDietPlans());
        }

        private List<MealsDailyDietPlan> SeedMealsDailyDietPlans()
        {
            return new List<MealsDailyDietPlan>
            {
                new MealsDailyDietPlan
                {
                    Id = 1,
                    MealId = 1,
                    DailyDietPlansId = 1,
                }
            };
        }
    }
}
