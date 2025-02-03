using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

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
                }
            };
        }
    }
}
