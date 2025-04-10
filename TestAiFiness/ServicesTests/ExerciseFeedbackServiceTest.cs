using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
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
    public class ExerciseFeedbackServiceTest
    {
        private IRepository repository;
        private IExerciseFeedbackService exerciseFeedbackService;
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
            exerciseFeedbackService = new ExerciseFeedbackService(repository);

        }
        [Test]
        public async Task AddExerciseFeedback_ShouldSuccessfullyAddFeedback()
        {

            var exercise = new Exercise
            {
                Name = "Test Exercise",
                Description = "Test Description",
                ImageUrl = "test-image.jpg",
                VideoUrl = "test-video.mp4",
                MuscleGroup = "Chest",
                DifficultyLevel = "Intermediate",
                Series = 3,
                Repetitions = 12,
                CreatedById = 1
            };
            await applicationDbContext.Exercises.AddAsync(exercise);
            await applicationDbContext.SaveChangesAsync();

            var submitCommentRequest = new SubmitCommentRequest
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1,
                Content = "Great exercise!"
            };

            await exerciseFeedbackService.AddExerciseFeedbackAsync(submitCommentRequest);


            var feedbackInDb = await applicationDbContext.ExerciseFeedbacks
                .FirstOrDefaultAsync(f =>
                    f.ExerciseId == exercise.Id &&
                    f.TrainingPlanId == 1 &&
                    f.Feedback == "Great exercise!");

            Assert.IsNotNull(feedbackInDb);
            Assert.AreEqual(submitCommentRequest.Content, feedbackInDb.Feedback);
            Assert.AreEqual(submitCommentRequest.ExerciseId, feedbackInDb.ExerciseId);
            Assert.AreEqual(submitCommentRequest.TrainingPlanId, feedbackInDb.TrainingPlanId);
        }

        [Test]
        public async Task AddExerciseFeedback_ShouldHandleMultipleFeedbacks()
        { 
            var exercise = new Exercise
            {
                Name = "Multiple Feedback Exercise",
                Description = "Test Description",
                ImageUrl = "test-image.jpg",
                VideoUrl = "test-video.mp4",
                MuscleGroup = "Back",
                DifficultyLevel = "Advanced",
                Series = 4,
                Repetitions = 10,
                CreatedById = 1
            };
            await applicationDbContext.Exercises.AddAsync(exercise);
            await applicationDbContext.SaveChangesAsync();

            var submitCommentRequests = new[]
            {
                new SubmitCommentRequest
                {
                    ExerciseId = exercise.Id,
                    TrainingPlanId = 1,
                    Content = "First feedback"
                },
                new SubmitCommentRequest
                {
                    ExerciseId = exercise.Id,
                    TrainingPlanId = 2,
                    Content = "Second feedback"
                }
            };


            foreach (var request in submitCommentRequests)
            {
                await exerciseFeedbackService.AddExerciseFeedbackAsync(request);
            }


            var feedbacksInDb = await applicationDbContext.ExerciseFeedbacks
                .Where(f => f.ExerciseId == exercise.Id)
                .ToListAsync();

            Assert.AreEqual(2, feedbacksInDb.Count);
            Assert.IsTrue(feedbacksInDb.Any(f => f.Feedback == "First feedback"));
            Assert.IsTrue(feedbacksInDb.Any(f => f.Feedback == "Second feedback"));
        }

        [Test]
        public async Task AddExerciseFeedback_ShouldSaveFeedbackWithCurrentTimestamp()
        {

            var exercise = new Exercise
            {
                Name = "Timestamp Exercise",
                Description = "Test Description",
                ImageUrl = "test-image.jpg",
                VideoUrl = "test-video.mp4",
                MuscleGroup = "Core",
                DifficultyLevel = "Intermediate",
                Series = 3,
                Repetitions = 12,
                CreatedById = 1
            };
            await applicationDbContext.Exercises.AddAsync(exercise);
            await applicationDbContext.SaveChangesAsync();

            var submitCommentRequest = new SubmitCommentRequest
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1,
                Content = "Timestamp feedback"
            };


            await exerciseFeedbackService.AddExerciseFeedbackAsync(submitCommentRequest);


            var feedbackInDb = await applicationDbContext.ExerciseFeedbacks
                .FirstOrDefaultAsync(f =>
                    f.ExerciseId == exercise.Id &&
                    f.TrainingPlanId == 1);

            Assert.IsNotNull(feedbackInDb);
            Assert.That(feedbackInDb.CreatedAt, Is.EqualTo(DateTime.Now).Within(1).Seconds);
        }

        [Test]
        public async Task EditExerciseFeedback_ShouldSuccessfullyUpdateFeedback()
        {

            var exercise = new Exercise
            {
                Name = "Edit Feedback Exercise",
                Description = "Test Description",
                ImageUrl = "test-image.jpg",
                VideoUrl = "test-video.mp4",
                MuscleGroup = "Legs",
                DifficultyLevel = "Beginner",
                Series = 3,
                Repetitions = 15,
                CreatedById = 1
            };
            await applicationDbContext.Exercises.AddAsync(exercise);
            await applicationDbContext.SaveChangesAsync();


            var initialFeedback = new ExerciseFeedback
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1,
                Feedback = "Initial feedback",
                CreatedAt = DateTime.Now
            };
            await applicationDbContext.ExerciseFeedbacks.AddAsync(initialFeedback);
            await applicationDbContext.SaveChangesAsync();


            var editRequest = new SubmitCommentRequest
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1,
                Content = "Updated feedback"
            };

            await exerciseFeedbackService.EditExerciseFeedbackAsync(editRequest);

      
            var updatedFeedback = await applicationDbContext.ExerciseFeedbacks
                .FirstOrDefaultAsync(f =>
                    f.ExerciseId == exercise.Id &&
                    f.TrainingPlanId == 1);

            Assert.IsNotNull(updatedFeedback);
            Assert.AreEqual("Updated feedback", updatedFeedback.Feedback);
        }

        [Test]
        public async Task EditExerciseFeedback_ShouldThrowExceptionWhenFeedbackNotFound()
        {
    
            var editRequest = new SubmitCommentRequest
            {
                ExerciseId = 999,
                TrainingPlanId = 1,
                Content = "Updated feedback"
            };

       
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await exerciseFeedbackService.EditExerciseFeedbackAsync(editRequest);
            });

        }

        [Test]
        public async Task DeleteExerciseFeedback_ShouldSuccessfullyDeleteFeedback()
        {

            var exercise = new Exercise
            {
                Id = 1,
                Name = "Delete Feedback Exercise",
                Description = "Test Description",
                ImageUrl = "test-image.jpg",
                VideoUrl = "test-video.mp4",
                MuscleGroup = "Arms",
                DifficultyLevel = "Intermediate",
                Series = 3,
                Repetitions = 12,
                CreatedById = 1
            };
            await applicationDbContext.Exercises.AddAsync(exercise);
            await applicationDbContext.SaveChangesAsync();

      
            var feedbackToDelete = new ExerciseFeedback
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1,
                Feedback = "Feedback to delete",
                CreatedAt = DateTime.Now
            };
            await applicationDbContext.ExerciseFeedbacks.AddAsync(feedbackToDelete);
            await applicationDbContext.SaveChangesAsync();


            applicationDbContext.ChangeTracker.Clear();

            var deleteModel = new DeleteCommentModel
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1
            };


            await exerciseFeedbackService.DeleteExerciseFeedbackAsync(deleteModel);


            var deletedFeedback = await applicationDbContext.ExerciseFeedbacks
                .AsNoTracking()
                .FirstOrDefaultAsync(f =>
                    f.ExerciseId == exercise.Id &&
                    f.TrainingPlanId == 1);

            Assert.IsNull(deletedFeedback);
        }

        [Test]
        public async Task DeleteExerciseFeedback_ShouldThrowExceptionWhenFeedbackNotFound()
        {

            var deleteModel = new DeleteCommentModel
            {
                ExerciseId = 999, 
                TrainingPlanId = 1
            };

      
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await exerciseFeedbackService.DeleteExerciseFeedbackAsync(deleteModel);
            });
        }

        [Test]
        public async Task DeleteExerciseFeedback_ShouldDeleteSpecificFeedbackWhenMultipleFeedbacksExist()
        {

            var exercise = new Exercise
            {
                Name = "Multiple Feedback Delete Exercise",
                Description = "Test Description",
                ImageUrl = "test-image.jpg",
                VideoUrl = "test-video.mp4",
                MuscleGroup = "Shoulders",
                DifficultyLevel = "Advanced",
                Series = 4,
                Repetitions = 10,
                CreatedById = 1
            };
            await applicationDbContext.Exercises.AddAsync(exercise);
            await applicationDbContext.SaveChangesAsync();

            var feedbacks = new[]
            {
        new ExerciseFeedback
        {
            ExerciseId = exercise.Id,
            TrainingPlanId = 1,
            Feedback = "First feedback",
            CreatedAt = DateTime.Now
        },
        new ExerciseFeedback
        {
            ExerciseId = exercise.Id,
            TrainingPlanId = 2,
            Feedback = "Second feedback",
            CreatedAt = DateTime.Now
        }
    };
            await applicationDbContext.ExerciseFeedbacks.AddRangeAsync(feedbacks);
            await applicationDbContext.SaveChangesAsync();

 
            applicationDbContext.ChangeTracker.Clear();


            var deleteModel = new DeleteCommentModel
            {
                ExerciseId = exercise.Id,
                TrainingPlanId = 1
            };

           
            await exerciseFeedbackService.DeleteExerciseFeedbackAsync(deleteModel);

        
            var remainingFeedbacks = await applicationDbContext.ExerciseFeedbacks
                .AsNoTracking() 
                .Where(f => f.ExerciseId == exercise.Id)
                .ToListAsync();

            Assert.AreEqual(1, remainingFeedbacks.Count);
            Assert.AreEqual("Second feedback", remainingFeedbacks[0].Feedback);
            Assert.AreEqual(2, remainingFeedbacks[0].TrainingPlanId);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();

        }
    }
}
