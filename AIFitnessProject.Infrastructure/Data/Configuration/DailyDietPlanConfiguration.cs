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
                    DificultyLevel = "Лесно",
                    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                },
                new DailyDietPlan
                {
                    Id = 2,
                    Title = "Основни хранения - Ден 2",
                    CreatorId = 2,
                    DayOfWeel = "Вторник",
                    DietId = 1,
                    DificultyLevel = "Средно-Напреднал",
                    ImageUrl = "/img/DailyDietPlan/dailyDietPlan2.webp",
                }
                //new DailyDietPlan
                //{
                //    Id = 3,
                //    Title = "Основни хранения - Ден 3",
                //    CreatorId = 2,
                //    DayOfWeel = "Сряда",
                //    DietId = 1,
                //    DificultyLevel = "Трудно",
                //    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                //},
                //new DailyDietPlan
                //{
                //    Id = 4,
                //    Title = "Основни хранения - Ден 4",
                //    CreatorId = 2,
                //    DayOfWeel = "Четвъртък",
                //    DietId = 1,
                //    DificultyLevel = "Лесно",
                //    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                //},
                // new DailyDietPlan
                //{
                //    Id = 5,
                //    Title = "Основни хранения - Ден 5",
                //    CreatorId = 2,
                //    DayOfWeel = "Петък",
                //    DietId = 1,
                //    DificultyLevel = "Средно",
                //    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                //},
                //  new DailyDietPlan
                //{
                //    Id = 6,
                //    Title = "Основни хранения - Ден 6",
                //    CreatorId = 2,
                //    DayOfWeel = "Събота",
                //    DietId = 1,
                //    DificultyLevel = "Трудно",
                //    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                //},
                //   new DailyDietPlan
                //{
                //    Id = 7,
                //    Title = "Основни хранения - Ден 7",
                //    CreatorId = 2,
                //    DayOfWeel = "Неделя",
                //    DietId = 1,
                //    DificultyLevel = "Лесно",
                //    ImageUrl = "/img/DailyDietPlan/DailyDietPlanImage.jpeg",
                //}
            };
        }
    }
}
