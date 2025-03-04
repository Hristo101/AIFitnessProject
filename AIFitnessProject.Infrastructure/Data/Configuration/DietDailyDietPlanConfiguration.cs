using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class DietDailyDietPlanConfiguration : IEntityTypeConfiguration<DietDailyDietPlan>
    {
        public void Configure(EntityTypeBuilder<DietDailyDietPlan> builder)
        {
            builder.HasData(SeedDietDailyDietPlan());
        }

        private List<DietDailyDietPlan> SeedDietDailyDietPlan()
        {
            return new List<DietDailyDietPlan>
            {
                new DietDailyDietPlan
                {
                    Id= 1,
                    DietId = 1,
                    DailyDietPlanId = 1,
                },
                new DietDailyDietPlan
                {
                    Id = 2,
                    DietId = 1,
                    DailyDietPlanId = 2
                }
            };
        }
    }
}
