using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly IRepository repository;

        public TrainingPlanService(IRepository _repository)
        {
            this.repository = _repository;
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

        public async Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetails(int id)
        {
            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
            .Include(tp => tp.Workouts)
                .ThenInclude(w => w.WorkoutsExercises)
                    .ThenInclude(we => we.Exercise)
            .FirstOrDefaultAsync(tp => tp.Id == id);

            var viewModel = new TrainingPlanDetailsViewModel
            {
                Id = trainingPlan.Id,
                Name = trainingPlan.Name,
                Description = trainingPlan.Description,
                ImageUrl = trainingPlan.ImageUrl,
                Workouts = trainingPlan.Workouts.Select(workout => new WorkoutViewModel
                {
                    Title = workout.Title,
                    DayOfWeek = workout.DayOfWeek,
                    ImageUrl = workout.ImageUrl,
                    Exercises = workout.WorkoutsExercises.Select(we => new ExerciseViewModel
                    {
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
    }

}

