using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlan>
    { 
        public void Configure(EntityTypeBuilder<TrainingPlan> builder)
        {
            builder.HasData(SeedTrainingPlans());
        }

        private List<TrainingPlan> SeedTrainingPlans()
        {
            return new List<TrainingPlan>
            {
                new TrainingPlan
                {
                    Id = 1,
                    CreatedById = 2,
                    UserId = "cd87d0e2-4047-473e-924a-3e10406c5583",
                    ImageUrl = "/img/Flux_Dev_Create_a_highquality_fitnessthemed_image_that_represe_32.jpeg",
                    Name = "План за покачване на мускулна маса",
                    Description = "Тренировъчният план за покачване на мускулна маса ще ти помогне да стимулираш растежа на мускулите чрез прогресивно натоварване и правилна техника. Когато увеличаваш тежестта или повторенията постепенно, мускулите ти ще бъдат предизвикани да се адаптират и да растат по-големи и по-силни. Силовите тренировки не само увеличават обема на мускулите, но и подобряват силата, което ти дава възможност да работиш с по-големи тежести и да продължаваш да напредваш. Това ще оптимизира метаболизма ти и ще подобри цялостната ти физическа форма, като същевременно ще увеличи способността ти да изгаряш мазнини, дори когато не тренираш активно. Ключово е да комбинираш тези тренировки с подходящо хранене и възстановяване, за да постигнеш максимални резултати в покачването на мускулната маса."

                }
            };
        }
    }
}
