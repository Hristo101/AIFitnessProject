using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.SignalR;
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
    public class HomeServiceTest
    {
        private IRepository repository;
        private IHomeService homeService;
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
            homeService = new HomeService(repository);

        }
        [Test]
        public async Task AllDietitianOpinionAsync_WithData_ReturnsCorrectOpinions()
        {
            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian-user-id",
                UserName = "dietitian@example.com",
                Email = "dietitian@example.com",
                FirstName = "Мария",
                LastName = "Диетологова",
                ProfilePicture = "dietitian-profile.jpg"
            };

            var dietitian = new Dietitian
            {
                Id = 1,
                UserId = "dietitian-user-id",
                User = dietitianUser,
                Specialization = "Здравословно хранене",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален диетолог с опит",
                SertificationDetails = "Сертифициран диетолог",
                PhoneNumber = "0888123456"
            };

            var opinion = new Opinion
            {
                Id = 1,
                SenderId = "dietitian-user-id",
                Sender = dietitianUser,
                Content = "Това е мнение за диетолога",
                Rating = 5
            };

            await repository.AddAsync(dietitianUser);
            await repository.AddAsync(dietitian);
            await repository.AddAsync(opinion);
            await repository.SaveChangesAsync();

            var result = await homeService.AllDietitianOpinionAsync();

            Assert.That(result, Is.Not.Null);
            var opinions = result.ToList();
            Assert.That(opinions.Count, Is.EqualTo(1));
            Assert.That(opinions[0].FirstName, Is.EqualTo("Мария"));
            Assert.That(opinions[0].LastName, Is.EqualTo("Диетологова"));
            Assert.That(opinions[0].Content, Is.EqualTo("Това е мнение за диетолога"));
            Assert.That(opinions[0].Rating, Is.EqualTo(5));
            Assert.That(opinions[0].DietitianImageUrl, Is.EqualTo("dietitian-profile.jpg"));
        }

        [Test]
        public async Task AllDietitianOpinionAsync_WithMultipleOpinions_ReturnsAllOpinions()
        {
            var dietitianUser1 = new ApplicationUser
            {
                Id = "dietitian-user-id-1",
                UserName = "dietitian1@example.com",
                Email = "dietitian1@example.com",
                FirstName = "Мария",
                LastName = "Диетологова",
                ProfilePicture = "dietitian1-profile.jpg"
            };

            var dietitianUser2 = new ApplicationUser
            {
                Id = "dietitian-user-id-2",
                UserName = "dietitian2@example.com",
                Email = "dietitian2@example.com",
                FirstName = "Петър",
                LastName = "Диетологов",
                ProfilePicture = "dietitian2-profile.jpg"
            };

            var dietitian1 = new Dietitian
            {
                Id = 1,
                UserId = "dietitian-user-id-1",
                User = dietitianUser1,
                Specialization = "Здравословно хранене",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален диетолог с опит",
                SertificationDetails = "Сертифициран диетолог",
                PhoneNumber = "0888123456"
            };

            var dietitian2 = new Dietitian
            {
                Id = 2,
                UserId = "dietitian-user-id-2",
                User = dietitianUser2,
                Specialization = "Спортно хранене",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Спортен диетолог",
                SertificationDetails = "Сертифициран спортен диетолог",
                PhoneNumber = "0888654321"
            };

            var opinions = new List<Opinion>
    {
        new Opinion
        {
            Id = 1,
            SenderId = "dietitian-user-id-1",
            Sender = dietitianUser1,
            Content = "Това е мнение от първия диетолог",
            Rating = 5
        },
        new Opinion
        {
            Id = 2,
            SenderId = "dietitian-user-id-2",
            Sender = dietitianUser2,
            Content = "Това е мнение от втория диетолог",
            Rating = 4
        }
    };

            await repository.AddAsync(dietitianUser1);
            await repository.AddAsync(dietitianUser2);
            await repository.AddAsync(dietitian1);
            await repository.AddAsync(dietitian2);
            await repository.AddRangeAsync(opinions);
            await repository.SaveChangesAsync();

            var result = await homeService.AllDietitianOpinionAsync();

            Assert.That(result, Is.Not.Null);
            var resultList = result.ToList();
            Assert.That(resultList.Count, Is.EqualTo(2));

            var opinion1 = resultList.FirstOrDefault(o => o.FirstName == "Мария");
            Assert.That(opinion1, Is.Not.Null);
            Assert.That(opinion1.Content, Is.EqualTo("Това е мнение от първия диетолог"));
            Assert.That(opinion1.Rating, Is.EqualTo(5));
            Assert.That(opinion1.DietitianImageUrl, Is.EqualTo("dietitian1-profile.jpg"));

            var opinion2 = resultList.FirstOrDefault(o => o.FirstName == "Петър");
            Assert.That(opinion2, Is.Not.Null);
            Assert.That(opinion2.Content, Is.EqualTo("Това е мнение от втория диетолог"));
            Assert.That(opinion2.Rating, Is.EqualTo(4));
            Assert.That(opinion2.DietitianImageUrl, Is.EqualTo("dietitian2-profile.jpg"));
        }

        [Test]
        public async Task AllDietitianOpinionAsync_WithNoOpinions_ReturnsEmptyCollection()
        {
            var result = await homeService.AllDietitianOpinionAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetModelsForHomePageAsync_WithData_ReturnsCorrectModels()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-user-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Иван",
                LastName = "Тренев",
                ProfilePicture = "trainer-profile.jpg"
            };

            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian-user-id",
                UserName = "dietitian@example.com",
                Email = "dietitian@example.com",
                FirstName = "Мария",
                LastName = "Диетологова",
                ProfilePicture = "dietitian-profile.jpg"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-user-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален треньор",
                SertificationDetails = "Сертифициран треньор",
                PhoneNumber = "0888123456"
            };

            var dietitian = new Dietitian
            {
                Id = 1,
                UserId = "dietitian-user-id",
                User = dietitianUser,
                Specialization = "Здравословно хранене",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален диетолог",
                SertificationDetails = "Сертифициран диетолог",
                PhoneNumber = "0888654321"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(dietitianUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(dietitian);
            await repository.SaveChangesAsync();

            var result = await homeService.GetModelsForHomePageAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Trainers, Is.Not.Null);
            Assert.That(result.Trainers.Count, Is.EqualTo(1));
            Assert.That(result.Trainers[0].FirstName, Is.EqualTo("Иван"));
            Assert.That(result.Trainers[0].ImageUrl, Is.EqualTo("trainer-profile.jpg"));

            Assert.That(result.Dietitians, Is.Not.Null);
            Assert.That(result.Dietitians.Count, Is.EqualTo(1));
            Assert.That(result.Dietitians[0].FirstName, Is.EqualTo("Мария"));
            Assert.That(result.Dietitians[0].ImageUrl, Is.EqualTo("dietitian-profile.jpg"));
        }

        [Test]
        public async Task GetModelsForHomePageAsync_WithMultipleTrainersAndDietitians_ReturnsAllEntries()
        {
            var trainerUsers = new List<ApplicationUser>
    {
        new ApplicationUser
        {
            Id = "trainer-user-id-1",
            UserName = "trainer1@example.com",
            Email = "trainer1@example.com",
            FirstName = "Иван",
            LastName = "Тренев",
            ProfilePicture = "trainer1-profile.jpg"
        },
        new ApplicationUser
        {
            Id = "trainer-user-id-2",
            UserName = "trainer2@example.com",
            Email = "trainer2@example.com",
            FirstName = "Георги",
            LastName = "Фитнесов",
            ProfilePicture = "trainer2-profile.jpg"
        }
    };

            var dietitianUsers = new List<ApplicationUser>
    {
        new ApplicationUser
        {
            Id = "dietitian-user-id-1",
            UserName = "dietitian1@example.com",
            Email = "dietitian1@example.com",
            FirstName = "Мария",
            LastName = "Диетологова",
            ProfilePicture = "dietitian1-profile.jpg"
        },
        new ApplicationUser
        {
            Id = "dietitian-user-id-2",
            UserName = "dietitian2@example.com",
            Email = "dietitian2@example.com",
            FirstName = "Елена",
            LastName = "Нутриева",
            ProfilePicture = "dietitian2-profile.jpg"
        }
    };

            var trainers = new List<Trainer>
    {
        new Trainer
        {
            Id = 1,
            UserId = "trainer-user-id-1",
            User = trainerUsers[0],
            Specialization = "Силови тренировки",
            Experience = 5,
            SertificateImage = GenerateValidBase64Image(),
            Bio = "Професионален треньор",
            SertificationDetails = "Сертифициран треньор",
            PhoneNumber = "0888123456"
        },
        new Trainer
        {
            Id = 2,
            UserId = "trainer-user-id-2",
            User = trainerUsers[1],
            Specialization = "Кардио тренировки",
            Experience = 3,
            SertificateImage = GenerateValidBase64Image(),
            Bio = "Кардио специалист",
            SertificationDetails = "Сертифициран кардио треньор",
            PhoneNumber = "0888765432"
        }
    };

            var dietitians = new List<Dietitian>
    {
        new Dietitian
        {
            Id = 1,
            UserId = "dietitian-user-id-1",
            User = dietitianUsers[0],
            Specialization = "Здравословно хранене",
            Experience = 5,
            SertificateImage = GenerateValidBase64Image(),
            Bio = "Професионален диетолог",
            SertificationDetails = "Сертифициран диетолог",
            PhoneNumber = "0888654321"
        },
        new Dietitian
        {
            Id = 2,
            UserId = "dietitian-user-id-2",
            User = dietitianUsers[1],
            Specialization = "Спортно хранене",
            Experience = 4,
            SertificateImage = GenerateValidBase64Image(),
            Bio = "Спортен диетолог",
            SertificationDetails = "Сертифициран спортен диетолог",
            PhoneNumber = "0888345678"
        }
    };

            await repository.AddRangeAsync(trainerUsers);
            await repository.AddRangeAsync(dietitianUsers);
            await repository.AddRangeAsync(trainers);
            await repository.AddRangeAsync(dietitians);
            await repository.SaveChangesAsync();

            var result = await homeService.GetModelsForHomePageAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Trainers, Is.Not.Null);
            Assert.That(result.Trainers.Count, Is.EqualTo(2));
            Assert.That(result.Trainers.Any(t => t.FirstName == "Иван" && t.ImageUrl == "trainer1-profile.jpg"), Is.True);
            Assert.That(result.Trainers.Any(t => t.FirstName == "Георги" && t.ImageUrl == "trainer2-profile.jpg"), Is.True);

            Assert.That(result.Dietitians, Is.Not.Null);
            Assert.That(result.Dietitians.Count, Is.EqualTo(2));
            Assert.That(result.Dietitians.Any(d => d.FirstName == "Мария" && d.ImageUrl == "dietitian1-profile.jpg"), Is.True);
            Assert.That(result.Dietitians.Any(d => d.FirstName == "Елена" && d.ImageUrl == "dietitian2-profile.jpg"), Is.True);
        }

        [Test]
        public async Task GetModelsForHomePageAsync_WithNoData_ReturnsEmptyCollections()
        {
            var result = await homeService.GetModelsForHomePageAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Trainers, Is.Not.Null);
            Assert.That(result.Trainers.Count, Is.EqualTo(0));
            Assert.That(result.Dietitians, Is.Not.Null);
            Assert.That(result.Dietitians.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetModelsForHowWeWorkPageAsync_WithData_ReturnsCorrectOpinions()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-user-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Иван",
                LastName = "Тренев",
                ProfilePicture = "trainer-profile.jpg"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-user-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален треньор",
                SertificationDetails = "Сертифициран треньор",
                PhoneNumber = "0888123456"
            };

            var opinion = new Opinion
            {
                Id = 1,
                SenderId = "trainer-user-id",
                Sender = trainerUser,
                Content = "Това е мнение за треньора",
                Rating = 5
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(opinion);
            await repository.SaveChangesAsync();

            var result = await homeService.GetModelsForHowWeWorkPageAsync();

            Assert.That(result, Is.Not.Null);
            var opinions = result.ToList();
            Assert.That(opinions.Count, Is.EqualTo(1));
            Assert.That(opinions[0].FirstName, Is.EqualTo("Иван"));
            Assert.That(opinions[0].LastName, Is.EqualTo("Тренев"));
            Assert.That(opinions[0].Content, Is.EqualTo("Това е мнение за треньора"));
            Assert.That(opinions[0].Rating, Is.EqualTo(5));
            Assert.That(opinions[0].TrainerImageUrl, Is.EqualTo("trainer-profile.jpg"));
        }

        [Test]
        public async Task GetModelsForHowWeWorkPageAsync_WithMultipleOpinions_ReturnsAllOpinions()
        {
            var trainerUser1 = new ApplicationUser
            {
                Id = "trainer-user-id-1",
                UserName = "trainer1@example.com",
                Email = "trainer1@example.com",
                FirstName = "Иван",
                LastName = "Тренев",
                ProfilePicture = "trainer1-profile.jpg"
            };

            var trainerUser2 = new ApplicationUser
            {
                Id = "trainer-user-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Георги",
                LastName = "Фитнесов",
                ProfilePicture = "trainer2-profile.jpg"
            };

            var trainer1 = new Trainer
            {
                Id = 1,
                UserId = "trainer-user-id-1",
                User = trainerUser1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален треньор",
                SertificationDetails = "Сертифициран треньор",
                PhoneNumber = "0888123456"
            };

            var trainer2 = new Trainer
            {
                Id = 2,
                UserId = "trainer-user-id-2",
                User = trainerUser2,
                Specialization = "Кардио тренировки",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Кардио специалист",
                SertificationDetails = "Сертифициран кардио треньор",
                PhoneNumber = "0888765432"
            };

            var opinions = new List<Opinion>
    {
        new Opinion
        {
            Id = 1,
            SenderId = "trainer-user-id-1",
            Sender = trainerUser1,
            Content = "Това е мнение от първия треньор",
            Rating = 5
        },
        new Opinion
        {
            Id = 2,
            SenderId = "trainer-user-id-2",
            Sender = trainerUser2,
            Content = "Това е мнение от втория треньор",
            Rating = 4
        }
    };

            await repository.AddAsync(trainerUser1);
            await repository.AddAsync(trainerUser2);
            await repository.AddAsync(trainer1);
            await repository.AddAsync(trainer2);
            await repository.AddRangeAsync(opinions);
            await repository.SaveChangesAsync();

            var result = await homeService.GetModelsForHowWeWorkPageAsync();

            Assert.That(result, Is.Not.Null);
            var resultList = result.ToList();
            Assert.That(resultList.Count, Is.EqualTo(2));

            var opinion1 = resultList.FirstOrDefault(o => o.FirstName == "Иван");
            Assert.That(opinion1, Is.Not.Null);
            Assert.That(opinion1.Content, Is.EqualTo("Това е мнение от първия треньор"));
            Assert.That(opinion1.Rating, Is.EqualTo(5));
            Assert.That(opinion1.TrainerImageUrl, Is.EqualTo("trainer1-profile.jpg"));

            var opinion2 = resultList.FirstOrDefault(o => o.FirstName == "Георги");
            Assert.That(opinion2, Is.Not.Null);
            Assert.That(opinion2.Content, Is.EqualTo("Това е мнение от втория треньор"));
            Assert.That(opinion2.Rating, Is.EqualTo(4));
            Assert.That(opinion2.TrainerImageUrl, Is.EqualTo("trainer2-profile.jpg"));
        }

        [Test]
        public async Task GetModelsForHowWeWorkPageAsync_WithNoOpinions_ReturnsEmptyCollection()
        {
            var result = await homeService.GetModelsForHowWeWorkPageAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
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
