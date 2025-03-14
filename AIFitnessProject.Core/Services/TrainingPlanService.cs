using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.ExerciseFeedback;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly IRepository repository;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public TrainingPlanService(IRepository _repository, IHostingEnvironment hostingEnvironment)
        {
            this.repository = _repository;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task  CreateTrainigPlan(string id, string trainerId, CreateTraingPlanViewModel model, int requestId)
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

            var rquest = await repository.All<RequestsToCoach>()
                .Where(x => x.Id == requestId)
                .FirstOrDefaultAsync();

            rquest.IsAnswered = true;
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
                .Include(x =>x.User)
                .Include(x =>x.Trainer)
                .FirstAsync();

            trainingPlan.IsActive = true;
            trainingPlan.IsEdit = false;
            await repository.SaveChangesAsync();

            var notification = new Notification
            {
                SenderId = trainingPlan.Trainer.UserId,
                RecieverId = trainingPlan.UserId,
                Message = $"Вашият тренировъчен план с ID {id} е активен и готов за изпълнение!",
                CreatedAt = DateTime.Now,
                ReadStatus = false
            };

            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();

            await _hubContext.Clients.User(notification.RecieverId).SendAsync("ReceiveNotification", notification.Message);
        }

        public async Task<AllTrainingPlanViewModel> GetAllTrainingPlanForUserAsync(string userId)
        {
        var model = await repository.AllAsReadOnly<TrainingPlan>()
                .Where(x =>x.IsActive == true)
                .Where(x =>x.IsEdit == false)
                 .Where(x => x.UserId == userId)
                 .Select(x => new AllTrainingPlanViewModel()
                 {
                     Id = x.Id,
                     DescriptionOfTriningPlan = x.Description,
                     ImageUrl = x.ImageUrl,
                     TitleOfTriningPlan = x.Name,
                 }).FirstOrDefaultAsync();

            return model;
        }

        public async Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForUserForDetails(int id, string userId)
        {
            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                .Include(tp => tp.TrainingPlanWorkouts)
                    .ThenInclude(tpw => tpw.Workout)
                        .ThenInclude(w => w.WorkoutsExercises)
                            .ThenInclude(we => we.Exercise)
                .Where(tp => tp.Id == id)
                .Where(tp =>tp.UserId == userId)
                .FirstAsync();

            if (trainingPlan == null)
            {
                return null;
            }

            var viewModel = new TrainingPlanDetailsViewModel
            {
                Id = trainingPlan.Id,
                Name = trainingPlan.Name,
                Description = trainingPlan.Description,
                UserId = trainingPlan.UserId,
                ImageUrl = trainingPlan.ImageUrl,
                isInCalendar = trainingPlan.IsInCalendar,
                Workouts = trainingPlan.TrainingPlanWorkouts.Select(tpWorkout => new WorkoutViewModel
                {
                    Id = tpWorkout.Id,
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
                        Series = we.Exercise.Series,
                        Repetitions = we.Exercise.Repetitions,
                        MuscleGroup = we.Exercise.MuscleGroup,
                        DifficultyLevel = we.Exercise.DifficultyLevel
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }

        public async Task SendEditTrainingPlanAsync(int id,string userId)
        {
            var trainingPlan = await repository.All<TrainingPlan>()
                .Where(x =>x.Id == id)
                .Where(x =>x.UserId == userId)
                .FirstAsync();

            trainingPlan.IsActive = false;
            trainingPlan.IsEdit = true;
            await repository.SaveChangesAsync();
        }

        public async Task<ICollection<RejectedTrainingPlanViewModel>> GetModelsForAllTrainingPlanAsync(string userId)
        {
            var trainer = await repository.All<Trainer>().Where(x => x.UserId == userId).FirstAsync();
            var models = await repository.AllAsReadOnly<TrainingPlan>().Include(x => x.User)
                .Where(x => x.Trainer.Id == trainer.Id)
                .Where(x => x.IsActive == false)
                .Where(x =>x.IsEdit == true)
                .Include(x =>x.User)
                .Select(x => new RejectedTrainingPlanViewModel()
                {
                   TrainingPlanId = x.Id,
                   TrainingPlanDescription = x.Description,
                   Email = x.User.Email,
                   UserFirstName = x.User.FirstName,
                   UserLastName = x.User.LastName,
                   TrainingPlanImageUrl = x.ImageUrl,
                   UserImageUrl = x.User.ProfilePicture,
                   TrainingPlanTitle = x.Name
                })
                .ToListAsync();
            
            return models;
        }

        public async Task<RejectedTrainingPlanDetails> GetRejectedTrainingPlanAsync(int id, string userId)
        {
            var trainer = await repository.All<Trainer>()
                                          .Where(x => x.UserId == userId)
                                          .FirstOrDefaultAsync();

            var trainingPlan = await repository.AllAsReadOnly<TrainingPlan>()
                .Where(x => x.CreatedById == trainer.Id)
                .Where(x => x.IsActive == false)
                .Include(tp => tp.TrainingPlanWorkouts)
                    .ThenInclude(tpw => tpw.Workout)
                        .ThenInclude(w => w.WorkoutsExercises)
                            .ThenInclude(we => we.Exercise)
                .Include(tp => tp.ExerciseFeedbacks)
                    .ThenInclude(ef => ef.Exercise)
                .Include(x => x.User)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            var viewModel = new RejectedTrainingPlanDetails
            {
                Id = id,
                Name = trainingPlan.Name,
                FirstName = trainingPlan.User.FirstName,
                LastName = trainingPlan.User.LastName,
                UserEmail = trainingPlan.User.Email,
                UserProfilePicture = trainingPlan.User.ProfilePicture,
                Description = trainingPlan.Description,
                Workouts = trainingPlan.TrainingPlanWorkouts.Where(x =>x.TrainingPlanId == trainingPlan.Id ).Select(tpw => new WorkoutViewModelForRejectedTrainingPlan
                {
                    Id = tpw.WorkoutId,
                    Title = tpw.Workout.Title,
                    ImageUrl = tpw.Workout.ImageUrl,
                    DayOfWeek = tpw.Workout.DayOfWeek,
                    DifficultyLevel = tpw.Workout.DificultyLevel,
                    MuscleGroup = tpw.Workout.MuscleGroup,
                    Exercises = tpw.Workout.WorkoutsExercises.Select(we =>
                    {
                        var feedback = trainingPlan.ExerciseFeedbacks
                                        .FirstOrDefault(ef => ef.ExerciseId == we.ExcersiceId);
                        return new ExerciseFeedbackViewModel
                        {
                            Id = we.ExcersiceId,
                            Name = we.Exercise.Name,
                            Description = we.Exercise.Description,
                            ImageUrl = we.Exercise.ImageUrl,
                            MuscleGroup = we.Exercise.MuscleGroup,
                            VideoUrl = we.Exercise.VideoUrl,
                            Series = we.Exercise.Series,
                            Repetitions = we.Exercise.Repetitions,
                            Feedback = feedback?.Feedback ?? string.Empty,
                        };
                    }).ToList()
                }).ToList()
            };

            var availableExercises = await repository.AllAsReadOnly<Exercise>()
                .Select(e => new ExerciseViewModel
                {
                    Id = e.Id, 
                    Name = e.Name,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    VideoUrl = e.VideoUrl,
                    MuscleGroup = e.MuscleGroup,
                    Series = e.Series,
                    Repetitions = e.Repetitions,
                    DifficultyLevel = e.DifficultyLevel
                })
                .ToListAsync();

            viewModel.AvailableExercises = availableExercises;

            return viewModel;
        }

        public async Task AcceptTrainingPlanAsync(int id, string userId)
        {
            var trainer = await repository.All<Trainer>()
                                         .Where(x => x.UserId == userId)
                                         .FirstOrDefaultAsync();

            var trainingPlan = await repository.All<TrainingPlan>()
                .Where(x => x.Id == id)
                .Where(x => x.UserId == userId)
                .Include(x => x.Trainer)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            if (trainingPlan == null)
            {
                throw new ArgumentException("Training plan not found or does not belong to the user.");
            }

            trainingPlan.IsInCalendar = true;
            await repository.SaveChangesAsync();

            var existingCalendar = await repository.All<Calendar>()
                .FirstOrDefaultAsync(c => c.UserId == userId);


            if (existingCalendar != null)
            {
                if(existingCalendar.DietitianId != null || existingCalendar.DietitianId != 0)
                {
                    existingCalendar.TrainerId = trainingPlan.CreatedById;
                    await repository.SaveChangesAsync();
                }
            }
            else
            {
                Calendar calendar = new Calendar
                {
                    TrainerId = trainingPlan.CreatedById,
                    UserId = trainingPlan.UserId
                };
                await repository.AddAsync(calendar);
                await repository.SaveChangesAsync();
            }
        }
    }

}

