using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants;

namespace AIFitnessProject.Core.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository repository;

        public WorkoutService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task AddWorkout(string selectedIds, int trainingPlanId)
        {
            var ids = selectedIds.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < ids.Count; i++)
            {
                var workouts = await repository
                .All<Infrastructure.Data.Models.Workout>()
                .Where(x => x.Id == ids[i])
                .FirstAsync();

                workouts.TrainingPlanId = trainingPlanId;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<ICollection<WorkoutViewModel>> All(string userId,int id)
        {
            var trainer = await repository.AllAsReadOnly<Infrastructure.Data.Models.Trainer>()
                .Where(x => x.UserId == userId)
                 .FirstAsync();

            var model = await repository.AllAsReadOnly<Infrastructure.Data.Models.Workout>()
                 .Where(x => x.CreatorId == trainer.Id)
                 .Select(x => new WorkoutViewModel()
                 {
                     Id = x.Id,
                     Title = x.Title,
                     TrainingPlanId = id,
                     DayOfWeek = x.DayOfWeek,
                     ImageUrl = x.ImageUrl,
                     Exercises = x.WorkoutsExercises.Select(we => new ExerciseViewModel
                     {
                         Name = we.Exercise.Name,
                         Description = we.Exercise.Description,
                         ImageUrl = we.Exercise.ImageUrl,
                         VideoUrl = we.Exercise.VideoUrl,
                         MuscleGroup = we.Exercise.MuscleGroup,
                         Series = we.Exercise.Series,
                         Repetitions = we.Exercise.Repetitions,
                         DifficultyLevel = we.Exercise.DifficultyLevel
                     }).ToList()
                 })
                 .ToListAsync();

            return model;
        }

        public async Task<AddWorkoutViewModel> GetModelForAdd()
        {
           var model = new AddWorkoutViewModel();
           
            model.Exercises = await repository.AllAsReadOnly<Infrastructure.Data.Models.Exercise>()
                .Select(we => new ExerciseViewModel()
                {
                    Id = we.Id,
                    Name = we.Name,
                    Description = we.Description,
                    ImageUrl = we.ImageUrl,
                    VideoUrl = we.VideoUrl,
                    MuscleGroup = we.MuscleGroup,
                    Series = we.Series,
                    Repetitions = we.Repetitions,
                    DifficultyLevel = we.DifficultyLevel
                })
                .ToListAsync();

            return model;

        }

        public async Task<WorkoutViewModel> GetModelForDetails(int id)
        {
            var model = await repository.AllAsReadOnly<Infrastructure.Data.Models.Workout>()
                .Where(x => x.Id == id)
                .Select(x => new WorkoutViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DayOfWeek = x.DayOfWeek,
                    ImageUrl = x.ImageUrl,
                    Exercises = x.WorkoutsExercises.Select(we => new ExerciseViewModel
                    {
                        Id = we.Exercise.Id,
                        Name = we.Exercise.Name,
                        Description = we.Exercise.Description,
                        ImageUrl = we.Exercise.ImageUrl,
                        VideoUrl = we.Exercise.VideoUrl,
                        MuscleGroup = we.Exercise.MuscleGroup,
                        Series = we.Exercise.Series,
                        Repetitions = we.Exercise.Repetitions,
                        DifficultyLevel = we.Exercise.DifficultyLevel
                    }).ToList()
                })
                .FirstAsync();

            return model;
        }
    }
}
