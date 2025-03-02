using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
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
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public WorkoutService(IRepository _repository, Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment)
        {
            this.repository = _repository;
            this.hostingEnvironment = _hostingEnvironment;
        }
        public async Task AddWorkout(string selectedIds, int trainingPlanId)
        {
            var ids = selectedIds.Split(',').Select(int.Parse).ToList();

            foreach (var id in ids)
            {
                var workout = await repository.All<Workout>()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (workout != null)
                {
                    var trainingPlanWorkout = new TrainingPlanWorkout
                    {
                        TrainingPlanId = trainingPlanId,
                        WorkoutId = workout.Id
                    };

                    await repository.AddAsync(trainingPlanWorkout);
                }
            }
            await repository.SaveChangesAsync();
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

        public async Task<ICollection<ExerciseViewModel>> AllExercise()
        {
            var allExercise = await repository.AllAsReadOnly<Exercise>()
               .Select(x => new ExerciseViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   ImageUrl = x.ImageUrl,
                   VideoUrl = x.VideoUrl,
                   Repetitions = x.Repetitions,
                   Series = x.Series,
                   DifficultyLevel = x.DifficultyLevel,
                   MuscleGroup = x.MuscleGroup
               })
               .ToListAsync();

            return allExercise;
        }

        public async Task<ICollection<WorkoutViewModelForTrainer>> AllWorkousForTrainer(string userId)
        {
            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                .Where(x =>x.UserId == userId)
                .FirstOrDefaultAsync();


                      var trainingPlanWorkouts = await repository.AllAsReadOnly<TrainingPlanWorkout>()
               .Include(x => x.TrainingPlan)
               .Include(x => x.Workout)
                   .ThenInclude(x => x.WorkoutsExercises)
                   .ThenInclude(x => x.Exercise)
               .Where(x => x.TrainingPlanId == trainingPlan.Id)
               .Select(x => new WorkoutViewModelForTrainer
               {
                   Id = x.WorkoutId,
                   UserId = userId,
                   TrainingPlanId = x.TrainingPlanId,
                   DayOfWeek = x.Workout.DayOfWeek,
                   DifficultyLevel = x.Workout.DificultyLevel,
                   ImageUrl = x.Workout.ImageUrl,
                   MuscleGroup = x.Workout.MuscleGroup,
                   Title = x.Workout.Title,
                   IsEdit = x.TrainingPlan.IsInCalendar,
                   ExerciseCount = x.Workout.WorkoutsExercises.Count
               }).ToListAsync();
             
            return trainingPlanWorkouts;

        }

        public async Task AttachNewExerciseToWorkoutAsync(int workoutId, string exerciseIds)
        {
            var items = exerciseIds.Split(",").Select(int.Parse).ToList();

            foreach (var item in items)
            {
                var workoutExercise = new WorkoutsExercise()
                {
                    WorkoutId = workoutId,
                    ExcersiceId = item
                };
                await repository.AddAsync(workoutExercise);
                await repository.SaveChangesAsync();
            }
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

        public async Task DeleteExercise(int workoutId, int exerciseId)
        {
            var modelForDelete = await repository.All<WorkoutsExercise>()
                .Where(x =>x.WorkoutId == workoutId && x.ExcersiceId == exerciseId)
                .FirstOrDefaultAsync();

            repository.Delete(modelForDelete);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteWorkoutForTrainer(int id, int trainingPlanId)
        {
            var trainingPlanWorkout = await repository.All<TrainingPlanWorkout>()
                .Where(x =>x.WorkoutId == id && x.TrainingPlanId == trainingPlanId)
                .FirstOrDefaultAsync();

             repository.Delete(trainingPlanWorkout);
            await repository.SaveChangesAsync();
        }

        public async Task EditWourkout(int trainingPlanId, int workoutId, EditWorkoutViewModelForTrainer model)
        {
            var trainingPlanWorkouts = await repository.All<TrainingPlanWorkout>()
                .Where( x=>x.WorkoutId == workoutId)
                .Where(x =>x.TrainingPlanId == trainingPlanId)
                .Include(x => x.TrainingPlan)
                .Include(x =>x.Workout)
                .FirstOrDefaultAsync();

            trainingPlanWorkouts.Workout.Title = model.Title;
            trainingPlanWorkouts.Workout.DayOfWeek = model.DayOfWeek;
            trainingPlanWorkouts.Workout.DificultyLevel = model.DifficultyLevel;
            trainingPlanWorkouts.Workout.MuscleGroup = model.MuscleGroup;
            if (model.NewImageUrl != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img/workouts");

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
                trainingPlanWorkouts.Workout.ImageUrl = "/img/workouts/" + uniqueFileName;
            }
            await repository.SaveChangesAsync();
        }

        public async Task<DetailsWorkoutViewModelForTrainer> GetDetailsWorkoutViewModelForTrainer(int id,string userId)
        {
           var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x =>x.Id == userId)
                .FirstOrDefaultAsync();

            var model = await repository.AllAsReadOnly<Workout>()
                .Include(x =>x.WorkoutsExercises)
                .ThenInclude(x =>x.Exercise)
                .Where(x =>x.Id == id)
                .Select(x => new DetailsWorkoutViewModelForTrainer
                {
                    Id = x.Id,
                    DayOfWeek = x.DayOfWeek,
                    DifficultyLevel = x.DificultyLevel,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ProfilePicture = user.ProfilePicture,
                    ImageUrl = x.ImageUrl,
                    MuscleGroup = x.MuscleGroup,
                    Title = x.Title,
                    Exercises = x.WorkoutsExercises.Select(x => new ExerciseViewModel
                    {
                        Id = x.Exercise.Id,
                        Name = x.Exercise.Name,
                        Description = x.Exercise.Description,
                        ImageUrl = x.Exercise.ImageUrl,
                        VideoUrl = x.Exercise.VideoUrl,
                        Repetitions = x.Exercise.Repetitions,
                        Series = x.Exercise.Series,
                        DifficultyLevel = x.Exercise.DifficultyLevel,
                        MuscleGroup = x.Exercise.MuscleGroup
                    }).ToList(),
                    ExerciseCount = x.WorkoutsExercises.Count,
                }).FirstOrDefaultAsync();

            return model;
        }

        public async Task<EditWorkoutViewModelForTrainer> GetEditWorkoutViewModelForTrainer(int id,string userId,string trainerId)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
            .Where(x => x.UserId == trainerId)
             .FirstOrDefaultAsync();


            var allExercise = await AllExercise();


            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                .Where(x =>x.UserId == userId)
                .Where(x=>x.CreatedById == trainer.Id)
                .FirstOrDefaultAsync(); 

            var model = await repository.AllAsReadOnly<Workout>()
              .Include(x => x.WorkoutsExercises)
              .ThenInclude(x => x.Exercise)
              .Where(x => x.Id == id)
              .Select(x => new EditWorkoutViewModelForTrainer
              {
                  Id = x.Id,
                  DayOfWeek = x.DayOfWeek,
                  TrainingPlanId = trainingPlan.Id,
                  UserId = userId,
                  DifficultyLevel = x.DificultyLevel,
                  ImageUrl = x.ImageUrl,
                  MuscleGroup = x.MuscleGroup,
                  Title = x.Title,
                  Exercises = x.WorkoutsExercises.Select(x => new ExerciseViewModel
                  {
                      Id = x.Exercise.Id,
                      Name = x.Exercise.Name,
                      Description = x.Exercise.Description,
                      ImageUrl = x.Exercise.ImageUrl,
                      VideoUrl = x.Exercise.VideoUrl,
                      Repetitions = x.Exercise.Repetitions,
                      Series = x.Exercise.Series,
                      DifficultyLevel = x.Exercise.DifficultyLevel,
                      MuscleGroup = x.Exercise.MuscleGroup
                  }).ToList(),
                  ExerciseCount = x.WorkoutsExercises.Count,
              }).FirstOrDefaultAsync();

            model.AllExercises = allExercise;
            return model;
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
