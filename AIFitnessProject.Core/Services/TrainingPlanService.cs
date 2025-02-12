using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Document;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly IRepository repository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public TrainingPlanService(IRepository _repository, IHostingEnvironment hostingEnvironment)
        {
            this.repository = _repository;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task  CreateTrainigPlan(string id, string trainerId, CreateTraingPlanViewModel model)
        {
           var trainer = await repository.All<Trainer>().Where(x =>x.UserId == trainerId).FirstAsync();
            TrainingPlan  trainingPlan = new TrainingPlan()
            {
                Description = model.TrainingPlanDescription,
                Name = model.TrainingPlanName,
                CreatedById = trainer.Id,
                UserId = id,
                IsActive = false,
            };
            if (model.ImageUrl!= null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageUrl.CopyToAsync(memoryStream);
                    string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                   trainingPlan.ImageUrl = base64Image;
                }
            }

            await repository.AddAsync(trainingPlan);
            await repository.SaveChangesAsync();
        }

        public async Task<ICollection<AllTrainingPlanViewModel>> GetAllTrainingPlanAsync(string userId)
        {
            var trainer = await repository.All<Trainer>().Where(x => x.UserId == userId).FirstAsync();
            var models = await repository.AllAsReadOnly<TrainingPlan>().Include(x =>x.User)
                .Where(x =>x.Trainer.Id == trainer.Id)
                .Where(x =>x.IsActive == false)
                .Select(x => new AllTrainingPlanViewModel()
                {
                    Id = x.Id,
                    DescriptionOfTriningPlan = x.Description,
                    ImageUrl = x.ImageUrl,
                    TitleOfTriningPlan = x.Name,
                })
                .ToListAsync();

            return models;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<TrainingPlan>()
                .AnyAsync(x => x.Id == id);
        }
        public async Task<TrainingPlan> GetDietById(int id)
        {
            var trainingPlan = await repository.All<TrainingPlan>()
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();

            return trainingPlan;
        }
        public async Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetails(int id)
        {
            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                .Include(tp => tp.TrainingPlanWorkouts)
                    .ThenInclude(tpw => tpw.Workout)
                        .ThenInclude(w => w.WorkoutsExercises)
                            .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (trainingPlan == null)
            {
                return null;
            }

            var viewModel = new TrainingPlanDetailsViewModel
            {
                Id = trainingPlan.Id,
                Name = trainingPlan.Name,
                Description = trainingPlan.Description,
                ImageUrl = trainingPlan.ImageUrl,
                Workouts = trainingPlan.TrainingPlanWorkouts.Select(tpWorkout => new WorkoutViewModel
                {
                    Title = tpWorkout.Workout.Title,
                    DayOfWeek = tpWorkout.Workout.DayOfWeek,
                    ImageUrl = tpWorkout.Workout.ImageUrl,
                    Exercises = tpWorkout.Workout.WorkoutsExercises.Select(we => new ExerciseViewModel
                    {
                        Id = we.ExcersiceId,
                        Name = we.Exercise.Name,
                        Description = we.Exercise.Description,
                        ImageUrl = we.Exercise.ImageUrl,
                        VideoUrl = we.Exercise.VideoUrl,
                        MuscleGroup = we.Exercise.MuscleGroup,
                        DifficultyLevel = we.Exercise.DifficultyLevel
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }


        public async Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetailsFromExercise(int exerciseId)
        {
            var workoutsExercise = await repository.AllAsReadOnly<WorkoutsExercise>()
                .Where(x => x.ExcersiceId == exerciseId)
                .Include(x => x.Workout)
                .ThenInclude(x => x.TrainingPlanWorkouts)
                .ThenInclude(x => x.TrainingPlan)
                .Include(x => x.Exercise)
                .FirstOrDefaultAsync();

            if (workoutsExercise == null || workoutsExercise.Workout?.TrainingPlanWorkouts == null)
            {
                return null;
            }

            var trainingPlan = workoutsExercise.Workout.TrainingPlanWorkouts.FirstOrDefault()?.TrainingPlan;

            if (trainingPlan == null)
            {
                return null;
            }

            var viewModel = new TrainingPlanDetailsViewModel
            {
                Id = trainingPlan.Id,
                Name = trainingPlan.Name,
                Description = trainingPlan.Description,
                ImageUrl = trainingPlan.ImageUrl,
                Workouts = trainingPlan.TrainingPlanWorkouts.Select(tpWorkout => new WorkoutViewModel
                {
                    Title = tpWorkout.Workout.Title,
                    DayOfWeek = tpWorkout.Workout.DayOfWeek,
                    ImageUrl = tpWorkout.Workout.ImageUrl,
                    Exercises = tpWorkout.Workout.WorkoutsExercises.Select(we => new ExerciseViewModel
                    {
                        Id = we.ExcersiceId,
                        Name = we.Exercise.Name,
                        Description = we.Exercise.Description,
                        ImageUrl = we.Exercise.ImageUrl,
                        VideoUrl = we.Exercise.VideoUrl,
                        MuscleGroup = we.Exercise.MuscleGroup,
                        DifficultyLevel = we.Exercise.DifficultyLevel
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }

        public async Task<EditTrainingPlanViewModel> GetTrainingPlanForEditAsync(int id)
        {
                  var model = await repository.AllAsReadOnly<TrainingPlan>()
                 .Where(x => x.Id == id)
                 .Select(x => new EditTrainingPlanViewModel()
                 {
                     ImageUrl = x.ImageUrl,
                     TrainingPlanName = x.Name,
                     TrainingPlanDescription = x.Description,
                 })
                 .FirstAsync();

            return model;
        }

        public async Task EditAsync(int id, EditTrainingPlanViewModel model)
        {
            var trainingPlan = await repository.All<TrainingPlan>().Where(x => x.Id == id).FirstAsync();

            if (trainingPlan != null)
            {
                trainingPlan.Name = model.TrainingPlanName;
                trainingPlan.Description = model.TrainingPlanDescription;

                if (model.NewImageUrl != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/exercises");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImageUrl.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.NewImageUrl.CopyToAsync(fileStream);
                    }
                    trainingPlan.ImageUrl = "/img/exercises/" + uniqueFileName;
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<SendTrainingPlanViewModel> GetTrainingPlanModelForSendView(int id)
        {
            var countOfWorkouts = await repository.AllAsReadOnly<TrainingPlanWorkout>()
                .Where(x => x.TrainingPlanId == id)
                .ToListAsync();

            var trainingPlanModel = await repository.AllAsReadOnly<TrainingPlan>()
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .Select(x => new SendTrainingPlanViewModel()
                {
                    Id = id,
                    DescriptionTrainingPlan = x.Description,
                    ImageUrlTrainingPlan = x.ImageUrl,
                    UserProfilePicture = x.User.ProfilePicture,
                    Name = x.Name,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    WorkoutsCount = countOfWorkouts.Count(),
                }).FirstAsync();

            return trainingPlanModel;
        }

        public async Task SendToUserAsync(int id)
        {
            var trainingPlan = await repository.All<TrainingPlan>()
                .Where(x =>x.Id == id)
                .FirstAsync();

            trainingPlan.IsActive = true;
            await repository.SaveChangesAsync();
        }
    }

}

