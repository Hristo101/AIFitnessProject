using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.MealFeedback;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAiFiness.ServicesTests
{
    [TestFixture]
    public class MealFeedbackServiceTest
    {
        private IRepository repository;
        private IMealFeedbackService mealFeedbackService;
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
            mealFeedbackService = new MealFeedbackService(repository);

        }
        [Test]
        public async Task AddMealFeedbackAsync_ShouldAddFeedbackToDatabase()
        {

            var user = new ApplicationUser
            {
                Id = "user1",
                FirstName = "Test",
                LastName = "User",
                Height = 180,
                Weight = 80,
                Aim = "Test Aim",
                ExperienceLevel = "Beginner"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 1,
                Specialization = "Nutrition",
                Experience = 5,
                SertificateImage = "certificate.jpg", // Required field
                SertificationDetails = "Professional Certification",
                Bio = "Professional dietitian",
                PhoneNumber = "+1234567890",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 1,
                Name = "Test Meal",
                Recipe = "Test Recipe",
                MealTime = "Breakfast",
                ImageUrl = "test.jpg",
                VideoUrl = "test.mp4",
                DificultyLevel = "Easy",
                Calories = 500,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 1,
                Name = "Test Diet",
                UserId = "user1",
                Description = "Test Description",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var request = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "This meal was great!"
            };

            // Act
            await mealFeedbackService.AddMealFeedbackAsync(request);

            // Assert
            var feedbacks = await repository.AllAsReadOnly<MealFeedback>().ToListAsync();

            Assert.That(feedbacks, Is.Not.Null);
            Assert.That(feedbacks.Count, Is.EqualTo(1));
            Assert.That(feedbacks[0].MealId, Is.EqualTo(request.MealId));
            Assert.That(feedbacks[0].DietId, Is.EqualTo(request.DietId));
            Assert.That(feedbacks[0].Feedback, Is.EqualTo(request.Content));
            Assert.That(feedbacks[0].IsAnswered, Is.False);
            Assert.That(feedbacks[0].CreatedAt.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public async Task AddMealFeedbackAsync_WithNonExistentMealId_ShouldStillAddFeedback()
        {
            var user = new ApplicationUser
            {
                Id = "user2",
                FirstName = "Test",
                LastName = "User2",
                Height = 175,
                Weight = 75,
                Aim = "Test Aim",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 2,
                Specialization = "Weight Loss",
                Experience = 7,
                SertificateImage = "cert_weight_loss.jpg", 
                SertificationDetails = "Weight Loss Specialist",
                Bio = "Weight loss expert",
                PhoneNumber = "+0987654321",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var diet = new Diet
            {
                Id = 2,
                UserId = "user2",
                Name = "Weight Loss Diet",
                Description = "Diet for weight loss",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var request = new SubmitCommentRequestDTO
            {
                MealId = 999, // Non-existent meal ID
                DietId = diet.Id,
                Content = "Feedback for non-existent meal"
            };

            // Act
            await mealFeedbackService.AddMealFeedbackAsync(request);

            // Assert
            var feedbacks = await repository.AllAsReadOnly<MealFeedback>().ToListAsync();

            Assert.That(feedbacks, Is.Not.Null);
            Assert.That(feedbacks.Count, Is.EqualTo(1));
            Assert.That(feedbacks[0].MealId, Is.EqualTo(request.MealId));
            Assert.That(feedbacks[0].Feedback, Is.EqualTo(request.Content));
        }

        [Test]
        public async Task AddMealFeedbackAsync_WithNonExistentDietId_ShouldStillAddFeedback()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "user3",
                FirstName = "Test",
                LastName = "User3",
                Height = 185,
                Weight = 85,
                Aim = "Test Aim",
                ExperienceLevel = "Advanced"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 3,
                Specialization = "Sports Nutrition",
                Experience = 10,
                SertificateImage = "sports_cert.jpg", // Required field
                SertificationDetails = "Sports Nutrition Certificate",
                Bio = "Sports nutrition expert",
                PhoneNumber = "+1122334455",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 3,
                Name = "Sports Meal",
                Recipe = "High protein recipe",
                MealTime = "Post-workout",
                ImageUrl = "sports_meal.jpg",
                VideoUrl = "sports_meal.mp4",
                DificultyLevel = "Medium",
                Calories = 600,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);
            await repository.SaveChangesAsync();

            var request = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = 999, // Non-existent diet ID
                Content = "Feedback for meal with non-existent diet"
            };

            // Act
            await mealFeedbackService.AddMealFeedbackAsync(request);

            // Assert
            var feedbacks = await repository.AllAsReadOnly<MealFeedback>().ToListAsync();

            Assert.That(feedbacks, Is.Not.Null);
            Assert.That(feedbacks.Count, Is.EqualTo(1));
            Assert.That(feedbacks[0].DietId, Is.EqualTo(request.DietId));
            Assert.That(feedbacks[0].Feedback, Is.EqualTo(request.Content));
        }

        [Test]
        public async Task AddMealFeedbackAsync_WithMultipleFeedbacks_ShouldAddAllFeedbacks()
        {

            var user = new ApplicationUser
            {
                Id = "user4",
                FirstName = "Test",
                LastName = "User4",
                Height = 170,
                Weight = 70,
                Aim = "Test Aim",
                ExperienceLevel = "Beginner"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 4,
                Specialization = "Vegan Nutrition",
                Experience = 8,
                SertificateImage = "vegan_cert.jpg", 
                SertificationDetails = "Vegan Nutrition Specialist",
                Bio = "Vegan nutrition expert",
                PhoneNumber = "+5566778899",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 4,
                Name = "Vegan Meal",
                Recipe = "Plant-based recipe",
                MealTime = "Lunch",
                ImageUrl = "vegan_meal.jpg",
                VideoUrl = "vegan_meal.mp4",
                DificultyLevel = "Easy",
                Calories = 400,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 4,
                UserId = "user4",
                Name = "Vegan Diet Plan",
                Description = "Full vegan diet plan",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var request1 = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "First feedback"
            };

            var request2 = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "Second feedback"
            };

            var request3 = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "Third feedback"
            };


            await mealFeedbackService.AddMealFeedbackAsync(request1);
            await mealFeedbackService.AddMealFeedbackAsync(request2);
            await mealFeedbackService.AddMealFeedbackAsync(request3);


            var feedbacks = await repository.AllAsReadOnly<MealFeedback>().ToListAsync();

            Assert.That(feedbacks, Is.Not.Null);
            Assert.That(feedbacks.Count, Is.EqualTo(3));

            var feedbackContents = feedbacks.Select(f => f.Feedback).ToList();
            CollectionAssert.Contains(feedbackContents, request1.Content);
            CollectionAssert.Contains(feedbackContents, request2.Content);
            CollectionAssert.Contains(feedbackContents, request3.Content);
        }

        [Test]
        public async Task AddMealFeedbackAsync_WithMaxLengthContent_ShouldAddFeedback()
        {

            var user = new ApplicationUser
            {
                Id = "user5",
                FirstName = "Test",
                LastName = "User5",
                Height = 178,
                Weight = 78,
                Aim = "Test Aim",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 5,
                Specialization = "Clinical Nutrition",
                Experience = 12,
                SertificateImage = "clinical_cert.jpg", 
                SertificationDetails = "Clinical Nutrition Certificate",
                Bio = "Clinical nutrition expert",
                PhoneNumber = "+1357924680",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 5,
                Name = "Clinical Meal",
                Recipe = "Special diet recipe",
                MealTime = "Dinner",
                ImageUrl = "clinical_meal.jpg",
                VideoUrl = "clinical_meal.mp4",
                DificultyLevel = "Medium",
                Calories = 450,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 5,
                Name = "Clinical Diet",
                UserId = "user5",
                Description = "Special clinical diet",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            string maxLengthContent = new string('A', 500);
            var request = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = maxLengthContent
            };

            await mealFeedbackService.AddMealFeedbackAsync(request);

 
            var feedback = await repository.AllAsReadOnly<MealFeedback>().FirstOrDefaultAsync();

            Assert.That(feedback, Is.Not.Null);
            Assert.That(feedback.Feedback, Is.EqualTo(maxLengthContent));
            Assert.That(feedback.Feedback.Length, Is.EqualTo(500));
        }

        [Test]
        public async Task AddMealFeedbackAsync_WithEmptyContent_ShouldAddFeedbackWithEmptyString()
        {

            var user = new ApplicationUser
            {
                Id = "user6",
                FirstName = "Test",
                LastName = "User6",
                Height = 165,
                Weight = 65,
                Aim = "Test Aim",
                ExperienceLevel = "Beginner"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 6,
                Specialization = "Pediatric Nutrition",
                Experience = 9,
                SertificateImage = "pediatric_cert.jpg",
                SertificationDetails = "Pediatric Nutrition Specialist",
                Bio = "Pediatric nutrition expert",
                PhoneNumber = "+2468013579",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 6,
                Name = "Kid's Meal",
                Recipe = "Kid-friendly recipe",
                MealTime = "Snack",
                ImageUrl = "kids_meal.jpg",
                VideoUrl = "kids_meal.mp4",
                DificultyLevel = "Easy",
                Calories = 300,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 6,
                Name = "Pediatric Diet",
                UserId = "user6",
                Description = "Diet for children",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var request = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "" 
            };

            await mealFeedbackService.AddMealFeedbackAsync(request);


            var feedback = await repository.AllAsReadOnly<MealFeedback>().FirstOrDefaultAsync();

            Assert.That(feedback, Is.Not.Null);
            Assert.That(feedback.Feedback, Is.EqualTo(string.Empty));
        }

        [Test]
        public async Task AddMealFeedbackAsync_SavesCurrentDateTimeForCreatedAt()
        {

            var user = new ApplicationUser
            {
                Id = "user7",
                FirstName = "Test",
                LastName = "User7",
                Height = 182,
                Weight = 82,
                Aim = "Test Aim",
                ExperienceLevel = "Advanced"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 7,
                Specialization = "General Nutrition",
                Experience = 6,
                SertificateImage = "general_cert.jpg", 
                SertificationDetails = "General Nutrition Certificate",
                Bio = "General nutrition expert",
                PhoneNumber = "+9876543210",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 7,
                Name = "General Meal",
                Recipe = "Balanced recipe",
                MealTime = "Breakfast",
                ImageUrl = "general_meal.jpg",
                VideoUrl = "general_meal.mp4",
                DificultyLevel = "Medium",
                Calories = 500,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 7,
                UserId = "user7",
                Name = "General Diet",
                Description = "Balanced diet plan",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var beforeTime = DateTime.Now;

            System.Threading.Thread.Sleep(10);

            var request = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "Time test feedback"
            };


            await mealFeedbackService.AddMealFeedbackAsync(request);
            var afterTime = DateTime.Now;


            var feedback = await repository.AllAsReadOnly<MealFeedback>().FirstOrDefaultAsync();

            Assert.That(feedback, Is.Not.Null);

            Assert.That(feedback.CreatedAt, Is.GreaterThanOrEqualTo(beforeTime));
            Assert.That(feedback.CreatedAt, Is.LessThanOrEqualTo(afterTime));
        }

        [Test]
        public async Task AddMealFeedbackAsync_SetsIsAnsweredToFalseByDefault()
        {

            var user = new ApplicationUser
            {
                Id = "user8",
                FirstName = "Test",
                LastName = "User8",
                Height = 175,
                Weight = 75,
                Aim = "Test Aim",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 8,
                Specialization = "Sports Nutrition",
                Experience = 8,
                
                SertificateImage = "sports_cert8.jpg", // Required field
                SertificationDetails = "Sports Nutrition Certificate",
                Bio = "Sports nutrition expert",
                PhoneNumber = "+1472583690",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 8,
                Name = "Sports Meal 8",
                Recipe = "High protein recipe",
                MealTime = "Post-workout",
                ImageUrl = "sports_meal8.jpg",
                VideoUrl = "sports_meal8.mp4",
                DificultyLevel = "Hard",
                Calories = 700,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 8,
                Name = "Sports Diet 8",
                Description = "Athletic diet plan",
                UserId = "user8",
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var request = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "Is this meal suitable for pre-competition?"
            };

            // Act
            await mealFeedbackService.AddMealFeedbackAsync(request);

            // Assert
            var feedback = await repository.AllAsReadOnly<MealFeedback>().FirstOrDefaultAsync();

            Assert.That(feedback, Is.Not.Null);
            Assert.That(feedback.IsAnswered, Is.False, "New feedback should have IsAnswered set to false by default");
        }
        [Test]
        public async Task DeleteMealFeedbackAsync_WithValidData_ShouldDeleteFeedback()
        {

            var user = new ApplicationUser
            {
                Id = "deleteUser1",
                UserName = "deleteUser1@example.com",
                FirstName = "Delete",
                LastName = "User1",
                Height = 180,
                Weight = 75,
                Aim = "Fitness",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);


            var dietitian = new Dietitian
            {
                Id = 10,
                Specialization = "Sports Nutrition",
                Experience = 8,
                SertificateImage = "delete_test_cert.jpg",
                SertificationDetails = "Sports Nutrition Certificate",
                Bio = "Experienced sports nutritionist",
                PhoneNumber = "+1122334455",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 10,
                Name = "Delete Test Meal",
                Recipe = "Test recipe for deletion",
                MealTime = "Lunch",
                ImageUrl = "delete_test_meal.jpg",
                VideoUrl = "delete_test_meal.mp4",
                DificultyLevel = "Medium",
                Calories = 450,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 10,
                Name = "Delete Test Diet",
                Description = "Test diet for deletion",
                ImageUrl = "delete_test_diet.jpg", 
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);


            var mealFeedback = new MealFeedback
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Feedback = "Feedback to be deleted",
                IsAnswered = false,
                CreatedAt = DateTime.Now
            };
            await repository.AddAsync(mealFeedback);
            await repository.SaveChangesAsync();

            var deleteModel = new DeleteCommentModelDTO
            {
                MealId = meal.Id,
                DietId = diet.Id
            };


            await mealFeedbackService.DeleteMealFeedbackAsync(deleteModel);


            var feedbacks = await repository.AllAsReadOnly<MealFeedback>().ToListAsync();
            Assert.That(feedbacks.Count, Is.EqualTo(0), "Feedback should be deleted");
        }

        [Test]
        public async Task DeleteMealFeedbackAsync_WithNonExistentFeedback_ShouldThrowArgumentException()
        {

            var user = new ApplicationUser
            {
                Id = "deleteUser2",
                UserName = "deleteUser2@example.com",
                FirstName = "Delete",
                LastName = "User2",
                Height = 175,
                Weight = 70,
                Aim = "Weight Loss",
                ExperienceLevel = "Beginner"
            };
            await repository.AddAsync(user);


            var dietitian = new Dietitian
            {
                Id = 11,
                Specialization = "Weight Management",
                Experience = 5,
                SertificateImage = "delete_test_cert2.jpg",
                SertificationDetails = "Weight Management Certificate",
                Bio = "Weight management specialist",
                PhoneNumber = "+9988776655",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);


            var meal = new Meal
            {
                Id = 11,
                Name = "Delete Test Meal 2",
                Recipe = "Another test recipe",
                MealTime = "Dinner",
                ImageUrl = "delete_test_meal2.jpg",
                VideoUrl = "delete_test_meal2.mp4",
                DificultyLevel = "Easy",
                Calories = 350,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

 
            var diet = new Diet
            {
                Id = 11,
                Name = "Delete Test Diet 2",
                Description = "Another test diet",
                ImageUrl = "delete_test_diet2.jpg", 
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var deleteModel = new DeleteCommentModelDTO
            {
                MealId = meal.Id,
                DietId = diet.Id

            };


            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await mealFeedbackService.DeleteMealFeedbackAsync(deleteModel));


        }

        [Test]
        public async Task DeleteMealFeedbackAsync_WithMultipleFeedbacks_ShouldDeleteOnlySpecifiedFeedback()
        {

            var user = new ApplicationUser
            {
                Id = "deleteUser3",
                UserName = "deleteUser3@example.com",
                FirstName = "Delete",
                LastName = "User3",
                Height = 182,
                Weight = 80,
                Aim = "Muscle Gain",
                ExperienceLevel = "Advanced"
            };
            await repository.AddAsync(user);


            var dietitian = new Dietitian
            {
                Id = 12,
                Specialization = "Muscle Nutrition",
                Experience = 10,
                SertificateImage = "delete_test_cert3.jpg",
                SertificationDetails = "Muscle Nutrition Certificate",
                Bio = "Muscle nutrition specialist",
                PhoneNumber = "+1231231234",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);


            var meal1 = new Meal
            {
                Id = 12,
                Name = "Delete Test Meal 3-1",
                Recipe = "High protein recipe",
                MealTime = "Breakfast",
                ImageUrl = "delete_test_meal3_1.jpg",
                VideoUrl = "delete_test_meal3_1.mp4",
                DificultyLevel = "Medium",
                Calories = 500,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal1);

            var meal2 = new Meal
            {
                Id = 13,
                Name = "Delete Test Meal 3-2",
                Recipe = "High carb recipe",
                MealTime = "Post-workout",
                ImageUrl = "delete_test_meal3_2.jpg",
                VideoUrl = "delete_test_meal3_2.mp4",
                DificultyLevel = "Hard",
                Calories = 600,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal2);

            var diet = new Diet
            {
                Id = 12,
                Name = "Delete Test Diet 3",
                Description = "Muscle gain diet",
                ImageUrl = "delete_test_diet3.jpg",
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);

            var mealFeedback1 = new MealFeedback
            {
                MealId = meal1.Id,
                DietId = diet.Id,
                Feedback = "Feedback 1 to be kept",
                IsAnswered = false,
                CreatedAt = DateTime.Now.AddDays(-1)
            };
            await repository.AddAsync(mealFeedback1);

            var mealFeedback2 = new MealFeedback
            {
                MealId = meal2.Id,
                DietId = diet.Id,
                Feedback = "Feedback 2 to be deleted",
                IsAnswered = true,
                CreatedAt = DateTime.Now
            };
            await repository.AddAsync(mealFeedback2);
            await repository.SaveChangesAsync();

            var deleteModel = new DeleteCommentModelDTO
            {
                MealId = meal2.Id,
                DietId = diet.Id
            };


            await mealFeedbackService.DeleteMealFeedbackAsync(deleteModel);


            var feedbacks = await repository.AllAsReadOnly<MealFeedback>().ToListAsync();
            Assert.That(feedbacks.Count, Is.EqualTo(1), "Only the specified feedback should be deleted");
            Assert.That(feedbacks[0].MealId, Is.EqualTo(meal1.Id), "The correct feedback should remain");
            Assert.That(feedbacks[0].DietId, Is.EqualTo(diet.Id));
            Assert.That(feedbacks[0].Feedback, Is.EqualTo("Feedback 1 to be kept"));
        }


        [Test]
        public async Task EditMealFeedbackAsync_WithValidData_ShouldUpdateFeedbackContent()
        {

            var user = new ApplicationUser
            {
                Id = "editUser1",
                UserName = "editUser1@example.com",
                FirstName = "Edit",
                LastName = "User1",
                Height = 178,
                Weight = 73,
                Aim = "Balanced Diet",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);

            // Create dietitian
            var dietitian = new Dietitian
            {
                Id = 20,
                Specialization = "Balanced Nutrition",
                Experience = 7,
                SertificateImage = "edit_test_cert.jpg",
                SertificationDetails = "Nutrition Certificate",
                Bio = "Balanced nutrition expert",
                PhoneNumber = "+5544332211",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            // Create meal
            var meal = new Meal
            {
                Id = 20,
                Name = "Edit Test Meal",
                Recipe = "Test recipe for editing",
                MealTime = "Lunch",
                ImageUrl = "edit_test_meal.jpg",
                VideoUrl = "edit_test_meal.mp4",
                DificultyLevel = "Easy",
                Calories = 400,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            // Create diet with required ImageUrl
            var diet = new Diet
            {
                Id = 20,
                Name = "Edit Test Diet",
                Description = "Test diet for editing",
                ImageUrl = "edit_test_diet.jpg", // Required field
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);

            // Create meal feedback to edit
            var mealFeedback = new MealFeedback
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Feedback = "Original feedback content",
                IsAnswered = false,
                CreatedAt = DateTime.Now.AddHours(-1)
            };
            await repository.AddAsync(mealFeedback);
            await repository.SaveChangesAsync();

            var editRequest = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "Updated feedback content"
            };

            // Act
            await mealFeedbackService.EditMealFeedbackAsync(editRequest);

            // Assert
            var updatedFeedback = await repository.AllAsReadOnly<MealFeedback>()
                .FirstOrDefaultAsync(f => f.MealId == meal.Id && f.DietId == diet.Id);

            Assert.That(updatedFeedback, Is.Not.Null);
            Assert.That(updatedFeedback.Feedback, Is.EqualTo("Updated feedback content"));
            // CreatedAt and IsAnswered should remain unchanged
            Assert.That(updatedFeedback.IsAnswered, Is.False);
        }

        [Test]
        public async Task EditMealFeedbackAsync_WithNonExistentFeedback_ShouldThrowArgumentException()
        {

            var user = new ApplicationUser
            {
                Id = "editUser2",
                UserName = "editUser2@example.com",
                FirstName = "Edit",
                LastName = "User2",
                Height = 170,
                Weight = 65,
                Aim = "Healthy Diet",
                ExperienceLevel = "Beginner"
            };
            await repository.AddAsync(user);


            var dietitian = new Dietitian
            {
                Id = 21,
                Specialization = "Healthy Eating",
                Experience = 4,
                SertificateImage = "edit_test_cert2.jpg",
                SertificationDetails = "Healthy Eating Certificate",
                Bio = "Healthy eating specialist",
                PhoneNumber = "+9876543210",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);


            var meal = new Meal
            {
                Id = 21,
                Name = "Edit Test Meal 2",
                Recipe = "Healthy recipe",
                MealTime = "Dinner",
                ImageUrl = "edit_test_meal2.jpg",
                VideoUrl = "edit_test_meal2.mp4",
                DificultyLevel = "Easy",
                Calories = 350,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);


            var diet = new Diet
            {
                Id = 21,
                Name = "Edit Test Diet 2",
                Description = "Healthy diet plan",
                ImageUrl = "edit_test_diet2.jpg", 
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var editRequest = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "This feedback doesn't exist"

            };


            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await mealFeedbackService.EditMealFeedbackAsync(editRequest));

        }

        [Test]
        public async Task EditMealFeedbackAsync_WithEmptyContent_ShouldUpdateWithEmptyContent()
        {

            var user = new ApplicationUser
            {
                Id = "editUser3",
                UserName = "editUser3@example.com",
                FirstName = "Edit",
                LastName = "User3",
                Height = 185,
                Weight = 85,
                Aim = "Weight Maintenance",
                ExperienceLevel = "Advanced"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 22,
                Specialization = "Weight Maintenance",
                Experience = 9,
                SertificateImage = "edit_test_cert3.jpg",
                SertificationDetails = "Weight Maintenance Certificate",
                Bio = "Weight maintenance expert",
                PhoneNumber = "+1357924680",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 22,
                Name = "Edit Test Meal 3",
                Recipe = "Balanced recipe",
                MealTime = "Snack",
                ImageUrl = "edit_test_meal3.jpg",
                VideoUrl = "edit_test_meal3.mp4",
                DificultyLevel = "Medium",
                Calories = 250,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 22,
                Name = "Edit Test Diet 3",
                Description = "Balanced diet plan",
                ImageUrl = "edit_test_diet3.jpg", 
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);


            var mealFeedback = new MealFeedback
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Feedback = "Original feedback with content",
                IsAnswered = true,
                CreatedAt = DateTime.Now.AddDays(-1)
            };
            await repository.AddAsync(mealFeedback);
            await repository.SaveChangesAsync();

            var editRequest = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = "" 
            };


            await mealFeedbackService.EditMealFeedbackAsync(editRequest);

            var updatedFeedback = await repository.AllAsReadOnly<MealFeedback>()
                .FirstOrDefaultAsync(f => f.MealId == meal.Id && f.DietId == diet.Id);

            Assert.That(updatedFeedback, Is.Not.Null);
            Assert.That(updatedFeedback.Feedback, Is.EqualTo(string.Empty));

            Assert.That(updatedFeedback.IsAnswered, Is.True);
        }

        [Test]
        public async Task EditMealFeedbackAsync_WithMaxLengthContent_ShouldUpdateWithMaxLengthContent()
        {

            var user = new ApplicationUser
            {
                Id = "editUser4",
                UserName = "editUser4@example.com",
                FirstName = "Edit",
                LastName = "User4",
                Height = 172,
                Weight = 68,
                Aim = "Fitness",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);

            var dietitian = new Dietitian
            {
                Id = 23,
                Specialization = "Fitness Nutrition",
                Experience = 6,
                SertificateImage = "edit_test_cert4.jpg",
                SertificationDetails = "Fitness Nutrition Certificate",
                Bio = "Fitness nutrition expert",
                PhoneNumber = "+2468013579",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);

            var meal = new Meal
            {
                Id = 23,
                Name = "Edit Test Meal 4",
                Recipe = "Fitness recipe",
                MealTime = "Pre-workout",
                ImageUrl = "edit_test_meal4.jpg",
                VideoUrl = "edit_test_meal4.mp4",
                DificultyLevel = "Hard",
                Calories = 550,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal);

            var diet = new Diet
            {
                Id = 23,
                Name = "Edit Test Diet 4",
                Description = "Fitness diet plan",
                ImageUrl = "edit_test_diet4.jpg", 
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);


            var mealFeedback = new MealFeedback
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Feedback = "Short original feedback",
                IsAnswered = false,
                CreatedAt = DateTime.Now.AddHours(-2)
            };
            await repository.AddAsync(mealFeedback);
            await repository.SaveChangesAsync();


            string maxLengthContent = new string('A', 500);
            var editRequest = new SubmitCommentRequestDTO
            {
                MealId = meal.Id,
                DietId = diet.Id,
                Content = maxLengthContent
            };


            await mealFeedbackService.EditMealFeedbackAsync(editRequest);


            var updatedFeedback = await repository.AllAsReadOnly<MealFeedback>()
                .FirstOrDefaultAsync(f => f.MealId == meal.Id && f.DietId == diet.Id);

            Assert.That(updatedFeedback, Is.Not.Null);
            Assert.That(updatedFeedback.Feedback, Is.EqualTo(maxLengthContent));
            Assert.That(updatedFeedback.Feedback.Length, Is.EqualTo(500));
        }

        [Test]
        public async Task EditMealFeedbackAsync_WithMultipleFeedbacks_ShouldUpdateOnlySpecifiedFeedback()
        {

            var user = new ApplicationUser
            {
                Id = "editUser5",
                UserName = "editUser5@example.com",
                FirstName = "Edit",
                LastName = "User5",
                Height = 175,
                Weight = 75,
                Aim = "General Fitness",
                ExperienceLevel = "Intermediate"
            };
            await repository.AddAsync(user);


            var dietitian = new Dietitian
            {
                Id = 24,
                Specialization = "General Nutrition",
                Experience = 7,
                SertificateImage = "edit_test_cert5.jpg",
                SertificationDetails = "General Nutrition Certificate",
                Bio = "General nutrition expert",
                PhoneNumber = "+9876543210",
                UserId = user.Id
            };
            await repository.AddAsync(dietitian);


            var meal1 = new Meal
            {
                Id = 24,
                Name = "Edit Test Meal 5-1",
                Recipe = "Recipe 1",
                MealTime = "Breakfast",
                ImageUrl = "edit_test_meal5_1.jpg",
                VideoUrl = "edit_test_meal5_1.mp4",
                DificultyLevel = "Easy",
                Calories = 300,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal1);

            var meal2 = new Meal
            {
                Id = 25,
                Name = "Edit Test Meal 5-2",
                Recipe = "Recipe 2",
                MealTime = "Dinner",
                ImageUrl = "edit_test_meal5_2.jpg",
                VideoUrl = "edit_test_meal5_2.mp4",
                DificultyLevel = "Medium",
                Calories = 550,
                CreatedById = dietitian.Id
            };
            await repository.AddAsync(meal2);

            var diet = new Diet
            {
                Id = 24,
                Name = "Edit Test Diet 5",
                Description = "General diet plan",
                ImageUrl = "edit_test_diet5.jpg", 
                UserId = user.Id,
                CreatedById = dietitian.Id,
                IsActive = true
            };
            await repository.AddAsync(diet);


            var mealFeedback1 = new MealFeedback
            {
                MealId = meal1.Id,
                DietId = diet.Id,
                Feedback = "Feedback 1 - should not change",
                IsAnswered = false,
                CreatedAt = DateTime.Now.AddDays(-1)
            };
            await repository.AddAsync(mealFeedback1);

            var mealFeedback2 = new MealFeedback
            {
                MealId = meal2.Id,
                DietId = diet.Id,
                Feedback = "Feedback 2 - to be updated",
                IsAnswered = true,
                CreatedAt = DateTime.Now
            };
            await repository.AddAsync(mealFeedback2);
            await repository.SaveChangesAsync();

            var editRequest = new SubmitCommentRequestDTO
            {
                MealId = meal2.Id,
                DietId = diet.Id,
                Content = "Updated feedback for meal 2"
            };


            await mealFeedbackService.EditMealFeedbackAsync(editRequest);

            var feedbacks = await repository.AllAsReadOnly<MealFeedback>()
                .OrderBy(f => f.MealId)
                .ToListAsync();

            Assert.That(feedbacks.Count, Is.EqualTo(2), "Both feedbacks should still exist");

            Assert.That(feedbacks[0].MealId, Is.EqualTo(meal1.Id));
            Assert.That(feedbacks[0].Feedback, Is.EqualTo("Feedback 1 - should not change"),
                "The first feedback should remain unchanged");

            Assert.That(feedbacks[1].MealId, Is.EqualTo(meal2.Id));
            Assert.That(feedbacks[1].Feedback, Is.EqualTo("Updated feedback for meal 2"),
                "The second feedback should be updated");
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }
    }
}
