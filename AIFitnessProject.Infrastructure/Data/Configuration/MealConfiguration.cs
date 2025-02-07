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
                    ImageUrl = "https://sire-media-foxbg.fichub.com/24k_bg/custompage-main/302854.1024x576.jpg",
                    Calories = 400,
                    VideoUrl = "https://youtube.com/shorts/f_dzcO3PsjI?si=C1qR4_cE7Yjtb7Eg",
                    MealTime = "Закуска",
                    Recipe = "Съставки:4 яйца, 1 домат ,2 филийки пълнозърнест хляб ,1 ч.л. зехтин, сол и пипер на вкус ,листенца пресен босилек (по желание)\r\n Инструкции за приготвяне:Загрейте малко масло или зехтин в тиган на средна температура.Разбийте 4 яйца и ги изпържете, като добавите малко сол и пипер по вкус.След това измийте доматите и ги нарежете.Накрая добавете 2 филийки пълнозърнест хляб."
                },

                new Meal
                {
                    Id = 2,
                    Name = "Пилешко филе с ориз и зеленчуци",
                    DificultyLevel = "Средно",
                    ImageUrl = "https://static.dir.bg/uploads/images/2024/09/20/2807112/1920x1080.jpg?_=1726837485",
                    Calories = 550,
                    VideoUrl = "https://youtube.com/shorts/GevngVUx-i4?si=SU5C1eU9e4iU2_qt",
                    MealTime = "Обяд",
                    Recipe = "Съставки: 150 г пилешко филе, 100 г кафяв ориз, 200 г зеленчуци (зеле, моркови) и две филийки хляб. \r\n Инструкции за приготвяне:Пилешко филе: Подправи 150 г пилешко с сол, пипер и подправки по избор. Загрей тиган с малко зехтин и го готви 6-7 минути от всяка страна, докато стане златисто.\r\n Кафяв ориз: Изплакни 100 г ориз и го готви в 200 мл вода около 30 минути на среден огън, докато поеме водата.\r\n Зеленчуци: Нарежи 200 г зеле и моркови. Задуши ги на пара или ги кипни за 5-7 минути.\r\n Хляб: Запечи 2 филийки пълнозърнест хляб.\r\n Сглобяване: Подреди пилешкото, ориза, зеленчуците и хляба в чиния."
                },

               new Meal
                {
                    Id = 3,
                    Name = "Риба с гарнитура картофена салата",
                    DificultyLevel = "Средно",
                    ImageUrl = "https://ofertini.com/imgdata/400/riba-sharan-chaushan-som-plocha-garnitura-151750.jpg",
                    Calories = 460,
                    VideoUrl = "https://youtu.be/2JWygq1mjeY?si=QCMfyANQfgh-AyvF",
                    MealTime = "Вечеря",
                    Recipe = "Съставки: 150 г риба(Ципура), 200 г картофена салата, 1филийка пълнозърнест хляб, лимонов сок и сол на вкус, 1ч.л зехтин. \r\n Инструкции за приготвяне: Загрей фурната на 180°C,почисти рибата, направи 2-3 разреза върху кожата и я натрий със сол,полей със зехтин и лимонов сок.постави я в тавичка, покрита с хартия за печене, и печи 25-30 минути.След това свари 200 г картофи и ги овкуси.Поднеси ги заедно в чиния и полей малко лимонов сок за свежест. "
                }
            };
        }
    }

}
