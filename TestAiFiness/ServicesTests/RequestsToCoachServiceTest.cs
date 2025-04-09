using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using AIFitnessProject.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using AIFitnessProject.Core.Models.RequestsToCoach;

[TestFixture]
public class RequestsToCoachServiceTest
{
    private IRepository repository;
    private IRequestsToCoach requestsToCoach;
    private Mock<INotificationService> notificationServiceMock;
    private ApplicationDbContext applicationDbContext;

    [SetUp]
    public void Setup()
    {
        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("RequestsToCoachDB_" + Guid.NewGuid())
            .Options;
        applicationDbContext = new ApplicationDbContext(contextOptions, false);
        applicationDbContext.Database.EnsureDeleted();
        applicationDbContext.Database.EnsureCreated();
        repository = new Repository(applicationDbContext);

        notificationServiceMock = new Mock<INotificationService>();
        requestsToCoach = new RequestsToCoachService(
            repository,
            notificationServiceMock.Object
        );
    }


    [Test]
    public async Task Add_WithValidData_CreatesRequestAndReturnsTrue()
    {
     
        var trainerUser = new ApplicationUser()
        {
            Id = "test-trainer-user-id",
            UserName = "trainer@example.com",
            Email = "trainer@example.com",
            FirstName = "Иван",
            LastName = "Треньоров"
        };

        var trainer = new Trainer()
        {
            Id = 1,
            UserId = "test-trainer-user-id",
            SertificateImage = "sertificate",
            User = trainerUser
        };

        var user = new ApplicationUser()
        {
            Id = "test-user-id",
            UserName = "user@example.com",
            Email = "user@example.com"
        };

        
        var mockFormFile = new Mock<IFormFile>();
        mockFormFile.Setup(f => f.Length).Returns(1024);
        mockFormFile.Setup(f => f.FileName).Returns("test-image.jpg");
        mockFormFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            .Returns((Stream stream, CancellationToken token) =>
            {
                byte[] imageBytes = new byte[1024];
                new Random().NextBytes(imageBytes);
                return stream.WriteAsync(imageBytes, 0, imageBytes.Length);
            });

   
        var surveyModel = new SurveyViewModel
        {
            FirstName = "Петър",
            LastName = "Иванов",
            Weight = 80,
            Height = 180,
            ExpirienceLevel = "Начинаещ",
            HealthStatus = "Добро",
            Target = "Качване на мускулна маса",
            TrainingBackground = "Нямам опит",
            TrainingCommitment = "5 пъти седмично",
            TrainingPreferences = "Силови тренировки",
            ProfilePictures = new IFormFile[] { mockFormFile.Object }
        };

       
        notificationServiceMock
            .Setup(ns => ns.AddNotification(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
            .Returns(Task.CompletedTask);

       
        await repository.AddAsync(trainerUser);
        await repository.AddAsync(trainer);
        await repository.AddAsync(user);
        await repository.SaveChangesAsync();

       
        var result = await requestsToCoach.Add(user.Id, trainer.Id, surveyModel);


        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);

        
            var updatedUser = repository.All<ApplicationUser>()
                .FirstOrDefault(u => u.Id == user.Id);
            Assert.That(updatedUser.FirstName, Is.EqualTo("Петър"));
            Assert.That(updatedUser.LastName, Is.EqualTo("Иванов"));
            Assert.That(updatedUser.Weight, Is.EqualTo(80));
            Assert.That(updatedUser.Height, Is.EqualTo(180));
            Assert.That(updatedUser.ExperienceLevel, Is.EqualTo("Начинаещ"));

        
            var request = repository.All<RequestsToCoach>()
                .FirstOrDefault(r => r.UserId == user.Id);
            Assert.That(request, Is.Not.Null);
            Assert.That(request.TrainerId, Is.EqualTo(trainer.Id));
            Assert.That(request.IsAnswered, Is.False);
            Assert.That(request.PicturesOfPersons, Has.Count.EqualTo(1));
        });

    
        notificationServiceMock.Verify(
            ns => ns.AddNotification(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                "RequestsToCoaches"),
            Times.Once);
    }

    [Test]
    public async Task ExistAsync_WithExistingRequest_ReturnsTrue()
    {
        
        var trainerUser = new ApplicationUser()
        {
            Id = "test-trainer-user-id",
            UserName = "trainer@example.com",
            Email = "trainer@example.com"
        };

        var trainer = new Trainer()
        {
            Id = 1,
            UserId = "test-trainer-user-id",
            SertificateImage = "sertificate",
            User = trainerUser
        };

        var user = new ApplicationUser()
        {
            Id = "test-user-id",
            UserName = "user@example.com",
            Email = "user@example.com"
        };

        var request = new RequestsToCoach
        {
            TrainerId = 1,
            UserId = user.Id,
            IsAnswered = false,
            Date = DateTime.Now,
            HealthStatus = "добро",
            Target = "да отслабна",
            TrainingBackground = "Не съм спортувал преди",
            TrainingCommitment = "5+ дни",
            TrainingPreferences = "тежести",
            PicturesOfPersons = new List<string>() { "picture1,picture2"}
        };

        await repository.AddAsync(trainerUser);
        await repository.AddAsync(trainer);
        await repository.AddAsync(user);
        await repository.AddAsync(request);
        await repository.SaveChangesAsync();

        
        var result = await requestsToCoach.ExistAsync(1);

        
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task ExistAsync_WithNonExistentRequest_ReturnsFalse()
    {
       
        var result = await requestsToCoach.ExistAsync(999);

        
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task GetAllAsync_WithExistingRequests_ReturnsCorrectViewModel()
    {
       
        var trainerUser = new ApplicationUser()
        {
            Id = "test-trainer-user-id",
            UserName = "trainer@example.com",
            Email = "trainer@example.com"
        };

        var trainer = new Trainer()
        {
            Id = 1,
            UserId = "test-trainer-user-id",
            SertificateImage = "sertificate",
            User = trainerUser
        };

        var user1 = new ApplicationUser()
        {
            Id = "test-user-id-1",
            UserName = "user1@example.com",
            Email = "user1@example.com",
            FirstName = "Петър",
            LastName = "Иванов",
            ProfilePicture = "user1-profile.jpg"
        };

        var user2 = new ApplicationUser()
        {
            Id = "test-user-id-2",
            UserName = "user2@example.com",
            Email = "user2@example.com",
            FirstName = "Мария",
            LastName = "Петрова",
            ProfilePicture = "user2-profile.jpg"
        };

        var requests = new List<RequestsToCoach>
        {
            new RequestsToCoach
            {
                Id = 1,
                TrainerId = 1,
                UserId = user1.Id,
                User = user1,
                IsAnswered = false,
                Target = "Отслабване",
                TrainingBackground = "Начинаещ",
                HealthStatus = "Добро",
                TrainingCommitment = "5+ дни",
                TrainingPreferences = "тежести",
                PicturesOfPersons = new List<string>() { "picture1,picture2"},
                Date = DateTime.Now,

            },
            new RequestsToCoach
            {
                Id = 2,
                TrainerId = 1,
                UserId = user2.Id,
                User = user2,
                IsAnswered = false,
                Target = "Качване на мускулна маса",
                TrainingBackground = "Среднонапреднал",
                HealthStatus = "Добро",
                TrainingCommitment = "5+ дни",
                TrainingPreferences = "тежести",
                PicturesOfPersons = new List<string>() { "picture1,picture2"},
                Date = DateTime.Now,
            }
        };

        await repository.AddAsync(trainerUser);
        await repository.AddAsync(trainer);
        await repository.AddAsync(user1);
        await repository.AddAsync(user2);
        await repository.AddRangeAsync(requests);
        await repository.SaveChangesAsync();

       
        var result = await requestsToCoach.GetAllAsync("test-trainer-user-id");

      
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        });

        var resultList = result.ToList();
        Assert.Multiple(() =>
        {
            var firstRequest = resultList[0];
            Assert.That(firstRequest.Id, Is.EqualTo(1));
            Assert.That(firstRequest.UserId, Is.EqualTo("test-user-id-1"));
            Assert.That(firstRequest.FirstName, Is.EqualTo("Петър"));
            Assert.That(firstRequest.LastName, Is.EqualTo("Иванов"));
            Assert.That(firstRequest.ProfilePicture, Is.EqualTo("user1-profile.jpg"));
            Assert.That(firstRequest.ExperienceLevel, Is.EqualTo("Начинаещ"));
            Assert.That(firstRequest.TargetOfTraining, Is.EqualTo("Отслабване"));

            var secondRequest = resultList[1];
            Assert.That(secondRequest.Id, Is.EqualTo(2));
            Assert.That(secondRequest.UserId, Is.EqualTo("test-user-id-2"));
            Assert.That(secondRequest.FirstName, Is.EqualTo("Мария"));
            Assert.That(secondRequest.LastName, Is.EqualTo("Петрова"));
            Assert.That(secondRequest.ProfilePicture, Is.EqualTo("user2-profile.jpg"));
            Assert.That(secondRequest.ExperienceLevel, Is.EqualTo("Среднонапреднал"));
            Assert.That(secondRequest.TargetOfTraining, Is.EqualTo("Качване на мускулна маса"));
        });
    }

    [Test]
    public async Task GetAllAsync_WithNoRequests_ReturnsEmptyList()
    {
       
        var trainerUser = new ApplicationUser()
        {
            Id = "test-trainer-user-id",
            UserName = "trainer@example.com",
            Email = "trainer@example.com"
        };

        var trainer = new Trainer()
        {
            Id = 1,
            UserId = "test-trainer-user-id",
            SertificateImage = "sertificate",
            User = trainerUser
        };

        await repository.AddAsync(trainerUser);
        await repository.AddAsync(trainer);
        await repository.SaveChangesAsync();

     
        var result = await requestsToCoach.GetAllAsync("test-trainer-user-id");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        });
    }

    [Test]
    public async Task GetViewModelForDetailsAsync_WithExistingRequest_ReturnsCorrectViewModel()
    {
        
        var trainerUser = new ApplicationUser()
        {
            Id = "test-trainer-user-id",
            UserName = "trainer@example.com",
            Email = "trainer@example.com"
        };

        var trainer = new Trainer()
        {
            Id = 1,
            UserId = "test-trainer-user-id",
            SertificateImage = "sertificate",
            User = trainerUser
        };

        var user = new ApplicationUser()
        {
            Id = "test-user-id",
            UserName = "user@example.com",
            Email = "user@example.com",
            FirstName = "Петър",
            LastName = "Иванов",
            ProfilePicture = "user-profile.jpg"
        };

        var request = new RequestsToCoach
        {
            Id = 1,
            TrainerId = 1,
            UserId = user.Id,
            User = user,
            HealthStatus = "Добро",
            Target = "Отслабване",
            TrainingBackground = "Начинаещ",
            TrainingCommitment = "3 пъти седмично",
            TrainingPreferences = "Кардио тренировки",
            PicturesOfPersons =  { "base64-image-1", "base64-image-2" }
        };

        await repository.AddAsync(trainerUser);
        await repository.AddAsync(trainer);
        await repository.AddAsync(user);
        await repository.AddAsync(request);
        await repository.SaveChangesAsync();

       
        var result = await requestsToCoach.GetViewModelForDetailsAsync(1);

        
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.UserId, Is.EqualTo("test-user-id"));
            Assert.That(result.Email, Is.EqualTo("user@example.com"));
            Assert.That(result.ProfilePicture, Is.EqualTo("user-profile.jpg"));
            Assert.That(result.FirstName, Is.EqualTo("Петър"));
            Assert.That(result.LastName, Is.EqualTo("Иванов"));
            Assert.That(result.HealthStatus, Is.EqualTo("Добро"));
            Assert.That(result.Target, Is.EqualTo("Отслабване"));
            Assert.That(result.TrainingBackground, Is.EqualTo("Начинаещ"));
            Assert.That(result.TrainingCommitment, Is.EqualTo("3 пъти седмично"));
            Assert.That(result.TrainingPreferences, Is.EqualTo("Кардио тренировки"));

            
            var actualRequest = repository.All<RequestsToCoach>()
                .FirstOrDefault(r => r.Id == 1);

            Assert.That(actualRequest, Is.Not.Null);
            Assert.That(actualRequest.PicturesOfPersons, Is.Not.Null);
            Assert.That(actualRequest.PicturesOfPersons.Count, Is.EqualTo(2));
            Assert.That(actualRequest.PicturesOfPersons[0], Is.EqualTo("base64-image-1"));
            Assert.That(actualRequest.PicturesOfPersons[1], Is.EqualTo("base64-image-2"));
        });
    } 
    [Test]
    public async Task GetViewModelForDetailsAsync_WithNonExistentRequest_ThrowsException()
    {
     
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await requestsToCoach.GetViewModelForDetailsAsync(999)
        );
    }
    [TearDown]
    public void TearDown()
    {
        applicationDbContext.Database.EnsureDeleted();
        applicationDbContext.Dispose();
    }

}