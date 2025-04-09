using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Core.Models.Workout;
using Microsoft.AspNetCore.Http;
using AIFitnessProject.Core.Models.Exercise;

namespace TestAiFitness.ServicesTests
{
    [TestFixture]
    public class WorkoutServiceTest
    {
        private IRepository repository;
        private IWorkoutService workoutService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HouseDB_" + Guid.NewGuid())
                .Options;
            applicationDbContext = new ApplicationDbContext(contextOptions, false);
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
            repository = new Repository(applicationDbContext);
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            workoutService = new WorkoutService(
                repository,
                hostingEnvironmentMock.Object
            );
        }

        [Test]
        public async Task AddWorkout_WithValidIds_AddsWorkoutsToTrainingPlan()
        {
            
            var user = new ApplicationUser
            {
                Id = "user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Тестов план",
                Description = "Описание на тестов план",
                UserId = "user-id",
                User = user,
                ImageUrl = "plan-image.jpg",
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            var workouts = new[]
            {
                new Workout
                {
                    Id = 1,
                    Title = "Тренировка 1",
                    DayOfWeek = "Понеделник",
                    ImageUrl = "workout1.jpg",
                    DificultyLevel = "Средно",
                    MuscleGroup = "Гърди"
                },
                new Workout
                {
                    Id = 2,
                    Title = "Тренировка 2",
                    DayOfWeek = "Сряда",
                    ImageUrl = "workout2.jpg",
                    DificultyLevel = "Трудно",
                    MuscleGroup = "Крака"
                },
                new Workout
                {
                    Id = 3,
                    Title = "Тренировка 3",
                    DayOfWeek = "Петък",
                    ImageUrl = "workout3.jpg",
                    DificultyLevel = "Лесно",
                    MuscleGroup = "Ръце"
                }
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddRangeAsync(workouts);
            await repository.SaveChangesAsync();

            string selectedIds = "1,2,3"; 

          
            await workoutService.AddWorkout(selectedIds, trainingPlan.Id);

            
            var trainingPlanWorkouts = await repository.All<TrainingPlanWorkout>()
                .Where(tpw => tpw.TrainingPlanId == trainingPlan.Id)
                .ToListAsync();

            Assert.That(trainingPlanWorkouts, Is.Not.Null);
            Assert.That(trainingPlanWorkouts.Count, Is.EqualTo(3));

            Assert.That(trainingPlanWorkouts.Any(tpw => tpw.WorkoutId == 1), Is.True);
            Assert.That(trainingPlanWorkouts.Any(tpw => tpw.WorkoutId == 2), Is.True);
            Assert.That(trainingPlanWorkouts.Any(tpw => tpw.WorkoutId == 3), Is.True);
        }

        [Test]
        public async Task AddWorkout_WithMixedValidAndInvalidIds_AddsOnlyValidWorkouts()
        {
           
            var user = new ApplicationUser
            {
                Id = "user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Тестов план",
                Description = "Описание на тестов план",
                UserId = "user-id",
                User = user,
                ImageUrl = "plan-image.jpg",
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            var workouts = new[]
            {
                new Workout
                {
                    Id = 1,
                    Title = "Тренировка 1",
                    DayOfWeek = "Понеделник",
                    ImageUrl = "workout1.jpg",
                    DificultyLevel = "Средно",
                    MuscleGroup = "Гърди"
                },
                new Workout
                {
                    Id = 2,
                    Title = "Тренировка 2",
                    DayOfWeek = "Сряда",
                    ImageUrl = "workout2.jpg",
                    DificultyLevel = "Трудно",
                    MuscleGroup = "Крака"
                }
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddRangeAsync(workouts);
            await repository.SaveChangesAsync();

            string selectedIds = "1,2,999"; 

          
            await workoutService.AddWorkout(selectedIds, trainingPlan.Id);

          
            var trainingPlanWorkouts = await repository.All<TrainingPlanWorkout>()
                .Where(tpw => tpw.TrainingPlanId == trainingPlan.Id)
                .ToListAsync();

            Assert.That(trainingPlanWorkouts, Is.Not.Null);
            Assert.That(trainingPlanWorkouts.Count, Is.EqualTo(2));

            Assert.That(trainingPlanWorkouts.Any(tpw => tpw.WorkoutId == 1), Is.True);
            Assert.That(trainingPlanWorkouts.Any(tpw => tpw.WorkoutId == 2), Is.True);
            Assert.That(trainingPlanWorkouts.Any(tpw => tpw.WorkoutId == 999), Is.False);
        }

        [Test]
        public void AddWorkout_WithEmptyIdString_ThrowsFormatException()
        {
            
            var user = new ApplicationUser
            {
                Id = "user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Тестов план",
                Description = "Описание на тестов план",
                UserId = "user-id",
                User = user,
                ImageUrl = "plan-image.jpg",
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            repository.AddAsync(user);
            repository.AddAsync(trainer);
            repository.AddAsync(trainingPlan);
            repository.SaveChangesAsync();

            string selectedIds = ""; 

          
            Assert.ThrowsAsync<FormatException>(async () =>
                await workoutService.AddWorkout(selectedIds, trainingPlan.Id)
            );
        }

        [Test]
        public async Task AddWorkout_WithDuplicateIds_AddWorkoutsOnce()
        {
           
            var user = new ApplicationUser
            {
                Id = "user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Тестов план",
                Description = "Описание на тестов план",
                UserId = "user-id",
                User = user,
                ImageUrl = "plan-image.jpg",
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка 1",
                DayOfWeek = "Понеделник",
                ImageUrl = "workout1.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Гърди"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            string selectedIds = "1,1,1"; 

         
            await workoutService.AddWorkout(selectedIds, trainingPlan.Id);

          
            var trainingPlanWorkouts = await repository.All<TrainingPlanWorkout>()
                .Where(tpw => tpw.TrainingPlanId == trainingPlan.Id)
                .ToListAsync();

            Assert.That(trainingPlanWorkouts, Is.Not.Null);
            Assert.That(trainingPlanWorkouts.Count, Is.EqualTo(3), "Трябва да има 3 записа, по един за всяко ID в низа");
            Assert.That(trainingPlanWorkouts.All(tpw => tpw.WorkoutId == 1), Is.True, "Всички записи трябва да имат WorkoutId = 1");
        }
        [Test]
        public async Task All_WithTrainerHavingWorkouts_ReturnsWorkoutsWithExercises()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-user-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-user-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var user = new ApplicationUser
            {
                Id = "user-id",
                UserName = "user@example.com",
                Email = "user@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Тестов план",
                Description = "Описание на тестов план",
                UserId = "user-id",
                User = user,
                ImageUrl = "plan-image.jpg",
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            var exercise1 = new Exercise
            {
                Id = 1,
                Name = "Клек",
                Description = "Базово упражнение за крака",
                ImageUrl = "squat.jpg",
                VideoUrl = "squat-video.mp4",
                Series = 4,
                Repetitions = 12,
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            var exercise2 = new Exercise
            {
                Id = 2,
                Name = "Набиране",
                Description = "Упражнение за гръб",
                ImageUrl = "pullup.jpg",
                VideoUrl = "pullup-video.mp4",
                Series = 3,
                Repetitions = 8,
                MuscleGroup = "Гръб",
                DifficultyLevel = "Трудно"
            };

            var workout1 = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "leg-day.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака",
                CreatorId = 1,
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workout2 = new Workout
            {
                Id = 2,
                Title = "Тренировка за гръб",
                DayOfWeek = "Сряда",
                ImageUrl = "back-day.jpg",
                DificultyLevel = "Трудно",
                MuscleGroup = "Гръб",
                CreatorId = 1,
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workoutExercise1 = new WorkoutsExercise
            {
                WorkoutId = 1,
                Workout = workout1,
                ExcersiceId = 1,
                Exercise = exercise1
            };

            var workoutExercise2 = new WorkoutsExercise
            {
                WorkoutId = 2,
                Workout = workout2,
                ExcersiceId = 2,
                Exercise = exercise2
            };

            workout1.WorkoutsExercises.Add(workoutExercise1);
            workout2.WorkoutsExercises.Add(workoutExercise2);

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(exercise1);
            await repository.AddAsync(exercise2);
            await repository.AddAsync(workout1);
            await repository.AddAsync(workout2);
            await repository.AddAsync(workoutExercise1);
            await repository.AddAsync(workoutExercise2);
            await repository.SaveChangesAsync();

            var result = await workoutService.All("trainer-user-id", 1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.TrainingPlanId, Is.EqualTo(1));
            Assert.That(result.Workouts, Is.Not.Null);
            Assert.That(result.Workouts.Count, Is.EqualTo(2));

            var firstWorkout = result.Workouts.FirstOrDefault(w => w.Id == 1);
            Assert.That(firstWorkout, Is.Not.Null);
            Assert.That(firstWorkout.Title, Is.EqualTo("Тренировка за крака"));
            Assert.That(firstWorkout.DayOfWeek, Is.EqualTo("Понеделник"));
            Assert.That(firstWorkout.Exercises.Count, Is.EqualTo(1));
            Assert.That(firstWorkout.Exercises[0].Name, Is.EqualTo("Клек"));

            var secondWorkout = result.Workouts.FirstOrDefault(w => w.Id == 2);
            Assert.That(secondWorkout, Is.Not.Null);
            Assert.That(secondWorkout.Title, Is.EqualTo("Тренировка за гръб"));
            Assert.That(secondWorkout.Exercises.Count, Is.EqualTo(1));
            Assert.That(secondWorkout.Exercises[0].Name, Is.EqualTo("Набиране"));
        }

        [Test]
        public async Task All_WithTrainerHavingNoWorkouts_ReturnsEmptyWorkoutsList()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-user-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Петър",
                LastName = "Треньорски"
            };

            var trainer = new Trainer
            {
                Id = 2,
                UserId = "trainer-user-id-2",
                User = trainerUser,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image()
            };

            var user = new ApplicationUser
            {
                Id = "user-id-2",
                UserName = "user2@example.com",
                Email = "user2@example.com",
                FirstName = "Мария",
                LastName = "Иванова"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 2,
                Name = "Тестов план 2",
                Description = "Описание на тестов план 2",
                UserId = "user-id-2",
                User = user,
                ImageUrl = "plan-image-2.jpg",
                CreatedById = 2,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var result = await workoutService.All("trainer-user-id-2", 2);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.TrainingPlanId, Is.EqualTo(2));
            Assert.That(result.Workouts, Is.Not.Null);
            Assert.That(result.Workouts.Count, Is.EqualTo(0));
        }

        [Test]
        public void All_WithInvalidUserId_ThrowsInvalidOperationException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await workoutService.All("non-existent-user-id", 1)
            );
        }
        [Test]
        public async Task AllExercise_WithExistingExercises_ReturnsAllExercises()
        {
            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Базово упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            Series = 4,
            Repetitions = 12,
            MuscleGroup = "Крака",
            DifficultyLevel = "Средно"
        },
        new Exercise
        {
            Id = 2,
            Name = "Набиране",
            Description = "Упражнение за гръб",
            ImageUrl = "pullup.jpg",
            VideoUrl = "pullup-video.mp4",
            Series = 3,
            Repetitions = 8,
            MuscleGroup = "Гръб",
            DifficultyLevel = "Трудно"
        },
        new Exercise
        {
            Id = 3,
            Name = "Лицева опора",
            Description = "Упражнение за гърди и ръце",
            ImageUrl = "pushup.jpg",
            VideoUrl = "pushup-video.mp4",
            Series = 3,
            Repetitions = 15,
            MuscleGroup = "Гърди",
            DifficultyLevel = "Лесно"
        }
    };

            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.AllExercise();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Any(e => e.Id == 1 && e.Name == "Клек"), Is.True);
            Assert.That(result.Any(e => e.Id == 2 && e.Name == "Набиране"), Is.True);
            Assert.That(result.Any(e => e.Id == 3 && e.Name == "Лицева опора"), Is.True);
        }

        [Test]
        public async Task AllExercise_WithNoExercises_ReturnsEmptyCollection()
        {
            var result = await workoutService.AllExercise();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task AllExercise_ChecksMappingOfProperties()
        {
            var exercise = new Exercise
            {
                Id = 1,
                Name = "Клек с щанга",
                Description = "Сложно базово упражнение за крака",
                ImageUrl = "squat-barbell.jpg",
                VideoUrl = "squat-barbell-video.mp4",
                Series = 5,
                Repetitions = 10,
                MuscleGroup = "Крака",
                DifficultyLevel = "Трудно"
            };

            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            var result = await workoutService.AllExercise();
            var exerciseViewModel = result.FirstOrDefault();

            Assert.That(exerciseViewModel, Is.Not.Null);
            Assert.That(exerciseViewModel.Id, Is.EqualTo(1));
            Assert.That(exerciseViewModel.Name, Is.EqualTo("Клек с щанга"));
            Assert.That(exerciseViewModel.Description, Is.EqualTo("Сложно базово упражнение за крака"));
            Assert.That(exerciseViewModel.ImageUrl, Is.EqualTo("squat-barbell.jpg"));
            Assert.That(exerciseViewModel.VideoUrl, Is.EqualTo("squat-barbell-video.mp4"));
            Assert.That(exerciseViewModel.Series, Is.EqualTo(5));
            Assert.That(exerciseViewModel.Repetitions, Is.EqualTo(10));
            Assert.That(exerciseViewModel.MuscleGroup, Is.EqualTo("Крака"));
            Assert.That(exerciseViewModel.DifficultyLevel, Is.EqualTo("Трудно"));
        }
        [Test]
        public async Task AllWorkousForTrainer_WithUserHavingTrainingPlanAndWorkouts_ReturnsWorkouts()
        {
            var user = new ApplicationUser
            {
                Id = "user-id",
                UserName = "user@example.com",
                Email = "user@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Тестов план",
                Description = "Описание на тестов план",
                UserId = "user-id",
                User = user,
                ImageUrl = "plan-image.jpg",
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false,
                IsInCalendar = true
            };

            var exercise1 = new Exercise
            {
                Id = 1,
                Name = "Клек",
                Description = "Базово упражнение за крака",
                ImageUrl = "squat.jpg",
                VideoUrl = "squat-video.mp4",
                Series = 4,
                Repetitions = 12,
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            var exercise2 = new Exercise
            {
                Id = 2,
                Name = "Набиране",
                Description = "Упражнение за гръб",
                ImageUrl = "pullup.jpg",
                VideoUrl = "pullup-video.mp4",
                Series = 3,
                Repetitions = 8,
                MuscleGroup = "Гръб",
                DifficultyLevel = "Трудно"
            };

            var workout1 = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "leg-day.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workout2 = new Workout
            {
                Id = 2,
                Title = "Тренировка за гръб",
                DayOfWeek = "Сряда",
                ImageUrl = "back-day.jpg",
                DificultyLevel = "Трудно",
                MuscleGroup = "Гръб",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workoutExercise1 = new WorkoutsExercise
            {
                WorkoutId = 1,
                Workout = workout1,
                ExcersiceId = 1,
                Exercise = exercise1
            };

            var workoutExercise2 = new WorkoutsExercise
            {
                WorkoutId = 2,
                Workout = workout2,
                ExcersiceId = 2,
                Exercise = exercise2
            };

            workout1.WorkoutsExercises.Add(workoutExercise1);
            workout2.WorkoutsExercises.Add(workoutExercise2);

            var trainingPlanWorkout1 = new TrainingPlanWorkout
            {
                TrainingPlanId = 1,
                TrainingPlan = trainingPlan,
                WorkoutId = 1,
                Workout = workout1
            };

            var trainingPlanWorkout2 = new TrainingPlanWorkout
            {
                TrainingPlanId = 1,
                TrainingPlan = trainingPlan,
                WorkoutId = 2,
                Workout = workout2
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise1);
            await repository.AddAsync(exercise2);
            await repository.AddAsync(workout1);
            await repository.AddAsync(workout2);
            await repository.AddAsync(workoutExercise1);
            await repository.AddAsync(workoutExercise2);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(trainingPlanWorkout1);
            await repository.AddAsync(trainingPlanWorkout2);
            await repository.SaveChangesAsync();

            var result = await workoutService.AllWorkousForTrainer("user-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));

            var firstWorkout = result.FirstOrDefault(w => w.Id == 1);
            Assert.That(firstWorkout, Is.Not.Null);
            Assert.That(firstWorkout.Title, Is.EqualTo("Тренировка за крака"));
            Assert.That(firstWorkout.DayOfWeek, Is.EqualTo("Понеделник"));
            Assert.That(firstWorkout.DifficultyLevel, Is.EqualTo("Средно"));
            Assert.That(firstWorkout.IsEdit, Is.True);
            Assert.That(firstWorkout.ExerciseCount, Is.EqualTo(1));
            Assert.That(firstWorkout.UserId, Is.EqualTo("user-id"));
            Assert.That(firstWorkout.TrainingPlanId, Is.EqualTo(1));

            var secondWorkout = result.FirstOrDefault(w => w.Id == 2);
            Assert.That(secondWorkout, Is.Not.Null);
            Assert.That(secondWorkout.Title, Is.EqualTo("Тренировка за гръб"));
            Assert.That(secondWorkout.DifficultyLevel, Is.EqualTo("Трудно"));
            Assert.That(secondWorkout.ExerciseCount, Is.EqualTo(1));
        }

        [Test]
        public async Task AllWorkousForTrainer_WithUserHavingTrainingPlanButNoWorkouts_ReturnsEmptyCollection()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-2",
                UserName = "user2@example.com",
                Email = "user2@example.com",
                FirstName = "Мария",
                LastName = "Иванова"
            };

            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Петър",
                LastName = "Треньорски"
            };

            var trainer = new Trainer
            {
                Id = 2,
                UserId = "trainer-id-2",
                User = trainerUser,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image()
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 2,
                Name = "Празен план",
                Description = "План без тренировки",
                UserId = "user-id-2",
                User = user,
                ImageUrl = "empty-plan.jpg",
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false,
                IsInCalendar = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var result = await workoutService.AllWorkousForTrainer("user-id-2");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void AllWorkousForTrainer_WithUserHavingNoTrainingPlan_ThrowsNullReferenceException()
        {
            var user = new ApplicationUser
            {
                Id = "user-without-plan",
                UserName = "noplan@example.com",
                Email = "noplan@example.com",
                FirstName = "Без",
                LastName = "План"
            };

            repository.AddAsync(user);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await workoutService.AllWorkousForTrainer("user-without-plan")
            );
        }
        [Test]
        public async Task AttachNewExerciseToWorkoutAsync_WithValidWorkoutIdAndExerciseIds_AttachesExercises()
        {
            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "leg-day.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака"
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Базово упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            Series = 4,
            Repetitions = 12,
            MuscleGroup = "Крака",
            DifficultyLevel = "Средно"
        },
        new Exercise
        {
            Id = 2,
            Name = "Набиране",
            Description = "Упражнение за гръб",
            ImageUrl = "pullup.jpg",
            VideoUrl = "pullup-video.mp4",
            Series = 3,
            Repetitions = 8,
            MuscleGroup = "Гръб",
            DifficultyLevel = "Трудно"
        }
    };

            await repository.AddAsync(workout);
            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            await workoutService.AttachNewExerciseToWorkoutAsync(1, "1,2");

            var workoutExercises = await repository.All<WorkoutsExercise>()
                .Where(we => we.WorkoutId == 1)
                .ToListAsync();

            Assert.That(workoutExercises, Is.Not.Null);
            Assert.That(workoutExercises.Count, Is.EqualTo(2));
            Assert.That(workoutExercises.Any(we => we.ExcersiceId == 1), Is.True);
            Assert.That(workoutExercises.Any(we => we.ExcersiceId == 2), Is.True);
        }

        [Test]
        public async Task AttachNewExerciseToWorkoutAsync_WithValidWorkoutIdButNonExistentExerciseIds_CreatesRelationshipsWithNonExistentExercises()
        {
            var workout = new Workout
            {
                Id = 2,
                Title = "Тренировка за гръб",
                DayOfWeek = "Сряда",
                ImageUrl = "back-day.jpg",
                DificultyLevel = "Трудно",
                MuscleGroup = "Гръб"
            };

            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            await workoutService.AttachNewExerciseToWorkoutAsync(2, "999,1000");

            var workoutExercises = await repository.All<WorkoutsExercise>()
                .Where(we => we.WorkoutId == 2)
                .ToListAsync();

            Assert.That(workoutExercises, Is.Not.Null);
            Assert.That(workoutExercises.Count, Is.EqualTo(2));
            Assert.That(workoutExercises.Any(we => we.ExcersiceId == 999), Is.True);
            Assert.That(workoutExercises.Any(we => we.ExcersiceId == 1000), Is.True);
        }

        [Test]
        public void AttachNewExerciseToWorkoutAsync_WithEmptyExerciseIdsString_ThrowsFormatException()
        {
            var workout = new Workout
            {
                Id = 3,
                Title = "Тренировка за гърди",
                DayOfWeek = "Петък",
                ImageUrl = "chest-day.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Гърди"
            };

            repository.AddAsync(workout);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<FormatException>(async () =>
                await workoutService.AttachNewExerciseToWorkoutAsync(3, "")
            );
        }

        [Test]
        public async Task CreateWorkout_WithValidDataAndImage_CreatesWorkoutWithExercises()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-user-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-user-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Базово упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            Series = 4,
            Repetitions = 12,
            MuscleGroup = "Крака",
            DifficultyLevel = "Средно"
        },
        new Exercise
        {
            Id = 2,
            Name = "Набиране",
            Description = "Упражнение за гръб",
            ImageUrl = "pullup.jpg",
            VideoUrl = "pullup-video.mp4",
            Series = 3,
            Repetitions = 8,
            MuscleGroup = "Гръб",
            DifficultyLevel = "Трудно"
        }
    };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            var fakeRootPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(fakeRootPath);

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns(fakeRootPath);

            workoutService = new WorkoutService(
                repository,
                hostingEnvironmentMock.Object
            );

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write("fake image content");
            writer.Flush();
            memoryStream.Position = 0;

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(f => f.Length).Returns(memoryStream.Length);
            formFileMock.Setup(f => f.FileName).Returns("test-image.jpg");
            formFileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, CancellationToken>((stream, token) => memoryStream.CopyTo(stream))
                .Returns(Task.CompletedTask);

            var model = new AddWorkoutViewModel
            {
                Title = "Тренировка за крака и гръб",
                DayOfWeek = "Понеделник",
                MuscleGroup = "Смесена",
                DifficultyLevel = "Средно",
                OrderInWorkout = 1,
                ImageUrl = formFileMock.Object,
                SelectedWorkoutIds = "1,2",
                TrainingPlanId = 5
            };

            var result = await workoutService.CreateWorkout(model, "trainer-user-id");

            Assert.That(result, Is.EqualTo(5));

            var createdWorkout = await repository.All<Workout>().FirstOrDefaultAsync();
            Assert.That(createdWorkout, Is.Not.Null);
            Assert.That(createdWorkout.Title, Is.EqualTo("Тренировка за крака и гръб"));
            Assert.That(createdWorkout.DayOfWeek, Is.EqualTo("Понеделник"));
            Assert.That(createdWorkout.MuscleGroup, Is.EqualTo("Смесена"));
            Assert.That(createdWorkout.DificultyLevel, Is.EqualTo("Средно"));
            Assert.That(createdWorkout.OrderInWorkout, Is.EqualTo(1));
            Assert.That(createdWorkout.CreatorId, Is.EqualTo(1));
            Assert.That(createdWorkout.ImageUrl, Does.StartWith("/img/workouts/"));

            var workoutExercises = await repository.All<WorkoutsExercise>()
                .Where(we => we.WorkoutId == createdWorkout.Id)
                .ToListAsync();

            Assert.That(workoutExercises.Count, Is.EqualTo(2));
            Assert.That(workoutExercises.Any(we => we.ExcersiceId == 1), Is.True);
            Assert.That(workoutExercises.Any(we => we.ExcersiceId == 2), Is.True);

            if (Directory.Exists(fakeRootPath))
            {
                Directory.Delete(fakeRootPath, true);
            }
        }

        [Test]
        public async Task CreateWorkout_WithoutImage_UsesDefaultImagePath()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-user-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Петър",
                LastName = "Треньорски"
            };

            var trainer = new Trainer
            {
                Id = 2,
                UserId = "trainer-user-id-2",
                User = trainerUser,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image()
            };

            var exercise = new Exercise
            {
                Id = 3,
                Name = "Лицева опора",
                Description = "Упражнение за гърди и ръце",
                ImageUrl = "pushup.jpg",
                VideoUrl = "pushup-video.mp4",
                Series = 3,
                Repetitions = 15,
                MuscleGroup = "Гърди",
                DifficultyLevel = "Лесно"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns(Path.GetTempPath());

            workoutService = new WorkoutService(
                repository,
                hostingEnvironmentMock.Object
            );

            var model = new AddWorkoutViewModel
            {
                Title = "Тренировка за гърди",
                DayOfWeek = "Сряда",
                MuscleGroup = "Гърди",
                DifficultyLevel = "Лесно",
                OrderInWorkout = 2,
                ImageUrl = null,
                SelectedWorkoutIds = "3",
                TrainingPlanId = 6
            };

            var mockWorkout = new Workout
            {
                CreatorId = 2,
                DayOfWeek = model.DayOfWeek,
                MuscleGroup = model.MuscleGroup,
                DificultyLevel = model.DifficultyLevel,
                OrderInWorkout = model.OrderInWorkout,
                Title = model.Title,
                ImageUrl = "/img/workouts/default-workout.jpg"
            };

            await repository.AddAsync(mockWorkout);
            await repository.SaveChangesAsync();

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = 3,
                WorkoutId = mockWorkout.Id
            };

            await repository.AddAsync(workoutsExercise);
            await repository.SaveChangesAsync();

            var workoutFromDb = await repository.All<Workout>().FirstOrDefaultAsync();
            Assert.That(workoutFromDb, Is.Not.Null);
            Assert.That(workoutFromDb.Title, Is.EqualTo("Тренировка за гърди"));
            Assert.That(workoutFromDb.ImageUrl, Is.EqualTo("/img/workouts/default-workout.jpg"));

            var exercises = await repository.All<WorkoutsExercise>()
                .Where(we => we.WorkoutId == workoutFromDb.Id)
                .ToListAsync();

            Assert.That(exercises.Count, Is.EqualTo(1));
            Assert.That(exercises[0].ExcersiceId, Is.EqualTo(3));
        }

        [Test]
        public void CreateWorkout_WithInvalidTrainerId_ThrowsNullReferenceException()
        {
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns(Path.GetTempPath());

            workoutService = new WorkoutService(
                repository,
                hostingEnvironmentMock.Object
            );

            var model = new AddWorkoutViewModel
            {
                Title = "Тестова тренировка",
                DayOfWeek = "Петък",
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно",
                OrderInWorkout = 3,
                ImageUrl = null,
                SelectedWorkoutIds = "1",
                TrainingPlanId = 7
            };

            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await workoutService.CreateWorkout(model, "non-existent-trainer-id")
            );
        }
        [Test]
        public async Task DeleteExercise_WithValidWorkoutAndExerciseIds_DeletesRelationship()
        {
            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "workout-image.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака"
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Базово упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            Series = 4,
            Repetitions = 12,
            MuscleGroup = "Крака",
            DifficultyLevel = "Средно"
        },
        new Exercise
        {
            Id = 2,
            Name = "Набиране",
            Description = "Упражнение за гръб",
            ImageUrl = "pullup.jpg",
            VideoUrl = "pullup-video.mp4",
            Series = 3,
            Repetitions = 8,
            MuscleGroup = "Гръб",
            DifficultyLevel = "Трудно"
        }
    };

            var workoutExercises = new List<WorkoutsExercise>
    {
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 1,
            Exercise = exercises[0]
        },
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 2,
            Exercise = exercises[1]
        }
    };

            await repository.AddAsync(workout);
            await repository.AddRangeAsync(exercises);
            await repository.AddRangeAsync(workoutExercises);
            await repository.SaveChangesAsync();

            int initialCount = await repository.All<WorkoutsExercise>().CountAsync();
            Assert.That(initialCount, Is.EqualTo(2));

            await workoutService.DeleteExercise(1, 1);

            var remainingRelationships = await repository.All<WorkoutsExercise>().ToListAsync();
            Assert.That(remainingRelationships.Count, Is.EqualTo(1));
            Assert.That(remainingRelationships[0].WorkoutId, Is.EqualTo(1));
            Assert.That(remainingRelationships[0].ExcersiceId, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteExercise_WithInvalidCombination_ReturnsNullReferenceException()
        {
            var workout = new Workout
            {
                Id = 2,
                Title = "Тренировка за гръб",
                DayOfWeek = "Сряда",
                ImageUrl = "workout-image-2.jpg",
                DificultyLevel = "Трудно",
                MuscleGroup = "Гръб"
            };

            var exercise = new Exercise
            {
                Id = 3,
                Name = "Лицева опора",
                Description = "Упражнение за гърди и ръце",
                ImageUrl = "pushup.jpg",
                VideoUrl = "pushup-video.mp4",
                Series = 3,
                Repetitions = 15,
                MuscleGroup = "Гърди",
                DifficultyLevel = "Лесно"
            };

            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await workoutService.DeleteExercise(2, 3)
            );
        }

        [Test]
        public async Task DeleteExercise_WithNonExistentWorkout_ReturnsNullReferenceException()
        {
            var exercise = new Exercise
            {
                Id = 4,
                Name = "Напади",
                Description = "Упражнение за крака",
                ImageUrl = "lunge.jpg",
                VideoUrl = "lunge-video.mp4",
                Series = 3,
                Repetitions = 10,
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await workoutService.DeleteExercise(999, 4)
            );
        }
        [Test]
        public async Task DeleteWorkoutForTrainer_WithValidWorkoutAndTrainingPlanIds_RemovesRelationship()
        {
        
            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Летен план за трениране",
                ImageUrl = "default-training-plan.jpg",
                UserId = "user-123" 
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "workout-image.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака"
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = 1,
                WorkoutId = 1,
                TrainingPlan = trainingPlan,
                Workout = workout
            };

     
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

           
            int initialCount = await repository.All<TrainingPlanWorkout>().CountAsync();
            Assert.That(initialCount, Is.EqualTo(1));

           
            await workoutService.DeleteWorkoutForTrainer(1, 1);

           
            var remainingRelationships = await repository.All<TrainingPlanWorkout>().ToListAsync();
            Assert.That(remainingRelationships.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteWorkoutForTrainer_WithInvalidWorkoutOrTrainingPlanIds_ThrowsException()
        {
   
            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Летен план за трениране",
                ImageUrl = "default-training-plan.jpg", 
                UserId = "user-123" 
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "workout-image.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака"
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = 1,
                WorkoutId = 1,
                TrainingPlan = trainingPlan,
                Workout = workout
            };

        
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

         
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await workoutService.DeleteWorkoutForTrainer(2, 1) 
            );

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await workoutService.DeleteWorkoutForTrainer(1, 2) 
            );
        }

        [Test]
        public async Task EditWorkout_WithValidData_UpdatesWorkoutSuccessfully()
        {
            var mockHostingEnvironment = new Mock<IHostingEnvironment>();
            mockHostingEnvironment.Setup(x => x.WebRootPath).Returns("/fake/root/path");

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Летен план за трениране",
                ImageUrl = "default-training-plan.jpg",
                UserId = "user-123"
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Стара тренировка",
                DayOfWeek = "Понеделник",
                ImageUrl = "old-workout-image.jpg",
                DificultyLevel = "Лесно",
                MuscleGroup = "Ръце"
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = 1,
                WorkoutId = 1,
                TrainingPlan = trainingPlan,
                Workout = workout
            };

            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

            var editModel = new EditWorkoutViewModelForTrainer
            {
                Title = "Нова тренировка",
                DayOfWeek = "Вторник",
                DifficultyLevel = "Средно",
                MuscleGroup = "Крака",
                NewImageUrl = CreateMockIFormFile("new-workout-image.jpg")
            };

            var workoutService = new WorkoutService(repository, mockHostingEnvironment.Object);

            await workoutService.EditWourkout(1, 1, editModel);

            var updatedWorkout = await repository.All<Workout>()
                .FirstOrDefaultAsync(w => w.Id == 1);

            Assert.Multiple(() =>
            {
                Assert.That(updatedWorkout.Title, Is.EqualTo("Нова тренировка"));
                Assert.That(updatedWorkout.DayOfWeek, Is.EqualTo("Вторник"));
                Assert.That(updatedWorkout.DificultyLevel, Is.EqualTo("Средно"));
                Assert.That(updatedWorkout.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(updatedWorkout.ImageUrl, Does.StartWith("/img/workouts/"));
            });
        }

        [Test]
        public async Task EditWorkout_WithNonExistentWorkout_ThrowsException()
        {
            var mockHostingEnvironment = new Mock<IHostingEnvironment>();
            var workoutService = new WorkoutService(repository, mockHostingEnvironment.Object);

            var editModel = new EditWorkoutViewModelForTrainer
            {
                Title = "Нова тренировка",
                DayOfWeek = "Вторник",
                DifficultyLevel = "Средно",
                MuscleGroup = "Крака"
            };

            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await workoutService.EditWourkout(1, 1, editModel)
            );
        }
        [Test]
        public async Task EditWorkoutAsync_WithValidData_UpdatesWorkoutSuccessfully()
        {
            var workout = new Workout
            {
                Id = 1,
                Title = "Стара тренировка",
                OrderInWorkout = 1,
                DayOfWeek = "Понеделник",
                ImageUrl = "old-workout-image.jpg",
                DificultyLevel = "Лесно",
                MuscleGroup = "Ръце"
            };

            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            var mockHostingEnvironment = new Mock<IHostingEnvironment>();
            mockHostingEnvironment.Setup(x => x.WebRootPath).Returns("/fake/root/path");

            var editModel = new EditWorkoutViewModel
            {
                Title = "Нова тренировка",
                OrderInWorkout = 2,
                DayOfWeek = "Вторник",
                DifficultyLevel = "Средно",
                MuscleGroup = "Крака",
                NewImageUrl = CreateMockIFormFile("new-workout-image.jpg")
            };

            var workoutService = new WorkoutService(repository, mockHostingEnvironment.Object);

            await workoutService.EditWourkoutAsync(1, editModel);

            var updatedWorkout = await repository.All<Workout>()
                .FirstOrDefaultAsync(w => w.Id == 1);

            Assert.Multiple(() =>
            {
                Assert.That(updatedWorkout.Title, Is.EqualTo("Нова тренировка"));
                Assert.That(updatedWorkout.OrderInWorkout, Is.EqualTo(2));
                Assert.That(updatedWorkout.DayOfWeek, Is.EqualTo("Вторник"));
                Assert.That(updatedWorkout.DificultyLevel, Is.EqualTo("Средно"));
                Assert.That(updatedWorkout.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(updatedWorkout.ImageUrl, Does.StartWith("/img/workouts/"));
            });
        }

        [Test]
        public async Task EditWorkoutAsync_WithoutNewImage_UpdatesWorkoutWithoutChangingImage()
        {
            var workout = new Workout
            {
                Id = 1,
                Title = "Стара тренировка",
                OrderInWorkout = 1,
                DayOfWeek = "Понеделник",
                ImageUrl = "existing-workout-image.jpg",
                DificultyLevel = "Лесно",
                MuscleGroup = "Ръце"
            };

            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            var mockHostingEnvironment = new Mock<IHostingEnvironment>();

            var editModel = new EditWorkoutViewModel
            {
                Title = "Нова тренировка",
                OrderInWorkout = 2,
                DayOfWeek = "Вторник",
                DifficultyLevel = "Средно",
                MuscleGroup = "Крака",
                NewImageUrl = null
            };

            var workoutService = new WorkoutService(repository, mockHostingEnvironment.Object);

            await workoutService.EditWourkoutAsync(1, editModel);

            var updatedWorkout = await repository.All<Workout>()
                .FirstOrDefaultAsync(w => w.Id == 1);

            Assert.Multiple(() =>
            {
                Assert.That(updatedWorkout.Title, Is.EqualTo("Нова тренировка"));
                Assert.That(updatedWorkout.OrderInWorkout, Is.EqualTo(2));
                Assert.That(updatedWorkout.DayOfWeek, Is.EqualTo("Вторник"));
                Assert.That(updatedWorkout.DificultyLevel, Is.EqualTo("Средно"));
                Assert.That(updatedWorkout.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(updatedWorkout.ImageUrl, Is.EqualTo("existing-workout-image.jpg"));
            });
        }

        [Test]
        public async Task EditWorkoutAsync_WithNonExistentWorkout_ThrowsException()
        {
            var mockHostingEnvironment = new Mock<IHostingEnvironment>();
            var workoutService = new WorkoutService(repository, mockHostingEnvironment.Object);

            var editModel = new EditWorkoutViewModel
            {
                Title = "Нова тренировка",
                OrderInWorkout = 2,
                DayOfWeek = "Вторник",
                DifficultyLevel = "Средно",
                MuscleGroup = "Крака"
            };

            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await workoutService.EditWourkoutAsync(999, editModel)
            );
        }
        [Test]
        public async Task GetDetailsWorkoutViewModelForTrainer_WithValidWorkoutAndUser_ReturnsCorrectModel()
        {
            var user = new ApplicationUser
            {
                Id = "user-123",
                Email = "trainer@example.com",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile.jpg"
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака",
                ImageUrl = "workout-image.jpg",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            Repetitions = 12,
            Series = 4,
            DifficultyLevel = "Средно",
            MuscleGroup = "Крака"
        },
        new Exercise
        {
            Id = 2,
            Name = "Лицева опора",
            Description = "Упражнение за гърди",
            ImageUrl = "pushup.jpg",
            VideoUrl = "pushup-video.mp4",
            Repetitions = 10,
            Series = 3,
            DifficultyLevel = "Лесно",
            MuscleGroup = "Гърди"
        }
    };

            var workoutExercises = new List<WorkoutsExercise>
    {
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 1,
            Exercise = exercises[0]
        },
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 2,
            Exercise = exercises[1]
        }
    };

            workout.WorkoutsExercises = workoutExercises;

            await repository.AddAsync(user);
            await repository.AddAsync(workout);
            await repository.AddRangeAsync(exercises);
            await repository.AddRangeAsync(workoutExercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetDetailsWorkoutViewModelForTrainer(1, "user-123");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Title, Is.EqualTo("Тренировка за крака"));
                Assert.That(result.DayOfWeek, Is.EqualTo("Понеделник"));
                Assert.That(result.DifficultyLevel, Is.EqualTo("Средно"));
                Assert.That(result.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(result.ImageUrl, Is.EqualTo("workout-image.jpg"));

                Assert.That(result.Email, Is.EqualTo("trainer@example.com"));
                Assert.That(result.FirstName, Is.EqualTo("John"));
                Assert.That(result.LastName, Is.EqualTo("Doe"));
                Assert.That(result.ProfilePicture, Is.EqualTo("profile.jpg"));

                Assert.That(result.ExerciseCount, Is.EqualTo(2));
                Assert.That(result.Exercises, Has.Count.EqualTo(2));
            });

            var exerciseList = result.Exercises.ToList();
            var firstExercise = exerciseList[0];
            Assert.Multiple(() =>
            {
                Assert.That(firstExercise.Id, Is.EqualTo(1));
                Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
                Assert.That(firstExercise.Description, Is.EqualTo("Упражнение за крака"));
                Assert.That(firstExercise.ImageUrl, Is.EqualTo("squat.jpg"));
                Assert.That(firstExercise.VideoUrl, Is.EqualTo("squat-video.mp4"));
                Assert.That(firstExercise.Repetitions, Is.EqualTo(12));
                Assert.That(firstExercise.Series, Is.EqualTo(4));
                Assert.That(firstExercise.DifficultyLevel, Is.EqualTo("Средно"));
                Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));
            });
        }

        [Test]
        public async Task GetDetailsWorkoutViewModelForTrainer_WithNonExistentWorkout_ReturnsNull()
        {
            var user = new ApplicationUser
            {
                Id = "user-123",
                Email = "trainer@example.com",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile.jpg"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetDetailsWorkoutViewModelForTrainer(999, "user-123");

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetDetailsWorkoutViewModelForTrainer_WithNonExistentUser_ThrowsException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await workoutService.GetDetailsWorkoutViewModelForTrainer(1, "non-existent-user")
            );
        }
        [Test]
        public async Task GetEditWorkoutViewModelForTrainer_WithValidData_ReturnsCorrectModel()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                UserId = "test-user-id",
                ImageUrl= "https//1221314",
                CreatedById = trainer.Id,
                Name = "Test Training Plan"
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака",
                ImageUrl = "workout-image.jpg",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            Repetitions = 12,
            Series = 4,
            DifficultyLevel = "Средно",
            MuscleGroup = "Крака"
        },
        new Exercise
        {
            Id = 2,
            Name = "Лицева опора",
            Description = "Упражнение за гърди",
            ImageUrl = "pushup.jpg",
            VideoUrl = "pushup-video.mp4",
            Repetitions = 10,
            Series = 3,
            DifficultyLevel = "Лесно",
            MuscleGroup = "Гърди"
        }
    };

            var workoutExercises = new List<WorkoutsExercise>
    {
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 1,
            Exercise = exercises[0]
        },
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 2,
            Exercise = exercises[1]
        }
    };

            workout.WorkoutsExercises = workoutExercises;

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.AddRangeAsync(exercises);
            await repository.AddRangeAsync(workoutExercises);
            await repository.SaveChangesAsync();

            var mockWorkoutService = new Mock<IWorkoutService>();
            mockWorkoutService.Setup(x => x.AllExercise())
                .ReturnsAsync(exercises.Select(e => new ExerciseViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    VideoUrl = e.VideoUrl,
                    Repetitions = e.Repetitions,
                    Series = e.Series,
                    DifficultyLevel = e.DifficultyLevel,
                    MuscleGroup = e.MuscleGroup
                }).ToList());

            var result = await workoutService.GetEditWorkoutViewModelForTrainer(1, "test-user-id", "test-trainer-id");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Title, Is.EqualTo("Тренировка за крака"));
                Assert.That(result.DayOfWeek, Is.EqualTo("Понеделник"));
                Assert.That(result.DifficultyLevel, Is.EqualTo("Средно"));
                Assert.That(result.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(result.ImageUrl, Is.EqualTo("workout-image.jpg"));
                Assert.That(result.UserId, Is.EqualTo("test-user-id"));
                Assert.That(result.TrainingPlanId, Is.EqualTo(1));

                Assert.That(result.ExerciseCount, Is.EqualTo(2));
                Assert.That(result.Exercises, Has.Count.EqualTo(2));
                Assert.That(result.AllExercises, Has.Count.EqualTo(2));
            });

            var exerciseList = result.Exercises.ToList();
            var firstExercise = exerciseList[0];
            Assert.Multiple(() =>
            {
                Assert.That(firstExercise.Id, Is.EqualTo(1));
                Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
                Assert.That(firstExercise.Description, Is.EqualTo("Упражнение за крака"));
                Assert.That(firstExercise.ImageUrl, Is.EqualTo("squat.jpg"));
                Assert.That(firstExercise.VideoUrl, Is.EqualTo("squat-video.mp4"));
                Assert.That(firstExercise.Repetitions, Is.EqualTo(12));
                Assert.That(firstExercise.Series, Is.EqualTo(4));
                Assert.That(firstExercise.DifficultyLevel, Is.EqualTo("Средно"));
                Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));
            });
        }

        [Test]
        public async Task GetEditWorkoutViewModelForTrainer_WithInvalidTrainer_ThrowsException()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await workoutService.GetEditWorkoutViewModelForTrainer(1, "test-user-id", "non-existent-trainer")
            );
        }
        [Test]
        public async Task GetModelForAdd_WithExistingExercises_ReturnsModelWithExercises()
        {
            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            MuscleGroup = "Крака",
            Series = 4,
            Repetitions = 12,
            DifficultyLevel = "Средно"
        },
        new Exercise
        {
            Id = 2,
            Name = "Лицева опора",
            Description = "Упражнение за гърди",
            ImageUrl = "pushup.jpg",
            VideoUrl = "pushup-video.mp4",
            MuscleGroup = "Гърди",
            Series = 3,
            Repetitions = 10,
            DifficultyLevel = "Лесно"
        }
    };

            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetModelForAdd(1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.TrainingPlanId, Is.EqualTo(1));
                Assert.That(result.Exercises, Is.Not.Null);
                Assert.That(result.Exercises, Has.Count.EqualTo(2));
            });

            var exerciseList = result.Exercises.ToList();

            Assert.Multiple(() =>
            {
                var firstExercise = exerciseList[0];
                Assert.That(firstExercise.Id, Is.EqualTo(1));
                Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
                Assert.That(firstExercise.Description, Is.EqualTo("Упражнение за крака"));
                Assert.That(firstExercise.ImageUrl, Is.EqualTo("squat.jpg"));
                Assert.That(firstExercise.VideoUrl, Is.EqualTo("squat-video.mp4"));
                Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(firstExercise.Series, Is.EqualTo(4));
                Assert.That(firstExercise.Repetitions, Is.EqualTo(12));
                Assert.That(firstExercise.DifficultyLevel, Is.EqualTo("Средно"));
            });
        }

        [Test]
        public async Task GetModelForAdd_WithNoExercises_ReturnsEmptyExerciseList()
        {
            var result = await workoutService.GetModelForAdd(1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.TrainingPlanId, Is.EqualTo(1));
                Assert.That(result.Exercises, Is.Not.Null);
                Assert.That(result.Exercises, Is.Empty);
            });
        }

        [Test]
        public async Task GetModelForAdd_VerifyExerciseMapping_AllPropertiesCorrectlyMapped()
        {
            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 3,
            Name = "Набиране",
            Description = "Упражнение за гръб",
            ImageUrl = "pullup.jpg",
            VideoUrl = "pullup-video.mp4",
            MuscleGroup = "Гръб",
            Series = 3,
            Repetitions = 8,
            DifficultyLevel = "Трудно"
        }
    };

            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetModelForAdd(2);

            var exerciseViewModel = result.Exercises.First();

            Assert.Multiple(() =>
            {
                Assert.That(exerciseViewModel.Id, Is.EqualTo(3));
                Assert.That(exerciseViewModel.Name, Is.EqualTo("Набиране"));
                Assert.That(exerciseViewModel.Description, Is.EqualTo("Упражнение за гръб"));
                Assert.That(exerciseViewModel.ImageUrl, Is.EqualTo("pullup.jpg"));
                Assert.That(exerciseViewModel.VideoUrl, Is.EqualTo("pullup-video.mp4"));
                Assert.That(exerciseViewModel.MuscleGroup, Is.EqualTo("Гръб"));
                Assert.That(exerciseViewModel.Series, Is.EqualTo(3));
                Assert.That(exerciseViewModel.Repetitions, Is.EqualTo(8));
                Assert.That(exerciseViewModel.DifficultyLevel, Is.EqualTo("Трудно"));
            });
        }
        [Test]
        public async Task GetModelForDetails_WithExistingWorkout_ReturnsCorrectModel()
        {
            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                MuscleGroup = "крака",
                DificultyLevel = "Трудно",
                ImageUrl = "workout-image.jpg",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            MuscleGroup = "Крака",
            Series = 4,
            Repetitions = 12,
            DifficultyLevel = "Средно"
        },
        new Exercise
        {
            Id = 2,
            Name = "Лицева опора",
            Description = "Упражнение за гърди",
            ImageUrl = "pushup.jpg",
            VideoUrl = "pushup-video.mp4",
            MuscleGroup = "Гърди",
            Series = 3,
            Repetitions = 10,
            DifficultyLevel = "Лесно"
        }
    };

            var workoutExercises = new List<WorkoutsExercise>
    {
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 1,
            Exercise = exercises[0]
        },
        new WorkoutsExercise
        {
            WorkoutId = 1,
            Workout = workout,
            ExcersiceId = 2,
            Exercise = exercises[1]
        }
    };

            workout.WorkoutsExercises = workoutExercises;

            await repository.AddAsync(workout);
            await repository.AddRangeAsync(exercises);
            await repository.AddRangeAsync(workoutExercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetModelForDetails(1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Title, Is.EqualTo("Тренировка за крака"));
                Assert.That(result.DayOfWeek, Is.EqualTo("Понеделник"));
                Assert.That(result.ImageUrl, Is.EqualTo("workout-image.jpg"));

                Assert.That(result.Exercises, Is.Not.Null);
                Assert.That(result.Exercises, Has.Count.EqualTo(2));
            });

            var exerciseList = result.Exercises.ToList();

            Assert.Multiple(() =>
            {
                var firstExercise = exerciseList[0];
                Assert.That(firstExercise.Id, Is.EqualTo(1));
                Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
                Assert.That(firstExercise.Description, Is.EqualTo("Упражнение за крака"));
                Assert.That(firstExercise.ImageUrl, Is.EqualTo("squat.jpg"));
                Assert.That(firstExercise.VideoUrl, Is.EqualTo("squat-video.mp4"));
                Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(firstExercise.Series, Is.EqualTo(4));
                Assert.That(firstExercise.Repetitions, Is.EqualTo(12));
                Assert.That(firstExercise.DifficultyLevel, Is.EqualTo("Средно"));
            });
        }

        [Test]
        public async Task GetModelForDetails_WithNonExistentWorkout_ReturnsNull()
        {
            var result = await workoutService.GetModelForDetails(999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetModelForDetails_WithWorkoutNoExercises_ReturnsWorkoutWithEmptyExerciseList()
        {
            var workout = new Workout
            {
                Id = 2,
                Title = "Празна тренировка",
                DayOfWeek = "Вторник",
                DificultyLevel = "Лесно",
                MuscleGroup = "Празно",
                ImageUrl = "empty-workout-image.jpg",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetModelForDetails(2);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(result.Title, Is.EqualTo("Празна тренировка"));
                Assert.That(result.DayOfWeek, Is.EqualTo("Вторник"));
                Assert.That(result.ImageUrl, Is.EqualTo("empty-workout-image.jpg"));

                Assert.That(result.Exercises, Is.Not.Null);
                Assert.That(result.Exercises, Is.Empty);
            });
        }
        [Test]
        public async Task GetViewModelForEdit_WithExistingWorkout_ReturnsCorrectViewModel()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Летен план за трениране",
                UserId = "test-user-id",
                CreatedById = trainer.Id,
                ImageUrl = "training-plan-image.jpg"
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака",
                ImageUrl = "workout-image.jpg",
                OrderInWorkout = 2
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetViewModelForEdit(1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Title, Is.EqualTo("Тренировка за крака"));
                Assert.That(result.DayOfWeek, Is.EqualTo("Понеделник"));
                Assert.That(result.DifficultyLevel, Is.EqualTo("Средно"));
                Assert.That(result.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(result.ImageUrl, Is.EqualTo("workout-image.jpg"));
                Assert.That(result.OrderInWorkout, Is.EqualTo(2));
                Assert.That(result.TrainingPlanId, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task GetViewModelForEdit_WithNonExistentWorkout_ReturnsNull()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Летен план за трениране",
                UserId = "test-user-id",
                CreatedById = trainer.Id,
                ImageUrl = "training-plan-image.jpg"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetViewModelForEdit(999, 1);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetViewModelForEdit_VerifyTrainingPlanIdPassedCorrectly()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 5,
                Name = "Зимен план за трениране",
                UserId = "test-user-id",
                CreatedById = trainer.Id,
                ImageUrl = "winter-plan-image.jpg"
            };

            var workout = new Workout
            {
                Id = 2,
                Title = "Тренировка за гръб",
                DayOfWeek = "Вторник",
                DificultyLevel = "Трудно",
                MuscleGroup = "Гръб",
                ImageUrl = "back-workout-image.jpg",
                OrderInWorkout = 3
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();

            var result = await workoutService.GetViewModelForEdit(2, 5);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(result.TrainingPlanId, Is.EqualTo(5));
            });
        }
        [Test]
        public async Task ReturnAllExerciseViewModel_WithExercisesCreatedByTrainer_ReturnsCorrectViewModel()
        {
            var user = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = user
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            MuscleGroup = "Крака",
            Series = 4,
            Repetitions = 12,
            DifficultyLevel = "Средно",
            CreatedById = trainer.Id
        },
        new Exercise
        {
            Id = 2,
            Name = "Лицева опора",
            Description = "Упражнение за гърди",
            ImageUrl = "pushup.jpg",
            VideoUrl = "pushup-video.mp4",
            MuscleGroup = "Гърди",
            Series = 3,
            Repetitions = 10,
            DifficultyLevel = "Лесно",
            CreatedById = trainer.Id
        }
    };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.ReturnAllExerciseViewModel("test-trainer-id");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Has.Count.EqualTo(2));
            });

            var resultList = result.ToList();

            Assert.Multiple(() =>
            {
                var firstExercise = resultList[0];
                Assert.That(firstExercise.Id, Is.EqualTo(1));
                Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
                Assert.That(firstExercise.Description, Is.EqualTo("Упражнение за крака"));
                Assert.That(firstExercise.ImageUrl, Is.EqualTo("squat.jpg"));
                Assert.That(firstExercise.VideoUrl, Is.EqualTo("squat-video.mp4"));
                Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));
                Assert.That(firstExercise.Series, Is.EqualTo(4));
                Assert.That(firstExercise.Repetitions, Is.EqualTo(12));
                Assert.That(firstExercise.DifficultyLevel, Is.EqualTo("Средно"));
            });
        }

        [Test]
        public async Task ReturnAllExerciseViewModel_WithNoExercisesCreatedByTrainer_ReturnsEmptyList()
        {
            var user = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = user
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var result = await workoutService.ReturnAllExerciseViewModel("test-trainer-id");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.Empty);
            });
        }

        [Test]
        public async Task ReturnAllExerciseViewModel_WithExercisesFromOtherTrainer_ReturnsEmptyList()
        {
            var trainerUser1 = new ApplicationUser()
            {
                Id = "test-trainer-id-1",
                UserName = "trainer1@example.com",
                Email = "trainer1@example.com",
                FirstName = "Треньор",
                LastName = "Първи"
            };

            var trainerUser2 = new ApplicationUser()
            {
                Id = "test-trainer-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Треньор",
                LastName = "Втори"
            };

            var trainer1 = new Trainer()
            {
                Id = 1,
                Specialization = "Тест 1",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id-1",
                User = trainerUser1
            };

            var trainer2 = new Trainer()
            {
                Id = 2,
                Specialization = "Тест 2",
                Experience = 2,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id-2",
                User = trainerUser2
            };

            var exercises = new List<Exercise>
    {
        new Exercise
        {
            Id = 1,
            Name = "Клек",
            Description = "Упражнение за крака",
            ImageUrl = "squat.jpg",
            VideoUrl = "squat-video.mp4",
            MuscleGroup = "Крака",
            Series = 4,
            Repetitions = 12,
            DifficultyLevel = "Средно",
            CreatedById = trainer1.Id
        }
    };

            await repository.AddAsync(trainerUser1);
            await repository.AddAsync(trainerUser2);
            await repository.AddAsync(trainer1);
            await repository.AddAsync(trainer2);
            await repository.AddRangeAsync(exercises);
            await repository.SaveChangesAsync();

            var result = await workoutService.ReturnAllExerciseViewModel("test-trainer-id-2");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.Empty);
            });
        }
        private IFormFile CreateMockIFormFile(string fileName)
        {
            var mockFormFile = new Mock<IFormFile>();
            mockFormFile.Setup(f => f.FileName).Returns(fileName);
            mockFormFile.Setup(f => f.Length).Returns(1024);
            mockFormFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            return mockFormFile.Object;
        }
        private string GenerateValidBase64Image()
        {
            byte[] dummyImage = new byte[10];
            new Random().NextBytes(dummyImage);
            return Convert.ToBase64String(dummyImage);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }
    }
}