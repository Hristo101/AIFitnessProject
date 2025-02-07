using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIFitnessProject.Infrastructure.Data.Models;

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
                    DietId = 1,
                    DificultyLevel = "лесно",
                    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                }
            };
        }
    }
}
