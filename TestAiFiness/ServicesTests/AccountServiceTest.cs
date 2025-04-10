using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Account;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
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
    public class AccountServiceTest
    {

        private IRepository repository;
        private IAccountService accountService;
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
            accountService = new AccountService(repository);

        }
        [Test]
        public async Task AddMoreInformationAsync_WithValidData_UpdatesUserInformation()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-1",
                UserName = "user@example.com",
                Email = "user@example.com"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write("fake image content");
            writer.Flush();
            memoryStream.Position = 0;

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(f => f.Length).Returns(memoryStream.Length);
            formFileMock.Setup(f => f.FileName).Returns("profile.jpg");
            formFileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, CancellationToken>((stream, token) => memoryStream.CopyTo(stream))
                .Returns(Task.CompletedTask);

            var model = new MoreInformationViewModel
            {
                FirstName = "Иван",
                LastName = "Петров",
                ExperienceLevel = "Начинаещ",
                Height = 180,
                Weight = 80,
                Aim = "Покачване на мускулна маса",
                ProfilePicture = formFileMock.Object
            };

            await accountService.AddMoreInformationAsync("user-id-1", model);

            var updatedUser = await repository.All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == "user-id-1");

            Assert.That(updatedUser, Is.Not.Null);
            Assert.That(updatedUser.FirstName, Is.EqualTo("Иван"));
            Assert.That(updatedUser.LastName, Is.EqualTo("Петров"));
            Assert.That(updatedUser.ExperienceLevel, Is.EqualTo("Начинаещ"));
            Assert.That(updatedUser.Height, Is.EqualTo(180));
            Assert.That(updatedUser.Weight, Is.EqualTo(80));
            Assert.That(updatedUser.Aim, Is.EqualTo("Покачване на мускулна маса"));
            Assert.That(updatedUser.ProfilePicture, Is.Not.Null);
        }

        [Test]
        public async Task ChangeInformation_WithValidData_UpdatesUserInformation()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-2",
                UserName = "oldusername",
                Email = "oldemail@example.com",
                FirstName = "Стар",
                LastName = "Потребител",
                ExperienceLevel = "Начинаещ",
                Height = 175,
                Weight = 70,
                ProfilePicture = "old-profile-picture"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write("new image content");
            writer.Flush();
            memoryStream.Position = 0;

            var formFileMock = new Mock<IFormFile>();
            formFileMock.Setup(f => f.Length).Returns(memoryStream.Length);
            formFileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Callback<Stream, CancellationToken>((stream, token) => memoryStream.CopyTo(stream))
                .Returns(Task.CompletedTask);

            var model = new EditProfileViewModel
            {
                UserName = "newusername",
                Email = "newemail@example.com",
                FirstName = "Нов",
                LastName = "Потребител",
                ExperienceLevel = "Напреднал",
                Height = 180,
                Weight = 75,
                NewImageUrl = formFileMock.Object
            };

            var result = await accountService.ChangeInformation("user-id-2", model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo("newusername"));
            Assert.That(result.Email, Is.EqualTo("newemail@example.com"));
            Assert.That(result.FirstName, Is.EqualTo("Нов"));
            Assert.That(result.LastName, Is.EqualTo("Потребител"));
            Assert.That(result.ExperienceLevel, Is.EqualTo("Напреднал"));
            Assert.That(result.Height, Is.EqualTo(180));
            Assert.That(result.Weight, Is.EqualTo(75));
            Assert.That(result.ProfilePicture, Is.Not.EqualTo("old-profile-picture"));
        }

        [Test]
        public async Task Edit_WithValidId_ReturnsUserInformation()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-3",
                UserName = "testuser",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител",
                ExperienceLevel = "Начинаещ",
                Height = 185,
                Weight = 85,
                ProfilePicture = "test-profile-picture"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var result = await accountService.Edit("user-id-3");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo("testuser"));
            Assert.That(result.Email, Is.EqualTo("test@example.com"));
            Assert.That(result.FirstName, Is.EqualTo("Тест"));
            Assert.That(result.LastName, Is.EqualTo("Потребител"));
            Assert.That(result.ExperienceLevel, Is.EqualTo("Начинаещ"));
            Assert.That(result.Height, Is.EqualTo(185));
            Assert.That(result.Weight, Is.EqualTo(85));
            Assert.That(result.ImageUrl, Is.EqualTo("test-profile-picture"));
        }

        [Test]
        public async Task GetMoldelForMyProfile_WithValidIdAndNotInRole_ReturnsUserProfile()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-4",
                UserName = "normaluser",
                Email = "normal@example.com",
                FirstName = "Обикновен",
                LastName = "Потребител",
                ExperienceLevel = "Средно",
                Height = 170,
                Weight = 65,
                ProfilePicture = "normal-profile-picture"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var result = await accountService.GetMoldelForMyProfile("user-id-4", false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("user-id-4"));
            Assert.That(result.UserName, Is.EqualTo("normaluser"));
            Assert.That(result.Email, Is.EqualTo("normal@example.com"));
            Assert.That(result.FirstName, Is.EqualTo("Обикновен"));
            Assert.That(result.LastName, Is.EqualTo("Потребител"));
            Assert.That(result.ExperienceLevel, Is.EqualTo("Средно"));
            Assert.That(result.Height, Is.EqualTo(170));
            Assert.That(result.Weight, Is.EqualTo(65));
            Assert.That(result.ImageUrl, Is.EqualTo("normal-profile-picture"));
        }

        [Test]
        public async Task GetMoldelForMyProfile_WithValidIdAndInRole_ReturnsTrainerProfile()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id",
                UserName = "trainer",
                Email = "trainer@example.com",
                FirstName = "Треньор",
                LastName = "Потребител",
                ExperienceLevel = "Напреднал",
                Height = 190,
                Weight = 85,
                ProfilePicture = "trainer-profile-picture"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален треньор",
                SertificationDetails = "Сертифициран треньор",
                PhoneNumber = "0888123456"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var result = await accountService.GetMoldelForMyProfile("trainer-id", true);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("trainer-id"));
            Assert.That(result.UserName, Is.EqualTo("trainer"));
            Assert.That(result.Email, Is.EqualTo("trainer@example.com"));
            Assert.That(result.FirstName, Is.EqualTo("Треньор"));
            Assert.That(result.LastName, Is.EqualTo("Потребител"));
            Assert.That(result.ExperienceLevel, Is.EqualTo("Напреднал"));
            Assert.That(result.Height, Is.EqualTo(190));
            Assert.That(result.Weight, Is.EqualTo(85));
            Assert.That(result.ImageUrl, Is.EqualTo("trainer-profile-picture"));
        }

        [Test]
        public async Task GetAllUsers_WithValidTrainerId_ReturnsAllTrainerClients()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id-2",
                UserName = "trainer2",
                Email = "trainer2@example.com",
                FirstName = "Треньор",
                LastName = "Два"
            };

            var trainer = new Trainer
            {
                Id = 2,
                UserId = "trainer-id-2",
                User = trainerUser,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321"
            };

            var clientUser1 = new ApplicationUser
            {
                Id = "client-id-1",
                UserName = "client1",
                Email = "client1@example.com",
                FirstName = "Клиент",
                LastName = "Едно",
                ProfilePicture = "client1-profile",
                Aim = "Отслабване",
                ExperienceLevel = "Начинаещ"
            };

            var clientUser2 = new ApplicationUser
            {
                Id = "client-id-2",
                UserName = "client2",
                Email = "client2@example.com",
                FirstName = "Клиент",
                LastName = "Две",
                ProfilePicture = "client2-profile",
                Aim = "Покачване на мускулна маса",
                ExperienceLevel = "Средно"
            };

            var trainingPlan1 = new TrainingPlan
            {
                Id = 1,
                Name = "План 1",
                UserId = "client-id-1",
                ImageUrl = "picture",
                User = clientUser1,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsInCalendar = true
            };

            var trainingPlan2 = new TrainingPlan
            {
                Id = 2,
                Name = "План 2",
                UserId = "client-id-2",
                User = clientUser2,
                ImageUrl = "picture",
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsInCalendar = false
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(clientUser1);
            await repository.AddAsync(clientUser2);
            await repository.AddAsync(trainingPlan1);
            await repository.AddAsync(trainingPlan2);
            await repository.SaveChangesAsync();

            var result = await accountService.GetAllUsers("trainer-id-2");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));

            var client1 = result.FirstOrDefault(c => c.UserId == "client-id-1");
            Assert.That(client1, Is.Not.Null);
            Assert.That(client1.FirsName, Is.EqualTo("Клиент"));
            Assert.That(client1.LastName, Is.EqualTo("Едно"));
            Assert.That(client1.Email, Is.EqualTo("client1@example.com"));
            Assert.That(client1.ProfilePicture, Is.EqualTo("client1-profile"));
            Assert.That(client1.Aim, Is.EqualTo("Отслабване"));
            Assert.That(client1.ExperienceLevel, Is.EqualTo("Начинаещ"));
            Assert.That(client1.IsInCalendar, Is.True);

            var client2 = result.FirstOrDefault(c => c.UserId == "client-id-2");
            Assert.That(client2, Is.Not.Null);
            Assert.That(client2.FirsName, Is.EqualTo("Клиент"));
            Assert.That(client2.LastName, Is.EqualTo("Две"));
            Assert.That(client2.IsInCalendar, Is.False);
        }

        [Test]
        public async Task GetAllDietitianClients_WithValidDietitianId_ReturnsAllDietitianClients()
        {
            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian-id",
                UserName = "dietitian",
                Email = "dietitian@example.com",
                FirstName = "Диетолог",
                LastName = "Един"
            };

            var dietitian = new Dietitian
            {
                Id = 1,
                UserId = "dietitian-id",
                User = dietitianUser,
                Specialization = "Здравословно хранене",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален диетолог",
                SertificationDetails = "Сертифициран диетолог",
                PhoneNumber = "0888123456"
            };

            var clientUser1 = new ApplicationUser
            {
                Id = "diet-client-id-1",
                UserName = "dietclient1",
                Email = "dietclient1@example.com",
                FirstName = "Клиент",
                LastName = "Диета1",
                ProfilePicture = "dietclient1-profile",
                Aim = "Отслабване",
                ExperienceLevel = "Начинаещ"
            };

            var clientUser2 = new ApplicationUser
            {
                Id = "diet-client-id-2",
                UserName = "dietclient2",
                Email = "dietclient2@example.com",
                FirstName = "Клиент",
                LastName = "Диета2",
                ProfilePicture = "dietclient2-profile",
                Aim = "Здравословно хранене",
                ExperienceLevel = "Средно"
            };

            var diet1 = new Diet
            {
                Id = 1,
                Name = "Диета 1",
                UserId = "diet-client-id-1",
                User = clientUser1,
                CreatedById = 1,
                Dietitian = dietitian,
                IsActive = true,
                IsInCalendar = true
            };

            var diet2 = new Diet
            {
                Id = 2,
                Name = "Диета 2",
                UserId = "diet-client-id-2",
                User = clientUser2,
                CreatedById = 1,
                Dietitian = dietitian,
                IsActive = true,
                IsInCalendar = false
            };

            await repository.AddAsync(dietitianUser);
            await repository.AddAsync(dietitian);
            await repository.AddAsync(clientUser1);
            await repository.AddAsync(clientUser2);
            await repository.AddAsync(diet1);
            await repository.AddAsync(diet2);
            await repository.SaveChangesAsync();

            var result = await accountService.GetAllDietitianClients("dietitian-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));

            var client1 = result.FirstOrDefault(c => c.UserId == "diet-client-id-1");
            Assert.That(client1, Is.Not.Null);
            Assert.That(client1.FirsName, Is.EqualTo("Клиент"));
            Assert.That(client1.LastName, Is.EqualTo("Диета1"));
            Assert.That(client1.Email, Is.EqualTo("dietclient1@example.com"));
            Assert.That(client1.ProfilePicture, Is.EqualTo("dietclient1-profile"));
            Assert.That(client1.Aim, Is.EqualTo("Отслабване"));
            Assert.That(client1.ExperienceLevel, Is.EqualTo("Начинаещ"));
            Assert.That(client1.IsInCalendar, Is.True);

            var client2 = result.FirstOrDefault(c => c.UserId == "diet-client-id-2");
            Assert.That(client2, Is.Not.Null);
            Assert.That(client2.FirsName, Is.EqualTo("Клиент"));
            Assert.That(client2.LastName, Is.EqualTo("Диета2"));
            Assert.That(client2.IsInCalendar, Is.False);
        }

        [Test]
        public async Task GetViewModelForMyTrainer_WithValidUserId_ReturnsTrainerInfo()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "my-trainer-id",
                UserName = "mytrainer",
                Email = "mytrainer@example.com",
                FirstName = "Мой",
                LastName = "Треньор",
                ProfilePicture = "mytrainer-profile"
            };

            var trainer = new Trainer
            {
                Id = 3,
                UserId = "my-trainer-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 7,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456"
            };

            var clientUser = new ApplicationUser
            {
                Id = "client-with-trainer-id",
                UserName = "clientwithtrainer",
                Email = "clientwithtrainer@example.com"
            };

            var trainingPlan = new TrainingPlan
            {
                Id = 3,
                Name = "Моят план",
                UserId = "client-with-trainer-id",
                User = clientUser,
                ImageUrl = "picture",
                CreatedById = 3,
                Trainer = trainer,
                IsActive = true
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(clientUser);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var result = await accountService.GetViewModelForMyTrainer("client-with-trainer-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.TrainerId, Is.EqualTo(3));
            Assert.That(result.FirstName, Is.EqualTo("Мой"));
            Assert.That(result.LastName, Is.EqualTo("Треньор"));
            Assert.That(result.Email, Is.EqualTo("mytrainer@example.com"));
            Assert.That(result.ProfilePicture, Is.EqualTo("mytrainer-profile"));
            Assert.That(result.Specialization, Is.EqualTo("Силови тренировки"));
            Assert.That(result.Expirience, Is.EqualTo(7));
        }

        [Test]
        public async Task GetViewModelForMyDietitian_WithValidUserId_ReturnsDietitianInfo()
        {
            var dietitianUser = new ApplicationUser
            {
                Id = "my-dietitian-id",
                UserName = "mydietitian",
                Email = "mydietitian@example.com",
                FirstName = "Моят",
                LastName = "Диетолог",
                ProfilePicture = "mydietitian-profile"
            };

            var dietitian = new Dietitian
            {
                Id = 2,
                UserId = "my-dietitian-id",
                User = dietitianUser,
                Specialization = "Здравословно хранене",
                Experience = 6,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321"
            };

            var clientUser = new ApplicationUser
            {
                Id = "client-with-dietitian-id",
                UserName = "clientwithdietitian",
                Email = "clientwithdietitian@example.com"
            };

            var diet = new Diet
            {
                Id = 3,
                Name = "Моята диета",
                UserId = "client-with-dietitian-id",
                User = clientUser,
                CreatedById = 2,
                Dietitian = dietitian,
                IsActive = true
            };

            await repository.AddAsync(dietitianUser);
            await repository.AddAsync(dietitian);
            await repository.AddAsync(clientUser);
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var result = await accountService.GetViewModelForMyDietitian("client-with-dietitian-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.DietitianId, Is.EqualTo(2));
            Assert.That(result.FirstName, Is.EqualTo("Моят"));
            Assert.That(result.LastName, Is.EqualTo("Диетолог"));
            Assert.That(result.Email, Is.EqualTo("mydietitian@example.com"));
            Assert.That(result.ProfilePicture, Is.EqualTo("mydietitian-profile"));
            Assert.That(result.Specialization, Is.EqualTo("Здравословно хранене"));
            Assert.That(result.Expirience, Is.EqualTo(6));
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
