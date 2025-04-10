using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestAiFiness.ServicesTests
{
    [TestFixture]
    public class TrainingPlanServiceTest
    {
        private IRepository repository;
        private ITrainingPlanService trainingPlanService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HouseDB_" + Guid.NewGuid())
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions,false);
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            repository = new Repository(applicationDbContext);
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            var hubContextMock = new Mock<IHubContext<NotificationHub>>();
            var notificationServiceMock = new Mock<INotificationService>();

            trainingPlanService = new TrainingPlanService(
                repository,
                hostingEnvironmentMock.Object,
                hubContextMock.Object,
                notificationServiceMock.Object
            );

        }
        [Test]
        public async Task CreateTrainingPlan_WithoutImage_SuccessfullyCreatesPlanAndUpdatesRequest()
        {

            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                Aim = "Искам да покача своята мускулна маса.Целта ми е да стана около 95 килограма,но да кача само мускулна маса.",
                ExperienceLevel = "Начинаещ",
                SecurityStamp = "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f",
                ConcurrencyStamp = "ddd19b43-78e7-4f76-ada7-a863c26dda43",
            };
            var
             user1 = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "https://nicksfitstyle.com/wp-content/uploads/img12-scaled.jpg",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
                Height = 203,
                Weight = 82,
                ExperienceLevel = "Напреднал",
                SecurityStamp = "d258ec24-1129-4a44-84b4-4597aecc18e9",
                ConcurrencyStamp = "ec2261ab-a653-4698-bbf8-03187c3e1877",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Светослав Ковачев е фитнес треньор, който е преминал през истинска трансформация. В началото на своето фитнес пътуване той не е имал перфектно тяло, а напротив – борел се е с наднормено тегло и липса на мотивация. Със силна воля и постоянство, той успява да постигне значителни резултати и сега е не само преобразен физически, но и психически.\r\n\r\nДнес Светослав е сертифициран треньор с опит и страст за това, което прави. Неговата цел е да помага на хората да постигнат не само физическите си цели, но и да изградят здравословни навици, които да продължат през целия живот. Той вярва, че промяната е възможна за всеки, стига да има правилния подход и подкрепа.\r\n\r\n\r\n\r\n\r\n",
                PhoneNumber = "0895124157",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };
            var request = new RequestsToCoach
            {
                Id = 1,
                IsAnswered = false,
                UserId = user.Id,
                HealthStatus = "Супер съм",
                Target = "да отслабна",
                Date = DateTime.Now,
                TrainingBackground = "Тренирал съм",
                TrainingPreferences = "Тежести",
                TrainingCommitment = "5 дена",
                PicturesOfPersons = new List<string>() { "picture1,picture2" },
                User = user,
                TrainerId = trainer.Id,
                Trainer = trainer
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(request);
            await repository.SaveChangesAsync();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns("C:/FakeWebRoot");
            hostingEnvironmentMock.Setup(x => x.ContentRootPath).Returns("C:/FakeContentRoot");
        
            var defaultImageBytes = new byte[] { 0, 0, 0 };
            trainingPlanService = new TrainingPlanService(
                repository,
                hostingEnvironmentMock.Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                new Mock<INotificationService>().Object
            );
            var memoryStream = new MemoryStream(new byte[] { 1, 2, 3 });
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                    .Callback<Stream, CancellationToken>((s, ct) => memoryStream.CopyTo(s));
            fileMock.Setup(f => f.Length).Returns(memoryStream.Length);

            var model = new CreateTraingPlanViewModel
            {
                TrainingPlanName = "Beginner Plan",
                SurveyId = request.Id,
                UserId = user.Id,
                TrainingPlanDescription = "A plan for beginners",
                ImageUrl = fileMock.Object
            };

          
            await trainingPlanService.CreateTrainigPlan(user.Id, trainer.UserId, model, 1);

    
            var dbTrainingPlan = await repository.All<TrainingPlan>().FirstOrDefaultAsync();
            var dbRequest = await repository.GetByIdAsync<RequestsToCoach>(1);

            Assert.That(dbTrainingPlan, Is.Not.Null);
            Assert.That(dbTrainingPlan.Name, Is.EqualTo("Beginner Plan"));
            Assert.That(dbTrainingPlan.Description, Is.EqualTo("A plan for beginners"));
            Assert.That(dbTrainingPlan.UserId, Is.EqualTo(user.Id));
            Assert.That(dbTrainingPlan.User, Is.Not.Null);
            Assert.That(dbTrainingPlan.CreatedById, Is.EqualTo(trainer.Id));
            Assert.That(dbTrainingPlan.Trainer, Is.Not.Null);
            Assert.That(dbTrainingPlan.IsActive, Is.False);
            Assert.That(dbTrainingPlan.ImageUrl, Is.Not.Null); 
            Assert.That(dbRequest.IsAnswered, Is.True);
        }

        [Test]
        public async Task CreateTrainingPlan_WithInvalidRequestId_CreatesPlanButDoesNotUpdateRequest()
        {
     
            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                Aim = "Искам да покача своята мускулна маса.Целта ми е да стана около 95 килограма,но да кача само мускулна маса.",
                ExperienceLevel = "Начинаещ",
                SecurityStamp = "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f",
                ConcurrencyStamp = "ddd19b43-78e7-4f76-ada7-a863c26dda43",
            };

            
            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "https://nicksfitstyle.com/wp-content/uploads/img12-scaled.jpg",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
                Height = 203,
                Weight = 82,
                ExperienceLevel = "Напреднал",
                SecurityStamp = "d258ec24-1129-4a44-84b4-4597aecc18e9",
                ConcurrencyStamp = "ec2261ab-a653-4698-bbf8-03187c3e1877",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Светослав Ковачев е фитнес треньор, който е преминал през истинска трансформация. В началото на своето фитнес пътуване той не е имал перфектно тяло, а напротив – борел се е с наднормено тегло и липса на мотивация. Със силна воля и постоянство, той успява да постигне значителни резултати и сега е не само преобразен физически, но и психически.",
                PhoneNumber = "0895124157",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS). Специализирам в създаването на тренировъчни програми, които помагат за изграждане на сила и мускулна маса. Заедно ще постигнем вашите фитнес цели!",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns("C:/FakeWebRoot");
            hostingEnvironmentMock.Setup(x => x.ContentRootPath).Returns("C:/FakeContentRoot");

            trainingPlanService = new TrainingPlanService(
                repository,
                hostingEnvironmentMock.Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                new Mock<INotificationService>().Object
            );

            var model = new CreateTraingPlanViewModel
            {
                TrainingPlanName = "Test Plan",
                TrainingPlanDescription = "A test plan",
                UserId = user.Id,
                ImageUrl = null
            };


            Assert.ThrowsAsync<NullReferenceException>(async () =>
            await trainingPlanService.CreateTrainigPlan(user.Id, trainer.UserId, model, 999)
          );

        }

        [Test]
        public async Task GetAllTrainingPlanAsync_WithValidUserId_ReturnsTrainerPlans()
        {

           
            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "https://nicksfitstyle.com/wp-content/uploads/img12-scaled.jpg",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
                Height = 203,
                Weight = 82,
                ExperienceLevel = "Напреднал",
                SecurityStamp = "d258ec24-1129-4a44-84b4-4597aecc18e9",
                ConcurrencyStamp = "ec2261ab-a653-4698-bbf8-03187c3e1877",
            };

           
            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Светослав Ковачев е фитнес треньор, който е преминал през истинска трансформация.",
                PhoneNumber = "0895124157",
                SertificationDetails = "Здравейте, аз съм сертифициран специалист по сила и кондиция (CSCS).",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

           
            var clientUser = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                Aim = "Искам да покача своята мускулна маса.Целта ми е да стана около 95 килограма,но да кача само мускулна маса.",
                ExperienceLevel = "Начинаещ",
                SecurityStamp = "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f",
                ConcurrencyStamp = "ddd19b43-78e7-4f76-ada7-a863c26dda43",
            };

        
            var trainingPlans = new List<TrainingPlan>
    {
        new TrainingPlan
        {
            Id = 1,
            Name = "План за начинаещи",
            Description = "Основен план за начинаещи",
            ImageUrl = GenerateValidBase64Image(),
            UserId = clientUser.Id,
            User = clientUser,
            CreatedById = trainer.Id,
            Trainer = trainer,
            IsActive = false 
        },
        new TrainingPlan
        {
            Id = 2,
            Name = "План за напреднали",
            Description = "Интензивен план за напреднали",
            ImageUrl = GenerateValidBase64Image(),
            UserId = clientUser.Id,
            User = clientUser,
            CreatedById = trainer.Id,
            Trainer = trainer,
            IsActive = false 
        },
        new TrainingPlan
        {
            Id = 3,
            Name = "Активен план",
            Description = "Този план е активен",
            ImageUrl = GenerateValidBase64Image(),
            UserId = clientUser.Id,
            User = clientUser,
            CreatedById = trainer.Id,
            Trainer = trainer,
            IsActive = true 
        }
    };

         
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(clientUser);
            await repository.AddAsync(trainer);
            await repository.AddRangeAsync(trainingPlans);
            await repository.SaveChangesAsync();

            
            var result = await trainingPlanService.GetAllTrainingPlanAsync(trainer.UserId);

       
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2), "Трябва да върне само 2 плана (неактивните)");

            var firstPlan = result.FirstOrDefault(p => p.Id == 1);
            var secondPlan = result.FirstOrDefault(p => p.Id == 2);

            Assert.That(firstPlan, Is.Not.Null, "Първият план трябва да е в резултата");
            Assert.That(secondPlan, Is.Not.Null, "Вторият план трябва да е в резултата");

            Assert.That(firstPlan.TitleOfTriningPlan, Is.EqualTo("План за начинаещи"));
            Assert.That(firstPlan.DescriptionOfTriningPlan, Is.EqualTo("Основен план за начинаещи"));

            Assert.That(secondPlan.TitleOfTriningPlan, Is.EqualTo("План за напреднали"));
            Assert.That(secondPlan.DescriptionOfTriningPlan, Is.EqualTo("Интензивен план за напреднали"));

           
            Assert.That(result.Any(p => p.TitleOfTriningPlan == "Активен план"), Is.False, "Активният план не трябва да бъде върнат");
        }

        [Test]
        public async Task GetAllTrainingPlanAsync_WithInvalidUserId_ThrowsInvalidOperationException()
        {
          
            var trainerUser = new ApplicationUser()
            {
                Id = "valid-user-id",
                UserName = "validuser",
                Email = "valid@abv.bg",
                FirstName = "Valid",
                LastName = "User",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Фитнес",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                Bio = "Валиден треньор",
                UserId = "valid-user-id"
            };

            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            string invalidUserId = "non-existent-user-id";

 
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.GetAllTrainingPlanAsync(invalidUserId)
            );
        }



        [Test]
        public async Task GetTrainingPlanModelsForDetails_WithValidId_ReturnsCorrectViewModel()
        {
       
            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                ExperienceLevel = "Начинаещ",
            };

          
            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "defaultImage",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0895124157",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

    
            var exercise1 = new Exercise()
            {
                Id = 1,
                Name = "Клек",
                Description = "Класическо упражнение за крака",
                ImageUrl = GenerateValidBase64Image(),
                VideoUrl = "https://www.youtube.com/watch?v=example1",
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            var exercise2 = new Exercise()
            {
                Id = 2,
                Name = "Набиране",
                Description = "Упражнение за гръб",
                ImageUrl = GenerateValidBase64Image(),
                VideoUrl = "https://www.youtube.com/watch?v=example2",
                MuscleGroup = "Гръб",
                DifficultyLevel = "Трудно"
            };

     
            var workout = new Workout()
            {
                Id = 1,
                Title = "Тренировка за крака и гръб",
                DayOfWeek = "Понеделник",
                ImageUrl = GenerateValidBase64Image(),
                DificultyLevel = "Гръб",
                MuscleGroup = "Трудно",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

       
            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Комплексна програма",
                Description = "Програма за цяло тяло",
                ImageUrl = GenerateValidBase64Image(),
                UserId = user.Id,
                User = user,
                CreatedById = trainer.Id,
                Trainer = trainer,
                IsActive = false,
                TrainingPlanWorkouts = new List<TrainingPlanWorkout>()
            };


            var workoutExercise1 = new WorkoutsExercise()
            {
                WorkoutId = workout.Id,
                Workout = workout,
                ExcersiceId = exercise1.Id,
                Exercise = exercise1
            };

            var workoutExercise2 = new WorkoutsExercise()
            {
                WorkoutId = workout.Id,
                Workout = workout,
                ExcersiceId = exercise2.Id,
                Exercise = exercise2
            };

            workout.WorkoutsExercises.Add(workoutExercise1);
            workout.WorkoutsExercises.Add(workoutExercise2);

      
            var trainingPlanWorkout = new TrainingPlanWorkout()
            {
                TrainingPlanId = trainingPlan.Id,
                TrainingPlan = trainingPlan,
                WorkoutId = workout.Id,
                Workout = workout
            };

            trainingPlan.TrainingPlanWorkouts.Add(trainingPlanWorkout);

           
            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise1);
            await repository.AddAsync(exercise2);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workoutExercise1);
            await repository.AddAsync(workoutExercise2);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

           
            var result = await trainingPlanService.GetTrainingPlanModelsForDetails(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Комплексна програма"));
            Assert.That(result.Description, Is.EqualTo("Програма за цяло тяло"));
            Assert.That(result.ImageUrl, Is.Not.Null);

            Assert.That(result.Workouts, Is.Not.Null);
            Assert.That(result.Workouts.Count, Is.EqualTo(1));
            Assert.That(result.Workouts[0].Title, Is.EqualTo("Тренировка за крака и гръб"));
            Assert.That(result.Workouts[0].DayOfWeek, Is.EqualTo("Понеделник"));

        
            Assert.That(result.Workouts[0].Exercises, Is.Not.Null);
            Assert.That(result.Workouts[0].Exercises.Count, Is.EqualTo(2));

            
            var firstExercise = result.Workouts[0].Exercises.FirstOrDefault(e => e.Id == 1);
            Assert.That(firstExercise, Is.Not.Null);
            Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
            Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));

           
            var secondExercise = result.Workouts[0].Exercises.FirstOrDefault(e => e.Id == 2);
            Assert.That(secondExercise, Is.Not.Null);
            Assert.That(secondExercise.Name, Is.EqualTo("Набиране"));
            Assert.That(secondExercise.MuscleGroup, Is.EqualTo("Гръб"));
        }

        [Test]
        public async Task GetTrainingPlanModelsForDetails_WithInvalidId_ReturnsNull()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                ProfilePicture = "defaultImage",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Test",
                LastName = "User",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Test",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-user-id"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            int invalidId = 999;

            var result = await trainingPlanService.GetTrainingPlanModelsForDetails(invalidId);

        }
        [Test]
        public async Task GetTrainingPlanModelsForDetailsFromExercise_WithValidExerciseId_ReturnsCorrectViewModel()
        {

            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                ExperienceLevel = "Начинаещ",
            };


            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "defaultImage",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0895124157",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

    
            var exercise1 = new Exercise()
            {
                Id = 1,
                Name = "Клек",
                Description = "Класическо упражнение за крака",
                ImageUrl = GenerateValidBase64Image(),
                VideoUrl = "https://www.youtube.com/watch?v=example1",
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            var exercise2 = new Exercise()
            {
                Id = 2,
                Name = "Набиране",
                Description = "Упражнение за гръб",
                ImageUrl = GenerateValidBase64Image(),
                VideoUrl = "https://www.youtube.com/watch?v=example2",
                MuscleGroup = "Гръб",
                DifficultyLevel = "Трудно"
            };


            var workout = new Workout()
            {
                Id = 1,
                Title = "Тренировка за крака и гръб",
                DayOfWeek = "Понеделник",
                ImageUrl = GenerateValidBase64Image(),
                DificultyLevel = "Средно",
                MuscleGroup = "Комбинирана",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

         
            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Комплексна програма",
                Description = "Програма за цяло тяло",
                ImageUrl = GenerateValidBase64Image(),
                UserId = user.Id,
                User = user,
                CreatedById = trainer.Id,
                Trainer = trainer,
                IsActive = false,
                TrainingPlanWorkouts = new List<TrainingPlanWorkout>()
            };


            var workoutExercise1 = new WorkoutsExercise()
            {
                WorkoutId = workout.Id,
                Workout = workout,
                ExcersiceId = exercise1.Id,
                Exercise = exercise1
            };

            var workoutExercise2 = new WorkoutsExercise()
            {
                WorkoutId = workout.Id,
                Workout = workout,
                ExcersiceId = exercise2.Id,
                Exercise = exercise2
            };

            workout.WorkoutsExercises.Add(workoutExercise1);
            workout.WorkoutsExercises.Add(workoutExercise2);


            var trainingPlanWorkout = new TrainingPlanWorkout()
            {
                TrainingPlanId = trainingPlan.Id,
                TrainingPlan = trainingPlan,
                WorkoutId = workout.Id,
                Workout = workout
            };

            workout.TrainingPlanWorkouts = new List<TrainingPlanWorkout> { trainingPlanWorkout };
            trainingPlan.TrainingPlanWorkouts.Add(trainingPlanWorkout);

       
            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise1);
            await repository.AddAsync(exercise2);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workoutExercise1);
            await repository.AddAsync(workoutExercise2);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

           
            var result = await trainingPlanService.GetTrainingPlanModelsForDetailsFromExercise(exercise1.Id);

      
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(trainingPlan.Id));
            Assert.That(result.Name, Is.EqualTo("Комплексна програма"));
            Assert.That(result.Description, Is.EqualTo("Програма за цяло тяло"));

        }

        [Test]
        public async Task GetTrainingPlanModelsForDetailsFromExercise_WithInvalidExerciseId_ReturnsNull()
        {
     
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Test",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-user-id"
            };


            var validExercise = new Exercise()
            {
                Id = 10,
                Name = "Валидно упражнение без връзки",
                Description = "Това упражнение съществува, но не е свързано с тренировка",
                MuscleGroup = "Тест",
                ImageUrl = "gasgsaga",
                VideoUrl = "httpsqerqr",
                DifficultyLevel = "Лесно"
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(validExercise);
            await repository.SaveChangesAsync();

            int nonExistentExerciseId = 999;
            var result1 = await trainingPlanService.GetTrainingPlanModelsForDetailsFromExercise(nonExistentExerciseId);

            var result2 = await trainingPlanService.GetTrainingPlanModelsForDetailsFromExercise(validExercise.Id);

            Assert.That(result1, Is.Null, "Методът трябва да върне null при невалидно ID на упражнение");
            Assert.That(result2, Is.Null, "Методът трябва да върне null при упражнение без връзка с тренировка");
        }

        [Test]
        public async Task GetTrainingPlanModelsForDetailsFromExercise_WithExerciseInWorkoutButNoTrainingPlan_ReturnsNull()
        {
   
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Test",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-user-id"
            };

            var exercise = new Exercise()
            {
                Id = 20,
                Name = "Тестово упражнение",
                Description = "Упражнение свързано с тренировка, но без план",
                ImageUrl = GenerateValidBase64Image(),
                VideoUrl = "httpswecs",
                MuscleGroup = "Тест",
                DifficultyLevel = "Средно"
            };

            var workout = new Workout()
            {
                Id = 20,
                Title = "Тестова тренировка без план",
                DayOfWeek = "Вторник",
                ImageUrl = GenerateValidBase64Image(),
                DificultyLevel = "Лесно",
                MuscleGroup = "Тест",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workoutExercise = new WorkoutsExercise()
            {
                WorkoutId = workout.Id,
                Workout = workout,
                ExcersiceId = exercise.Id,
                Exercise = exercise
            };

            workout.WorkoutsExercises.Add(workoutExercise);

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise);
            await repository.AddAsync(workout);
            await repository.AddAsync(workoutExercise);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetTrainingPlanModelsForDetailsFromExercise(exercise.Id);

            Assert.That(result, Is.Null, "Методът трябва да върне null при упражнение в тренировка без тренировъчен план");
        }
        [Test]
        public async Task EditAsync_WithValidIdAndData_UpdatesTrainingPlan()
        {

            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                ExperienceLevel = "Начинаещ",
            };

         
            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "defaultImage",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0895124157",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

  
            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Стар план",
                Description = "Старо описание",
                ImageUrl = "/img/exercises/old-image.jpg",
                UserId = user.Id,
                User = user,
                CreatedById = trainer.Id,
                Trainer = trainer,
                IsActive = false,
            };

     
            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

          
            var memoryStream = new MemoryStream(new byte[] { 1, 2, 3 });
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.FileName).Returns("test-image.jpg");
            fileMock.Setup(f => f.Length).Returns(memoryStream.Length);
            fileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
                    .Callback<Stream, CancellationToken>((s, ct) => memoryStream.CopyTo(s));

       
            var model = new EditTrainingPlanViewModel
            {
                TrainingPlanName = "Нов план",
                TrainingPlanDescription = "Ново описание",
                NewImageUrl = fileMock.Object
            };

          
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            var fakeWebRootPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(fakeWebRootPath);
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns(fakeWebRootPath);

          
            trainingPlanService = new TrainingPlanService(
                repository,
                hostingEnvironmentMock.Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                new Mock<INotificationService>().Object
            );

           
            await trainingPlanService.EditAsync(trainingPlan.Id, model);

          
            var updatedPlan = await repository.All<TrainingPlan>().FirstOrDefaultAsync(x => x.Id == trainingPlan.Id);

            Assert.That(updatedPlan, Is.Not.Null);
            Assert.That(updatedPlan.Name, Is.EqualTo("Нов план"));
            Assert.That(updatedPlan.Description, Is.EqualTo("Ново описание"));
            Assert.That(updatedPlan.ImageUrl, Does.StartWith("/img/exercises/"));
            Assert.That(updatedPlan.ImageUrl, Is.Not.EqualTo("/img/exercises/old-image.jpg"));

           
            try
            {
                Directory.Delete(fakeWebRootPath, true);
            }
            catch
            {
               
            }
        }

        [Test]
        public async Task EditAsync_WithValidIdAndNoNewImage_UpdatesTrainingPlanKeepingOldImage()
        {
        
            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "defaultImage",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                ExperienceLevel = "Начинаещ",
            };

         
            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "defaultImage",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0895124157",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

     
            var trainingPlan = new TrainingPlan()
            {
                Id = 2,
                Name = "Стар план",
                Description = "Старо описание",
                ImageUrl = "/img/exercises/old-image.jpg",
                UserId = user.Id,
                User = user,
                CreatedById = trainer.Id,
                Trainer = trainer,
                IsActive = false,
            };

       
            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

        
            var model = new EditTrainingPlanViewModel
            {
                TrainingPlanName = "Нов план без ново изображение",
                TrainingPlanDescription = "Ново описание без ново изображение",
                NewImageUrl = null 
            };

          
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns(Path.GetTempPath());

       
            trainingPlanService = new TrainingPlanService(
                repository,
                hostingEnvironmentMock.Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                new Mock<INotificationService>().Object
            );

          
            await trainingPlanService.EditAsync(trainingPlan.Id, model);

            
            var updatedPlan = await repository.All<TrainingPlan>().FirstOrDefaultAsync(x => x.Id == trainingPlan.Id);

            Assert.That(updatedPlan, Is.Not.Null);
            Assert.That(updatedPlan.Name, Is.EqualTo("Нов план без ново изображение"));
            Assert.That(updatedPlan.Description, Is.EqualTo("Ново описание без ново изображение"));
            Assert.That(updatedPlan.ImageUrl, Is.EqualTo("/img/exercises/old-image.jpg"), "Изображението трябва да остане непроменено");
        }

        [Test]
        public void EditAsync_WithInvalidId_ThrowsInvalidOperationException()
        {
          
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Test",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-user-id"
            };

            repository.AddAsync(user);
            repository.AddAsync(trainer);
            repository.SaveChangesAsync();

         
            int invalidId = 999;

         
            var model = new EditTrainingPlanViewModel
            {
                TrainingPlanName = "Невалиден план",
                TrainingPlanDescription = "Описание за невалиден план",
                NewImageUrl = null
            };

          
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(x => x.WebRootPath).Returns(Path.GetTempPath());

       
            trainingPlanService = new TrainingPlanService(
                repository,
                hostingEnvironmentMock.Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                new Mock<INotificationService>().Object
            );

            
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.EditAsync(invalidId, model)
            );
        }

        [Test]
        public async Task GetTrainingPlanModelForSendView_WithValidId_ReturnsCorrectViewModel()
        {
     
            var user = new ApplicationUser()
            {
                Id = "cd87d0e2-4047-473e-924a-3e10406c5583",
                ProfilePicture = "user-profile-image.jpg",
                UserName = "pesho@abv.bg",
                NormalizedUserName = "PESHO@ABV.BG",
                Email = "pesho@abv.bg",
                NormalizedEmail = "PESHO@ABV.BG",
                FirstName = "Pesho",
                LastName = "Ivanov",
                Height = 203,
                Weight = 92,
                ExperienceLevel = "Начинаещ",
            };

         
            var trainerUser = new ApplicationUser()
            {
                Id = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                UserName = "svetoslav102",
                ProfilePicture = "trainer-profile-image.jpg",
                NormalizedUserName = "SVETOSLAV102",
                Email = "svetoslav@abv.bg",
                NormalizedEmail = "SVETOSLAV@ABV.BG",
                FirstName = "Светослав",
                LastName = "Ковачев",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Изграждане на мускулна маса",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0895124157",
                UserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };

            
            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Тестови план за изпращане",
                Description = "Описание на тестови план за изпращане",
                ImageUrl = "training-plan-image.jpg",
                UserId = user.Id,
                User = user,
                CreatedById = trainer.Id,
                Trainer = trainer,
                IsActive = false,
            };

            
            var workout1 = new Workout()
            {
                Id = 1,
                Title = "Тренировка 1",
                DayOfWeek = "Понеделник",
                ImageUrl = "workout1-image.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Гърди"
            };

            var workout2 = new Workout()
            {
                Id = 2,
                Title = "Тренировка 2",
                DayOfWeek = "Сряда",
                ImageUrl = "workout2-image.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Гръб"
            };

            var workout3 = new Workout()
            {
                Id = 3,
                Title = "Тренировка 3",
                DayOfWeek = "Петък",
                ImageUrl = "workout3-image.jpg",
                DificultyLevel = "Трудно",
                MuscleGroup = "Крака"
            };

           
            var trainingPlanWorkout1 = new TrainingPlanWorkout()
            {
                TrainingPlanId = trainingPlan.Id,
                TrainingPlan = trainingPlan,
                WorkoutId = workout1.Id,
                Workout = workout1
            };

            var trainingPlanWorkout2 = new TrainingPlanWorkout()
            {
                TrainingPlanId = trainingPlan.Id,
                TrainingPlan = trainingPlan,
                WorkoutId = workout2.Id,
                Workout = workout2
            };

            var trainingPlanWorkout3 = new TrainingPlanWorkout()
            {
                TrainingPlanId = trainingPlan.Id,
                TrainingPlan = trainingPlan,
                WorkoutId = workout3.Id,
                Workout = workout3
            };

          
            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workout1);
            await repository.AddAsync(workout2);
            await repository.AddAsync(workout3);
            await repository.AddAsync(trainingPlanWorkout1);
            await repository.AddAsync(trainingPlanWorkout2);
            await repository.AddAsync(trainingPlanWorkout3);
            await repository.SaveChangesAsync();

          
            var result = await trainingPlanService.GetTrainingPlanModelForSendView(trainingPlan.Id);

           
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(trainingPlan.Id));
            Assert.That(result.Name, Is.EqualTo("Тестови план за изпращане"));
            Assert.That(result.DescriptionTrainingPlan, Is.EqualTo("Описание на тестови план за изпращане"));
            Assert.That(result.ImageUrlTrainingPlan, Is.EqualTo("training-plan-image.jpg"));
            Assert.That(result.UserProfilePicture, Is.EqualTo("user-profile-image.jpg"));
            Assert.That(result.UserEmail, Is.EqualTo("pesho@abv.bg"));
            Assert.That(result.UserFirstName, Is.EqualTo("Pesho"));
            Assert.That(result.UserLastName, Is.EqualTo("Ivanov"));
            Assert.That(result.WorkoutsCount, Is.EqualTo(3));
        }

        [Test]
        public void GetTrainingPlanModelForSendView_WithInvalidId_ThrowsInvalidOperationException()
        {

            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Test",
                LastName = "User",
                ProfilePicture = "test-image.jpg"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Test",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-user-id"
            };

            repository.AddAsync(user);
            repository.AddAsync(trainer);
            repository.SaveChangesAsync();

   
            int invalidId = 999;

   
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.GetTrainingPlanModelForSendView(invalidId)
            );
        }

        [Test]
        public async Task SendToUserAsync_WithValidId_ActivatesPlanAndSendsNotification()
        {

            var clientUser = new ApplicationUser()
            {
                Id = "client-user-id",
                ProfilePicture = "client-profile.jpg",
                UserName = "client@example.com",
                Email = "client@example.com",
                FirstName = "Клиент",
                LastName = "Потребител",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id",
                ProfilePicture = "trainer-profile.jpg",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Треньор",
                LastName = "Потребител",
            };


            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Фитнес",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456",
                UserId = "trainer-user-id",
                User = trainerUser
            };


            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "План за изпращане",
                Description = "Описание на плана за изпращане",
                ImageUrl = "plan-image.jpg",
                UserId = "client-user-id",
                User = clientUser,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = true     
            };

            await repository.AddAsync(clientUser);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();


            var notificationServiceMock = new Mock<INotificationService>();
            var hubContextMock = new Mock<IHubContext<NotificationHub>>();
            var clientProxyMock = new Mock<IClientProxy>();

            hubContextMock
                .Setup(h => h.Clients.User(It.IsAny<string>()))
                .Returns(clientProxyMock.Object);

            notificationServiceMock
                .Setup(ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                hubContextMock.Object,
                notificationServiceMock.Object
            );

            await trainingPlanService.SendToUserAsync(trainingPlan.Id);

           
            var updatedPlan = await repository.All<TrainingPlan>()
                .FirstOrDefaultAsync(tp => tp.Id == trainingPlan.Id);

            Assert.That(updatedPlan, Is.Not.Null);
            Assert.That(updatedPlan.IsActive, Is.True, "Планът трябва да бъде активиран");
            Assert.That(updatedPlan.IsEdit, Is.False, "Планът не трябва да бъде в режим на редактиране");

          
            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    "trainer-user-id", 
                    "client-user-id",  
                    $"Вашият тренировъчен план: {trainingPlan.Name} е активен и готов за изпълнение!",
                    "TrainingPlan"
                ),
                Times.Once,
                "Методът AddNotification трябва да бъде извикан точно веднъж с правилните параметри"
            );
        }

        [Test]
        public void SendToUserAsync_WithInvalidId_ThrowsInvalidOperationException()
        {
            
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Test",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-user-id"
            };

            repository.AddAsync(user);
            repository.AddAsync(trainer);
            repository.SaveChangesAsync();

           
            int invalidId = 999;

 
            var notificationServiceMock = new Mock<INotificationService>();
            var hubContextMock = new Mock<IHubContext<NotificationHub>>();

          
            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                hubContextMock.Object,
                notificationServiceMock.Object
            );

         
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.SendToUserAsync(invalidId)
            );

           
            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                ),
                Times.Never,
                "Методът AddNotification не трябва да бъде извикван при невалидно ID"
            );
        }

        [Test]
        public async Task AddNotification_CreatesAndSavesNotificationInDatabase()
        {
          
            var senderUser = new ApplicationUser()
            {
                Id = "sender-id",
                UserName = "sender@example.com",
                Email = "sender@example.com",
            };

            var receiverUser = new ApplicationUser()
            {
                Id = "receiver-id",
                UserName = "receiver@example.com",
                Email = "receiver@example.com",
            };

         
            await repository.AddAsync(senderUser);
            await repository.AddAsync(receiverUser);
            await repository.SaveChangesAsync();

          
            var hubContextMock = new Mock<IHubContext<NotificationHub>>();
            var clientsProxyMock = new Mock<IHubClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            hubContextMock
                .Setup(h => h.Clients)
                .Returns(clientsProxyMock.Object);

            clientsProxyMock
                .Setup(c => c.User("receiver-id"))
                .Returns(clientProxyMock.Object);

    
            var notificationService = new NotificationService(
                hubContextMock.Object,
                repository
            );

           
            await notificationService.AddNotification("sender-id", "receiver-id", "Тестово съобщение", "Test");

         
            var notification = await repository.All<Notification>().FirstOrDefaultAsync();

            Assert.That(notification, Is.Not.Null);
            Assert.That(notification.SenderId, Is.EqualTo("sender-id"));
            Assert.That(notification.RecieverId, Is.EqualTo("receiver-id"));
            Assert.That(notification.Message, Is.EqualTo("Тестово съобщение"));
            Assert.That(notification.Source, Is.EqualTo("Test"));
            Assert.That(notification.ReadStatus, Is.False);

        }
        [Test]
        public async Task GetAllTrainingPlanForUserAsync_WithValidUserIdAndActivePlan_ReturnsViewModel()
        {
            var user = new ApplicationUser()
            {
                Id = "user-with-plan-id",
                UserName = "user@example.com",
                Email = "user@example.com",
                FirstName = "Потребител",
                LastName = "С План",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Фитнес",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "trainer-id"
            };

            var activePlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Активен план",
                Description = "Описание на активен план",
                ImageUrl = "active-plan-image.jpg",
                UserId = "user-with-plan-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false
            };

            var inactivePlan = new TrainingPlan()
            {
                Id = 2,
                Name = "Неактивен план",
                Description = "Описание на неактивен план",
                ImageUrl = "inactive-plan-image.jpg",
                UserId = "user-with-plan-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            var editModePlan = new TrainingPlan()
            {
                Id = 3,
                Name = "План в редактиране",
                Description = "Описание на план в редактиране",
                ImageUrl = "edit-plan-image.jpg",
                UserId = "user-with-plan-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = true
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(activePlan);
            await repository.AddAsync(inactivePlan);
            await repository.AddAsync(editModePlan);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetAllTrainingPlanForUserAsync("user-with-plan-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.TitleOfTriningPlan, Is.EqualTo("Активен план"));
            Assert.That(result.DescriptionOfTriningPlan, Is.EqualTo("Описание на активен план"));
            Assert.That(result.ImageUrl, Is.EqualTo("active-plan-image.jpg"));
        }

        [Test]
        public async Task GetAllTrainingPlanForUserAsync_WithValidUserIdButNoActivePlan_ReturnsNull()
        {
            var user = new ApplicationUser()
            {
                Id = "user-without-active-plan-id",
                UserName = "noactiveplan@example.com",
                Email = "noactiveplan@example.com",
                FirstName = "Потребител",
                LastName = "Без Активен План",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Фитнес",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "another-trainer-id"
            };

            var inactivePlan = new TrainingPlan()
            {
                Id = 4,
                Name = "Неактивен план",
                Description = "Описание на неактивен план",
                ImageUrl = "inactive-plan-image.jpg",
                UserId = "user-without-active-plan-id",
                User = user,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            var editModePlan = new TrainingPlan()
            {
                Id = 5,
                Name = "План в редактиране",
                Description = "Описание на план в редактиране",
                ImageUrl = "edit-plan-image.jpg",
                UserId = "user-without-active-plan-id",
                User = user,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsEdit = true
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(inactivePlan);
            await repository.AddAsync(editModePlan);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetAllTrainingPlanForUserAsync("user-without-active-plan-id");

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetAllTrainingPlanForUserAsync_WithInvalidUserId_ReturnsNull()
        {
            var user = new ApplicationUser()
            {
                Id = "existing-user-id",
                UserName = "existing@example.com",
                Email = "existing@example.com"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetAllTrainingPlanForUserAsync("non-existent-user-id");

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetTrainingPlanModelsForUserForDetails_WithValidIdAndUserId_ReturnsCorrectViewModel()
        {
            var user = new ApplicationUser()
            {
                Id = "user-id-123",
                ProfilePicture = "user-profile.jpg",
                UserName = "user@example.com",
                Email = "user@example.com",
                FirstName = "Име",
                LastName = "Фамилия",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "trainer-id-123"
            };

            var exercise1 = new Exercise()
            {
                Id = 1,
                Name = "Клек",
                Description = "Базово упражнение за крака",
                ImageUrl = "squat.jpg",
                VideoUrl = "squat-video.mp4",
                Series = 4,
                Repetitions = 12,
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            var exercise2 = new Exercise()
            {
                Id = 2,
                Name = "Набиране",
                Description = "Упражнение за гръб",
                ImageUrl = "pullup.jpg",
                VideoUrl = "pullup-video.mp4",
                Series = 3,
                Repetitions = 8,
                MuscleGroup = "Гръб",
                DifficultyLevel = "Трудно"
            };

            var workout = new Workout()
            {
                Id = 1,
                Title = "Тренировка за цяло тяло",
                DayOfWeek = "Понеделник",
                ImageUrl = "full-body-workout.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Смесена",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Фитнес план за начинаещи",
                Description = "Начален план за изграждане на базова сила",
                ImageUrl = "beginner-plan.jpg",
                UserId = "user-id-123",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false,
                IsInCalendar = true,
                TrainingPlanWorkouts = new List<TrainingPlanWorkout>()
            };

            var workoutExercise1 = new WorkoutsExercise()
            {
                WorkoutId = 1,
                Workout = workout,
                ExcersiceId = 1,
                Exercise = exercise1
            };

            var workoutExercise2 = new WorkoutsExercise()
            {
                WorkoutId = 1,
                Workout = workout,
                ExcersiceId = 2,
                Exercise = exercise2
            };

            workout.WorkoutsExercises.Add(workoutExercise1);
            workout.WorkoutsExercises.Add(workoutExercise2);

            var trainingPlanWorkout = new TrainingPlanWorkout()
            {
                Id = 1,
                TrainingPlanId = 1,
                TrainingPlan = trainingPlan,
                WorkoutId = 1,
                Workout = workout
            };

            trainingPlan.TrainingPlanWorkouts.Add(trainingPlanWorkout);

            await repository.AddAsync(user);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise1);
            await repository.AddAsync(exercise2);
            await repository.AddAsync(workout);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(workoutExercise1);
            await repository.AddAsync(workoutExercise2);
            await repository.AddAsync(trainingPlanWorkout);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetTrainingPlanModelsForUserForDetails(1, "user-id-123");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Фитнес план за начинаещи"));
            Assert.That(result.Description, Is.EqualTo("Начален план за изграждане на базова сила"));
            Assert.That(result.ImageUrl, Is.EqualTo("beginner-plan.jpg"));
            Assert.That(result.UserId, Is.EqualTo("user-id-123"));
            Assert.That(result.isInCalendar, Is.True);

            Assert.That(result.Workouts, Is.Not.Null);
            Assert.That(result.Workouts.Count, Is.EqualTo(1));
            Assert.That(result.Workouts[0].Id, Is.EqualTo(1));
            Assert.That(result.Workouts[0].Title, Is.EqualTo("Тренировка за цяло тяло"));
            Assert.That(result.Workouts[0].DayOfWeek, Is.EqualTo("Понеделник"));

            Assert.That(result.Workouts[0].Exercises, Is.Not.Null);
            Assert.That(result.Workouts[0].Exercises.Count, Is.EqualTo(2));

            var firstExercise = result.Workouts[0].Exercises.FirstOrDefault(e => e.Id == 1);
            Assert.That(firstExercise, Is.Not.Null);
            Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
            Assert.That(firstExercise.Description, Is.EqualTo("Базово упражнение за крака"));
            Assert.That(firstExercise.ImageUrl, Is.EqualTo("squat.jpg"));
            Assert.That(firstExercise.VideoUrl, Is.EqualTo("squat-video.mp4"));
            Assert.That(firstExercise.Series, Is.EqualTo(4));
            Assert.That(firstExercise.Repetitions, Is.EqualTo(12));
            Assert.That(firstExercise.MuscleGroup, Is.EqualTo("Крака"));
            Assert.That(firstExercise.DifficultyLevel, Is.EqualTo("Средно"));

            var secondExercise = result.Workouts[0].Exercises.FirstOrDefault(e => e.Id == 2);
            Assert.That(secondExercise, Is.Not.Null);
            Assert.That(secondExercise.Name, Is.EqualTo("Набиране"));
        }

        [Test]
        public void GetTrainingPlanModelsForUserForDetails_WithNonExistingId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser()
            {
                Id = "user-id-test",
                UserName = "test@example.com",
                Email = "test@example.com"
            };

            repository.AddAsync(user);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.GetTrainingPlanModelsForUserForDetails(999, "user-id-test")
            );
        }

        [Test]
        public void GetTrainingPlanModelsForUserForDetails_WithWrongUserId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser()
            {
                Id = "owner-user-id",
                ProfilePicture = "owner-profile.jpg",
                UserName = "owner@example.com",
                Email = "owner@example.com"
            };

            var otherUser = new ApplicationUser()
            {
                Id = "other-user-id",
                ProfilePicture = "other-profile.jpg",
                UserName = "other@example.com",
                Email = "other@example.com"
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "trainer-id-456"
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 2,
                Name = "План само за собственика",
                Description = "Този план принадлежи само на owner-user-id",
                ImageUrl = "owner-plan.jpg",
                UserId = "owner-user-id",
                User = user,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false
            };

            repository.AddAsync(user);
            repository.AddAsync(otherUser);
            repository.AddAsync(trainer);
            repository.AddAsync(trainingPlan);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.GetTrainingPlanModelsForUserForDetails(2, "other-user-id")
            );
        }


        [Test]
        public async Task GetModelsForAllTrainingPlanAsync_WithRejectedPlans_ReturnsModels()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id",
                ProfilePicture = "client-profile.jpg",
                UserName = "client@example.com",
                Email = "client@example.com",
                FirstName = "Иван",
                LastName = "Петров",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id",
                ProfilePicture = "trainer-profile.jpg",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456",
                UserId = "trainer-user-id",
                User = trainerUser
            };

            var rejectedPlan1 = new TrainingPlan()
            {
                Id = 1,
                Name = "Отхвърлен план 1",
                Description = "Описание на отхвърлен план 1",
                ImageUrl = "rejected-plan1.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = true
            };

            var rejectedPlan2 = new TrainingPlan()
            {
                Id = 2,
                Name = "Отхвърлен план 2",
                Description = "Описание на отхвърлен план 2",
                ImageUrl = "rejected-plan2.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = true
            };

            var activePlan = new TrainingPlan()
            {
                Id = 3,
                Name = "Активен план",
                Description = "Описание на активен план",
                ImageUrl = "active-plan.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false
            };

            var inactivePlan = new TrainingPlan()
            {
                Id = 4,
                Name = "Неактивен план без редактиране",
                Description = "Описание на неактивен план без редактиране",
                ImageUrl = "inactive-plan.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(rejectedPlan1);
            await repository.AddAsync(rejectedPlan2);
            await repository.AddAsync(activePlan);
            await repository.AddAsync(inactivePlan);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetModelsForAllTrainingPlanAsync("trainer-user-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));

            var firstPlan = result.FirstOrDefault(p => p.TrainingPlanId == 1);
            var secondPlan = result.FirstOrDefault(p => p.TrainingPlanId == 2);

            Assert.That(firstPlan, Is.Not.Null);
            Assert.That(firstPlan.TrainingPlanTitle, Is.EqualTo("Отхвърлен план 1"));
            Assert.That(firstPlan.TrainingPlanDescription, Is.EqualTo("Описание на отхвърлен план 1"));
            Assert.That(firstPlan.TrainingPlanImageUrl, Is.EqualTo("rejected-plan1.jpg"));
            Assert.That(firstPlan.Email, Is.EqualTo("client@example.com"));
            Assert.That(firstPlan.UserFirstName, Is.EqualTo("Иван"));
            Assert.That(firstPlan.UserLastName, Is.EqualTo("Петров"));
            Assert.That(firstPlan.UserImageUrl, Is.EqualTo("client-profile.jpg"));

            Assert.That(secondPlan, Is.Not.Null);
            Assert.That(secondPlan.TrainingPlanTitle, Is.EqualTo("Отхвърлен план 2"));
            Assert.That(secondPlan.TrainingPlanDescription, Is.EqualTo("Описание на отхвърлен план 2"));

            Assert.That(result.Any(p => p.TrainingPlanId == 3), Is.False);
            Assert.That(result.Any(p => p.TrainingPlanId == 4), Is.False);
        }

        [Test]
        public async Task GetModelsForAllTrainingPlanAsync_WithNoRejectedPlans_ReturnsEmptyCollection()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id-2",
                ProfilePicture = "client-profile-2.jpg",
                UserName = "client2@example.com",
                Email = "client2@example.com",
                FirstName = "Петър",
                LastName = "Иванов",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id-2",
                ProfilePicture = "trainer-profile-2.jpg",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Димитър",
                LastName = "Треньорски",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321",
                UserId = "trainer-user-id-2",
                User = trainerUser
            };

            var activePlan = new TrainingPlan()
            {
                Id = 5,
                Name = "Активен план на друг треньор",
                Description = "Описание на активен план на друг треньор",
                ImageUrl = "active-plan-2.jpg",
                UserId = "client-user-id-2",
                User = user,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false
            };

            var inactivePlan = new TrainingPlan()
            {
                Id = 6,
                Name = "Неактивен план без редактиране на друг треньор",
                Description = "Описание на неактивен план без редактиране на друг треньор",
                ImageUrl = "inactive-plan-2.jpg",
                UserId = "client-user-id-2",
                User = user,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = false,
                IsEdit = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(activePlan);
            await repository.AddAsync(inactivePlan);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetModelsForAllTrainingPlanAsync("trainer-user-id-2");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetModelsForAllTrainingPlanAsync_WithInvalidTrainerId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com"
            };

            repository.AddAsync(user);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.GetModelsForAllTrainingPlanAsync("non-existent-trainer-id")
            );
        }

        [Test]
        public async Task SendEditTrainingPlanAsync_WithValidIdAndUserId_UpdatesPlanAndSendsNotification()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id",
                ProfilePicture = "client-profile.jpg",
                UserName = "client@example.com",
                Email = "client@example.com",
                FirstName = "Иван",
                LastName = "Петров",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id",
                ProfilePicture = "trainer-profile.jpg",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456",
                UserId = "trainer-user-id",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Активен план за отхвърляне",
                Description = "Описание на активен план за отхвърляне",
                ImageUrl = "active-plan.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
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

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

            await trainingPlanService.SendEditTrainingPlanAsync(1, "client-user-id");

            var updatedPlan = await repository.All<TrainingPlan>()
                .FirstOrDefaultAsync(tp => tp.Id == 1);

            Assert.That(updatedPlan, Is.Not.Null);
            Assert.That(updatedPlan.IsActive, Is.False);
            Assert.That(updatedPlan.IsEdit, Is.True);

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    "client-user-id",
                    "trainer-user-id",
                    $"✖ Тренировъчен план с име: {trainingPlan.Name} бе отказан от {user.FirstName} {user.LastName}",
                    "RejectedTrainingPlan"
                ),
                Times.Once
            );
        }

        [Test]
        public void SendEditTrainingPlanAsync_WithInvalidId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id-2",
                ProfilePicture = "client-profile-2.jpg",
                UserName = "client2@example.com",
                Email = "client2@example.com",
                FirstName = "Петър",
                LastName = "Иванов",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321",
                UserId = "trainer-user-id-2"
            };

            repository.AddAsync(user);
            repository.AddAsync(trainer);
            repository.SaveChangesAsync();

            var notificationServiceMock = new Mock<INotificationService>();

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.SendEditTrainingPlanAsync(999, "client-user-id-2")
            );

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                ),
                Times.Never
            );
        }

        [Test]
        public void SendEditTrainingPlanAsync_WithWrongUserId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser()
            {
                Id = "owner-user-id",
                ProfilePicture = "owner-profile.jpg",
                UserName = "owner@example.com",
                Email = "owner@example.com",
                FirstName = "Собственик",
                LastName = "Планов",
            };

            var otherUser = new ApplicationUser()
            {
                Id = "other-user-id",
                ProfilePicture = "other-profile.jpg",
                UserName = "other@example.com",
                Email = "other@example.com",
                FirstName = "Друг",
                LastName = "Потребител",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id-3",
                ProfilePicture = "trainer-profile-3.jpg",
                UserName = "trainer3@example.com",
                Email = "trainer3@example.com",
            };

            var trainer = new Trainer()
            {
                Id = 3,
                Specialization = "Гъвкавост",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888987654",
                UserId = "trainer-user-id-3",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 2,
                Name = "План на собственика",
                Description = "Описание на плана на собственика",
                ImageUrl = "owner-plan.jpg",
                UserId = "owner-user-id",
                User = user,
                CreatedById = 3,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false
            };

            repository.AddAsync(user);
            repository.AddAsync(otherUser);
            repository.AddAsync(trainerUser);
            repository.AddAsync(trainer);
            repository.AddAsync(trainingPlan);
            repository.SaveChangesAsync();

            var notificationServiceMock = new Mock<INotificationService>();

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.SendEditTrainingPlanAsync(2, "other-user-id")
            );

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                ),
                Times.Never
            );

            var planAfterTest = repository.All<TrainingPlan>().FirstOrDefault(tp => tp.Id == 2);
            Assert.That(planAfterTest.IsActive, Is.True);
            Assert.That(planAfterTest.IsEdit, Is.False);
        }

        [Test]
        public async Task GetRejectedTrainingPlanAsync_WithValidData_ReturnsCorrectViewModel()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id",
                ProfilePicture = "client-profile.jpg",
                UserName = "client@example.com",
                Email = "client@example.com",
                FirstName = "Иван",
                LastName = "Петров",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id",
                ProfilePicture = "trainer-profile.jpg",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456",
                UserId = "trainer-user-id",
                User = trainerUser
            };

            var rejectedPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "Отхвърлен план",
                Description = "Описание на отхвърлен план",
                ImageUrl = "rejected-plan.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = false,
                IsEdit = true,
                ExerciseFeedbacks = new List<ExerciseFeedback>(),
                TrainingPlanWorkouts = new List<TrainingPlanWorkout>()
            };

            var exercise1 = new Exercise()
            {
                Id = 1,
                Name = "Клек",
                Description = "Базово упражнение за крака",
                ImageUrl = "squat.jpg",
                VideoUrl = "squat-video.mp4",
                Series = 4,
                Repetitions = 12,
                MuscleGroup = "Крака",
                DifficultyLevel = "Средно"
            };

            var exercise2 = new Exercise()
            {
                Id = 2,
                Name = "Набиране",
                Description = "Упражнение за гръб",
                ImageUrl = "pullup.jpg",
                VideoUrl = "pullup-video.mp4",
                Series = 3,
                Repetitions = 8,
                MuscleGroup = "Гръб",
                DifficultyLevel = "Трудно"
            };

            var exercise3 = new Exercise()
            {
                Id = 3,
                Name = "Лицеви опори",
                Description = "Упражнение за гърди и ръце",
                ImageUrl = "pushup.jpg",
                VideoUrl = "pushup-video.mp4",
                Series = 3,
                Repetitions = 15,
                MuscleGroup = "Гърди",
                DifficultyLevel = "Средно"
            };

            var workout1 = new Workout()
            {
                Id = 1,
                Title = "Тренировка за крака",
                DayOfWeek = "Понеделник",
                ImageUrl = "leg-day.jpg",
                DificultyLevel = "Средно",
                MuscleGroup = "Крака",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workout2 = new Workout()
            {
                Id = 2,
                Title = "Тренировка за гръб",
                DayOfWeek = "Сряда",
                ImageUrl = "back-day.jpg",
                DificultyLevel = "Трудно",
                MuscleGroup = "Гръб",
                WorkoutsExercises = new List<WorkoutsExercise>()
            };

            var workoutExercise1 = new WorkoutsExercise()
            {
                WorkoutId = 1,
                Workout = workout1,
                ExcersiceId = 1,
                Exercise = exercise1
            };

            var workoutExercise2 = new WorkoutsExercise()
            {
                WorkoutId = 2,
                Workout = workout2,
                ExcersiceId = 2,
                Exercise = exercise2
            };

            workout1.WorkoutsExercises.Add(workoutExercise1);
            workout2.WorkoutsExercises.Add(workoutExercise2);

            var trainingPlanWorkout1 = new TrainingPlanWorkout()
            {
                TrainingPlanId = 1,
                TrainingPlan = rejectedPlan,
                WorkoutId = 1,
                Workout = workout1
            };

            var trainingPlanWorkout2 = new TrainingPlanWorkout()
            {
                TrainingPlanId = 1,
                TrainingPlan = rejectedPlan,
                WorkoutId = 2,
                Workout = workout2
            };

            rejectedPlan.TrainingPlanWorkouts.Add(trainingPlanWorkout1);
            rejectedPlan.TrainingPlanWorkouts.Add(trainingPlanWorkout2);

            var exerciseFeedback = new ExerciseFeedback()
            {
                Id = 1,
                TrainingPlanId = 1,
                TrainingPlan = rejectedPlan,
                ExerciseId = 1,
                Exercise = exercise1,
                Feedback = "Това упражнение е твърде трудно за начинаещи."
            };

            rejectedPlan.ExerciseFeedbacks.Add(exerciseFeedback);

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(exercise1);
            await repository.AddAsync(exercise2);
            await repository.AddAsync(exercise3);
            await repository.AddAsync(workout1);
            await repository.AddAsync(workout2);
            await repository.AddAsync(rejectedPlan);
            await repository.AddAsync(workoutExercise1);
            await repository.AddAsync(workoutExercise2);
            await repository.AddAsync(trainingPlanWorkout1);
            await repository.AddAsync(trainingPlanWorkout2);
            await repository.AddAsync(exerciseFeedback);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.GetRejectedTrainingPlanAsync(1, "trainer-user-id");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Отхвърлен план"));
            Assert.That(result.Description, Is.EqualTo("Описание на отхвърлен план"));
            Assert.That(result.FirstName, Is.EqualTo("Иван"));
            Assert.That(result.LastName, Is.EqualTo("Петров"));
            Assert.That(result.UserEmail, Is.EqualTo("client@example.com"));
            Assert.That(result.UserProfilePicture, Is.EqualTo("client-profile.jpg"));

            Assert.That(result.Workouts, Is.Not.Null);
            Assert.That(result.Workouts.Count, Is.EqualTo(2));

            var firstWorkout = result.Workouts.FirstOrDefault(w => w.Id == 1);
            Assert.That(firstWorkout, Is.Not.Null);
            Assert.That(firstWorkout.Title, Is.EqualTo("Тренировка за крака"));
            Assert.That(firstWorkout.DayOfWeek, Is.EqualTo("Понеделник"));
            Assert.That(firstWorkout.DifficultyLevel, Is.EqualTo("Средно"));
            Assert.That(firstWorkout.MuscleGroup, Is.EqualTo("Крака"));

            Assert.That(firstWorkout.Exercises, Is.Not.Null);
            Assert.That(firstWorkout.Exercises.Count, Is.EqualTo(1));

            var firstExercise = firstWorkout.Exercises.FirstOrDefault(e => e.Id == 1);
            Assert.That(firstExercise, Is.Not.Null);
            Assert.That(firstExercise.Name, Is.EqualTo("Клек"));
            Assert.That(firstExercise.Feedback, Is.EqualTo("Това упражнение е твърде трудно за начинаещи."));

            var secondWorkout = result.Workouts.FirstOrDefault(w => w.Id == 2);
            Assert.That(secondWorkout, Is.Not.Null);

            var secondExercise = secondWorkout.Exercises.FirstOrDefault(e => e.Id == 2);
            Assert.That(secondExercise, Is.Not.Null);
            Assert.That(secondExercise.Name, Is.EqualTo("Набиране"));
            Assert.That(secondExercise.Feedback, Is.EqualTo(string.Empty));

            Assert.That(result.AvailableExercises, Is.Not.Null);
            Assert.That(result.AvailableExercises.Count, Is.EqualTo(3));
            Assert.That(result.AvailableExercises.Any(e => e.Id == 3), Is.True);
        }

        [Test]
        public void GetRejectedTrainingPlanAsync_WithInvalidTrainerId_ThrowsInvalidOperationException()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com"
            };

            repository.AddAsync(user);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await trainingPlanService.GetRejectedTrainingPlanAsync(1, "non-existent-trainer-id")
            );
        }

        [Test]
        public void GetRejectedTrainingPlanAsync_WithInvalidPlanId_ThrowsNullReferenceException()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id-2",
                UserName = "client2@example.com",
                Email = "client2@example.com"
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id-2",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com"
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321",
                UserId = "trainer-user-id-2",
                User = trainerUser
            };

            repository.AddAsync(user);
            repository.AddAsync(trainerUser);
            repository.AddAsync(trainer);
            repository.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await trainingPlanService.GetRejectedTrainingPlanAsync(999, "trainer-user-id-2")
            );
        }

        [Test]
        public async Task AcceptTrainingPlanAsync_WithValidIdAndNoCalendar_CreatesCalendarAndUpdatesTrainingPlan()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id",
                ProfilePicture = "client-profile.jpg",
                UserName = "client@example.com",
                Email = "client@example.com",
                FirstName = "Иван",
                LastName = "Петров",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id",
                ProfilePicture = "trainer-profile.jpg",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Георги",
                LastName = "Тренев",
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456",
                UserId = "trainer-user-id",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 1,
                Name = "План за приемане",
                Description = "Описание на план за приемане",
                ImageUrl = "plan-image.jpg",
                UserId = "client-user-id",
                User = user,
                CreatedById = 1,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false,
                IsInCalendar = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
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

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

            await trainingPlanService.AcceptTrainingPlanAsync(1, "client-user-id");

            var updatedPlan = await repository.All<TrainingPlan>()
                .FirstOrDefaultAsync(tp => tp.Id == 1);

            Assert.That(updatedPlan, Is.Not.Null);
            Assert.That(updatedPlan.IsInCalendar, Is.True);

            var createdCalendar = await repository.All<Calendar>()
                .FirstOrDefaultAsync(c => c.UserId == "client-user-id");

            Assert.That(createdCalendar, Is.Not.Null);
            Assert.That(createdCalendar.TrainerId, Is.EqualTo(1));
            Assert.That(createdCalendar.UserId, Is.EqualTo("client-user-id"));

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    "client-user-id",
                    "trainer-user-id",
                    $"✔ Тренировъчен план с име: {trainingPlan.Name} бе приет от {user.FirstName} {user.LastName}",
                    "TrainingPlanDetails"
                ),
                Times.Once
            );
        }

        [Test]
        public async Task AcceptTrainingPlanAsync_WithValidIdAndExistingCalendarWithDietitian_UpdatesCalendarAndTrainingPlan()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id-2",
                ProfilePicture = "client-profile-2.jpg",
                UserName = "client2@example.com",
                Email = "client2@example.com",
                FirstName = "Петър",
                LastName = "Иванов",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id-2",
                ProfilePicture = "trainer-profile-2.jpg",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Димитър",
                LastName = "Треньорски",
            };

            var trainer = new Trainer()
            {
                Id = 2,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321",
                UserId = "trainer-user-id-2",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 2,
                Name = "План за приемане с календар",
                Description = "Описание на план за приемане с календар",
                ImageUrl = "plan-image-2.jpg",
                UserId = "client-user-id-2",
                User = user,
                CreatedById = 2,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false,
                IsInCalendar = false
            };

            var existingCalendar = new Calendar
            {
                Id = 1,
                UserId = "client-user-id-2",
                DietitianId = 1, 
                TrainerId = null 
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.AddAsync(existingCalendar);
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

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

            await trainingPlanService.AcceptTrainingPlanAsync(2, "client-user-id-2");

            var updatedPlan = await repository.All<TrainingPlan>()
                .FirstOrDefaultAsync(tp => tp.Id == 2);

            Assert.That(updatedPlan, Is.Not.Null);
            Assert.That(updatedPlan.IsInCalendar, Is.True);

            var updatedCalendar = await repository.All<Calendar>()
                .FirstOrDefaultAsync(c => c.UserId == "client-user-id-2");

            Assert.That(updatedCalendar, Is.Not.Null);
            Assert.That(updatedCalendar.TrainerId, Is.EqualTo(2));
            Assert.That(updatedCalendar.DietitianId, Is.EqualTo(1), "Диетологът трябва да остане непроменен");

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    "client-user-id-2",
                    "trainer-user-id-2",
                    $"✔ Тренировъчен план с име: {trainingPlan.Name} бе приет от {user.FirstName} {user.LastName}",
                    "TrainingPlanDetails"
                ),
                Times.Once
            );
        }

        [Test]
        public void AcceptTrainingPlanAsync_WithInvalidId_ThrowsArgumentException()
        {
            var user = new ApplicationUser()
            {
                Id = "client-user-id-3",
                UserName = "client3@example.com",
                Email = "client3@example.com",
                FirstName = "Тест",
                LastName = "Потребител",
            };

            var trainer = new Trainer()
            {
                Id = 3,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888111222",
                UserId = "trainer-user-id-3"
            };

            repository.AddAsync(user);
            repository.AddAsync(trainer);
            repository.SaveChangesAsync();

            var notificationServiceMock = new Mock<INotificationService>();

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

            Assert.ThrowsAsync<ArgumentException>(async () =>
                await trainingPlanService.AcceptTrainingPlanAsync(999, "client-user-id-3")
            );

            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                ),
                Times.Never
            );
        }

        [Test]
        public async Task AcceptTrainingPlanAsync_WithWrongUserId_ThrowsArgumentException()
        {
            var user = new ApplicationUser()
            {
                Id = "owner-user-id",
                ProfilePicture = "owner-profile.jpg",
                UserName = "owner@example.com",
                Email = "owner@example.com",
                FirstName = "Собственик",
                LastName = "Планов",
            };

            var otherUser = new ApplicationUser()
            {
                Id = "other-user-id",
                ProfilePicture = "other-profile.jpg",
                UserName = "other@example.com",
                Email = "other@example.com",
                FirstName = "Друг",
                LastName = "Потребител",
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "trainer-user-id-4",
                ProfilePicture = "trainer-profile-4.jpg",
                UserName = "trainer4@example.com",
                Email = "trainer4@example.com",
            };

            var trainer = new Trainer()
            {
                Id = 4,
                Specialization = "Гъвкавост",
                Experience = 4,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888987654",
                UserId = "trainer-user-id-4",
                User = trainerUser
            };

            var trainingPlan = new TrainingPlan()
            {
                Id = 3,
                Name = "План на собственика",
                Description = "Описание на плана на собственика",
                ImageUrl = "owner-plan.jpg",
                UserId = "owner-user-id",
                User = user,
                CreatedById = 4,
                Trainer = trainer,
                IsActive = true,
                IsEdit = false,
                IsInCalendar = false
            };

            await repository.AddAsync(user);
            await repository.AddAsync(otherUser);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();

            var notificationServiceMock = new Mock<INotificationService>();

            trainingPlanService = new TrainingPlanService(
                repository,
                new Mock<IHostingEnvironment>().Object,
                new Mock<IHubContext<NotificationHub>>().Object,
                notificationServiceMock.Object
            );

   
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await trainingPlanService.AcceptTrainingPlanAsync(3, "other-user-id")
            );

            var planAfterTest = await repository.All<TrainingPlan>().FirstOrDefaultAsync(tp => tp.Id == 3);
            Assert.That(planAfterTest.IsInCalendar, Is.False);

   
            notificationServiceMock.Verify(
                ns => ns.AddNotification(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                ),
                Times.Never
            );
        }
        [Test]
        public async Task AllTrainingPlanAsync_WithPlans_ReturnsAllPlans()
        {
            var user1 = new ApplicationUser()
            {
                Id = "user-id-1",
                ProfilePicture = "user1-profile.jpg",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                FirstName = "Иван",
                LastName = "Петров"
            };

            var user2 = new ApplicationUser()
            {
                Id = "user-id-2",
                ProfilePicture = "user2-profile.jpg",
                UserName = "user2@example.com",
                Email = "user2@example.com",
                FirstName = "Мария",
                LastName = "Иванова"
            };

            var trainerUser1 = new ApplicationUser()
            {
                Id = "trainer-user-id-1",
                ProfilePicture = "trainer1-profile.jpg",
                UserName = "trainer1@example.com",
                Email = "trainer1@example.com",
                FirstName = "Георги",
                LastName = "Тренев"
            };

            var trainerUser2 = new ApplicationUser()
            {
                Id = "trainer-user-id-2",
                ProfilePicture = "trainer2-profile.jpg",
                UserName = "trainer2@example.com",
                Email = "trainer2@example.com",
                FirstName = "Петър",
                LastName = "Треньорски"
            };

            var trainer1 = new Trainer()
            {
                Id = 1,
                Specialization = "Силови тренировки",
                Experience = 5,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888123456",
                UserId = "trainer-user-id-1",
                User = trainerUser1
            };

            var trainer2 = new Trainer()
            {
                Id = 2,
                Specialization = "Кардио",
                Experience = 3,
                SertificateImage = GenerateValidBase64Image(),
                PhoneNumber = "0888654321",
                UserId = "trainer-user-id-2",
                User = trainerUser2
            };

            var plan1 = new TrainingPlan()
            {
                Id = 1,
                Name = "План за начинаещи",
                Description = "Лесен план за начинаещи",
                ImageUrl = "beginner-plan.jpg",
                UserId = "user-id-1",
                User = user1,
                CreatedById = 1,
                Trainer = trainer1,
                IsActive = true,
                IsEdit = false
            };

            var plan2 = new TrainingPlan()
            {
                Id = 2,
                Name = "Интензивен план",
                Description = "План за напреднали",
                ImageUrl = "advanced-plan.jpg",
                UserId = "user-id-2",
                User = user2,
                CreatedById = 2,
                Trainer = trainer2,
                IsActive = true,
                IsEdit = false
            };

            var plan3 = new TrainingPlan()
            {
                Id = 3,
                Name = "Кардио план",
                Description = "План за кардио тренировки",
                ImageUrl = "cardio-plan.jpg",
                UserId = "user-id-1",
                User = user1,
                CreatedById = 2,
                Trainer = trainer2,
                IsActive = false,
                IsEdit = true
            };

            await repository.AddAsync(user1);
            await repository.AddAsync(user2);
            await repository.AddAsync(trainerUser1);
            await repository.AddAsync(trainerUser2);
            await repository.AddAsync(trainer1);
            await repository.AddAsync(trainer2);
            await repository.AddAsync(plan1);
            await repository.AddAsync(plan2);
            await repository.AddAsync(plan3);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.AllTrainingPlanAsync();

            Assert.That(result, Is.Not.Null);
            var resultList = result.ToList();
            Assert.That(resultList.Count, Is.EqualTo(3));

            var firstPlan = resultList.FirstOrDefault(p => p.Id == 1);
            Assert.That(firstPlan, Is.Not.Null);
            Assert.That(firstPlan.TitleOfTriningPlan, Is.EqualTo("План за начинаещи"));
            Assert.That(firstPlan.DescriptionOfTriningPlan, Is.EqualTo("Лесен план за начинаещи"));
            Assert.That(firstPlan.ImageUrl, Is.EqualTo("beginner-plan.jpg"));
            Assert.That(firstPlan.FirstName, Is.EqualTo("Иван"));
            Assert.That(firstPlan.LastName, Is.EqualTo("Петров"));
            Assert.That(firstPlan.FirstNameTrainer, Is.EqualTo("Георги"));
            Assert.That(firstPlan.LastNameTrainer, Is.EqualTo("Тренев"));
            Assert.That(firstPlan.ProfileEmailUser, Is.EqualTo("user1@example.com"));
            Assert.That(firstPlan.ProfileEmailTrainer, Is.EqualTo("trainer1@example.com"));
            Assert.That(firstPlan.ProfilePictureUser, Is.EqualTo("user1-profile.jpg"));
            Assert.That(firstPlan.ProfilePictureTrainer, Is.EqualTo("trainer1-profile.jpg"));

            var secondPlan = resultList.FirstOrDefault(p => p.Id == 2);
            Assert.That(secondPlan, Is.Not.Null);
            Assert.That(secondPlan.TitleOfTriningPlan, Is.EqualTo("Интензивен план"));
            Assert.That(secondPlan.FirstName, Is.EqualTo("Мария"));
            Assert.That(secondPlan.FirstNameTrainer, Is.EqualTo("Петър"));

            var thirdPlan = resultList.FirstOrDefault(p => p.Id == 3);
            Assert.That(thirdPlan, Is.Not.Null);
            Assert.That(thirdPlan.TitleOfTriningPlan, Is.EqualTo("Кардио план"));
            Assert.That(thirdPlan.FirstName, Is.EqualTo("Иван"));
            Assert.That(thirdPlan.FirstNameTrainer, Is.EqualTo("Петър"));
        }

        [Test]
        public async Task AllTrainingPlanAsync_WithNoPlans_ReturnsEmptyCollection()
        {
            var user = new ApplicationUser()
            {
                Id = "test-user-id",
                UserName = "test@example.com",
                Email = "test@example.com",
                FirstName = "Тест",
                LastName = "Потребител"
            };

            var trainerUser = new ApplicationUser()
            {
                Id = "test-trainer-id",
                UserName = "trainer@example.com",
                Email = "trainer@example.com",
                FirstName = "Тест",
                LastName = "Треньор"
            };

            var trainer = new Trainer()
            {
                Id = 1,
                Specialization = "Тест",
                Experience = 1,
                SertificateImage = GenerateValidBase64Image(),
                UserId = "test-trainer-id",
                User = trainerUser
            };

            await repository.AddAsync(user);
            await repository.AddAsync(trainerUser);
            await repository.AddAsync(trainer);
            await repository.SaveChangesAsync();

            var result = await trainingPlanService.AllTrainingPlanAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }

        private string GenerateValidBase64Image()
        {

            byte[] dummyImage = new byte[10];
            new Random().NextBytes(dummyImage); 
            return Convert.ToBase64String(dummyImage);
        }
    }
}
