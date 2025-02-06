using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class WorkoutsExerciseConfiguration : IEntityTypeConfiguration<WorkoutsExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutsExercise> builder)
        {
            builder.HasData(SeedWorkoutsExercises());
        }

        private List<WorkoutsExercise> SeedWorkoutsExercises()
        {
            return new List<WorkoutsExercise>
            {
                new WorkoutsExercise
                {
                    Id = 1,
                    ExcersiceId = 1,  
                    WorkoutId = 1 
                },
                new WorkoutsExercise
                {
                    Id = 2,
                    ExcersiceId = 2,  
                    WorkoutId = 1
                },
                new WorkoutsExercise
                {
                    Id = 3,
                    ExcersiceId = 3, 
                    WorkoutId = 1
                },
                new WorkoutsExercise
                {
                    Id = 4,
                    ExcersiceId = 4,
                    WorkoutId = 1
                },
                  new WorkoutsExercise
                {
                    Id = 5,
                    ExcersiceId = 5,
                    WorkoutId = 2
                },
                     new WorkoutsExercise
                {
                    Id = 6,
                    ExcersiceId = 6,
                    WorkoutId = 2
                },

                new WorkoutsExercise
                {
                    Id = 7,
                    ExcersiceId = 7,
                    WorkoutId = 2
                },
                   new WorkoutsExercise
                {
                    Id = 8,
                    ExcersiceId = 8,
                    WorkoutId = 2
                },
                    new WorkoutsExercise
                {
                    Id = 9,
                    ExcersiceId = 14, // Екстензии за предно бедро
                    WorkoutId = 4
                },
                new WorkoutsExercise
                {
                    Id = 10,
                    ExcersiceId = 13, // Лег преса
                    WorkoutId = 4
                },
                new WorkoutsExercise
                {
                    Id = 11,
                    ExcersiceId = 15, // Екстензии за задно бедро
                    WorkoutId = 4
                },
                new WorkoutsExercise
                {
                    Id = 12,
                    ExcersiceId = 16, // Сгъване на адуктори
                    WorkoutId = 4
                },
                new WorkoutsExercise
                {
                    Id = 13,
                    ExcersiceId = 18, // Топка към стена
                    WorkoutId = 4
                },

                // Средна тренировка
                new WorkoutsExercise
                {
                    Id = 14,
                    ExcersiceId = 9,  // Римска тяга с лост
                    WorkoutId = 3
                },
                new WorkoutsExercise
                {
                    Id = 15,
                    ExcersiceId = 10, // Напади с дъмбели
                    WorkoutId = 3
                },
                new WorkoutsExercise
                {
                    Id = 16,
                    ExcersiceId = 11, // Клек с щанга
                    WorkoutId = 3
                },
                new WorkoutsExercise
                {
                    Id = 17,
                    ExcersiceId = 12, // Преден клек
                    WorkoutId = 3
                },
                new WorkoutsExercise
                {
                    Id = 18,
                    ExcersiceId = 17, // Български клек
                    WorkoutId = 3
                },

                // Трудна тренировка
                new WorkoutsExercise
                {
                    Id = 19,
                    ExcersiceId = 9,  // Римска тяга с лост
                    WorkoutId = 5
                },
                new WorkoutsExercise
                {
                    Id = 20,
                    ExcersiceId = 10, // Напади с дъмбели
                    WorkoutId = 5
                },
                new WorkoutsExercise
                {
                    Id = 21,
                    ExcersiceId = 11, // Клек с щанга
                    WorkoutId = 5
                },
                new WorkoutsExercise
                {
                    Id = 22,
                    ExcersiceId = 12, // Преден клек
                    WorkoutId = 5
                },
                new WorkoutsExercise
                {
                    Id = 23,
                    ExcersiceId = 17, // Български клек
                    WorkoutId = 5
                }
            };
        }
    }
}
