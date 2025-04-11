using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestAiFiness.ServicesTests
{
    [TestFixture]
    public class ExerciseServiceTest
    {
        private IRepository repository;
        private IExerciseService exersiceService;
        private ApplicationDbContext applicationDbContext;
        private Mock<IHostingEnvironment> hostingEnvironmentMock;
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HouseDB_" + Guid.NewGuid())
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions, false);
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
             hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns("fake/webroot/path");

            repository = new Repository(applicationDbContext);
            exersiceService = new ExerciseService(hostingEnvironmentMock.Object,repository);

        }
        [Test]
        public async Task AddExercise_ShouldAddExerciseWithoutImage()
        {
            var userId = "test-user-id";
            var trainer = new Trainer
            {
                Id = 1,
                UserId = userId,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

          
            var emptyContent = new MemoryStream(new byte[0]);
            var emptyFormFile = new FormFile(
                baseStream: emptyContent,
                baseStreamOffset: 0,
                length: 0,
                name: "ImageUrl",
                fileName: ""
            );

            var model = new CreateExerciseViewModel
            {
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Name = "Test Exercise",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = emptyFormFile
            };

            await exersiceService.AddExercise(model, userId);

            var exercise = await applicationDbContext.Exercises.FirstOrDefaultAsync(e => e.Name == "Test Exercise");
            Assert.IsNotNull(exercise);
            Assert.AreEqual("Test Description", exercise.Description);
            Assert.AreEqual("Intermediate", exercise.DifficultyLevel);
            Assert.AreEqual("Arms", exercise.MuscleGroup);
            Assert.AreEqual(10, exercise.Repetitions);
            Assert.AreEqual(3, exercise.Series);
            Assert.AreEqual("test-video.mp4", exercise.VideoUrl);
            Assert.AreEqual(trainer.Id, exercise.CreatedById);
        }
        [Test]
        public async Task AddExercise_ShouldAddExerciseWithImage()
        {
  
            var userId = "test-user-id";
            var trainer = new Trainer
            {
                Id = 1,
                UserId = userId,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

           
            var fileMock = new Mock<IFormFile>();
            var content = "Fake file content";
            var fileName = "test.jpg";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;

            fileMock.Setup(_ => _.CopyToAsync(It.IsAny<Stream>(), default(CancellationToken)))
                    .Callback<Stream, CancellationToken>((stream, token) => ms.CopyTo(stream));
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

 
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns("fake/webroot/path");

            exersiceService = new ExerciseService(hostingEnvironmentMock.Object, repository);

            var model = new CreateExerciseViewModel
            {
                Description = "Test Description with Image",
                DifficultyLevel = "Advanced",
                MuscleGroup = "Legs",
                Name = "Test Exercise with Image",
                Repetitions = 12,
                Series = 4,
                VideoUrl = "test-video-with-image.mp4",
                ImageUrl = fileMock.Object
            };


            await exersiceService.AddExercise(model, userId);


            var exercise = await applicationDbContext.Exercises.FirstOrDefaultAsync(e => e.Name == "Test Exercise with Image");
            Assert.IsNotNull(exercise);
            Assert.AreEqual("Test Description with Image", exercise.Description);
            Assert.AreEqual("Advanced", exercise.DifficultyLevel);
            Assert.AreEqual("Legs", exercise.MuscleGroup);
            Assert.AreEqual(12, exercise.Repetitions);
            Assert.AreEqual(4, exercise.Series);
            Assert.AreEqual("test-video-with-image.mp4", exercise.VideoUrl);
            Assert.IsNotNull(exercise.ImageUrl);
            Assert.IsTrue(exercise.ImageUrl.StartsWith("/img/exercises/"));
            Assert.AreEqual(trainer.Id, exercise.CreatedById);
        }

        [Test]
        public async Task AddExercise_ShouldThrowExceptionForInvalidUser()
        {
            
            var invalidUserId = "invalid-user-id";
            var model = new CreateExerciseViewModel
            {
                Description = "Test Description",
                DifficultyLevel = "Beginner",
                MuscleGroup = "Chest",
                Name = "Test Exercise Invalid User",
                Repetitions = 8,
                Series = 2,
                VideoUrl = "test-video-invalid.mp4",
                ImageUrl = null
            };

           
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await exersiceService.AddExercise(model, invalidUserId));
        }
        [Test]
        public async Task EditAsync_ShouldEditExerciseWithoutNewImage()
        {
        
            var exercise = new Exercise
            {
                Id = 1,
                Name = "Original Exercise",
                Description = "Original Description",
                DifficultyLevel = "Beginner",
                MuscleGroup = "Legs",
                Repetitions = 8,
                Series = 2,
                VideoUrl = "original-video.mp4",
                ImageUrl = "/img/exercises/original.jpg",
                CreatedById = 1
            };

            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            var model = new EditExerciseViewModel
            {
                Name = "Updated Exercise",
                Description = "Updated Description",
                DifficultyLevel = "Advanced",
                MuscleGroup = "Core",
                Repetitions = 12,
                Series = 4,
                VideoUrl = "updated-video.mp4",
                NewImage = null 
            };

           
            await exersiceService.EditAsync(1, model);

            
            var updatedExercise = await repository.All<Exercise>()
                .FirstOrDefaultAsync(e => e.Id == 1);

            Assert.IsNotNull(updatedExercise);
            Assert.AreEqual("Updated Exercise", updatedExercise.Name);
            Assert.AreEqual("Updated Description", updatedExercise.Description);
            Assert.AreEqual("Advanced", updatedExercise.DifficultyLevel);
            Assert.AreEqual("Core", updatedExercise.MuscleGroup);
            Assert.AreEqual(12, updatedExercise.Repetitions);
            Assert.AreEqual(4, updatedExercise.Series);
            Assert.AreEqual("updated-video.mp4", updatedExercise.VideoUrl);
            Assert.AreEqual("/img/exercises/original.jpg", updatedExercise.ImageUrl); 
        }

        [Test]
        public async Task EditAsync_ShouldEditExerciseWithNewImage()
        {
           
            var exercise = new Exercise
            {
                Id = 1,
                Name = "Original Exercise",
                Description = "Original Description",
                DifficultyLevel = "Beginner",
                MuscleGroup = "Legs",
                Repetitions = 8,
                Series = 2,
                VideoUrl = "original-video.mp4",
                ImageUrl = "/img/exercises/original.jpg",
                CreatedById = 1
            };

            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

         
            var content = "test image content";
            var fileName = "test.jpg";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            var formFile = new FormFile(
                baseStream: stream,
                baseStreamOffset: 0,
                length: stream.Length,
                name: "NewImage",
                fileName: fileName
            );

            var model = new EditExerciseViewModel
            {
                Name = "Updated Exercise",
                Description = "Updated Description",
                DifficultyLevel = "Advanced",
                MuscleGroup = "Core",
                Repetitions = 12,
                Series = 4,
                VideoUrl = "updated-video.mp4",
                NewImage = formFile
            };

          
            var webRootPath = hostingEnvironmentMock.Object.WebRootPath;
            var uploadsFolder = Path.Combine(webRootPath, "img/exercises");
            Directory.CreateDirectory(uploadsFolder);

           
            await exersiceService.EditAsync(1, model);

         
            var updatedExercise = await repository.All<Exercise>()
                .FirstOrDefaultAsync(e => e.Id == 1);

            Assert.IsNotNull(updatedExercise);
            Assert.AreEqual("Updated Exercise", updatedExercise.Name);
            Assert.AreEqual("Updated Description", updatedExercise.Description);
            Assert.AreEqual("Advanced", updatedExercise.DifficultyLevel);
            Assert.AreEqual("Core", updatedExercise.MuscleGroup);
            Assert.AreEqual(12, updatedExercise.Repetitions);
            Assert.AreEqual(4, updatedExercise.Series);
            Assert.AreEqual("updated-video.mp4", updatedExercise.VideoUrl);

        
            Assert.IsTrue(updatedExercise.ImageUrl.StartsWith("/img/exercises/"));
            Assert.IsTrue(updatedExercise.ImageUrl.EndsWith(".jpg"));
            Assert.AreNotEqual("/img/exercises/original.jpg", updatedExercise.ImageUrl);

            
            var newImagePath = Path.Combine(webRootPath, updatedExercise.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            Assert.IsTrue(File.Exists(newImagePath));
        }

        [Test]
        public async Task EditAsync_ShouldDoNothingWhenExerciseNotFound()
        {
          
            var model = new EditExerciseViewModel
            {
                Name = "Updated Exercise",
                Description = "Updated Description",
                DifficultyLevel = "Advanced",
                MuscleGroup = "Core",
                Repetitions = 12,
                Series = 4,
                VideoUrl = "updated-video.mp4",
                NewImage = null
            };


            await exersiceService.EditAsync(999, model);

  
            var exercises = await repository.All<Exercise>().ToListAsync();
            Assert.AreEqual(0, exercises.Count);
        }
        [Test]
        public async Task GetModelForDetailsFromWorkouts_ValidExerciseAndWorkout_ReturnsCorrectViewModel()
        {

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = 1
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                ImageUrl = "picture",
                CreatorId = 1,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms"
            };

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = exercise.Id,
                WorkoutId = workout.Id,
                Exercise = exercise,
                Workout = workout
            };


            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(workoutsExercise);
            await repository.SaveChangesAsync();

            var result = await exersiceService.GetModelForDetailsFromWorkouts(exercise.Id, workout.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(exercise.Id, result.Id);
            Assert.AreEqual(workout.Id, result.WorkoutId);
            Assert.AreEqual(exercise.Name, result.Name);
            Assert.AreEqual(exercise.Description, result.Description);
            Assert.AreEqual(exercise.DifficultyLevel, result.DifficultyLevel);
            Assert.AreEqual(exercise.MuscleGroup, result.MuscleGroup);
            Assert.AreEqual(exercise.Repetitions, result.Repetitions);
            Assert.AreEqual(exercise.Series, result.Series);
            Assert.AreEqual(exercise.VideoUrl, result.VideoUrl);
            Assert.AreEqual(exercise.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetModelForDetailsFromWorkouts_NonExistentWorkoutExercise_ReturnsNull()
        {
      
            int nonExistentExerciseId = 999;
            int nonExistentWorkoutId = 999;

       
            var result = await exersiceService.GetModelForDetailsFromWorkouts(nonExistentExerciseId, nonExistentWorkoutId);

        
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetModelForDetailsFromWorkouts_ExerciseExistsButNotInWorkout_ReturnsNull()

        {

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = 1
            };


            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                ImageUrl = "picture",
                CreatorId = 1,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms"
            };


            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();


            var result = await exersiceService.GetModelForDetailsFromWorkouts(exercise.Id, workout.Id);


            Assert.IsNull(result);
        }
        [Test]
        public async Task GetModelForDetails_ValidExerciseAndTrainer_ReturnsCorrectViewModel()
        {
        
            var userId = "test-user-id";

         
            var trainer = new Trainer
            {
                Id = 1,
                UserId = userId,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

          
            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = trainer.Id
            };

            
            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                ImageUrl = "picture",
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms"
            };

         
            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                ImageUrl = "picture",
                UserId = userId,
            };

  
            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = exercise.Id,
                WorkoutId = workout.Id,
                Exercise = exercise,
                Workout = workout
            };

        
            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                WorkoutId = workout.Id,
                TrainingPlanId = trainingPlan.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };

         
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workoutsExercise);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

            int trainingPlanId = trainingPlan.Id;

        
            var result = await exersiceService.GetModelForDetails(exercise.Id, userId, trainingPlanId);

        
            Assert.IsNotNull(result);
            Assert.AreEqual(exercise.Id, result.Id);
            Assert.AreEqual(trainingPlanId, result.TrainingPlanId);
            Assert.AreEqual(exercise.Name, result.Name);
            Assert.AreEqual(exercise.Description, result.Description);
            Assert.AreEqual(exercise.DifficultyLevel, result.DifficultyLevel);
            Assert.AreEqual(exercise.MuscleGroup, result.MuscleGroup);
            Assert.AreEqual(exercise.Repetitions, result.Repetitions);
            Assert.AreEqual(exercise.Series, result.Series);
            Assert.AreEqual(exercise.VideoUrl, result.VideoUrl);
            Assert.AreEqual(exercise.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetModelForDetails_NonExistentWorkoutExercise_ReturnsNull()
        {
          
            var userId = "test-user-id";

         
            var trainer = new Trainer
            {
                Id = 1,
                UserId = userId,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

       
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            int nonExistentExerciseId = 999;
            int trainingPlanId = 1;

         
            var result = await exersiceService.GetModelForDetails(nonExistentExerciseId, userId, trainingPlanId);

           
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetModelForDetails_NonExistentTrainer_ThrowsException()
        {
            
            string nonExistentUserId = "non-existent-user-id";
            int exerciseId = 1;
            int trainingPlanId = 1;

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await exersiceService.GetModelForDetails(exerciseId, nonExistentUserId, trainingPlanId));
        }
        [Test]
        public async Task GetModelForDetailsForUser_ValidExerciseAndTrainingPlan_ReturnsCorrectViewModel()
        {
            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                UserName = "testuser"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = 1
            };

            var workout = new Workout
            {
                Id = 1,
                ImageUrl = "picture",
                Title = "Test Workout",
                CreatorId = 1,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                ImageUrl = "picture",
                Name = "Test Training Plan",
                UserId = userId,
                IsActive = false,
                User = user
            };

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = exercise.Id,
                WorkoutId = workout.Id,
                Exercise = exercise,
                Workout = workout
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                WorkoutId = workout.Id,
                TrainingPlanId = trainingPlan.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };

            await repository.AddAsync(user);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workoutsExercise);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

            var result = await exersiceService.GetModelForDetailsForUser(exercise.Id, userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(exercise.Id, result.Id);
            Assert.AreEqual(trainingPlan.Id, result.TrainingPlanId);
            Assert.AreEqual(exercise.Name, result.Name);
            Assert.AreEqual(exercise.Description, result.Description);
            Assert.AreEqual(exercise.DifficultyLevel, result.DifficultyLevel);
            Assert.AreEqual(exercise.MuscleGroup, result.MuscleGroup);
            Assert.AreEqual(exercise.Repetitions, result.Repetitions);
            Assert.AreEqual(exercise.Series, result.Series);
            Assert.AreEqual(exercise.VideoUrl, result.VideoUrl);
            Assert.AreEqual(exercise.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetModelForDetailsForUser_NonExistentWorkoutExercise_ReturnsNull()
        {
            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                UserName = "testuser"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                ImageUrl = "picture",
                UserId = userId,
                IsActive = false,
                User = user
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var result = await exersiceService.GetModelForDetailsForUser(999, userId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetModelForDetailsForUser_NoMatchingTrainingPlan_ThrowsException()
        {
            var userId = "test-user-id";

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = 1
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = 1,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                ImageUrl = "picture",
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms"
            };

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = exercise.Id,
                WorkoutId = workout.Id,
                Exercise = exercise,
                Workout = workout
            };

            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(workoutsExercise);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await exersiceService.GetModelForDetailsForUser(exercise.Id, "non-existent-user-id"));
        }
        [Test]
        public async Task SwapExerciseInWorkoutAsync_ValidSwap_ReturnsTrue()
        {
           
            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                UserName = "testuser"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = userId,
                Specialization = "Test",
                Experience = 5,
                SertificateImage = "cert.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "1234567890"
            };

            var originalExercise = new Exercise
            {
                Id = 1,
                Name = "Original Exercise",
                Description = "Original Description",
                DifficultyLevel = "Beginner",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "original-video.mp4",
                ImageUrl = "/img/exercises/original.jpg",
                CreatedById = trainer.Id
            };

            var newExercise = new Exercise
            {
                Id = 2,
                Name = "New Exercise",
                Description = "New Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Legs",
                Repetitions = 12,
                Series = 4,
                VideoUrl = "new-video.mp4",
                ImageUrl = "/img/exercises/new.jpg",
                CreatedById = trainer.Id
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                ImageUrl = "/img/workouts/test.jpg"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                UserId = userId,
                IsActive = false,
                User = user,
                ImageUrl = "/img/trainingplans/test.jpg"
            };

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = originalExercise.Id,
                WorkoutId = workout.Id,
                Exercise = originalExercise,
                Workout = workout
            };

            var trainingPlanWorkout = new TrainingPlanWorkout
            {
                WorkoutId = workout.Id,
                TrainingPlanId = trainingPlan.Id,
                Workout = workout,
                TrainingPlan = trainingPlan
            };

            var exerciseFeedback = new ExerciseFeedback
            {
                Id = 1,
                Feedback = "Много сложно!",
                ExerciseId = originalExercise.Id,
                TrainingPlanId = trainingPlan.Id
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(originalExercise);
            await repository.AddAsync(newExercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workoutsExercise);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.AddAsync(exerciseFeedback);
            await repository.SaveChangesAsync();

            var request = new SwapExerciseRequest
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = workout.Id,
                ExerciseId = originalExercise.Id,
                NewExerciseId = newExercise.Id
            };


            var result = await exersiceService.SwapExerciseInWorkoutAsync(request);

            Assert.IsTrue(result);

       
            var updatedWorkout = await repository.All<Workout>()
                .Include(w => w.WorkoutsExercises)
                .FirstOrDefaultAsync(w => w.Id == workout.Id);

            Assert.IsNotNull(updatedWorkout);
            var updatedWorkoutExercise = updatedWorkout.WorkoutsExercises.FirstOrDefault();
            Assert.IsNotNull(updatedWorkoutExercise);
            Assert.AreEqual(newExercise.Id, updatedWorkoutExercise.ExcersiceId);

         
            var remainingFeedback = await repository.All<ExerciseFeedback>()
                .Where(ef => ef.ExerciseId == originalExercise.Id &&
                             ef.TrainingPlanId == trainingPlan.Id)
                .ToListAsync();

            Assert.AreEqual(0, remainingFeedback.Count);
        }

        [Test]
        public async Task SwapExerciseInWorkoutAsync_InvalidTrainingPlan_ReturnsFalse()
        {
            
            var request = new SwapExerciseRequest
            {
                TrainingPlanId = 999,
                WorkoutId = 1,
                ExerciseId = 1,
                NewExerciseId = 2
            };

            
            var result = await exersiceService.SwapExerciseInWorkoutAsync(request);

           
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SwapExerciseInWorkoutAsync_InvalidWorkoutOrExercise_ReturnsFalse()
        {
           
            var userId = "test-user-id";

            var user = new ApplicationUser
            {
                Id = userId,
                UserName = "testuser"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 1,
                Name = "Test Training Plan",
                UserId = userId,
                IsActive = false,
                User = user,
                ImageUrl = "/img/trainingplans/test.jpg"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var request = new SwapExerciseRequest
            {
                TrainingPlanId = trainingPlan.Id,
                WorkoutId = 999,
                ExerciseId = 999,
                NewExerciseId = 999
            };

            
            var result = await exersiceService.SwapExerciseInWorkoutAsync(request);

           
            Assert.IsFalse(result);
        }
        [Test]
        public async Task GetModelFromWorkoutForEdit_ValidExerciseAndWorkout_ReturnsCorrectViewModel()
        {
            var trainer = new Trainer
            {
                Id = 1,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = trainer.Id
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                ImageUrl = "/img/workouts/test.jpg"
            };

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = exercise.Id,
                WorkoutId = workout.Id,
                Exercise = exercise,
                Workout = workout
            };

            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(workoutsExercise);
            await repository.SaveChangesAsync();

            var result = await exersiceService.GetModelFromWorkoutForEdit(exercise.Id, workout.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(exercise.Id, result.Id);
            Assert.AreEqual(workout.Id, result.WorkoutId);
            Assert.AreEqual(exercise.Name, result.Name);
            Assert.AreEqual(exercise.Description, result.Description);
            Assert.AreEqual(exercise.DifficultyLevel, result.DifficultyLevel);
            Assert.AreEqual(exercise.MuscleGroup, result.MuscleGroup);
            Assert.AreEqual(exercise.Repetitions, result.Repetitions);
            Assert.AreEqual(exercise.Series, result.Series);
            Assert.AreEqual(exercise.VideoUrl, result.VideoUrl);
            Assert.AreEqual(exercise.ImageUrl, result.ExistingImageUrl);
        }

        [Test]
        public async Task GetModelFromWorkoutForEdit_NonExistentWorkoutExercise_ThrowsException()
        {
             Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await exersiceService.GetModelFromWorkoutForEdit(999, 999));
        }

        [Test]
        public async Task GetModelFromWorkoutForEdit_ExerciseNotInWorkout_ThrowsException()
        {
            var trainer = new Trainer
            {
                Id = 1,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = trainer.Id
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                ImageUrl = "/img/workouts/test.jpg"
            };

            var otherWorkout = new Workout
            {
                Id = 2,
                Title = "Other Workout",
                CreatorId = trainer.Id,
                DayOfWeek = "Tuesday",
                OrderInWorkout = 2,
                DificultyLevel = "Advanced",
                MuscleGroup = "Legs",
                ImageUrl = "/img/workouts/other.jpg"
            };

            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(otherWorkout);
            await repository.SaveChangesAsync();

             Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await exersiceService.GetModelFromWorkoutForEdit(exercise.Id, otherWorkout.Id));
        }
        [Test]
        public async Task GetModelForEdit_ValidExerciseAndTrainingPlan_ReturnsCorrectViewModel()
        {
            var trainer = new Trainer
            {
                Id = 1,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = trainer.Id
            };

            var workout = new Workout
            {
                Id = 1,
                Title = "Test Workout",
                CreatorId = trainer.Id,
                DayOfWeek = "Monday",
                OrderInWorkout = 1,
                DificultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                ImageUrl = "/img/workouts/test.jpg"
            };

            var workoutsExercise = new WorkoutsExercise
            {
                ExcersiceId = exercise.Id,
                WorkoutId = workout.Id,
                Exercise = exercise,
                Workout = workout
            };

            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(workoutsExercise);
            await repository.SaveChangesAsync();

            var result = await exersiceService.GetModelForEdit(exercise.Id, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(exercise.Id, result.Id);
            Assert.AreEqual(exercise.Name, result.Name);
            Assert.AreEqual(exercise.Description, result.Description);
        }

        [Test]
        public async Task GetModelForEdit_NonExistentWorkoutExercise_ReturnsNull()
        {
            var result = await exersiceService.GetModelForEdit(999, 1);
            Assert.IsNull(result);
        }

        [Test]
        public async Task EditAsyncFromWorkout_ValidExercise_UpdatesExercise()
        {
            var exercise = new Exercise
            {
                Id = 1,
                Name = "Original Exercise",
                Description = "Original Description",
                DifficultyLevel = "Beginner",
                MuscleGroup = "Legs",
                Repetitions = 8,
                Series = 2,
                VideoUrl = "original-video.mp4",
                ImageUrl = "/img/exercises/original.jpg"
            };

            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            var mockFormFile = new Mock<IFormFile>();
            mockFormFile.Setup(f => f.FileName).Returns("test.jpg");
            mockFormFile.Setup(f => f.Length).Returns(1024);
            mockFormFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default))
                .Callback<Stream, System.Threading.CancellationToken>((stream, token) =>
                {
                    byte[] testData = new byte[1024];
                    stream.Write(testData, 0, testData.Length);
                });

            var model = new EditExerciseFromWorkoutViewModel
            {
                Id = exercise.Id,
                Name = "Updated Exercise",
                Description = "Updated Description",
                DifficultyLevel = "Advanced",
                MuscleGroup = "Arms",
                Repetitions = 12,
                Series = 4,
                VideoUrl = "updated-video.mp4",
                NewImage = mockFormFile.Object
            };

            await exersiceService.EditAsyncFromWorkout(exercise.Id, model);

            var updatedExercise = await repository.All<Exercise>()
                .FirstOrDefaultAsync(e => e.Id == exercise.Id);

            Assert.IsNotNull(updatedExercise);
            Assert.AreEqual("Updated Exercise", updatedExercise.Name);
            Assert.AreEqual("Updated Description", updatedExercise.Description);
            Assert.AreEqual("Advanced", updatedExercise.DifficultyLevel);
            Assert.AreEqual("Arms", updatedExercise.MuscleGroup);
            Assert.AreEqual(12, updatedExercise.Repetitions);
            Assert.AreEqual(4, updatedExercise.Series);
            Assert.AreEqual("updated-video.mp4", updatedExercise.VideoUrl);
            Assert.IsTrue(updatedExercise.ImageUrl.StartsWith("/img/exercises/"));
        }

        [Test]
        public async Task EditAsyncFromWorkout_NonExistentExercise_DoesNotThrowException()
        {
            var mockFormFile = new Mock<IFormFile>();
            mockFormFile.Setup(f => f.FileName).Returns("test.jpg");

            var model = new EditExerciseFromWorkoutViewModel
            {
                Id = 999,
                Name = "Test Exercise",
                Description = "Test Description",
                NewImage = mockFormFile.Object
            };

            await exersiceService.EditAsyncFromWorkout(999, model);
        }

        [Test]
        public async Task AddFromEditWorkoutExercise_ValidExercise_CreatesExercise()
        {
            var userId = "test-user-id";
            var trainer = new Trainer
            {
                Id = 1,
                UserId = userId,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var mockFormFile = new Mock<IFormFile>();
            mockFormFile.Setup(f => f.FileName).Returns("test.jpg");
            mockFormFile.Setup(f => f.Length).Returns(1024);
            mockFormFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default))
                .Callback<Stream, System.Threading.CancellationToken>((stream, token) =>
                {
                    byte[] testData = new byte[1024];
                    stream.Write(testData, 0, testData.Length);
                });

            var model = new CreateNewExerciseForTrainerViewModel
            {
                Name = "New Exercise",
                Description = "New Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "new-video.mp4",
                ImageUrl = mockFormFile.Object
            };

            await exersiceService.AddFromEditWorkoutExercise(model, userId);

            var addedExercise = await repository.All<Exercise>()
                .FirstOrDefaultAsync(e => e.Name == "New Exercise");

            Assert.IsNotNull(addedExercise);
            Assert.AreEqual("New Exercise", addedExercise.Name);
            Assert.AreEqual("New Description", addedExercise.Description);
            Assert.AreEqual("Intermediate", addedExercise.DifficultyLevel);
            Assert.AreEqual("Arms", addedExercise.MuscleGroup);
            Assert.AreEqual(10, addedExercise.Repetitions);
            Assert.AreEqual(3, addedExercise.Series);
            Assert.AreEqual("new-video.mp4", addedExercise.VideoUrl);
            Assert.IsTrue(addedExercise.ImageUrl.StartsWith("/img/exercises/"));
        }

        [Test]
        public void AddFromEditWorkoutExercise_NonExistentTrainer_ThrowsInvalidOperationException()
        {
            var model = new CreateNewExerciseForTrainerViewModel
            {
                Name = "New Exercise",
                Description = "New Description"
            };

            Assert.Throws<InvalidOperationException>(() =>
                exersiceService.AddFromEditWorkoutExercise(model, "non-existent-user-id").GetAwaiter().GetResult());
        }
        [Test]
        public async Task ExistAsync_ExistingExercise_ReturnsTrue()
        {
            var trainer = new Trainer
            {
                Id = 1,
                Specialization = "Test Specialization",
                Experience = 5,
                SertificateImage = "test.jpg",
                SertificationDetails = "Details",
                Bio = "Bio",
                PhoneNumber = "123456789"
            };

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Test Exercise",
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = "/img/exercises/test.jpg",
                CreatedById = trainer.Id
            };

            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

            var result = await exersiceService.ExistAsync(exercise.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistAsync_NonExistentExercise_ReturnsFalse()
        {
            var result = await exersiceService.ExistAsync(999);

            Assert.IsFalse(result);
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();

        }
    }
}
