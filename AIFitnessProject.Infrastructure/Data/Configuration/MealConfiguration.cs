using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasData(SeedMeals());
        }

        private List<Meal> SeedMeals()
        {
            return new List<Meal>
            {
                new Meal
                {
                    Id = 1,
                    Name = "Пържени яйца с гарнитура домати",
                    DificultyLevel = "Лесно",
                    ImageUrl = "https://inthebeniskitchen.com/wp-content/uploads/2020/08/img_20200806_130537.jpg",
                    Calories = 400,
                    VideoUrl = "https://youtube.com/shorts/f_dzcO3PsjI?si=C1qR4_cE7Yjtb7Eg",
                    MealTime = "Закуска",
                    Recipe = "Съставки:4 яйца, 1 домат ,2 филийки пълнозърнест хляб ,1 ч.л. зехтин, сол и пипер на вкус ,листенца пресен босилек (по желание)\r\n Инструкции за приготвяне:Загрейте малко масло или зехтин в тиган на средна температура.Разбийте 4 яйца и ги изпържете, като добавите малко сол и пипер по вкус.След това измийте доматите и ги нарежете.Накрая добавете 2 филийки пълнозърнест хляб."
                }
            };
        }
    }

}
