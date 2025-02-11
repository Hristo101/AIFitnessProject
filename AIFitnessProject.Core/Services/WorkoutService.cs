using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository repository;
        private readonly IHostingEnvironment hostingEnvironment;
        public WorkoutService(IRepository _repository, IHostingEnvironment _hostingEnvironment)
        {
            this.repository = _repository;
            this.hostingEnvironment = _hostingEnvironment;
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

        public async Task<int> CreateWorkout(AddWorkoutViewModel model,string userId)
        {
            var trainer = await repository.AllAsReadOnly<Infrastructure.Data.Models.Trainer>()
               .Where(x => x.UserId == userId)
               .FirstOrDefaultAsync();

            Workout workout = new Workout()
           {
               CreatorId = trainer.Id,
               DayOfWeek = model.DayOfWeek,
               MuscleGroup = model.MuscleGroup,
               DificultyLevel = model.DifficultyLevel,
               OrderInWorkout = model.OrderInWorkout,
               Title = model.Title,
               TrainingPlanId = null,               
           };
            List<int> exercisesIds = model.SelectedWorkoutIds.Split(",").Select(int.Parse).ToList();

            if (model.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img/workouts");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageUrl.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageUrl.CopyToAsync(fileStream);
                }
                workout.ImageUrl = "/img/workouts/" + uniqueFileName;
            }
            await repository.AddAsync<Workout>(workout); 
            await repository.SaveChangesAsync();
            for (int i = 0; i < exercisesIds.Count; i++)
            {
                var exercise = await repository.AllAsReadOnly<Exercise>()
                    .Where(x => x.Id == exercisesIds[i])
                    .FirstAsync();

                WorkoutsExercise workoutsExercise = new WorkoutsExercise()
                {
                    ExcersiceId = exercise.Id,
                    WorkoutId = workout.Id,
                };
                await repository.AddAsync(workoutsExercise);
                await repository.SaveChangesAsync();
            }
            return model.TrainingPlanId;
        }

        public async Task<AddWorkoutViewModel> GetModelForAdd(int trainingPlanId)
        {
           var model = new AddWorkoutViewModel();
           model.TrainingPlanId = trainingPlanId;
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
                .FirstOrDefaultAsync();

            return model;
        }


        public async Task<ICollection<ExerciseViewModel>> ReturnAllExerciseViewModel(string userId)
        {
            var trainer = await repository.AllAsReadOnly<Infrastructure.Data.Models.Trainer>()
                .Where(x =>x.UserId == userId)
                .FirstOrDefaultAsync();

            var models = await repository.AllAsReadOnly<Infrastructure.Data.Models.Exercise>()
                 .Where(x => x.CreatedById == trainer.Id)
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

            return models;
        }
    }
}
