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
                    MuscleGroup = "Гърди",
                    DificultyLevel = "Средно-Напреднал",
                    OrderInWorkout = 1
                },
                 new Workout
                {
                    Id = 2,
                    Title = "Основна тренировка за гръб",
                    ImageUrl = "https://pulsefit.bg/uploads/cache/O/public/uploads/media-manager/app-modules-blog-models-blog/header/71/797/back_1800x675.jpg",
                    CreatorId = 2,
                    TrainingPlanId = 1,
                    DayOfWeek = "Вторник",
                    OrderInWorkout = 2,
                        MuscleGroup = "Гръб",
                    DificultyLevel = "Средно-Напреднал"
                },
                new Workout
                {
                    Id = 3,
                    Title = "Основна тренировка за крака",
                    ImageUrl = "https://4fitness.bg/blog/Files/Images/Article/Cache/580_232_koi-sa-nay-chestite-prichini-krakata-vi-da-izostavat.jpg",
                    CreatorId = 2,
                    DayOfWeek = "Сряда",
                    OrderInWorkout = 3,
                       MuscleGroup = "Крака",
                    DificultyLevel = "Средно-Напреднал"
                },
                new Workout
                {
                    Id = 4,
                    Title = "Основна тренировка за крака",
                    ImageUrl = "https://spisanie.muscleandfitness.bg/wp-content/uploads/2016/02/%D0%91%D0%B5%D0%B4%D1%80%D0%B5%D0%BD%D0%BE-%D1%81%D0%B3%D1%8A%D0%B2%D0%B0%D0%BD%D0%B5.jpg",
                    CreatorId = 2,
                    DayOfWeek = "Сряда",
                    OrderInWorkout = 3,
                     MuscleGroup = "Крака",
                    DificultyLevel = "Лесно"
                },
                new Workout
                {
                    Id = 5,
                    Title = "Основна тренировка за крака",
                    ImageUrl = "https://www.obekti.bg/sites/default/files/styles/facebook/public/images/shutterstock_714092962.jpg?itok=8KXBwu4y",
                    CreatorId = 2,
                    DayOfWeek = "Сряда",
                    OrderInWorkout = 3,
                     MuscleGroup = "Крака",
                    DificultyLevel = "Трудно"
                }
            };
        }
    }
}
