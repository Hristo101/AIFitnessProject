using AIFitnessProject.Core.Contracts;
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
    public class UserCommentServiceTest
    {
        private IRepository repository;
        private ICommentService userCommentService;
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
            userCommentService = new CommentService(repository, notificationServiceMock.Object);

        }
        [Test]
        public async Task AddNewComment_WithValidData_AddsCommentAndNotification()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id",
                UserName = "sender@example.com",
                Email = "sender@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var receiver = new ApplicationUser
            {
                Id = "receiver-id",
                UserName = "receiver@example.com",
                Email = "receiver@example.com",
                FirstName = "Петър",
                LastName = "Иванов"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "receiver-id",
                User = receiver,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456"
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var notificationServiceMock = new Mock<INotificationService>();
            notificationServiceMock
                .Setup(ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            userCommentService = new CommentService(repository, notificationServiceMock.Object);

            await userCommentService.AddNewComment("sender-id", 1, "Страхотен треньор!", 5);

            var comments = await repository.All<UserComment>().ToListAsync();
            Assert.That(comments.Count, Is.EqualTo(1));
            Assert.That(comments[0].SenderId, Is.EqualTo("sender-id"));
            Assert.That(comments[0].ReceiverId, Is.EqualTo("receiver-id"));
            Assert.That(comments[0].Content, Is.EqualTo("Страхотен треньор!"));
            Assert.That(comments[0].Rating, Is.EqualTo(5));

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    "sender-id",
                    "receiver-id",
                    $"Потребител с име Иван Петров ви постави коментар с оценка: 5 и със следния отзив:Страхотен треньор!",
                    "Comments"
                ),
                Times.Once
            );
        }

        [Test]
        public async Task AddNewCommentForDietitian_WithValidData_AddsCommentAndNotification()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id",
                UserName = "sender@example.com",
                Email = "sender@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var receiver = new ApplicationUser
            {
                Id = "dietitian-user-id",
                UserName = "dietitian@example.com",
                Email = "dietitian@example.com",
                FirstName = "Мария",
                LastName = "Диетологова"
            };

            var dietitian = new Dietitian
            {
                Id = 1,
                UserId = "dietitian-user-id",
                User = receiver,
                Specialization = "Здравословно хранене",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Професионален диетолог",
                SertificationDetails = "Сертифициран диетолог",
                PhoneNumber = "0888654321"
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.AddAsync(dietitian);
            await repository.SaveChangesAsync();

            var notificationServiceMock = new Mock<INotificationService>();
            notificationServiceMock
                .Setup(ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            userCommentService = new CommentService(repository, notificationServiceMock.Object);

            await userCommentService.AddNewCommentForDietitian("sender-id", 1, "Отличен диетолог!", 5);

            var comments = await repository.All<UserComment>().ToListAsync();
            Assert.That(comments.Count, Is.EqualTo(1));
            Assert.That(comments[0].SenderId, Is.EqualTo("sender-id"));
            Assert.That(comments[0].ReceiverId, Is.EqualTo("dietitian-user-id"));
            Assert.That(comments[0].Content, Is.EqualTo("Отличен диетолог!"));
            Assert.That(comments[0].Rating, Is.EqualTo(5));

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    "sender-id",
                    "dietitian-user-id",
                    $"Потребител с име Иван Петров ви постави коментар с оценка: 5 и със следния отзив: Отличен диетолог!",
                    "Comments"
                ),
                Times.Once
            );
        }

        [Test]
        public async Task DeleteComment_WithValidId_RemovesComment()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id",
                UserName = "sender@example.com",
                Email = "sender@example.com"
            };

            var receiver = new ApplicationUser
            {
                Id = "receiver-id",
                UserName = "receiver@example.com",
                Email = "receiver@example.com"
            };

            var comment = new UserComment
            {
                Id = 1,
                SenderId = "sender-id",
                Sender = sender,
                ReceiverId = "receiver-id",
                Receiver = receiver,
                Content = "Коментар за изтриване",
                Rating = 4
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            var initialCount = await repository.All<UserComment>().CountAsync();
            Assert.That(initialCount, Is.EqualTo(1));

            await userCommentService.DeleteComment(1);

            var remainingComments = await repository.All<UserComment>().ToListAsync();
            Assert.That(remainingComments.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task EditComment_WithValidData_UpdatesComment()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id",
                UserName = "sender@example.com",
                Email = "sender@example.com"
            };

            var receiver = new ApplicationUser
            {
                Id = "receiver-id",
                UserName = "receiver@example.com",
                Email = "receiver@example.com"
            };

            var comment = new UserComment
            {
                Id = 1,
                SenderId = "sender-id",
                Sender = sender,
                ReceiverId = "receiver-id",
                Receiver = receiver,
                Content = "Първоначален коментар",
                Rating = 3
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            await userCommentService.EditComment(1, "Редактиран коментар", 5);

            var updatedComment = await repository.All<UserComment>()
                .FirstOrDefaultAsync(c => c.Id == 1);

            Assert.That(updatedComment, Is.Not.Null);
            Assert.That(updatedComment.Content, Is.EqualTo("Редактиран коментар"));
            Assert.That(updatedComment.Rating, Is.EqualTo(5));
            Assert.That(updatedComment.SenderId, Is.EqualTo("sender-id"));
            Assert.That(updatedComment.ReceiverId, Is.EqualTo("receiver-id"));
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
