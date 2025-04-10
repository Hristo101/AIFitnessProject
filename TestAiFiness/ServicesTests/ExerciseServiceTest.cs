using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class ExerciseServiceTest
    {
        private IRepository repository;
        private IExerciseService exersiceService;
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
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns("fake/webroot/path");

            repository = new Repository(applicationDbContext);
            exersiceService = new ExerciseService(hostingEnvironmentMock.Object,repository);

        }
        [Test]
        public async Task AddExercise_ShouldAddExerciseWithoutImage()
        {
            // Arrange
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

            var model = new CreateExerciseViewModel
            {
                Description = "Test Description",
                DifficultyLevel = "Intermediate",
                MuscleGroup = "Arms",
                Name = "Test Exercise",
                Repetitions = 10,
                Series = 3,
                VideoUrl = "test-video.mp4",
                ImageUrl = null // Без изображение
            };

            // Act
            await exersiceService.AddExercise(model, userId);

            // Assert
            var exercise = await applicationDbContext.Exercises.FirstOrDefaultAsync(e => e.Name == "Test Exercise");
            Assert.IsNotNull(exercise);
            Assert.AreEqual("Test Description", exercise.Description);
            Assert.AreEqual("Intermediate", exercise.DifficultyLevel);
            Assert.AreEqual("Arms", exercise.MuscleGroup);
            Assert.AreEqual(10, exercise.Repetitions);
            Assert.AreEqual(3, exercise.Series);
            Assert.AreEqual("test-video.mp4", exercise.VideoUrl);
            Assert.AreEqual("", exercise.ImageUrl); // Очакваме празен стринг вместо null
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

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();

        }
    }
}
