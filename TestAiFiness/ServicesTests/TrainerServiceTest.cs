using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
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
    public class TrainerServiceTest
    {
        private IRepository repository;
        private ITrainerService trainerService;
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
            trainerService = new TrainerService(repository);

        }
        [Test]
        public async Task GetViewModelForDetails_WithTrainerAndComments_ReturnsCorrectViewModel()
        {
            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "trainer-profile.jpg"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                UserId = "test-trainer-id",
                User = trainerUser,
                Bio = "Опитен треньор с 5 години стаж",
                SertificateImage = "certificate.jpg",
                SertificationDetails = "Национална спортна академия",
                PhoneNumber = "+359888123456",
                Specialization = "Функционален трейнинг"
            };

            var commentSenderUser1 = new ApplicationUser()
            {
                Id = "sender-user-id-1",
                FirstName = "Петър",
                LastName = "Иванов"
            };

            var commentSenderUser2 = new ApplicationUser()
            {
                Id = "sender-user-id-2",
                FirstName = "Мария",
                LastName = "Георгиева"
            };

            var comments = new List<UserComment>
    {
        new UserComment
        {
            Id = 1,
            Rating = 5,
            Content = "Страхотен треньор!",
            ReceiverId = "test-trainer-id",
            Receiver = trainerUser,
            SenderId = "sender-user-id-1",
            Sender = commentSenderUser1
        },
        new UserComment
        {
            Id = 2,
            Rating = 4,
            Content = "Много полезни тренировки",
            ReceiverId = "test-trainer-id",
            Receiver = trainerUser,
            SenderId = "sender-user-id-2",
            Sender = commentSenderUser2
        }
    };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(commentSenderUser1);
            await repository.AddAsync(commentSenderUser2);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(comments);
            await repository.SaveChangesAsync();

            var result = await trainerService.GetViewModelForDetails(1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.FirstName, Is.EqualTo("Иван"));
                Assert.That(result.LastName, Is.EqualTo("Петров"));
                Assert.That(result.Bio, Is.EqualTo("Опитен треньор с 5 години стаж"));
                Assert.That(result.SertificationImage, Is.EqualTo("certificate.jpg"));
                Assert.That(result.TrainerImage, Is.EqualTo("trainer-profile.jpg"));
                Assert.That(result.SertificationDetails, Is.EqualTo("Национална спортна академия"));
                Assert.That(result.PhoneNumber, Is.EqualTo("+359888123456"));
                Assert.That(result.Specialization, Is.EqualTo("Функционален трейнинг"));
                Assert.That(result.Email, Is.EqualTo("trainer@example.com"));

                Assert.That(result.Comments, Is.Not.Null);
                Assert.That(result.Comments, Has.Count.EqualTo(2));
            });

            var commentList = result.Comments.ToList();
            Assert.Multiple(() =>
            {
                var firstComment = commentList[0];
                Assert.That(firstComment.Rating, Is.EqualTo(5));
                Assert.That(firstComment.Content, Is.EqualTo("Страхотен треньор!"));
                Assert.That(firstComment.SenderName, Is.EqualTo("Петър Иванов"));

                var secondComment = commentList[1];
                Assert.That(secondComment.Rating, Is.EqualTo(4));
                Assert.That(secondComment.Content, Is.EqualTo("Много полезни тренировки"));
                Assert.That(secondComment.SenderName, Is.EqualTo("Мария Георгиева"));
            });
        }

        [Test]
        public async Task GetViewModelForDetails_WithTrainerNoComments_ReturnsViewModelWithEmptyComments()
        {
            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "trainer-profile.jpg"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                UserId = "test-trainer-id",
                User = trainerUser,
                Bio = "Опитен треньор с 5 години стаж",
                SertificateImage = "certificate.jpg",
                SertificationDetails = "Национална спортна академия",
                PhoneNumber = "+359888123456",
                Specialization = "Функционален трейнинг"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var result = await trainerService.GetViewModelForDetails(1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Comments, Is.Not.Null);
                Assert.That(result.Comments, Is.Empty);
            });
        }

        [Test]
        public async Task GetViewModelForDetails_WithNonExistentTrainer_ReturnsNull()
        {
            var result = await trainerService.GetViewModelForDetails(999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetViewModelForDetailsForUser_WithTrainerAndComments_ReturnsCorrectViewModel()
        {
            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "trainer-profile.jpg"
            };

            var currentUser = new ApplicationUser()
            {
                Id = "current-user-id",
                UserName = "current@example.com",
                Email = "current@example.com",
                FirstName = "Петър",
                LastName = "Иванов",
                ProfilePicture = "current-user-profile.jpg"
            };

            var commentSenderUser1 = new ApplicationUser()
            {
                Id = "sender-user-id-1",
                UserName = "sender1@example.com",
                Email = "sender1@example.com",
                FirstName = "Мария",
                LastName = "Георгиева",
                ProfilePicture = "sender1-profile.jpg"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                UserId = "test-trainer-id",
                User = trainerUser,
                Bio = "Опитен треньор с 5 години стаж",
                SertificateImage = "certificate.jpg",
                SertificationDetails = "Национална спортна академия",
                PhoneNumber = "+359888123456",
                Specialization = "Функционален трейнинг"
            };

            var comments = new List<UserComment>
    {
        new UserComment
        {
            Id = 1,
            Rating = 5,
            Content = "Страхотен треньор!",
            ReceiverId = "test-trainer-id",
            Receiver = trainerUser,
            SenderId = "sender-user-id-1",
            Sender = commentSenderUser1
        },
        new UserComment
        {
            Id = 2,
            Rating = 4,
            Content = "Много полезни тренировки",
            ReceiverId = "test-trainer-id",
            Receiver = trainerUser,
            SenderId = "current-user-id",
            Sender = currentUser
        }
    };


            await repository.AddAsync(trainerUser);
            await repository.AddAsync(currentUser);
            await repository.AddAsync(commentSenderUser1);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(comments);
            await repository.SaveChangesAsync();

            var result = await trainerService.GetViewModelForDetailsForUser(1, "current-user-id");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.TrainerId, Is.EqualTo(1));
                Assert.That(result.UserId, Is.EqualTo("current-user-id"));
                Assert.That(result.FirstName, Is.EqualTo("Иван"));
                Assert.That(result.LastName, Is.EqualTo("Петров"));
                Assert.That(result.Bio, Is.EqualTo("Опитен треньор с 5 години стаж"));
                Assert.That(result.SertificationImage, Is.EqualTo("certificate.jpg"));
                Assert.That(result.TrainerImage, Is.EqualTo("trainer-profile.jpg"));
                Assert.That(result.SertificationDetails, Is.EqualTo("Национална спортна академия"));
                Assert.That(result.PhoneNumber, Is.EqualTo("+359888123456"));
                Assert.That(result.Specialization, Is.EqualTo("Функционален трейнинг"));
                Assert.That(result.Email, Is.EqualTo("trainer@example.com"));

                Assert.That(result.Comments, Is.Not.Null);
                Assert.That(result.Comments, Has.Count.EqualTo(2));
            });

            var commentList = result.Comments.ToList();
            Assert.Multiple(() =>
            {
                var firstComment = commentList[0];
                Assert.That(firstComment.Id, Is.EqualTo(1));
                Assert.That(firstComment.Rating, Is.EqualTo(5));
                Assert.That(firstComment.Content, Is.EqualTo("Страхотен треньор!"));
                Assert.That(firstComment.IsMine, Is.False);
                Assert.That(firstComment.SenderName, Is.EqualTo("Мария Георгиева"));
                Assert.That(firstComment.Email, Is.EqualTo("sender1@example.com"));
                Assert.That(firstComment.ProfilePicture, Is.EqualTo("sender1-profile.jpg"));

                var secondComment = commentList[1];
                Assert.That(secondComment.Id, Is.EqualTo(2));
                Assert.That(secondComment.Rating, Is.EqualTo(4));
                Assert.That(secondComment.Content, Is.EqualTo("Много полезни тренировки"));
                Assert.That(secondComment.IsMine, Is.True);
                Assert.That(secondComment.SenderName, Is.EqualTo("Петър Иванов"));
                Assert.That(secondComment.Email, Is.EqualTo("current@example.com"));
                Assert.That(secondComment.ProfilePicture, Is.EqualTo("current-user-profile.jpg"));
            });
        }

        [Test]
        public async Task GetViewModelForDetailsForUser_WithTrainerNoComments_ReturnsViewModelWithEmptyComments()
        {
            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "trainer-profile.jpg"
            };

            var currentUser = new ApplicationUser()
            {
                Id = "current-user-id",
                UserName = "current@example.com",
                Email = "current@example.com",
                FirstName = "Петър",
                LastName = "Иванов"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                UserId = "test-trainer-id",
                User = trainerUser,
                Bio = "Опитен треньор с 5 години стаж",
                SertificateImage = "certificate.jpg",
                SertificationDetails = "Национална спортна академия",
                PhoneNumber = "+359888123456",
                Specialization = "Функционален трейнинг"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(currentUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var result = await trainerService.GetViewModelForDetailsForUser(1, "current-user-id");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.TrainerId, Is.EqualTo(1));
                Assert.That(result.UserId, Is.EqualTo("current-user-id"));
                Assert.That(result.Comments, Is.Not.Null);
                Assert.That(result.Comments, Is.Empty);
            });
        }

        [Test]
        public async Task GetViewModelForDetailsForUser_WithNonExistentTrainer_ReturnsNull()
        {
            var currentUser = new ApplicationUser()
            {
                Id = "current-user-id",
                UserName = "current@example.com",
                Email = "current@example.com",
                FirstName = "Петър",
                LastName = "Иванов"
            };

            await repository.AddAsync(currentUser);
            await repository.SaveChangesAsync();

            var result = await trainerService.GetViewModelForDetailsForUser(999, "current-user-id");

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ShowAllTrainersAsync_WithMultipleTrainers_ReturnsCorrectViewModels()
        {
            var trainerUsers = new List<ApplicationUser>
    {
        new ApplicationUser()
        {
            Id = "trainer-user-id-1",
            UserName = "trainer1@example.com",
            Email = "trainer1@example.com",
            FirstName = "Иван",
            LastName = "Петров",
            ProfilePicture = "trainer1-profile.jpg"
        },
        new ApplicationUser()
        {
            Id = "trainer-user-id-2",
            UserName = "trainer2@example.com",
            Email = "trainer2@example.com",
            FirstName = "Мария",
            LastName = "Иванова",
            ProfilePicture = "trainer2-profile.jpg"
        }
    };

            var trainers = new List<Trainer>
    {
        new Trainer()
        {
            Id = 1,
            UserId = "trainer-user-id-1",
            User = trainerUsers[0],
              SertificateImage = "sertificate",
            Experience = 5,
            Specialization = "Функционален трейнинг"
        },
        new Trainer()
        {
            Id = 2,
            UserId = "trainer-user-id-2",
            User = trainerUsers[1],
              SertificateImage = "sertificate",
            Experience = 3,
            Specialization = "Кросфит"
        }
    };

            await repository.AddRangeAsync(trainerUsers);
            await repository.AddRangeAsync(trainers);
            await repository.SaveChangesAsync();

            var result = await trainerService.ShowAllTrainersAsync();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count(), Is.EqualTo(2));
            });

            var resultList = result.ToList();
            Assert.Multiple(() =>
            {
                var firstTrainer = resultList[0];
                Assert.That(firstTrainer.Id, Is.EqualTo(1));
                Assert.That(firstTrainer.FirstName, Is.EqualTo("Иван"));
                Assert.That(firstTrainer.LastName, Is.EqualTo("Петров"));
                Assert.That(firstTrainer.ImageUrl, Is.EqualTo("trainer1-profile.jpg"));
                Assert.That(firstTrainer.Experience, Is.EqualTo(5));
                Assert.That(firstTrainer.Specialization, Is.EqualTo("Функционален трейнинг"));

                var secondTrainer = resultList[1];
                Assert.That(secondTrainer.Id, Is.EqualTo(2));
                Assert.That(secondTrainer.FirstName, Is.EqualTo("Мария"));
                Assert.That(secondTrainer.LastName, Is.EqualTo("Иванова"));
                Assert.That(secondTrainer.ImageUrl, Is.EqualTo("trainer2-profile.jpg"));
                Assert.That(secondTrainer.Experience, Is.EqualTo(3));
                Assert.That(secondTrainer.Specialization, Is.EqualTo("Кросфит"));
            });
        }

        [Test]
        public async Task ShowAllTrainersAsync_WithNoTrainers_ReturnsEmptyList()
        {
            var result = await trainerService.ShowAllTrainersAsync();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public async Task ShowAllTrainersAsync_VerifyPropertiesMapping()
        {
            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Стефанов",
                ProfilePicture = "trainer-profile.jpg"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                UserId = "trainer-user-id",
                User = trainerUser,
                SertificateImage = "sertificate",
                Experience = 7,
                Specialization = "Силова подготовка"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var result = await trainerService.ShowAllTrainersAsync();

            var trainerViewModel = result.First();

            Assert.Multiple(() =>
            {
                Assert.That(trainerViewModel.Id, Is.EqualTo(1));
                Assert.That(trainerViewModel.FirstName, Is.EqualTo("Георги"));
                Assert.That(trainerViewModel.LastName, Is.EqualTo("Стефанов"));
                Assert.That(trainerViewModel.ImageUrl, Is.EqualTo("trainer-profile.jpg"));
                Assert.That(trainerViewModel.Experience, Is.EqualTo(7));
                Assert.That(trainerViewModel.Specialization, Is.EqualTo("Силова подготовка"));
            });
        }
        [Test]
        public async Task ExistAsync_WithExistingUserComment_ReturnsTrue()
        {
            var currentUser = new ApplicationUser()
            {
                Id = "current-user-id",
                UserName = "current@example.com",
                Email = "current@example.com",
                FirstName = "Петър",
                LastName = "Иванов"
            };

            var receiverUser = new ApplicationUser()
            {
                Id = "receiver-user-id",
                UserName = "receiver@example.com",
                Email = "receiver@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var userComment = new UserComment
            {
                Id = 1,
                Rating = 5,
                Content = "Страхотен треньор!",
                ReceiverId = "receiver-user-id",
                Receiver = receiverUser,
                SenderId = "current-user-id",
                Sender = currentUser
            };

            await repository.AddAsync(currentUser);
            await repository.AddAsync(receiverUser);
            await repository.AddAsync(userComment);
            await repository.SaveChangesAsync();

            var result = await trainerService.ExistAsync(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistAsync_WithNonExistentUserComment_ReturnsFalse()
        {
            var result = await trainerService.ExistAsync(999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ExistAsync_MultipleComments_CorrectlyIdentifiesExistingComment()
        {
            var currentUser = new ApplicationUser()
            {
                Id = "current-user-id",
                UserName = "current@example.com",
                Email = "current@example.com",
                FirstName = "Петър",
                LastName = "Иванов"
            };

            var receiverUser = new ApplicationUser()
            {
                Id = "receiver-user-id",
                UserName = "receiver@example.com",
                Email = "receiver@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var userComments = new List<UserComment>
    {
        new UserComment
        {
            Id = 1,
            Rating = 5,
            Content = "Страхотен треньор!",
            ReceiverId = "receiver-user-id",
            Receiver = receiverUser,
            SenderId = "current-user-id",
            Sender = currentUser
        },
        new UserComment
        {
            Id = 2,
            Rating = 4,
            Content = "Добра тренировка",
            ReceiverId = "receiver-user-id",
            Receiver = receiverUser,
            SenderId = "current-user-id",
            Sender = currentUser
        }
    };

            await repository.AddAsync(currentUser);
            await repository.AddAsync(receiverUser);
            await repository.AddRangeAsync(userComments);
            await repository.SaveChangesAsync();

            var existingResult = await trainerService.ExistAsync(1);
            var nonExistingResult = await trainerService.ExistAsync(3);

            Assert.Multiple(() =>
            {
                Assert.That(existingResult, Is.True);
                Assert.That(nonExistingResult, Is.False);
            });
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }
    }
}
