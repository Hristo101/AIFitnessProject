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
                }
            };
        }
    }
}
