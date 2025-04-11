using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAiFiness.ServicesTests
{
    [TestFixture]
    public class CalendarServiceTest
    {
        private IRepository repository;
        private ICalendarService calendarService;
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
            var notificationServiceMock = new Mock<INotificationService>();

            repository = new Repository(applicationDbContext);
            calendarService = new CalendarService(repository,notificationServiceMock.Object);

        }
        [Test]
        public async Task GetModeForUserCalendar_ValidUserAndTrainer_ReturnsCompleteViewModel()
        {
    
            var userId = "test-user-id";
            var trainerId = "trainer-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                ProfilePicture = "/profile/test.jpg"
            };


            var trainer = new Trainer
            {
                Id = 1,
                UserId = trainerId,
                Specialization = "Fitness",
                Experience = 5,
                SertificateImage = "cert.jpg",
                SertificationDetails = "Details",
                Bio = "Trainer Bio",
                PhoneNumber = "1234567890"
            };


            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                ImageUrl = "/workouts/test.jpg",
                DayOfWeek = "Monday",
                DificultyLevel = "Intermediate",
                MuscleGroup = "Full Body"
            };


            var exercise = new Exercise
            {
                Id = 1,
                Description = "Test description",
                ImageUrl = "picture",
                VideoUrl = "https",
                DifficultyLevel = "Трудно",
                Name = "Test Exercise",
                MuscleGroup = "Full Body",
                CreatedById = trainer.Id
            };

            var workoutExercise = new WorkoutsExercise
            {
                WorkoutId = workout.Id,
                ExcersiceId = exercise.Id,
                Workout = workout,
                Exercise = exercise
            };


            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user,
                TrainerId = trainer.Id,
                Trainer = trainer
            };


            var calendarWorkout = new CalendarWorkout
            {
                EventId = 1,
                WorkoutId = workout.Id,
                Workout = workout,
                CalendarId = calendar.Id,
                Calendar = calendar,
                DateOnly = new DateOnly(2024, 1, 15),
                StartEventTime = new TimeOnly(10, 0),
                EndEventTime = new TimeOnly(11, 0)
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                ImageUrl = "picture",
                UserId = userId,
                IsActive = true
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = workout.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };


            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workoutExercise);
            await repository.AddAsync(calendar);
            await repository.AddAsync(calendarWorkout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

           
            var result = await calendarService.GetModeForUserCalendar(userId, trainerId);

           
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
            Assert.AreEqual(calendar.Id, result.CalendarId);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual($"{user.FirstName} {user.LastName}", result.FullName);
            Assert.AreEqual(user.ProfilePicture, result.ProfilePictureUrl);

          
            Assert.IsNotNull(result.Workouts);
            Assert.AreEqual(1, result.Workouts.Count);
            var workoutViewModel = result.Workouts.First();
            Assert.AreEqual(workout.Id, workoutViewModel.Id);
            Assert.AreEqual(workout.Title, workoutViewModel.Name);
            Assert.AreEqual(workout.ImageUrl, workoutViewModel.ImageUrl);

           
            Assert.IsNotNull(result.TrainingPlanWorkouts);
            Assert.AreEqual(1, result.TrainingPlanWorkouts.Count);
            var trainingPlanWorkoutViewModel = result.TrainingPlanWorkouts.First();
            Assert.AreEqual(workout.Id, trainingPlanWorkoutViewModel.Id);
            Assert.AreEqual(workout.Title, trainingPlanWorkoutViewModel.Name);
        }

        [Test]
        public async Task GetModeForUserCalendar_NonExistentUser_ReturnsNull()
        {
          
            var nonExistentUserId = "non-existent-user-id";
            var trainerId = "trainer-user-id";

           
            var trainer = new Trainer
            {
                Id = 1,
                UserId = trainerId,
                Specialization = "Fitness",
                Experience = 5,
                SertificateImage = "cert.jpg",
                SertificationDetails = "Details",
                Bio = "Trainer Bio",
                PhoneNumber = "1234567890"
            };

            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

         
            var result = await calendarService.GetModeForUserCalendar(nonExistentUserId, trainerId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetModeForUserCalendar_UserWithNoCalendar_ReturnsViewModelWithEmptyCollections()
        {
   
            var userId = "test-user-id";
            var trainerId = "trainer-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                ProfilePicture = "/profile/test.jpg"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = trainerId,
                Specialization = "Fitness",
                Experience = 5,
                SertificateImage = "cert.jpg",
                SertificationDetails = "Details",
                Bio = "Trainer Bio",
                PhoneNumber = "1234567890"
            };

        
            var workout = new Workout
            {
                Id = 1,
                Title = "Sample Workout",
                CreatorId = trainer.Id,
                DificultyLevel = "Intermediate",
                ImageUrl = "/workouts/sample.jpg",
                MuscleGroup = "Full Body"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Sample Exercise",
                Description = "Test description",
                ImageUrl = "picture",
                VideoUrl = "https",
                DifficultyLevel = "Трудно",
                MuscleGroup = "Full Body",
                CreatedById = trainer.Id
            };

            var workoutExercise = new WorkoutsExercise
            {
                WorkoutId = workout.Id,
                ExcersiceId = exercise.Id
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Sample Training Plan",
                ImageUrl ="picture",
                UserId = userId,
                IsActive = true
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = workout.Id
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workoutExercise);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

     
            var result = await calendarService.GetModeForUserCalendar(userId, trainerId);


            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
            Assert.AreEqual(0, result.CalendarId);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual($"{user.FirstName} {user.LastName}", result.FullName);
            Assert.AreEqual(user.ProfilePicture, result.ProfilePictureUrl);

            Assert.IsNotNull(result.Workouts);
            Assert.IsEmpty(result.Workouts);

            Assert.IsNotNull(result.TrainingPlanWorkouts);
            Assert.IsNotEmpty(result.TrainingPlanWorkouts);

            Assert.IsNotNull(result.Meals);
            Assert.IsEmpty(result.Meals);
        }


        [Test]
        public async Task AddCalendarEventAsync_ValidEvent_ReturnsEventId()
        {

            var userId = "test-user-id";
            var trainerId = "trainer-user-id";


            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe"
            };


            var trainer = new Trainer
            {
                Id = 1,
                UserId = trainerId,
                User = user,
                Specialization = "Fitness",
                Experience = 5,
                SertificateImage = "cert.jpg",
                SertificationDetails = "Details",
                Bio = "Trainer Bio",
                PhoneNumber = "1234567890"
            };


            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user,
                TrainerId = trainer.Id,
                Trainer = trainer
            };


            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                DificultyLevel = "Intermediate",
                ImageUrl = "/workouts/test.jpg",
                MuscleGroup = "Full Body"
            };


            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(calendar);
            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();


            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService
                .Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);


            var calendarService = new CalendarService(
                repository,
                mockNotificationService.Object
            );


            var model = new AddEventViewModel
            {
                UserId = userId,
                CalendarId = calendar.Id,
                WorkoutId = workout.Id,
                Year = 2024,
                Month = 1,
                Day = 15,
                StartTime = "10:00",
                EndTime = "11:00"
            };


            var result = await calendarService.AddCalendarEventAsync(model, trainerId);


            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result);


            var addedCalendarWorkout = await repository.AllAsReadOnly<CalendarWorkout>()
                .FirstOrDefaultAsync(cw => cw.EventId == result);

            Assert.IsNotNull(addedCalendarWorkout);
            Assert.AreEqual(calendar.Id, addedCalendarWorkout.CalendarId);
            Assert.AreEqual(workout.Id, addedCalendarWorkout.WorkoutId);
            Assert.AreEqual(new DateOnly(2024, 1, 15), addedCalendarWorkout.DateOnly);
            Assert.AreEqual(new TimeOnly(10, 0), addedCalendarWorkout.StartEventTime);
            Assert.AreEqual(new TimeOnly(11, 0), addedCalendarWorkout.EndEventTime);

            // Verify notification was sent
            mockNotificationService.Verify(
                x => x.AddNotification(
                    trainer.UserId,
                    userId,
                    It.IsAny<string>(),
                    "Calendar"
                ),
                Times.Once
            );
        }


        [Test]
        public void AddCalendarEventAsync_InvalidTimeFormat_ThrowsException()
        {

            var userId = "test-user-id";
            var trainerId = "trainer-user-id";

            var model = new AddEventViewModel
            {
                UserId = userId,
                CalendarId = 1,
                WorkoutId = 1,
                Year = 2024,
                Month = 1,
                Day = 15,
                StartTime = "invalid-time",
                EndTime = "invalid-time"
            };


            Assert.ThrowsAsync<Exception>(async () =>
                await calendarService.AddCalendarEventAsync(model, trainerId));
        }

        [Test]
        public void AddCalendarEventAsync_NonExistentTrainer_ThrowsException()
        {

            var userId = "test-user-id";
            var nonExistentTrainerId = "non-existent-trainer-id";


            var model = new AddEventViewModel
            {
                UserId = userId,
                CalendarId = 1,
                WorkoutId = 1,
                Year = 2024,
                Month = 1,
                Day = 15,
                StartTime = "10:00",
                EndTime = "11:00"
            };

 
            Assert.ThrowsAsync<Exception>(async () =>
                await calendarService.AddCalendarEventAsync(model, nonExistentTrainerId));
        }
        [Test]
        public async Task GetModelForUserCalendarInDietitianArea_ValidUser_ReturnsCompleteViewModel()
        {
    
            var userId = "test-user-id";

           
            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                ProfilePicture = "/profile/test.jpg"
            };

     
            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user
            };

        
            var meal = new Meal
            {
                Id = 1,
                Name = "Test Meal",
                Calories = 500,
                ImageUrl = "/meals/test.jpg",
                MealTime = "Lunch",
                CreatedById = 1
            };

 
            var calendarMeal = new CalendarMeal
            {
                EventId = 1,
                MealId = meal.Id,
                Meal = meal,
                CalendarId = calendar.Id,
                Calendar = calendar,
                DateOnly = new DateOnly(2024, 1, 15),
                StartEventTime = new TimeOnly(12, 0),
                EndEventTime = new TimeOnly(13, 0)
            };

     
            var diet = new Diet
            {
                Id = 1,
                UserId = userId,
                IsActive = true
            };

  
            var dailyDietPlan = new DailyDietPlan
            {
                Id = 1
            };


            var dietDailyDietPlan = new DietDailyDietPlan
            {
                DietId = diet.Id,
                Diet = diet,
                DailyDietPlanId = dailyDietPlan.Id,
                DailyDietPlan = dailyDietPlan
            };

    
            var mealsDailyDietPlan = new MealsDailyDietPlan
            {
                DailyDietPlansId = dailyDietPlan.Id,
                DailyDietPlans = dailyDietPlan,
                MealId = meal.Id,
                Meal = meal
            };

           
            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                ImageUrl = "/workouts/test.jpg",
                CreatorId = 1,
                DayOfWeek = "Monday",
                DificultyLevel = "Intermediate",
                MuscleGroup = "Full Body"
            };


            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test description",
                ImageUrl = "picture",
                VideoUrl = "https",
                DifficultyLevel = "Трудно",
                MuscleGroup = "Full Body",
                CreatedById = 1
            };

     
            var workoutExercise = new WorkoutsExercise
            {
                WorkoutId = workout.Id,
                ExcersiceId = exercise.Id,
                Workout = workout,
                Exercise = exercise
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                ImageUrl = "picture",
                UserId = userId,
                IsActive = true
            };


            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = workout.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };


            await repository.AddAsync(user);
            await repository.AddAsync(calendar);
            await repository.AddAsync(meal);
            await repository.AddAsync(calendarMeal);
            await repository.AddAsync(diet);
            await repository.AddAsync(dailyDietPlan);
            await repository.AddAsync(dietDailyDietPlan);
            await repository.AddAsync(mealsDailyDietPlan);
            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workoutExercise);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();


            var result = await calendarService.GetModelForUserCalendarInDietitianArea(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
            Assert.AreEqual(calendar.Id, result.CalendarId);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual($"{user.FirstName} {user.LastName}", result.FullName);
            Assert.AreEqual(user.ProfilePicture, result.ProfilePictureUrl);


            Assert.IsNotNull(result.Meals);
            Assert.AreEqual(1, result.Meals.Count);
            var calendarMealViewModel = result.Meals.First();
            Assert.AreEqual(meal.Id, calendarMealViewModel.Id);
            Assert.AreEqual(meal.Name, calendarMealViewModel.Name);


            Assert.IsNotNull(result.DietMeal);
            Assert.AreEqual(1, result.DietMeal.Count);
            var dietMealViewModel = result.DietMeal.First();
            Assert.AreEqual(meal.Id, dietMealViewModel.Id);
            Assert.AreEqual(meal.Name, dietMealViewModel.Name);


            Assert.IsNotNull(result.TrainingPlanWorkouts);
            Assert.AreEqual(1, result.TrainingPlanWorkouts.Count);
            var trainingPlanWorkoutViewModel = result.TrainingPlanWorkouts.First();
            Assert.AreEqual(workout.Id, trainingPlanWorkoutViewModel.Id);
            Assert.AreEqual(workout.Title, trainingPlanWorkoutViewModel.Name);
        }

        [Test]
        public async Task GetModelForUserCalendarInDietitianArea_NonExistentUser_ReturnsNull()
        {

            Assert.ThrowsAsync<InvalidOperationException>(async () => await calendarService.GetModelForUserCalendarInDietitianArea("non-existent-user-id"));

        }

        [Test]
        public async Task GetModelForUserCalendarInDietitianArea_UserWithNoCalendar_ReturnsEmptyCollections()
        {

            var userId = "test-user-id";


            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                ProfilePicture = "/profile/test.jpg"
            };


            var diet = new Diet
            {
                Id = 1,
                UserId = userId,
                IsActive = true
            };


            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                ImageUrl = "/workouts/test.jpg",
                CreatorId = 1,
                DayOfWeek = "Monday",
                DificultyLevel = "Intermediate",
                MuscleGroup = "Full Body"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test description",
                ImageUrl = "picture",
                VideoUrl = "https",
                DifficultyLevel = "Трудно",
                MuscleGroup = "Full Body",
                CreatedById = 1
            };


            var workoutExercise = new WorkoutsExercise
            {
                WorkoutId = workout.Id,
                ExcersiceId = exercise.Id,
                Workout = workout,
                Exercise = exercise
            };


            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                ImageUrl = "picture",
                UserId = userId,
                IsActive = true
            };


            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = workout.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };


            await repository.AddAsync(user);
            await repository.AddAsync(diet);
            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workoutExercise);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();


            var result = await calendarService.GetModelForUserCalendarInDietitianArea(userId);


            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
            Assert.AreEqual(0, result.CalendarId);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual($"{user.FirstName} {user.LastName}", result.FullName);
            Assert.AreEqual(user.ProfilePicture, result.ProfilePictureUrl);

            Assert.IsNotNull(result.Meals);
            Assert.IsEmpty(result.Meals);

            Assert.IsNotNull(result.DietMeal);
            Assert.IsEmpty(result.DietMeal);

            Assert.IsNotNull(result.TrainingPlanWorkouts);
            Assert.IsNotEmpty(result.TrainingPlanWorkouts);
        }
        [Test]
        public async Task AddCalendarMealEventAsync_ValidEvent_ReturnsEventId()
        {

            var userId = "test-user-id";
            var dietitianId = "dietitian-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = dietitianId,
                SertificateImage = "sertificate",
                User = user,
                Specialization = "Nutrition",
                Experience = 5
            };

            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user,
                TrainerId = trainer.Id,
                Trainer = trainer
            };

            var meal = new Meal
            {
                Id = 1,
                Name = "Test Meal",
                Calories = 500,
                ImageUrl = "/meals/test.jpg",
                MealTime = "Lunch"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(calendar);
            await repository.AddAsync(meal);
            await repository.SaveChangesAsync();

            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService
                .Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var calendarService = new CalendarService(
                repository,
                mockNotificationService.Object
            );

            var model = new AddEventFromDietitianViewModel
            {
                UserId = userId,
                CalendarId = calendar.Id,
                MealId = meal.Id,
                Year = 2024,
                Month = 1,
                Day = 15,
                StartTime = "10:00",
                EndTime = "11:00"
            };

            // Act
            var result = await calendarService.AddCalendarMealEventAsync(model, dietitianId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result);

            var addedCalendarMeal = await repository.AllAsReadOnly<CalendarMeal>()
                .FirstOrDefaultAsync(cm => cm.EventId == result);

            Assert.IsNotNull(addedCalendarMeal);
            Assert.AreEqual(calendar.Id, addedCalendarMeal.CalendarId);
            Assert.AreEqual(meal.Id, addedCalendarMeal.MealId);
            Assert.AreEqual(new DateOnly(2024, 1, 15), addedCalendarMeal.DateOnly);
            Assert.AreEqual(new TimeOnly(10, 0), addedCalendarMeal.StartEventTime);
            Assert.AreEqual(new TimeOnly(11, 0), addedCalendarMeal.EndEventTime);
        }

        [Test]
        public void AddCalendarMealEventAsync_InvalidTimeFormat_ThrowsException()
        {
            var model = new AddEventFromDietitianViewModel
            {
                UserId = "test-user-id",
                CalendarId = 1,
                MealId = 1,
                Year = 2024,
                Month = 1,
                Day = 15,
                StartTime = "invalid-time",
                EndTime = "invalid-time"
            };

            Assert.ThrowsAsync<Exception>(() =>
                calendarService.AddCalendarMealEventAsync(model, "dietitian-user-id"));
        }

        [Test]
        public async Task GetModelForDetailsEvent_ValidEvent_ReturnsDetailsViewModel()
        {
    
            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe"
            };

            var trainer = new Trainer
            {
                Id = 1,
                SertificateImage = "sertificate",
                UserId = "trainer-id",
                Specialization = "Fitness"
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                DayOfWeek = "Monday",
                DificultyLevel = "Intermediate",
                ImageUrl = "/workouts/test.jpg",
                MuscleGroup = "Full Body"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test description",
                ImageUrl = "picture",
                VideoUrl = "https",
                DifficultyLevel = "Трудно",
                MuscleGroup = "Full Body",
                CreatedById = trainer.Id,
                Repetitions = 10,
                Series = 3
            };

            var workoutExercise = new WorkoutsExercise
            {
                WorkoutId = workout.Id,
                ExcersiceId = exercise.Id,
                Workout = workout,
                Exercise = exercise
            };

            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user
            };

            var calendarWorkout = new CalendarWorkout
            {
                EventId = 1,
                WorkoutId = workout.Id,
                Workout = workout,
                CalendarId = calendar.Id,
                Calendar = calendar,
                DateOnly = new DateOnly(2024, 1, 15),
                StartEventTime = new TimeOnly(10, 0),
                EndEventTime = new TimeOnly(11, 0)
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workoutExercise);
            await repository.AddAsync(calendar);
            await repository.AddAsync(calendarWorkout);
            await repository.SaveChangesAsync();

           
            var result = await calendarService.GetModelForDetailsEvent(calendarWorkout.EventId);

      
            Assert.IsNotNull(result);
            Assert.AreEqual("2024-01-15", result.DateOnly);
            Assert.AreEqual("10:00 ", result.StartEventTime);
            Assert.AreEqual("11:00 ", result.EndEventTime);
            Assert.AreEqual(workout.Title, result.WorkoutTitle);
            Assert.AreEqual(1, result.ExerciseCount);
            Assert.AreEqual(workout.DayOfWeek, result.WorkoutDayOfWeek);
            Assert.AreEqual(workout.DificultyLevel, result.WorkoutDifficultyLevel);
            Assert.AreEqual(workout.ImageUrl, result.WorkoutImage);
            Assert.AreEqual(workout.MuscleGroup, result.WorkoutMuscleGroup);
        }

        [Test]
        public async Task GetModelForDetailsEvent_NonExistentEvent_ReturnsNull()
        {
            var result = await calendarService.GetModelForDetailsEvent(999);
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteEvenetAndSendNotification_ValidEvent_DeletesEventAndSendsNotification()
        {

            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe"
            };

            var trainer = new Trainer
            {
                Id = 1,
                SertificateImage = "sertificate",
                UserId = "trainer-id"
            };

            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user,
                TrainerId = trainer.Id,
                Trainer = trainer
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                ImageUrl ="picture",
                MuscleGroup = "гърди",
                DificultyLevel = "трудно",
                CreatorId = trainer.Id
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                ImageUrl = "picture",
                UserId = userId,
                IsActive = true,
                Trainer = trainer
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = workout.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };

            var calendarWorkout = new CalendarWorkout
            {
                EventId = 1,
                WorkoutId = workout.Id,
                Workout = workout,
                CalendarId = calendar.Id,
                Calendar = calendar,
                DateOnly = new DateOnly(2024, 1, 15),
                StartEventTime = new TimeOnly(10, 0),
                EndEventTime = new TimeOnly(11, 0)
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.AddAsync(calendar);
            await repository.AddAsync(calendarWorkout);
            await repository.SaveChangesAsync();

            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService
                .Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var calendarService = new CalendarService(
                repository,
                mockNotificationService.Object
            );

            var timeOnly = new TimeOnly(11, 0);

            // Act
            await calendarService.DeleteEvenetAndSendNotification(calendarWorkout.EventId, timeOnly, userId);

            // Assert
            var deletedEvent = await repository.AllAsReadOnly<CalendarWorkout>()
                .FirstOrDefaultAsync(x => x.EventId == calendarWorkout.EventId);

            Assert.IsNull(deletedEvent);

            mockNotificationService.Verify(
                x => x.AddNotification(
                    userId,
                    trainer.UserId,
                    It.IsAny<string>(),
                    "Calendar"
                ),
                Times.Once
            );
        }

        [Test]
        public async Task DeleteEvenetAndSendNotification_NonExistentEvent_ThrowsException()
        {
            var userId = "test-user-id";
            var timeOnly = new TimeOnly(11, 0);

            Assert.ThrowsAsync<InvalidOperationException>(() =>
                calendarService.DeleteEvenetAndSendNotification(999, timeOnly, userId));
        }

        [Test]
        public async Task GetModelForUserCalendarForUserArea_ValidUser_ReturnsViewModel()
        {

            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                ProfilePicture = "/profile/test.jpg"
            };

            var trainer = new Trainer
            {
                Id = 1,
                SertificateImage = "sertificate",
                UserId = "trainer-id"
            };

            var calendar = new Calendar
            {
                Id = 1,
                UserId = userId,
                User = user,
                TrainerId = trainer.Id
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                ImageUrl = "/workouts/test.jpg",
                MuscleGroup = "гърди",
                CreatorId = trainer.Id,
                DayOfWeek = "Monday",
                DificultyLevel = "Intermediate"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test description",
                ImageUrl = "picture",
                VideoUrl = "https",
                DifficultyLevel = "Трудно",
                MuscleGroup = "Full Body",
                CreatedById = trainer.Id
            };

            var workoutExercise = new WorkoutsExercise
            {
                WorkoutId = workout.Id,
                ExcersiceId = exercise.Id,
                Workout = workout,
                Exercise = exercise
            };

            var calendarWorkout = new CalendarWorkout
            {
                EventId = 1,
                WorkoutId = workout.Id,
                Workout = workout,
                CalendarId = calendar.Id,
                Calendar = calendar,
                DateOnly = new DateOnly(2024, 1, 15),
                StartEventTime = new TimeOnly(10, 0),
                EndEventTime = new TimeOnly(11, 0)
            };

            var meal = new Meal
            {
                Id = 1,
                Name = "Test Meal",
                ImageUrl = "/meals/test.jpg",
                Calories = 500,
                MealTime = "Lunch"
            };

            var calendarMeal = new CalendarMeal
            {
                EventId = 2,
                MealId = meal.Id,
                Meal = meal,
                CalendarId = calendar.Id,
                Calendar = calendar,
                DateOnly = new DateOnly(2024, 1, 15),
                StartEventTime = new TimeOnly(12, 0),
                EndEventTime = new TimeOnly(13, 0)
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(calendar);
            await repository.AddAsync(workout);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workoutExercise);
            await repository.AddAsync(calendarWorkout);
            await repository.AddAsync(meal);
            await repository.AddAsync(calendarMeal);
            await repository.SaveChangesAsync();

            // Act
            var result = await calendarService.GetModelForUserCalendarForUserArea(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(calendar.Id, result.CalendarId);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual($"{user.FirstName} {user.LastName}", result.FullName);
            Assert.AreEqual(user.ProfilePicture, result.ProfilePictureUrl);

            Assert.IsNotNull(result.Workouts);
            Assert.AreEqual(1, result.Workouts.Count);
            var workoutViewModel = result.Workouts.First();
            Assert.AreEqual(workout.Id, workoutViewModel.Id);
            Assert.AreEqual(workout.Title, workoutViewModel.Name);

            Assert.IsNotNull(result.Meals);
            Assert.AreEqual(1, result.Meals.Count);
            var mealViewModel = result.Meals.First();
            Assert.AreEqual(meal.Id, mealViewModel.Id);
            Assert.AreEqual(meal.Name, mealViewModel.Name);
        }

        [Test]
        public async Task GetModelForUserCalendarForUserArea_NonExistentUser_ReturnsNull()
        {
            var result = await calendarService.GetModelForUserCalendarForUserArea("non-existent-user-id");
            Assert.IsNull(result);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();

        }
    }
}
