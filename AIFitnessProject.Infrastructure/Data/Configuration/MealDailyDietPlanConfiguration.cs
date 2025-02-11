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
                },
                 new MealsDailyDietPlan
                {
                    Id = 2,
                    MealId = 2,
                    DailyDietPlansId = 1,
                },
                  new MealsDailyDietPlan
                {
                    Id = 3,
                    MealId = 3,
                    DailyDietPlansId = 1,
                },
                  new MealsDailyDietPlan
                {
                    Id = 4,
                    MealId = 4,
                    DailyDietPlansId = 2,
                },
                 new MealsDailyDietPlan
                {
                    Id = 5,
                    MealId = 5,
                    DailyDietPlansId = 2,
                },
                  new MealsDailyDietPlan
                {
                    Id = 6,
                    MealId = 6,
                    DailyDietPlansId = 2,
                }
            };
        }
    }
}
