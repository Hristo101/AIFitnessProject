using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class TrainingPlanWorkoutConfiguration : IEntityTypeConfiguration<TrainingPlanWorkout>
    {
        public void Configure(EntityTypeBuilder<TrainingPlanWorkout> builder)
        {
            builder.HasData(SeedTrainingPlans());
        }

        private List<TrainingPlanWorkout> SeedTrainingPlans()
        {
            return new List<TrainingPlanWorkout>
            {
                new TrainingPlanWorkout
                {
                    Id= 1,
                    TrainingPlanId = 1,
                   WorkoutId = 1,
                },
                new TrainingPlanWorkout
                {
                    Id = 2,
                    TrainingPlanId = 1,
                    WorkoutId = 2
                }
            };
        }
    }
}
