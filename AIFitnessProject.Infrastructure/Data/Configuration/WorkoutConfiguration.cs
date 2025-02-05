using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.HasData(SeedWorkouts());
        }

        private List<Workout> SeedWorkouts()
        {
            return new List<Workout>
            {
                new Workout
                {
                    Id = 1,
                    Title = "Основна тренировка за гърди",
                    ImageUrl = "https://cdn5.amcn.in/a/sport-direct.alle.bg/assets/d0001a0431ab-c999999999/e2omdu5nt1ga19ea1zuc.jpg",
                    CreatorId = 2,           
                    TrainingPlanId = 1,        
                    DayOfWeek = "Понеделник",
                    OrderInWorkout = 1
                }
            };
        }
    }
}
