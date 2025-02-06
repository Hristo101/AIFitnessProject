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

        public async Task<ICollection<WorkoutViewModel>> All(string userId)
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
