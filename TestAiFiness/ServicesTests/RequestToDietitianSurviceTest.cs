using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestToDietitian;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAiFitness.ServicesTests
{
    [TestFixture]
    public class RequestToDietitianSurviceTest
    {
        private IRepository repository;
        private IRequestToDietitianSurvice requestToDietitianService;
        private Mock<INotificationService> mockNotificationService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FitnessDB_" + Guid.NewGuid())
                .Options;
            applicationDbContext = new ApplicationDbContext(contextOptions, false);
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
            repository = new Repository(applicationDbContext);
            var configurationMock = new Mock<IConfiguration>();
            mockNotificationService = new Mock<INotificationService>();
            requestToDietitianService = new RequestToDietitianSurvice(repository, mockNotificationService.Object, configurationMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }

        [Test]
        public async Task GetViewModelForDetailsAsync_WithNonExistingId_ShouldThrowInvalidOperationException()
        {

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await requestToDietitianService.GetViewModelForDetailsAsync(999));
        }

        [Test]
        public async Task Add_ShouldCreateRequestAndUpdateUser()
        {

            var userId = "user1";
            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "Old First Name",
                LastName = "Old Last Name",
                Height = 170,
                Weight = 70,
                ExperienceLevel = "Beginner",
                Aim = "Weight Loss"
            };
            await repository.AddAsync(user);

            var dietitianUserId = "dietitianUser";
            var dietitianUser = new ApplicationUser
            {
                Id = dietitianUserId,
                FirstName = "Dietitian",
                LastName = "User"
            };
            await repository.AddAsync(dietitianUser);

            var dietitian = new Dietitian
            {
                Id = 1,
                UserId = dietitianUserId,
                Specialization = "Weight Loss",
                Experience = 5,
                SertificateImage = "cert.jpg",
                SertificationDetails = "Certification Details",
                Bio = "Professional dietitian",
                PhoneNumber = "+1234567890"
            };
            await repository.AddAsync(dietitian);
            await repository.SaveChangesAsync();

            var mockFile1 = new Mock<IFormFile>();
            var content1 = "Fake file content 1";
            var ms1 = new MemoryStream();
            var writer1 = new StreamWriter(ms1);
            writer1.Write(content1);
            writer1.Flush();
            ms1.Position = 0;
            mockFile1.Setup(_ => _.OpenReadStream()).Returns(ms1);
            mockFile1.Setup(_ => _.Length).Returns(ms1.Length);

            var mockFile2 = new Mock<IFormFile>();
            var content2 = "Fake file content 2";
            var ms2 = new MemoryStream();
            var writer2 = new StreamWriter(ms2);
            writer2.Write(content2);
            writer2.Flush();
            ms2.Position = 0;
            mockFile2.Setup(_ => _.OpenReadStream()).Returns(ms2);
            mockFile2.Setup(_ => _.Length).Returns(ms2.Length);

            var model = new SurveyViewModel
            {
                FirstName = "New First Name",
                LastName = "New Last Name",
                Weight = 75,
                Height = 175,
                ExperienceLevel = "Intermediate",
                Target = "Lose weight and build muscle",
                DietBackground = "Tried keto diet before",
                HealthIssues = "None",
                FoodAllergies = "Peanuts",
                FavouriteFoods = "Chicken, rice, vegetables",
                MealPreparationPreference = "Simple and quick",
                PreferredMealsPerDay = "4+",
                DislikedFoods = "Seafood",
                SupplementsUsed = "Protein powder, creatine",
                ProfilePictures = new[] { mockFile1.Object, mockFile2.Object }
            };

            mockNotificationService.Setup(s => s.AddNotification(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);


            await requestToDietitianService.Add(userId, dietitian.Id, model);


            var updatedUser = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            Assert.That(updatedUser, Is.Not.Null);
            Assert.That(updatedUser.FirstName, Is.EqualTo("New First Name"));
            Assert.That(updatedUser.LastName, Is.EqualTo("New Last Name"));
            Assert.That(updatedUser.Weight, Is.EqualTo(75));
            Assert.That(updatedUser.Height, Is.EqualTo(175));
            Assert.That(updatedUser.ExperienceLevel, Is.EqualTo("Intermediate"));


            var request = await repository.All<RequestToDietitian>()
                .Where(r => r.UserId == userId && r.DietitianId == dietitian.Id)
                .FirstOrDefaultAsync();

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Target, Is.EqualTo("Lose weight and build muscle"));
            Assert.That(request.DietBackground, Is.EqualTo("Tried keto diet before"));
            Assert.That(request.HealthIssues, Is.EqualTo("None"));
            Assert.That(request.FoodAllergies, Is.EqualTo("Peanuts"));
            Assert.That(request.FavouriteFoods, Is.EqualTo("Chicken, rice, vegetables"));
            Assert.That(request.MealPreparationPreference, Is.EqualTo("Simple and quick"));
            Assert.That(request.PreferredMealsPerDay, Is.EqualTo("4+"));
            Assert.That(request.DislikedFoods, Is.EqualTo("Seafood"));
            Assert.That(request.SupplementsUsed, Is.EqualTo("Protein powder, creatine"));
            Assert.That(request.IsAnswered, Is.False);
            Assert.That(request.Date.Date, Is.EqualTo(DateTime.Now.Date));
            Assert.That(request.UserPictures, Is.Not.Null);
            Assert.That(request.UserPictures.Count, Is.EqualTo(2));

            mockNotificationService.Verify(s => s.AddNotification(
                It.Is<string>(userId => userId == user.Id),
                It.Is<string>(targetId => targetId == dietitianUser.Id),
                It.IsAny<string>(),
                It.Is<string>(type => type == "RequestToDietitian")),
                Times.Once);
        }

        [Test]
        public async Task Add_WithNullProfilePictures_ShouldCreateRequestWithoutPictures()
        {
     
            var userId = "user2";
            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "Old First Name",
                LastName = "Old Last Name",
                Height = 170,
                Weight = 70,
                ExperienceLevel = "Beginner",
                Aim = "Muscle Gain"
            };
            await repository.AddAsync(user);

            var dietitianUserId = "dietitianUser2";
            var dietitianUser = new ApplicationUser
            {
                Id = dietitianUserId,
                FirstName = "Dietitian",
                LastName = "User2"
            };
            await repository.AddAsync(dietitianUser);

            var dietitian = new Dietitian
            {
                Id = 2,
                UserId = dietitianUserId,
                Specialization = "Muscle Gain",
                Experience = 7,
                SertificateImage = "cert2.jpg",
                SertificationDetails = "Certification Details",
                Bio = "Professional dietitian",
                PhoneNumber = "+1234567890"
            };
            await repository.AddAsync(dietitian);
            await repository.SaveChangesAsync();

            var model = new SurveyViewModel
            {
                FirstName = "New First Name",
                LastName = "New Last Name",
                Weight = 75,
                Height = 175,
                ExperienceLevel = "Intermediate",
                Target = "Build muscle mass",
                DietBackground = "High protein diet",
                HealthIssues = "None",
                FoodAllergies = "None",
                FavouriteFoods = "Steak, eggs, protein shakes",
                MealPreparationPreference = "Meal prep once a week",
                PreferredMealsPerDay = "5+",
                DislikedFoods = "Vegetables",
                SupplementsUsed = "Protein, creatine, BCAAs",
                ProfilePictures = null
            };

   
            await requestToDietitianService.Add(userId, dietitian.Id, model);


            var request = await repository.All<RequestToDietitian>()
                .Where(r => r.UserId == userId && r.DietitianId == dietitian.Id)
                .FirstOrDefaultAsync();

            Assert.That(request, Is.Not.Null);
            Assert.That(request.UserPictures, Is.Not.Null);
            Assert.That(request.UserPictures.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task ExistAsync_WithExistingRequest_ShouldReturnTrue()
        {

            var userId = "user3";
            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "Test",
                LastName = "User"
            };
            await repository.AddAsync(user);

            var dietitianId = 3;
            var request = new RequestToDietitian
            {
                Id = 1,
                UserId = userId,
                DietitianId = dietitianId,
                Target = "Weight loss",
                IsAnswered = false,
                Date = DateTime.Now
            };
            await repository.AddAsync(request);
            await repository.SaveChangesAsync();


            var result = await requestToDietitianService.ExistAsync(request.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistAsync_WithNonExistingRequest_ShouldReturnFalse()
        { 
            var result = await requestToDietitianService.ExistAsync(999);


            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnOnlyUnansweredRequestsForDietitian()
        {

            var dietitianUserId = "dietitianUser3";
            var dietitianUser = new ApplicationUser
            {
                Id = dietitianUserId,
                FirstName = "Dietitian",
                LastName = "User3"
            };
            await repository.AddAsync(dietitianUser);

            var dietitian = new Dietitian
            {
                Id = 4,
                UserId = dietitianUserId,
                Specialization = "General Nutrition",
                Experience = 6,
                SertificateImage = "cert3.jpg",
                SertificationDetails = "Certification Details",
                Bio = "Professional dietitian",
                PhoneNumber = "+1234567890"
            };
            await repository.AddAsync(dietitian);


            var user1 = new ApplicationUser
            {
                Id = "user4",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile1.jpg",
                ExperienceLevel = "Beginner"
            };
            await repository.AddAsync(user1);

            var user2 = new ApplicationUser
            {
                Id = "user5",
                FirstName = "Jane",
                LastName = "Smith",
                ProfilePicture = "profile2.jpg",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user2);

            var user3 = new ApplicationUser
            {
                Id = "user6",
                FirstName = "Bob",
                LastName = "Johnson",
                ProfilePicture = "profile3.jpg",
                ExperienceLevel = "Advanced"
            };
            await repository.AddAsync(user3);

            var request1 = new RequestToDietitian
            {
                Id = 2,
                UserId = user1.Id,
                User = user1,
                DietitianId = dietitian.Id,
                Target = "Weight loss",
                DietBackground = "No previous diets",
                IsAnswered = false,
                Date = DateTime.Now.AddDays(-5)
            };
            await repository.AddAsync(request1);

            var request2 = new RequestToDietitian
            {
                Id = 3,
                UserId = user2.Id,
                User = user2,
                DietitianId = dietitian.Id,
                Target = "Muscle gain",
                DietBackground = "High protein diet",
                IsAnswered = false, 
                Date = DateTime.Now.AddDays(-3)
            };
            await repository.AddAsync(request2);

            var request3 = new RequestToDietitian
            {
                Id = 4,
                UserId = user3.Id,
                User = user3,
                DietitianId = dietitian.Id,
                Target = "Maintenance",
                DietBackground = "Balanced diet",
                IsAnswered = true, 
                Date = DateTime.Now.AddDays(-1)
            };
            await repository.AddAsync(request3);

            var otherDietitian = new Dietitian
            {
                Id = 5,
                UserId = "otherDietitianUser",
                Specialization = "Sports Nutrition",
                Experience = 8,
                SertificateImage = "cert4.jpg",
                SertificationDetails = "Certification Details",
                Bio = "Sports dietitian",
                PhoneNumber = "+0987654321"
            };
            await repository.AddAsync(otherDietitian);

            var request4 = new RequestToDietitian
            {
                Id = 5,
                UserId = user1.Id,
                User = user1,
                DietitianId = otherDietitian.Id,
                Target = "Sports performance",
                DietBackground = "Athletic diet",
                IsAnswered = false,
                Date = DateTime.Now
            };
            await repository.AddAsync(request4);

            await repository.SaveChangesAsync();


            var result = await requestToDietitianService.GetAllAsync(dietitianUserId);
            var resultList = result.ToList();


            Assert.That(resultList, Is.Not.Null);
            Assert.That(resultList.Count, Is.EqualTo(2), "Should return only unanswered requests for the specified dietitian");

            Assert.That(resultList.Any(r => r.Id == request1.Id), Is.True);
            Assert.That(resultList.Any(r => r.Id == request2.Id), Is.True);


            Assert.That(resultList.Any(r => r.Id == request3.Id), Is.False, "Should not include answered requests");


            Assert.That(resultList.Any(r => r.Id == request4.Id), Is.False, "Should not include requests for other dietitians");

            var firstRequest = resultList.First(r => r.Id == request1.Id);
            Assert.That(firstRequest.UserId, Is.EqualTo(user1.Id));
            Assert.That(firstRequest.FirstName, Is.EqualTo(user1.FirstName));
            Assert.That(firstRequest.LastName, Is.EqualTo(user1.LastName));
            Assert.That(firstRequest.ProfilePicture, Is.EqualTo(user1.ProfilePicture));
            Assert.That(firstRequest.ExperienceLevel, Is.EqualTo(user1.ExperienceLevel));
            Assert.That(firstRequest.Target, Is.EqualTo(request1.Target));
            Assert.That(firstRequest.DietBackground, Is.EqualTo(request1.DietBackground));
        }

        [Test]
        public async Task GetAllAsync_WithNoDietitianFound_ShouldThrowException()
        {

            string nonExistentDietitianUserId = "nonExistentUser";


            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await requestToDietitianService.GetAllAsync(nonExistentDietitianUserId));
        }

        [Test]
        public async Task GetAllAsync_WithNoRequests_ShouldReturnEmptyCollection()
        {

            var dietitianUserId = "dietitianUser4";
            var dietitianUser = new ApplicationUser
            {
                Id = dietitianUserId,
                FirstName = "Dietitian",
                LastName = "User4"
            };
            await repository.AddAsync(dietitianUser);

            var dietitian = new Dietitian
            {
                Id = 6,
                UserId = dietitianUserId,
                Specialization = "Nutrition",
                Experience = 4,
                SertificateImage = "cert5.jpg",
                SertificationDetails = "Certification Details",
                Bio = "Dietitian bio",
                PhoneNumber = "+1122334455"
            };
            await repository.AddAsync(dietitian);
            await repository.SaveChangesAsync();

            var result = await requestToDietitianService.GetAllAsync(dietitianUserId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0), "Should return empty collection when no requests exist");
        }
    }
}