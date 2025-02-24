using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using Microsoft.AspNetCore.Http;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using AIFitnessProject.Core.DTOs;

namespace AIFitnessProject.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository repository;

        public ExerciseService(IHostingEnvironment hostingEnvironment, IRepository _repository)
        {
            _hostingEnvironment = hostingEnvironment;
            this.repository = _repository;
        }

        public async Task AddExercise(CreateExerciseViewModel model, string userId)
        {
            var trainer = await repository.AllAsReadOnly<Infrastructure.Data.Models.Trainer>()
                .Where(x => x.UserId == userId)
                 .FirstAsync();

            var exercise = new Infrastructure.Data.Models.Exercise()
            {
                CreatedById = trainer.Id,
                Description = model.Description,
                DifficultyLevel = model.DifficultyLevel,
                MuscleGroup = model.MuscleGroup,
                Name = model.Name,
                Repetitions = model.Repetitions,
                Series = model.Series,
                VideoUrl = model.VideoUrl,
            };

            if (model.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/exercises");

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
                exercise.ImageUrl = "/img/exercises/" + uniqueFileName;
            }
            await repository.AddAsync(exercise);
            await repository.SaveChangesAsync();

        }

        public async Task EditAsync(int id, EditExerciseViewModel model)
        {
            var exercise = await repository.All<Infrastructure.Data.Models.Exercise>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (exercise != null)
            {
                exercise.MuscleGroup = model.MuscleGroup;
                exercise.Description = model.Description;
                exercise.Series = model.Series;
                exercise.Repetitions = model.Repetitions;
                exercise.DifficultyLevel = model.DifficultyLevel;
                exercise.VideoUrl = model.VideoUrl;
                exercise.Name = model.Name;

                if (model.NewImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/exercises");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.NewImage.CopyToAsync(fileStream);
                    }
                    exercise.ImageUrl = "/img/exercises/" + uniqueFileName;
                }

                await repository.SaveChangesAsync();
            }
        }


        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Infrastructure.Data.Models.Exercise>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<DetailsExerciseViewModel> GetModelForDetailsFromWorkouts(int id)
        {
            var workoutExercise = await repository.AllAsReadOnly<WorkoutsExercise>()
                .Where(x => x.ExcersiceId == id)
                .Include(x => x.Workout)
                    .ThenInclude(w => w.TrainingPlanWorkouts)
                        .ThenInclude(tpw => tpw.TrainingPlan)
                .FirstOrDefaultAsync();

            if (workoutExercise == null)
            {
                return null;
            }

            var exercise = await repository.AllAsReadOnly<Exercise>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (exercise == null)
            {
                return null;
            }

            var viewModel = new DetailsExerciseViewModel()
            {
                Id = exercise.Id,
                WorkoutId = workoutExercise.WorkoutId,
                Description = exercise.Description,
                DifficultyLevel = exercise.DifficultyLevel,
                ImageUrl = exercise.ImageUrl,
                VideoUrl = exercise.VideoUrl,
                MuscleGroup = exercise.MuscleGroup,
                Name = exercise.Name,
                Repetitions = exercise.Repetitions,
                Series = exercise.Series,
            };

            return viewModel;
        }



        public async Task<ExerciseViewModel> GetModelForDetails(int id, string userId)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x => x.UserId == userId)
                .FirstAsync();



            var workoutExercise = await repository.AllAsReadOnly<WorkoutsExercise>()
                .Where(x => x.ExcersiceId == id)
                .Include(x => x.Workout)
                    .ThenInclude(w => w.TrainingPlanWorkouts)
                    .ThenInclude(w => w.TrainingPlan)
                .FirstOrDefaultAsync();

            if (workoutExercise == null)
            {
                return null;
            }

            var trainingPlanId = workoutExercise.Workout.TrainingPlanWorkouts
                .Where(x => x.TrainingPlan.IsActive == false)
                .Where(x => x.TrainingPlan.UserId == userId)
                .Select(tp => tp.TrainingPlanId)
                .FirstOrDefault();

            var exercise = await repository.AllAsReadOnly<Exercise>()
                .Where(x => x.Id == id)
                .Select(x => new ExerciseViewModel()
                {
                    Id = x.Id,
                    TrainingPlanId = trainingPlanId,
                    Description = x.Description,
                    DifficultyLevel = x.DifficultyLevel,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    MuscleGroup = x.MuscleGroup,
                    Name = x.Name,
                    Repetitions = x.Repetitions,
                    Series = x.Series,
                }).FirstOrDefaultAsync();

            return exercise;
        }
        public async Task<ExerciseViewModel> GetModelForDetailsForUser(int id, string userId)
        {
            var trainer = await repository.AllAsReadOnly<TrainingPlan>()
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .FirstAsync();



            var workoutExercise = await repository.AllAsReadOnly<WorkoutsExercise>()
                .Where(x => x.ExcersiceId == id)
                .Include(x => x.Workout)
                    .ThenInclude(w => w.TrainingPlanWorkouts)
                    .ThenInclude(w => w.TrainingPlan)
                .FirstOrDefaultAsync();

            if (workoutExercise == null)
            {
                return null;
            }

            var trainingPlanId = workoutExercise.Workout.TrainingPlanWorkouts
                .Where(x => x.TrainingPlan.IsActive == false)
                .Where(x => x.TrainingPlan.UserId == userId)
                .Select(tp => tp.TrainingPlanId)
                .FirstOrDefault();

            var exercise = await repository.AllAsReadOnly<Exercise>()
                .Where(x => x.Id == id)
                .Select(x => new ExerciseViewModel()
                {
                    Id = x.Id,
                    TrainingPlanId = trainer.Id,
                    Description = x.Description,
                    DifficultyLevel = x.DifficultyLevel,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    MuscleGroup = x.MuscleGroup,
                    Name = x.Name,
                    Repetitions = x.Repetitions,
                    Series = x.Series,
                }).FirstOrDefaultAsync();

            return exercise;
        }

        public async Task<bool> SwapExerciseInWorkoutAsync(SwapExerciseRequest request)
        {
            var trainingPlan = await repository.All<TrainingPlan>()
                .Include(tp => tp.TrainingPlanWorkouts)
                    .ThenInclude(tpw => tpw.Workout)
                        .ThenInclude(w => w.WorkoutsExercises)
                            .ThenInclude(we => we.Exercise)
                                .ThenInclude(e => e.ExerciseFeedbacks)
                .FirstOrDefaultAsync(tp => tp.Id == request.TrainingPlanId);

            if (trainingPlan == null)
            {
                return false;
            }

            var workoutExercise = trainingPlan.TrainingPlanWorkouts
                .Where(tpw => tpw.Workout.WorkoutsExercises
                    .Any(we => we.Exercise.Id == request.ExerciseId && we.Workout.Id == request.WorkoutId))
                .FirstOrDefault();


            if (workoutExercise == null)
            {
                return false;
            }

            var newExercise = await repository.GetByIdAsync<Exercise>(request.NewExerciseId);
            if (newExercise == null)
            {
                return false;
            }

            //foreach (var workoutExercise in workoutExercises)
            //{
            var exerciseToReplace = workoutExercise.Workout.WorkoutsExercises
                .FirstOrDefault(we => we.Exercise.Id == request.ExerciseId && we.WorkoutId == request.WorkoutId);

            if (exerciseToReplace != null)
            {
                exerciseToReplace.ExcersiceId = newExercise.Id;
                exerciseToReplace.Exercise = newExercise;

                        var x = trainingPlan.TrainingPlanWorkouts
                 .Where(tpw => tpw.Workout.WorkoutsExercises
                     .Any(we => we.Exercise.Id == request.ExerciseId)).ToList();

                if (x.Count == 0)
                {
                    var exerciseFeedback = await repository.All<ExerciseFeedback>
                      ().Where(x => x.TrainingPlanId == request.TrainingPlanId).ToListAsync();

                    var feedbackToDelete = exerciseFeedback.Where(x => x.ExerciseId == request.ExerciseId).FirstOrDefault();
                    if (feedbackToDelete != null)
                    {
                        repository.Delete(feedbackToDelete);
                    }
                }
                     
                 

              
            }
            //}

            var changes = await repository.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<EditExerciseFromWorkoutViewModel> GetModelFromWorkoutForEdit(int id)
        {
            var workout = await repository.AllAsReadOnly<WorkoutsExercise>()
                 .Where(x => x.ExcersiceId == id)
                 .Include(x => x.Workout)
                 .FirstAsync();


            var exercise = await repository.AllAsReadOnly<Infrastructure.Data.Models.Exercise>()
                .Where(x => x.Id == id)
                .Include(x => x.WorkoutsExercises)
                .ThenInclude(x => x.Workout)
                .Select(x => new EditExerciseFromWorkoutViewModel()
                {
                    Id = x.Id,
                    WorkoutId = workout.WorkoutId,
                    Description = x.Description,
                    DifficultyLevel = x.DifficultyLevel,
                    ExistingImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    MuscleGroup = x.MuscleGroup,
                    Name = x.Name,
                    Repetitions = x.Repetitions,
                    Series = x.Series,
                })
                .FirstAsync();

            return exercise;
        }

        public async Task<EditExerciseViewModel> GetModelForEdit(int id)
        {
            var workoutExercise = await repository.AllAsReadOnly<WorkoutsExercise>()
                .Where(x => x.ExcersiceId == id)
                .Include(x => x.Workout)
                    .ThenInclude(w => w.TrainingPlanWorkouts)
                .FirstOrDefaultAsync();

            if (workoutExercise == null)
            {
                return null;
            }

            var trainingPlanId = workoutExercise.Workout.TrainingPlanWorkouts
                .Select(tp => tp.TrainingPlanId)
                .FirstOrDefault();

            var exercise = await repository.AllAsReadOnly<Exercise>()
                .Where(x => x.Id == id)
                .Select(x => new EditExerciseViewModel()
                {
                    Id = x.Id,
                    TrainingPlanId = trainingPlanId,
                    Description = x.Description,
                    DifficultyLevel = x.DifficultyLevel,
                    ExistingImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    MuscleGroup = x.MuscleGroup,
                    Name = x.Name,
                    Repetitions = x.Repetitions,
                    Series = x.Series,
                }).FirstOrDefaultAsync();

            return exercise;
        }


        public async Task EditAsyncFromWorkout(int id, EditExerciseFromWorkoutViewModel model)
        {
            var exercise = await repository.All<Infrastructure.Data.Models.Exercise>()
             .Where(x => x.Id == id)
             .FirstOrDefaultAsync();

            if (exercise != null)
            {
                exercise.MuscleGroup = model.MuscleGroup;
                exercise.Description = model.Description;
                exercise.Series = model.Series;
                exercise.Repetitions = model.Repetitions;
                exercise.DifficultyLevel = model.DifficultyLevel;
                exercise.VideoUrl = model.VideoUrl;
                exercise.Name = model.Name;

                if (model.NewImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/exercises");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.NewImage.CopyToAsync(fileStream);
                    }
                    exercise.ImageUrl = "/img/exercises/" + uniqueFileName;
                }

                await repository.SaveChangesAsync();
            }
        }
    }
}
