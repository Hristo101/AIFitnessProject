using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(SeedExercises());
        }

        private List<Exercise> SeedExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                    Id = 1,
                    Name = "Лицеви опори",
                    Description = "Упражнение за гърди, рамене и трицепс.",
                    ImageUrl = "https://example.com/images/pushups.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=k11CvzGtRGE",
                    MuscleGroup = "Гърди",
                    DifficultyLevel = "Лесно"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Лежанка",
                    Description = "Упражнение за средната част на гърдите.",
                    ImageUrl = "https://4fitness.bg/blog/Files/Images/exercises/close-grip-bench-press.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=hWbUlkb5Ms4",
                    MuscleGroup = "Гърди",
                    DifficultyLevel = "Средно"
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Кофички",
                    Description = "Упражнение за долната част на гърдите.",
                    ImageUrl = "https://4fitness.bg/blog/Files/Images/exercises/dips-exercise.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=m_sGDGxlibI",
                    MuscleGroup = "Гърди",
                    DifficultyLevel = "Средно"
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Кофички",
                    Description = "Упражнение за средната част на гърдите.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/28/399_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=GhG-UXc2v1Y",
                    MuscleGroup = "Гърди",
                    DifficultyLevel = "Лесно",
                },
                   new Exercise
                {
                    Id = 5,
                    Name = "Мъртва тяга",
                    Description = "Упражнение за цялата част на гърба.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/65_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=yPqv3ejnZvc",
                    MuscleGroup = "Гръб",
                    DifficultyLevel = "Трудно",
                   },
                     new Exercise
                {
                    Id = 6,
                    Name = "Горен скрипец с широк хват",
                    Description = "Упражнение за широкия гръбен мускул.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/392_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=_HsCxLNPpoY",
                    MuscleGroup = "Гръб",
                    DifficultyLevel = "Лесно",
                   },
                new Exercise
                {
                    Id = 7,
                    Name = "Горен скрипец с широк хват",
                    Description = "Упражнение за средната и долната част на гърба.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/403_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=LWBxwyp9zJg",
                    MuscleGroup = "Гръб",
                    DifficultyLevel = "Лесно",
                },
                  new Exercise
                {
                    Id = 8,
                    Name = "Дърпане на дъмбел с една ръка",
                    Description = "Упражнението основно натоварва средната и долната част на гърба, но също така ангажира и горната част като стабилизиращ фактор.\r\n\r\n1. Средна част на гърба (Mid-Back)\r\nРомбовидни мускули (Rhomboids) – Осигуряват стабилност на лопатките и спомагат за добрата стойка.\r\nСредна част на трапецовидния мускул (Middle Trapezius) – Участва в свиването на лопатките при дърпането.\r\n2. Долна част на гърба (Lower Back)\r\nШирок гръбен мускул (Latissimus Dorsi – Lats) – Основният мускул, отговорен за дебелината и ширината на гърба.\r\nЕректорите на гръбначния стълб (Erector Spinae) – Помагат за стабилизацията на тялото по време на движението.\r\n3. Горна част на гърба (Upper Back) – второстепенно натоварване\r\nГорна част на трапецовидния мускул (Upper Trapezius) – Не е основен мускул в движението, но подпомага стабилността.\r\nЗадно рамо (Posterior Deltoid) – Участва в движението, но с по-малка натовареност.\r\n",
                    ImageUrl = "https://fitnesdieta.com/images/uprajneniya/darpane-dumbbell.webp",
                    VideoUrl = "https://www.youtube.com/watch?v=3ff-qVskb-U",
                    MuscleGroup = "Гръб",
                    DifficultyLevel = "Средно",
                },

            };
        }
    }
}
