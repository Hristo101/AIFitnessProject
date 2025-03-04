using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class DailyDietPlanConfiguration : IEntityTypeConfiguration<DailyDietPlan>
    {
        public void Configure(EntityTypeBuilder<DailyDietPlan> builder)
        {
            builder.HasData(SeedDailyDietPlans());
        }

        private List<DailyDietPlan> SeedDailyDietPlans()
        {
            return new List<DailyDietPlan>
            {
                new DailyDietPlan
                {
                    Id = 1,
                    Title = "Основни хранения - Ден 1",
                    CreatorId = 2,
                    DayOfWeel = "Понеделник",
                    DificultyLevel = "Лесно",
                    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                },
                new DailyDietPlan
                {
                    Id = 2,
                    Title = "Основни хранения - Ден 2",
                    CreatorId = 2,
                    DayOfWeel = "Вторник",
                    DificultyLevel = "Средно-Напреднал",
                    ImageUrl = "/img/DailyDietPlan/dailyDietPlan2.webp",
                }
               
            };
        }
    }
}
