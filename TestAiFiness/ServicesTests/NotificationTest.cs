using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAiFiness.ServicesTests
{
    [TestFixture]
    public class NotificationTest
    {
        private IRepository repository;
        private INotificationService notificationService;
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
            var hubContextMock = new Mock<IHubContext<NotificationHub>>();

            repository = new Repository(applicationDbContext);
            notificationService = new NotificationService(hubContextMock.Object,repository);

        }
        [Test]
        public async Task DeleteNotification_WithValidId_DeletesNotification()
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

            var notification = new Notification
            {
                Id = 1,
                SenderId = "sender-id",
                Sender = sender,
                RecieverId = "receiver-id",
                Reciever = receiver,
                Message = "Тестово съобщение",
                CreatedAt = DateTime.Now,
                ReadStatus = false,
                Source = "Test"
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();


            applicationDbContext.ChangeTracker.Clear();

            await notificationService.DeleteNotification(1);

            var notificationsCount = await repository.All<Notification>().CountAsync();
            Assert.That(notificationsCount, Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteNotification_WithInvalidId_ThrowsNullReferenceException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await notificationService.DeleteNotification(999)
            );
        }

        [Test]
        public async Task DeleteNotification_DeletesOnlySpecifiedNotification()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id-2",
                UserName = "sender2@example.com",
                Email = "sender2@example.com",
                FirstName = "Георги",
                LastName = "Димитров"
            };

            var receiver = new ApplicationUser
            {
                Id = "receiver-id-2",
                UserName = "receiver2@example.com",
                Email = "receiver2@example.com",
                FirstName = "Димитър",
                LastName = "Георгиев"
            };

            var notifications = new List<Notification>
    {
        new Notification
        {
            Id = 2,
            SenderId = "sender-id-2",
            Sender = sender,
            RecieverId = "receiver-id-2",
            Reciever = receiver,
            Message = "Първо съобщение",
            CreatedAt = DateTime.Now.AddDays(-1),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 3,
            SenderId = "sender-id-2",
            Sender = sender,
            RecieverId = "receiver-id-2",
            Reciever = receiver,
            Message = "Второ съобщение",
            CreatedAt = DateTime.Now,
            ReadStatus = false,
            Source = "Test"
        }
    };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.AddRangeAsync(notifications);
            await repository.SaveChangesAsync();

            applicationDbContext.ChangeTracker.Clear();

            await notificationService.DeleteNotification(2);

            var remainingNotifications = await repository.All<Notification>().ToListAsync();

            Assert.That(remainingNotifications.Count, Is.EqualTo(1));
            Assert.That(remainingNotifications[0].Id, Is.EqualTo(3));
            Assert.That(remainingNotifications[0].Message, Is.EqualTo("Второ съобщение"));
        }

        [Test]
        public async Task AddNotification_WithValidData_AddsNotificationToDatabase()
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

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.SaveChangesAsync();

            var hubClientsMock = new Mock<IHubClients>();
            var hubUserProxyMock = new Mock<IClientProxy>();
            var hubContextMock = new Mock<IHubContext<NotificationHub>>();

            hubContextMock.Setup(h => h.Clients).Returns(hubClientsMock.Object);
            hubClientsMock.Setup(c => c.User("receiver-id")).Returns(hubUserProxyMock.Object);

            notificationService = new NotificationService(hubContextMock.Object, repository);

            await notificationService.AddNotification("sender-id", "receiver-id", "Тестово съобщение", "Test");

            var notifications = await repository.All<Notification>().ToListAsync();

            Assert.That(notifications.Count, Is.EqualTo(1));
            Assert.That(notifications[0].SenderId, Is.EqualTo("sender-id"));
            Assert.That(notifications[0].RecieverId, Is.EqualTo("receiver-id"));
            Assert.That(notifications[0].Message, Is.EqualTo("Тестово съобщение"));
            Assert.That(notifications[0].Source, Is.EqualTo("Test"));
            Assert.That(notifications[0].ReadStatus, Is.False);
            Assert.That(notifications[0].CreatedAt.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public async Task AddNotification_WithHubContext_SavesNotificationCorrectly()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id-2",
                UserName = "sender2@example.com",
                Email = "sender2@example.com",
                FirstName = "Георги",
                LastName = "Димитров"
            };

            var receiver = new ApplicationUser
            {
                Id = "receiver-id-2",
                UserName = "receiver2@example.com",
                Email = "receiver2@example.com",
                FirstName = "Димитър",
                LastName = "Георгиев"
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.SaveChangesAsync();

            var hubContextMock = new Mock<IHubContext<NotificationHub>>();
            var hubClientsMock = new Mock<IHubClients>();
            var hubUserProxyMock = new Mock<IClientProxy>();

            hubContextMock.Setup(h => h.Clients).Returns(hubClientsMock.Object);
            hubClientsMock.Setup(c => c.User("receiver-id-2")).Returns(hubUserProxyMock.Object);

            notificationService = new NotificationService(hubContextMock.Object, repository);

            await notificationService.AddNotification("sender-id-2", "receiver-id-2", "Друго съобщение", "Test");

            var notification = await repository.All<Notification>()
                .FirstOrDefaultAsync(n => n.SenderId == "sender-id-2" && n.RecieverId == "receiver-id-2");

            Assert.That(notification, Is.Not.Null);
            Assert.That(notification.Message, Is.EqualTo("Друго съобщение"));
            Assert.That(notification.Source, Is.EqualTo("Test"));
        }

        [Test]
        public async Task AddNotification_WithDifferentSources_StoresSourceCorrectly()
        {
            var sender = new ApplicationUser
            {
                Id = "sender-id-3",
                UserName = "sender3@example.com",
                Email = "sender3@example.com",
                FirstName = "Стоян",
                LastName = "Стоянов"
            };

            var receiver = new ApplicationUser
            {
                Id = "receiver-id-3",
                UserName = "receiver3@example.com",
                Email = "receiver3@example.com",
                FirstName = "Мария",
                LastName = "Петрова"
            };

            await repository.AddAsync(sender);
            await repository.AddAsync(receiver);
            await repository.SaveChangesAsync();

            var hubContextMock = new Mock<IHubContext<NotificationHub>>();
            var hubClientsMock = new Mock<IHubClients>();
            var hubUserProxyMock = new Mock<IClientProxy>();

            hubContextMock.Setup(h => h.Clients).Returns(hubClientsMock.Object);
            hubClientsMock.Setup(c => c.User(It.IsAny<string>())).Returns(hubUserProxyMock.Object);

            notificationService = new NotificationService(hubContextMock.Object, repository);

            await notificationService.AddNotification("sender-id-3", "receiver-id-3", "Съобщение 1", "TrainingPlan");
            await notificationService.AddNotification("sender-id-3", "receiver-id-3", "Съобщение 2", "RejectedTrainingPlan");

            var notifications = await repository.All<Notification>().ToListAsync();

            Assert.That(notifications.Count, Is.EqualTo(2));
            Assert.That(notifications[0].Source, Is.EqualTo("TrainingPlan"));
            Assert.That(notifications[1].Source, Is.EqualTo("RejectedTrainingPlan"));
        }
        [Test]
        public async Task GetAllNotifications_WithValidTrainerIdAndNotifications_ReturnsCorrectViewModel()
        {
            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев",
                ProfilePicture = "trainer-profile.jpg"
            };

            var sender1 = new ApplicationUser
            {
                Id = "user-id-1",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "user1-profile.jpg"
            };

            var sender2 = new ApplicationUser
            {
                Id = "admin-id",
                UserName = "hserev789@gmail.com",
                Email = "hserev789@gmail.com",
                FirstName = "Админ",
                LastName = "Админов",
                ProfilePicture = "admin-profile.jpg"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456"
            };

            var notifications = new List<Notification>
    {
        new Notification
        {
            Id = 1,
            SenderId = "user-id-1",
            Sender = sender1,
            RecieverId = "trainer-id",
            Reciever = trainerUser,
            Message = "Непрочетено съобщение от потребител",
            CreatedAt = DateTime.Now.AddDays(-1),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 2,
            SenderId = "admin-id",
            Sender = sender2,
            RecieverId = "trainer-id",
            Reciever = trainerUser,
            Message = "Непрочетено съобщение от админ",
            CreatedAt = DateTime.Now.AddDays(-2),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 3,
            SenderId = "user-id-1",
            Sender = sender1,
            RecieverId = "trainer-id",
            Reciever = trainerUser,
            Message = "Прочетено съобщение от потребител",
            CreatedAt = DateTime.Now.AddDays(-3),
            ReadStatus = true,
            Source = "Test"
        }
    };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(sender1);
            await repository.AddAsync(sender2);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(notifications);
            await repository.SaveChangesAsync();

            var result = await notificationService.GetAllNotifications("trainer-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReceiverProfilePicture, Is.EqualTo("trainer-profile.jpg"));
            Assert.That(result.ReceiverEmail, Is.EqualTo("trainer@example.com"));
            Assert.That(result.RecieverFirstName, Is.EqualTo("Георги"));
            Assert.That(result.RecieverLastName, Is.EqualTo("Тренев"));

            Assert.That(result.UnReadNotifications, Is.Not.Null);
            Assert.That(result.UnReadNotifications.Count, Is.EqualTo(2));

            var userUnreadNotification = result.UnReadNotifications.FirstOrDefault(n => n.Id == 1);
            Assert.That(userUnreadNotification, Is.Not.Null);
            Assert.That(userUnreadNotification.Message, Is.EqualTo("Непрочетено съобщение от потребител"));
            Assert.That(userUnreadNotification.Role, Is.EqualTo("Потребител"));

            var adminUnreadNotification = result.UnReadNotifications.FirstOrDefault(n => n.Id == 2);
            Assert.That(adminUnreadNotification, Is.Not.Null);
            Assert.That(adminUnreadNotification.Message, Is.EqualTo("Непрочетено съобщение от админ"));
            Assert.That(adminUnreadNotification.Role, Is.EqualTo("Администратор"));

            Assert.That(result.ReadNotifications, Is.Not.Null);
            Assert.That(result.ReadNotifications.Count, Is.EqualTo(1));

            var readNotification = result.ReadNotifications.First();
            Assert.That(readNotification.Id, Is.EqualTo(3));
            Assert.That(readNotification.Message, Is.EqualTo("Прочетено съобщение от потребител"));
        }

        [Test]
        public async Task GetAllNotifications_WithValidTrainerIdButNoNotifications_ReturnsBasicViewModel()
        {
            var sender1 = new ApplicationUser
            {
                Id = "user-id-1",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "user1-profile.jpg"
            };

            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Петър",
                LastName = "Треньорски",
                ProfilePicture = "trainer2-profile.jpg"
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

            var notification = new Notification
            {
                Id = 1,
                SenderId = "user-id-1",
                RecieverId = "trainer-id-2",
                Reciever = trainerUser,
                Message = "Непрочетено съобщение от потребител",
                CreatedAt = DateTime.Now.AddDays(-1),
                ReadStatus = false,
                Source = "Test"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(sender1);
            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();

            var result = await notificationService.GetAllNotifications("trainer-id-2");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReceiverProfilePicture, Is.EqualTo("trainer2-profile.jpg"));
            Assert.That(result.ReceiverEmail, Is.EqualTo("trainer2@example.com"));
            Assert.That(result.RecieverFirstName, Is.EqualTo("Петър"));
            Assert.That(result.RecieverLastName, Is.EqualTo("Треньорски"));
        }

        [Test]
        public async Task GetAllNotifications_WithInvalidTrainerId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await notificationService.GetAllNotifications("non-existent-trainer-id")
            );
        }
        [Test]
        public async Task GetAllNotificationsForUser_WithValidData_ReturnsCorrectViewModel()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-1",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "user-profile.jpg"
            };

            var trainerUser = new ApplicationUser
            {
                Id = "trainer-id-1",
                UserName = "trainer1@example.com",
                Email = "trainer1@example.com",
                FirstName = "Георги",
                LastName = "Тренев",
                ProfilePicture = "trainer-profile.jpg"
            };

            var adminUser = new ApplicationUser
            {
                Id = "admin-id",
                UserName = "hserev789@gmail.com",
                Email = "hserev789@gmail.com",
                FirstName = "Админ",
                LastName = "Админов",
                ProfilePicture = "admin-profile.jpg"
            };

            var trainer = new Trainer
            {
                Id = 1,
                UserId = "trainer-id-1",
                User = trainerUser,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image()
            };

            var notifications = new List<Notification>
    {
        new Notification
        {
            Id = 1,
            SenderId = "trainer-id-1",
            Sender = trainerUser,
            RecieverId = "user-id-1",
            Reciever = user,
            Message = "Непрочетено съобщение от треньор",
            CreatedAt = DateTime.Now.AddDays(-1),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 2,
            SenderId = "admin-id",
            Sender = adminUser,
            RecieverId = "user-id-1",
            Reciever = user,
            Message = "Непрочетено съобщение от админ",
            CreatedAt = DateTime.Now.AddDays(-2),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 3,
            SenderId = "trainer-id-1",
            Sender = trainerUser,
            RecieverId = "user-id-1",
            Reciever = user,
            Message = "Прочетено съобщение от треньор",
            CreatedAt = DateTime.Now.AddDays(-3),
            ReadStatus = true,
            Source = "Test"
        }
    };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(adminUser);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(notifications);
            await repository.SaveChangesAsync();

            var result = await notificationService.GetAllNotificationsForUser("user-id-1");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReceiverProfilePicture, Is.EqualTo("user-profile.jpg"));
            Assert.That(result.ReceiverEmail, Is.EqualTo("user1@example.com"));
            Assert.That(result.RecieverFirstName, Is.EqualTo("Иван"));
            Assert.That(result.RecieverLastName, Is.EqualTo("Петров"));

            Assert.That(result.UnReadNotifications, Is.Not.Null);
            Assert.That(result.UnReadNotifications.Count, Is.EqualTo(2));

            var trainerNotification = result.UnReadNotifications.FirstOrDefault(n => n.Id == 1);
            Assert.That(trainerNotification, Is.Not.Null);
            Assert.That(trainerNotification.Role, Is.EqualTo("Треньор"));

            var adminNotification = result.UnReadNotifications.FirstOrDefault(n => n.Id == 2);
            Assert.That(adminNotification, Is.Not.Null);
            Assert.That(adminNotification.Role, Is.EqualTo("Администратор"));

            Assert.That(result.ReadNotifications, Is.Not.Null);
            Assert.That(result.ReadNotifications.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetAllNotificationsForUser_WithInvalidId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await notificationService.GetAllNotificationsForUser("non-existent-user-id")
            );
        }

        [Test]
        public async Task MarkAllAsRead_WithUnreadNotifications_MarksAllAsRead()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-2",
                UserName = "user2@example.com",
                Email = "user2@example.com"
            };

            var sender = new ApplicationUser
            {
                Id = "sender-id-2",
                UserName = "sender2@example.com",
                Email = "sender2@example.com"
            };

            var notifications = new List<Notification>
    {
        new Notification
        {
            Id = 4,
            SenderId = "sender-id-2",
            Sender = sender,
            RecieverId = "user-id-2",
            Reciever = user,
            Message = "Непрочетено съобщение 1",
            CreatedAt = DateTime.Now.AddDays(-1),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 5,
            SenderId = "sender-id-2",
            Sender = sender,
            RecieverId = "user-id-2",
            Reciever = user,
            Message = "Непрочетено съобщение 2",
            CreatedAt = DateTime.Now.AddDays(-2),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 6,
            SenderId = "sender-id-2",
            Sender = sender,
            RecieverId = "user-id-2",
            Reciever = user,
            Message = "Вече прочетено съобщение",
            CreatedAt = DateTime.Now.AddDays(-3),
            ReadStatus = true,
            Source = "Test"
        }
    };

            await repository.AddAsync(user);
            await repository.AddAsync(sender);
            await repository.AddRangeAsync(notifications);
            await repository.SaveChangesAsync();

            await notificationService.MarkAllAsRead("user-id-2");

            var updatedNotifications = await repository.All<Notification>()
                .Where(n => n.RecieverId == "user-id-2")
                .ToListAsync();

            Assert.That(updatedNotifications.Count, Is.EqualTo(3));
            Assert.That(updatedNotifications.All(n => n.ReadStatus), Is.True);
        }

        [Test]
        public async Task MarkNotificationRead_WithUnreadNotification_MarksAsRead()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-3",
                UserName = "user3@example.com",
                Email = "user3@example.com"
            };

            var sender = new ApplicationUser
            {
                Id = "sender-id-3",
                UserName = "sender3@example.com",
                Email = "sender3@example.com"
            };

            var notification = new Notification
            {
                Id = 7,
                SenderId = "sender-id-3",
                Sender = sender,
                RecieverId = "user-id-3",
                Reciever = user,
                Message = "Тестово съобщение",
                CreatedAt = DateTime.Now,
                ReadStatus = false,
                Source = "Test"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(sender);
            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();

            await notificationService.MarkNotificationRead(7);

            var updatedNotification = await repository.GetByIdAsync<Notification>(7);
            Assert.That(updatedNotification.ReadStatus, Is.True);
        }

        [Test]
        public async Task GetNotificationById_WithValidId_ReturnsNotification()
        {
            var user = new ApplicationUser
            {
                Id = "user-id-4",
                UserName = "user4@example.com",
                Email = "user4@example.com"
            };

            var sender = new ApplicationUser
            {
                Id = "sender-id-4",
                UserName = "sender4@example.com",
                Email = "sender4@example.com"
            };

            var notification = new Notification
            {
                Id = 8,
                SenderId = "sender-id-4",
                Sender = sender,
                RecieverId = "user-id-4",
                Reciever = user,
                Message = "Тестово съобщение за получаване",
                CreatedAt = DateTime.Now,
                ReadStatus = false,
                Source = "Test"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(sender);
            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();

            var result = await notificationService.GetNotificationById(8);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(8));
            Assert.That(result.SenderId, Is.EqualTo("sender-id-4"));
            Assert.That(result.RecieverId, Is.EqualTo("user-id-4"));
            Assert.That(result.Message, Is.EqualTo("Тестово съобщение за получаване"));
            Assert.That(result.ReadStatus, Is.False);
        }

        [Test]
        public async Task GetNotificationById_WithInvalidId_ReturnsNull()
        {
            var result = await notificationService.GetNotificationById(999);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetAllNotificationsForDietitian_WithValidId_ReturnsCorrectViewModel()
        {
            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian-id",
                UserName = "dietitian@example.com",
                Email = "dietitian@example.com",
                FirstName = "Мария",
                LastName = "Диетологова",
                ProfilePicture = "dietitian-profile.jpg"
            };

            var clientUser = new ApplicationUser
            {
                Id = "client-id",
                UserName = "client@example.com",
                Email = "client@example.com",
                FirstName = "Петър",
                LastName = "Клиентов",
                ProfilePicture = "client-profile.jpg"
            };

            var adminUser = new ApplicationUser
            {
                Id = "admin-id-2",
                UserName = "hserev789@gmail.com",
                Email = "hserev789@gmail.com",
                FirstName = "Админ",
                LastName = "Админов",
                ProfilePicture = "admin-profile.jpg"
            };

            var dietitian = new Dietitian
            {
                Id = 1,
                UserId = "dietitian-id",
                User = dietitianUser,
                Experience = 3,
                Bio = "Професионален диетолог",
                SertificateImage = GenerateValidBase64Image()
            };

            var notifications = new List<Notification>
    {
        new Notification
        {
            Id = 9,
            SenderId = "client-id",
            Sender = clientUser,
            RecieverId = "dietitian-id",
            Reciever = dietitianUser,
            Message = "Непрочетено съобщение от клиент",
            CreatedAt = DateTime.Now.AddDays(-1),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 10,
            SenderId = "admin-id-2",
            Sender = adminUser,
            RecieverId = "dietitian-id",
            Reciever = dietitianUser,
            Message = "Непрочетено съобщение от админ",
            CreatedAt = DateTime.Now.AddDays(-2),
            ReadStatus = false,
            Source = "Test"
        },
        new Notification
        {
            Id = 11,
            SenderId = "client-id",
            Sender = clientUser,
            RecieverId = "dietitian-id",
            Reciever = dietitianUser,
            Message = "Прочетено съобщение от клиент",
            CreatedAt = DateTime.Now.AddDays(-3),
            ReadStatus = true,
            Source = "Test"
        }
    };

            await repository.AddAsync(dietitianUser);
            await repository.AddAsync(clientUser);
            await repository.AddAsync(adminUser);
            await repository.AddAsync(dietitian);
            await repository.AddRangeAsync(notifications);
            await repository.SaveChangesAsync();

            var result = await notificationService.GetAllNotificationsForDietitian("dietitian-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReceiverProfilePicture, Is.EqualTo("dietitian-profile.jpg"));
            Assert.That(result.ReceiverEmail, Is.EqualTo("dietitian@example.com"));
            Assert.That(result.RecieverFirstName, Is.EqualTo("Мария"));
            Assert.That(result.RecieverLastName, Is.EqualTo("Диетологова"));

            Assert.That(result.UnReadNotifications, Is.Not.Null);
            Assert.That(result.UnReadNotifications.Count, Is.EqualTo(2));

            var clientNotification = result.UnReadNotifications.FirstOrDefault(n => n.Id == 9);
            Assert.That(clientNotification, Is.Not.Null);
            Assert.That(clientNotification.Role, Is.EqualTo("Потребител"));

            var adminNotification = result.UnReadNotifications.FirstOrDefault(n => n.Id == 10);
            Assert.That(adminNotification, Is.Not.Null);
            Assert.That(adminNotification.Role, Is.EqualTo("Администратор"));
        }

        [Test]
        public async Task GetAllNotificationsForDietitian_WithInvalidId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await notificationService.GetAllNotificationsForDietitian("non-existent-dietitian-id")
            );
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
