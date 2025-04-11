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
    public class DietitianServiceTest
    {
        private IRepository repository;
        private IDietitianService calendarService;
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
            calendarService = new DietitianService(repository);

        }
        [Test]
        public async Task AllDietitianAsync_WithMultipleDietitians_ShouldReturnAll()
        {

            var testUser1 = new ApplicationUser
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile1.jpg"
            };

            var testUser2 = new ApplicationUser
            {
                Id = "user2",
                FirstName = "Jane",
                LastName = "Smith",
                ProfilePicture = "profile2.jpg"
            };

            applicationDbContext.Users.Add(testUser1);
            applicationDbContext.Users.Add(testUser2);

            var testDietitian1 = new Dietitian
            {
                Id = 1,
                Specialization = "Nutrition",
                Experience = 5,
                SertificateImage = "certificate1.jpg",
                SertificationDetails = "Certified Nutritionist",
                Bio = "Expert in nutrition",
                PhoneNumber = "1234567890",
                UserId = "user1",
                User = testUser1
            };

            var testDietitian2 = new Dietitian
            {
                Id = 2,
                Specialization = "Sports Nutrition",
                Experience = 8,
                SertificateImage = "certificate2.jpg",
                SertificationDetails = "Sports Nutrition Expert",
                Bio = "Specialized in athlete nutrition",
                PhoneNumber = "0987654321",
                UserId = "user2",
                User = testUser2
            };

            applicationDbContext.Dietitians.Add(testDietitian1);
            applicationDbContext.Dietitians.Add(testDietitian2);
            await applicationDbContext.SaveChangesAsync();

        
            var result = await calendarService.AllDietitianAsync();
            var dietitianList = result.ToList();

     
            Assert.That(dietitianList, Is.Not.Null);
            Assert.That(dietitianList.Count, Is.EqualTo(2));
            Assert.That(dietitianList.Any(d => d.Id == 1 && d.Specialization == "Nutrition"), Is.True);
            Assert.That(dietitianList.Any(d => d.Id == 2 && d.Specialization == "Sports Nutrition"), Is.True);
        }

        [Test]
        public async Task AllDietitianAsync_WithNoDietitians_ShouldReturnEmptyCollection()
        {

      
            var result = await calendarService.AllDietitianAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task AllDietitianAsync_ShouldMapPropertiesCorrectly()
        {

            var testUser = new ApplicationUser
            {
                Id = "user3",
                FirstName = "Robert",
                LastName = "Johnson",
                ProfilePicture = "robert_profile.jpg"
            };

            applicationDbContext.Users.Add(testUser);

            var testDietitian = new Dietitian
            {
                Id = 3,
                Specialization = "Детско хранене",
                Experience = 10,
                SertificateImage = "cert3.jpg",
                SertificationDetails = "Сертифициран диетолог",
                Bio = "Експерт по детско хранене",
                PhoneNumber = "5551234567",
                UserId = "user3",
                User = testUser
            };

            applicationDbContext.Dietitians.Add(testDietitian);
            await applicationDbContext.SaveChangesAsync();


            var result = await calendarService.AllDietitianAsync();
            var dietitian = result.FirstOrDefault(d => d.Id == 3);

            Assert.That(dietitian, Is.Not.Null);
            Assert.That(dietitian.FirstName, Is.EqualTo("Robert"));
            Assert.That(dietitian.LastName, Is.EqualTo("Johnson"));
            Assert.That(dietitian.ImageUrl, Is.EqualTo("robert_profile.jpg"));
            Assert.That(dietitian.Experience, Is.EqualTo(10));
            Assert.That(dietitian.Specialization, Is.EqualTo("Детско хранене"));
        }
        [Test]
        public async Task DetailsDietitianAsync_ShouldReturnCorrectDietitianDetails()
        {

            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian1",
                FirstName = "Ivan",
                LastName = "Petrov",
                ProfilePicture = "dietitian_profile.jpg",
                Email = "ivan.petrov@example.com",
                Height = 180,
                Weight = 80,
                Aim = "Help clients achieve their nutrition goals",
                ExperienceLevel = "Advanced"
            };

            var commentUser1 = new ApplicationUser
            {
                Id = "user1",
                FirstName = "Maria",
                LastName = "Ivanova",
                ProfilePicture = "user1_profile.jpg",
                Email = "maria@example.com",
                Height = 165,
                Weight = 60,
                Aim = "Lose weight",
                ExperienceLevel = "Beginner"
            };

            var commentUser2 = new ApplicationUser
            {
                Id = "user2",
                FirstName = "Petar",
                LastName = "Georgiev",
                ProfilePicture = "user2_profile.jpg",
                Email = "petar@example.com",
                Height = 175,
                Weight = 75,
                Aim = "Build muscle",
                ExperienceLevel = "Intermediate"
            };

            applicationDbContext.Users.Add(dietitianUser);
            applicationDbContext.Users.Add(commentUser1);
            applicationDbContext.Users.Add(commentUser2);


            var dietitian = new Dietitian
            {
                Id = 1,
                Specialization = "Спортно хранене",
                Experience = 7,
                SertificateImage = "certificate.jpg",
                SertificationDetails = "Сертифициран специалист по спортно хранене",
                Bio = "Работя с професионални атлети и любители спортисти вече 7 години",
                PhoneNumber = "0888123456",
                UserId = "dietitian1",
                User = dietitianUser
            };

            applicationDbContext.Dietitians.Add(dietitian);

            var comment1 = new UserComment
            {
                Id = 1,
                Rating = 5,
                Content = "Страхотен диетолог! Много ми помогна с хранителния режим.",
                ReceiverId = "dietitian1",
                Receiver = dietitianUser,
                SenderId = "user1",
                Sender = commentUser1
            };

            var comment2 = new UserComment
            {
                Id = 2,
                Rating = 4,
                Content = "Добри съвети, постигнах желаните резултати.",
                ReceiverId = "dietitian1",
                Receiver = dietitianUser,
                SenderId = "user2",
                Sender = commentUser2
            };

            applicationDbContext.UserComments.Add(comment1);
            applicationDbContext.UserComments.Add(comment2);

            await applicationDbContext.SaveChangesAsync();


            var result = await calendarService.DetailsDietitianAsync(1);


            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo("Ivan"));
            Assert.That(result.LastName, Is.EqualTo("Petrov"));
            Assert.That(result.Bio, Is.EqualTo("Работя с професионални атлети и любители спортисти вече 7 години"));
            Assert.That(result.SertificationImage, Is.EqualTo("certificate.jpg"));
            Assert.That(result.DietitianImage, Is.EqualTo("dietitian_profile.jpg"));
            Assert.That(result.SertificationDetails, Is.EqualTo("Сертифициран специалист по спортно хранене"));
            Assert.That(result.PhoneNumber, Is.EqualTo("0888123456"));
            Assert.That(result.Specialization, Is.EqualTo("Спортно хранене"));
            Assert.That(result.Email, Is.EqualTo("ivan.petrov@example.com"));


            Assert.That(result.Comments, Is.Not.Null);
            Assert.That(result.Comments.Count, Is.EqualTo(2));

            var commentsList = result.Comments.ToList();

            var firstComment = commentsList.FirstOrDefault(c => c.Content == "Страхотен диетолог! Много ми помогна с хранителния режим.");
            Assert.That(firstComment, Is.Not.Null);
            Assert.That(firstComment.Rating, Is.EqualTo(5));
            Assert.That(firstComment.SenderName, Is.EqualTo("Maria Ivanova"));


            var secondComment = commentsList.FirstOrDefault(c => c.Content == "Добри съвети, постигнах желаните резултати.");
            Assert.That(secondComment, Is.Not.Null);
            Assert.That(secondComment.Rating, Is.EqualTo(4));
            Assert.That(secondComment.SenderName, Is.EqualTo("Petar Georgiev"));
        }

        [Test]
        public async Task DetailsDietitianAsync_WithNonExistentId_ShouldThrowException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await calendarService.DetailsDietitianAsync(999));
        }

        [Test]
        public async Task DetailsDietitianAsync_WithNoComments_ShouldReturnEmptyCommentsList()
        {

            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian2",
                FirstName = "Nikolay",
                LastName = "Dimitrov",
                ProfilePicture = "nikolay_profile.jpg",
                Email = "nikolay@example.com",
                Height = 185,
                Weight = 85,
                Aim = "Помагам на клиентите с балансирано хранене",
                ExperienceLevel = "Expert"
            };

            applicationDbContext.Users.Add(dietitianUser);

            var dietitian = new Dietitian
            {
                Id = 2,
                Specialization = "Клинично хранене",
                Experience = 10,
                SertificateImage = "nikolay_cert.jpg",
                SertificationDetails = "Магистър по хранителни науки",
                Bio = "Специализирам в хранителни режими за хора с хронични заболявания",
                PhoneNumber = "0899123456",
                UserId = "dietitian2",
                User = dietitianUser
            };

            applicationDbContext.Dietitians.Add(dietitian);
            await applicationDbContext.SaveChangesAsync();


            var result = await calendarService.DetailsDietitianAsync(2);


            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(2));
            Assert.That(result.FirstName, Is.EqualTo("Nikolay"));
            Assert.That(result.LastName, Is.EqualTo("Dimitrov"));


            Assert.That(result.Comments, Is.Not.Null);
            Assert.That(result.Comments.Count, Is.EqualTo(0));
        }
        [Test]
        public async Task GetDetailsDietitianViewModelForUser_ShouldReturnCorrectViewModel()
        { 
            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian1",
                FirstName = "Ивана",
                LastName = "Димитрова",
                ProfilePicture = "ivana_profile.jpg",
                Email = "ivana@example.com",
                Height = 168,
                Weight = 60,
                Aim = "Помощ на клиенти с хранителни проблеми",
                ExperienceLevel = "Advanced"
            };

            var currentUser = new ApplicationUser
            {
                Id = "current_user",
                FirstName = "Георги",
                LastName = "Петров",
                ProfilePicture = "georgi_profile.jpg",
                Email = "georgi@example.com",
                Height = 182,
                Weight = 85,
                Aim = "Подобряване на мускулната маса",
                ExperienceLevel = "Intermediate"
            };

            var otherUser = new ApplicationUser
            {
                Id = "other_user",
                FirstName = "Мария",
                LastName = "Иванова",
                ProfilePicture = "maria_profile.jpg",
                Email = "maria@example.com",
                Height = 165,
                Weight = 55,
                Aim = "Отслабване",
                ExperienceLevel = "Beginner"
            };

            applicationDbContext.Users.Add(dietitianUser);
            applicationDbContext.Users.Add(currentUser);
            applicationDbContext.Users.Add(otherUser);


            var dietitian = new Dietitian
            {
                Id = 1,
                Specialization = "Вегетарианско хранене",
                Experience = 5,
                SertificateImage = "ivana_cert.jpg",
                SertificationDetails = "Сертифициран вегетариански диетолог",
                Bio = "Специалист по вегетарианско и веганско хранене с 5 години опит",
                PhoneNumber = "0877123456",
                UserId = "dietitian1",
                User = dietitianUser
            };

            applicationDbContext.Dietitians.Add(dietitian);


            var commentFromCurrentUser = new UserComment
            {
                Id = 1,
                Rating = 5,
                Content = "Изключително полезни съвети за моя вегетариански режим!",
                ReceiverId = "dietitian1",
                Receiver = dietitianUser,
                SenderId = "current_user",
                Sender = currentUser
            };

            var commentFromOtherUser = new UserComment
            {
                Id = 2,
                Rating = 4,
                Content = "Добри съвети за веганско хранене.",
                ReceiverId = "dietitian1",
                Receiver = dietitianUser,
                SenderId = "other_user",
                Sender = otherUser
            };

            applicationDbContext.UserComments.Add(commentFromCurrentUser);
            applicationDbContext.UserComments.Add(commentFromOtherUser);

            await applicationDbContext.SaveChangesAsync();


            var result = await calendarService.GetDetailsDietitianViewModelForUser(1, "current_user");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.DietitianId, Is.EqualTo(1));
            Assert.That(result.UserId, Is.EqualTo("current_user"));
            Assert.That(result.FirstName, Is.EqualTo("Ивана"));
            Assert.That(result.LastName, Is.EqualTo("Димитрова"));
            Assert.That(result.Bio, Is.EqualTo("Специалист по вегетарианско и веганско хранене с 5 години опит"));
            Assert.That(result.SertificationImage, Is.EqualTo("ivana_cert.jpg"));
            Assert.That(result.DietitianImage, Is.EqualTo("ivana_profile.jpg"));
            Assert.That(result.SertificationDetails, Is.EqualTo("Сертифициран вегетариански диетолог"));
            Assert.That(result.PhoneNumber, Is.EqualTo("0877123456"));
            Assert.That(result.Specialization, Is.EqualTo("Вегетарианско хранене"));
            Assert.That(result.Email, Is.EqualTo("ivana@example.com"));

            Assert.That(result.Comments, Is.Not.Null);
            Assert.That(result.Comments.Count, Is.EqualTo(2));

            var currentUserComment = result.Comments.FirstOrDefault(c => c.Content == "Изключително полезни съвети за моя вегетариански режим!");
            Assert.That(currentUserComment, Is.Not.Null);
            Assert.That(currentUserComment.Rating, Is.EqualTo(5));
            Assert.That(currentUserComment.IsMine, Is.True);
            Assert.That(currentUserComment.SenderName, Is.EqualTo("Георги Петров"));
            Assert.That(currentUserComment.Email, Is.EqualTo("georgi@example.com"));
            Assert.That(currentUserComment.ProfilePicture, Is.EqualTo("georgi_profile.jpg"));


            var otherUserComment = result.Comments.FirstOrDefault(c => c.Content == "Добри съвети за веганско хранене.");
            Assert.That(otherUserComment, Is.Not.Null);
            Assert.That(otherUserComment.Rating, Is.EqualTo(4));
            Assert.That(otherUserComment.IsMine, Is.False);
            Assert.That(otherUserComment.SenderName, Is.EqualTo("Мария Иванова"));
            Assert.That(otherUserComment.Email, Is.EqualTo("maria@example.com"));
            Assert.That(otherUserComment.ProfilePicture, Is.EqualTo("maria_profile.jpg"));
        }

        [Test]
        public async Task GetDetailsDietitianViewModelForUser_WithNonExistentDietitian_ShouldReturnNull()
        {

            var userId = "some_user_id";


            var result = await calendarService.GetDetailsDietitianViewModelForUser(999, userId);


            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetDetailsDietitianViewModelForUser_WithNoComments_ShouldReturnEmptyCommentsList()
        {

            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian2",
                FirstName = "Стоян",
                LastName = "Стоянов",
                ProfilePicture = "stoyan_profile.jpg",
                Email = "stoyan@example.com",
                Height = 180,
                Weight = 80,
                Aim = "Консултиране за балансирано хранене",
                ExperienceLevel = "Expert"
            };

            applicationDbContext.Users.Add(dietitianUser);

            var dietitian = new Dietitian
            {
                Id = 2,
                Specialization = "Балансирано хранене",
                Experience = 8,
                SertificateImage = "stoyan_cert.jpg",
                SertificationDetails = "Диплома за хранителни науки",
                Bio = "Специалист по балансирано хранене за всяка възраст",
                PhoneNumber = "0866123456",
                UserId = "dietitian2",
                User = dietitianUser
            };

            var currentUser = new ApplicationUser
            {
                Id = "user_no_comments",
                FirstName = "Петър",
                LastName = "Иванов",
                ProfilePicture = "petar_profile.jpg",
                Email = "petar@example.com",
                Height = 175,
                Weight = 75,
                Aim = "Здравословно хранене",
                ExperienceLevel = "Beginner"
            };

            applicationDbContext.Users.Add(currentUser);
            applicationDbContext.Dietitians.Add(dietitian);
            await applicationDbContext.SaveChangesAsync();

   
            var result = await calendarService.GetDetailsDietitianViewModelForUser(2, "user_no_comments");


            Assert.That(result, Is.Not.Null);
            Assert.That(result.DietitianId, Is.EqualTo(2));
            Assert.That(result.FirstName, Is.EqualTo("Стоян"));
            Assert.That(result.LastName, Is.EqualTo("Стоянов"));


            Assert.That(result.Comments, Is.Not.Null);
            Assert.That(result.Comments.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetDetailsDietitianViewModelForUser_ShouldCorrectlyIdentifyUserComments()
        {
   
            var dietitianUser = new ApplicationUser
            {
                Id = "dietitian3",
                FirstName = "Анна",
                LastName = "Димитрова",
                ProfilePicture = "anna_profile.jpg",
                Email = "anna@example.com",
                Height = 165,
                Weight = 58,
                Aim = "Помощ на клиенти със специални диети",
                ExperienceLevel = "Advanced"
            };

            var user1 = new ApplicationUser
            {
                Id = "user1_multiple_comments",
                FirstName = "Иван",
                LastName = "Петров",
                ProfilePicture = "ivan_profile.jpg",
                Email = "ivan@example.com",
                Height = 185,
                Weight = 90,
                Aim = "Спортно хранене",
                ExperienceLevel = "Intermediate"
            };

            var user2 = new ApplicationUser
            {
                Id = "user2_multiple_comments",
                FirstName = "Елена",
                LastName = "Георгиева",
                ProfilePicture = "elena_profile.jpg",
                Email = "elena@example.com",
                Height = 170,
                Weight = 62,
                Aim = "Отслабване",
                ExperienceLevel = "Beginner"
            };

            applicationDbContext.Users.AddRange(dietitianUser, user1, user2);

            var dietitian = new Dietitian
            {
                Id = 3,
                Specialization = "Клинично хранене",
                Experience = 10,
                SertificateImage = "anna_cert.jpg",
                SertificationDetails = "Магистър по диетология",
                Bio = "Специалист с дългогодишен опит в клиничното хранене",
                PhoneNumber = "0855123456",
                UserId = "dietitian3",
                User = dietitianUser
            };

            applicationDbContext.Dietitians.Add(dietitian);

 
            var comments = new List<UserComment>
    {
        new UserComment
        {
            Id = 10,
            Rating = 5,
            Content = "Отлични препоръки за моята спортна диета!",
            ReceiverId = "dietitian3",
            Receiver = dietitianUser,
            SenderId = "user1_multiple_comments",
            Sender = user1
        },
        new UserComment
        {
            Id = 11,
            Rating = 5,
            Content = "Втора консултация също беше много полезна.",
            ReceiverId = "dietitian3",
            Receiver = dietitianUser,
            SenderId = "user1_multiple_comments",
            Sender = user1
        },
        new UserComment
        {
            Id = 12,
            Rating = 4,
            Content = "Доволна съм от диетата за отслабване.",
            ReceiverId = "dietitian3",
            Receiver = dietitianUser,
            SenderId = "user2_multiple_comments",
            Sender = user2
        }
    };

            applicationDbContext.UserComments.AddRange(comments);
            await applicationDbContext.SaveChangesAsync();

   
            var resultUser1 = await calendarService.GetDetailsDietitianViewModelForUser(3, "user1_multiple_comments");

        
            Assert.That(resultUser1, Is.Not.Null);
            Assert.That(resultUser1.Comments.Count, Is.EqualTo(3));


            var user1Comments = resultUser1.Comments.Where(c => c.SenderName == "Иван Петров").ToList();
            Assert.That(user1Comments.Count, Is.EqualTo(2));
            Assert.That(user1Comments.All(c => c.IsMine), Is.True);

            var user2CommentInUser1View = resultUser1.Comments.FirstOrDefault(c => c.SenderName == "Елена Георгиева");
            Assert.That(user2CommentInUser1View, Is.Not.Null);
            Assert.That(user2CommentInUser1View.IsMine, Is.False);

            var resultUser2 = await calendarService.GetDetailsDietitianViewModelForUser(3, "user2_multiple_comments");


            Assert.That(resultUser2, Is.Not.Null);
            Assert.That(resultUser2.Comments.Count, Is.EqualTo(3));

            var user2Comments = resultUser2.Comments.Where(c => c.SenderName == "Елена Георгиева").ToList();
            Assert.That(user2Comments.Count, Is.EqualTo(1));
            Assert.That(user2Comments.All(c => c.IsMine), Is.True);


            var user1CommentsInUser2View = resultUser2.Comments.Where(c => c.SenderName == "Иван Петров").ToList();
            Assert.That(user1CommentsInUser2View.Count, Is.EqualTo(2));
            Assert.That(user1CommentsInUser2View.All(c => !c.IsMine), Is.True);
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();

        }
    }
}
