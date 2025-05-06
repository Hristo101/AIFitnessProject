using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;


namespace AIFitnessProject.Core.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IRepository repository;
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;
        public CalendarService(IRepository _repository, INotificationService notificationService, IConfiguration configuration)
        {
            this.repository = _repository;
            _notificationService = notificationService;
            _configuration = configuration;
        }

        public async Task<UserCalendarViewModel> GetModeForUserCalendar(string userId, string trainerId)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x => x.UserId == trainerId)
                .FirstOrDefaultAsync();

            var calendar = await repository.AllAsReadOnly<AIFitnessProject.Infrastructure.Data.Models.Calendar>()
                .Where(c => c.UserId == userId)
                .Include(x => x.CalendarWorkouts)
                .Include(x => x.CalendarMeals) 
                .Select(c => new
                {
                    c.Id,
                    Workouts = c.CalendarWorkouts.Select(cw => new
                    {
                        cw.Workout,
                        cw.EventId,
                        cw.WorkoutId,
                        cw.Workout.Title,
                        cw.Workout.ImageUrl,
                        ExerciseCount = cw.Workout.WorkoutsExercises.Count(),
                        MuscleGroup = cw.Workout.WorkoutsExercises.FirstOrDefault() != null
                            ? cw.Workout.WorkoutsExercises.First().Exercise.MuscleGroup
                            : "N/A",
                        cw.CalendarId,
                        cw.DateOnly,
                        cw.StartEventTime,
                        cw.EndEventTime
                    }).ToList(),
                    Meals = c.CalendarMeals.Select(cm => new
                    {
                        cm.Meal,
                        cm.EventId,
                        cm.MealId,
                        cm.Meal.Name,
                        cm.Meal.ImageUrl,
                        cm.Meal.Calories,
                        MealCount = cm.Meal.MealsDailyDietPlans.Count(), 
                        cm.CalendarId,
                        cm.DateOnly,
                        cm.StartEventTime,
                        cm.EndEventTime
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            var trainingPlanWorkouts = await repository.AllAsReadOnly<TrainingPlan>()
                .Where(tp => tp.UserId == userId && tp.IsActive)
                .SelectMany(tp => tp.TrainingPlanWorkouts)
                .Select(tpw => new
                {
                    tpw.WorkoutId,
                    tpw.Workout.Title,
                    tpw.Workout.ImageUrl,
                    ExerciseCount = tpw.Workout.WorkoutsExercises.Count(),
                    MuscleGroup = tpw.Workout.WorkoutsExercises.FirstOrDefault() != null
                        ? tpw.Workout.WorkoutsExercises.First().Exercise.MuscleGroup
                        : "N/A"
                })
                .ToListAsync();

            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userId)
                .Select(u => new
                {
                    u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    u.ProfilePicture
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var model = new UserCalendarViewModel
            {
                UserId = userId,
                CalendarId = calendar?.Id ?? 0,
                Email = user.Email,
                FullName = user.FullName,
                ProfilePictureUrl = user.ProfilePicture,
                Workouts = calendar?.Workouts.Select(cw => new WorkoutCalendarViewModel
                {
                    CreatedById = cw.Workout.CreatorId,
                    IsMine = cw.Workout.CreatorId == trainer.Id,
                    Id = cw.WorkoutId,
                    EventId = cw.EventId,
                    Name = cw.Title,
                    ImageUrl = cw.ImageUrl,
                    ExerciseCount = cw.ExerciseCount,
                    MuscleGroup = cw.MuscleGroup,
                    CalendarId = cw.CalendarId,
                    Date = cw.DateOnly,
                    StartEventTime = cw.StartEventTime,
                    EndEventTime = cw.EndEventTime
                }).ToList() ?? new List<WorkoutCalendarViewModel>(),
                TrainingPlanWorkouts = trainingPlanWorkouts.Select(tpw => new WorkoutCalendarViewModel
                {
                    Id = tpw.WorkoutId,
                    Name = tpw.Title,
                    ImageUrl = tpw.ImageUrl,
                    ExerciseCount = tpw.ExerciseCount,
                    MuscleGroup = tpw.MuscleGroup
                }).ToList(),
                Meals = calendar?.Meals.Select(cm => new MealCalendarViewModel
                {
                    CreatedById = cm.Meal.CreatedById,
                    IsMine = false,
                    Id = cm.MealId,
                    EventId = cm.EventId,
                    Name = cm.Name,
                    ImageUrl = cm.ImageUrl,
                    Calories = cm.Calories,
                    MealCount = cm.MealCount,
                    CalendarId = cm.CalendarId,
                    Date = cm.DateOnly,
                    StartEventTime = cm.StartEventTime,
                    EndEventTime = cm.EndEventTime,
                    MealTime = cm.StartEventTime.ToString() 
                }).ToList() ?? new List<MealCalendarViewModel>()
            };

            return model;
        }

        public async Task<int> AddCalendarEventAsync(AddEventViewModel model,string trainerId)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x =>x.UserId == trainerId)
                .Include(x =>x.User)
                .FirstOrDefaultAsync();
            try
            {
                var start = TimeOnly.Parse(model.StartTime);
                var end = TimeOnly.Parse(model.EndTime);
                var date = new DateOnly(model.Year, model.Month, model.Day);

                var calendarWorkout = new CalendarWorkout
                {
                    CalendarId = model.CalendarId,
                    WorkoutId = model.WorkoutId,
                    DateOnly = date,
                    StartEventTime = start,
                    EndEventTime = end,
                };

                await repository.AddAsync(calendarWorkout);
                await repository.SaveChangesAsync();

                string message = $"В календара ти беше добавено събитие от {trainer.User.FirstName} {trainer.User.LastName}.";
                await _notificationService.AddNotification(trainer.UserId,model.UserId,message,"Calendar");
                var user = await repository.AllAsReadOnly<ApplicationUser>().Where(x => x.Id == model.UserId).FirstOrDefaultAsync();

                await SendEmailAsync(
      user.Email,
     "Добавено събитие към календара",
     message
 );
                return calendarWorkout.EventId; 
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add calendar event", ex); 
            }
        }


        public async Task<UserCalendarViewModelForDietitianArea> GetModelForUserCalendarInDietitianArea(string userId)
        {
            var calendar = await repository.AllAsReadOnly< AIFitnessProject.Infrastructure.Data.Models.Calendar> ()
               .Where(c => c.UserId == userId)
               .Include(x => x.CalendarMeals)
               .Include(c =>c.CalendarWorkouts)
               .Select(c => new
               {
                   c.Id,
                   Meals = c.CalendarMeals.Select(cw => new
                   {
                       cw.MealId,
                       cw.EventId,
                       cw.Meal.Name,
                       cw.Meal.ImageUrl,
                       cw.Meal.MealTime,
                       cw.Meal.Calories,
                       MealCount = cw.Meal.MealsDailyDietPlans.Count(),
                       cw.CalendarId,
                       cw.DateOnly,
                       cw.StartEventTime,
                       cw.EndEventTime
                   }).ToList(),
                   Workouts = c.CalendarWorkouts.Select(cw => new
                   {
                       cw.Workout,
                       cw.EventId,
                       cw.WorkoutId,
                       cw.Workout.Title,
                       cw.Workout.ImageUrl,
                       ExerciseCount = cw.Workout.WorkoutsExercises.Count(),
                       MuscleGroup = cw.Workout.WorkoutsExercises.FirstOrDefault() != null
                            ? cw.Workout.WorkoutsExercises.First().Exercise.MuscleGroup
                            : "N/A",
                       cw.CalendarId,
                       cw.DateOnly,
                       cw.StartEventTime,
                       cw.EndEventTime

                   })
               })
               .FirstOrDefaultAsync();

            var diet = await repository.All<Diet>()
               .Where(tp => tp.UserId == userId && tp.IsActive)
               .FirstOrDefaultAsync();

            var meals = await repository.AllAsReadOnly<DietDailyDietPlan>()
                .Where(x => x.DietId == diet.Id)
                .SelectMany(x => x.DailyDietPlan.MealsDailyDietPlans)
                .Select(x => x.Meal)
                .Distinct()
                .ToListAsync();

         var trainingPlanWorkouts = await repository.AllAsReadOnly<TrainingPlan>()
        .Where(tp => tp.UserId == userId && tp.IsActive)
        .SelectMany(tp => tp.TrainingPlanWorkouts)
        .Select(tpw => new
        {
            tpw.WorkoutId,
            tpw.Workout.Title,
            tpw.Workout.ImageUrl,
            ExerciseCount = tpw.Workout.WorkoutsExercises.Count(),
            MuscleGroup = tpw.Workout.WorkoutsExercises.FirstOrDefault() != null
                ? tpw.Workout.WorkoutsExercises.First().Exercise.MuscleGroup
                : "N/A"
        })
        .ToListAsync();

            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userId)
                .Select(u => new
                {
                    u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    u.ProfilePicture
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var model = new UserCalendarViewModelForDietitianArea
            {
                UserId = userId,
                CalendarId = calendar?.Id ?? 0,
                Email = user.Email,
                FullName = user.FullName,
                ProfilePictureUrl = user.ProfilePicture,
                Meals = calendar?.Meals.Select(cw => new MealCalendarViewModel
                {
                    Id = cw.MealId,
                    Name = cw.Name,
                    EventId = cw.EventId,
                    ImageUrl = cw.ImageUrl,
                    MealTime = cw.MealTime,
                    Calories = cw.Calories,
                    CalendarId = cw.CalendarId,
                    Date = cw.DateOnly,
                    StartEventTime = cw.StartEventTime,
                    EndEventTime = cw.EndEventTime
                }).ToList() ?? new List<MealCalendarViewModel>(),
                DietMeal = meals.Select(tpw => new MealCalendarViewModel
                {
                    Id = tpw.Id,
                    Name = tpw.Name,
                    Calories = tpw.Calories,
                    ImageUrl = tpw.ImageUrl,
                    MealTime = tpw.MealTime,
                    MealCount = meals.Count,
                }).ToList(),
                TrainingPlanWorkouts = trainingPlanWorkouts.Select(tpw => new WorkoutCalendarViewModel
                {
                    Id = tpw.WorkoutId,
                    IsMine = false,
                    Name = tpw.Title,
                    ImageUrl = tpw.ImageUrl,
                    ExerciseCount = tpw.ExerciseCount,
                    MuscleGroup = tpw.MuscleGroup
                }).ToList()
            };

            return model;
        }

        public async Task<int> AddCalendarMealEventAsync(AddEventFromDietitianViewModel model,string dietitianId)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x => x.UserId == dietitianId)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            try
            {
                var start = TimeOnly.Parse(model.StartTime);
                var end = TimeOnly.Parse(model.EndTime);
                var date = new DateOnly(model.Year, model.Month, model.Day);

                var calendarWorkout = new CalendarMeal
                {
                    CalendarId = model.CalendarId,
                    MealId = model.MealId,
                    DateOnly = date,
                    StartEventTime = start,
                    EndEventTime = end,
                };

                await repository.AddAsync(calendarWorkout);
                await repository.SaveChangesAsync();

                string message = $"В календара ти беше добавено събитие от {dietitian.User.FirstName} {dietitian.User.LastName}.";
                await _notificationService.AddNotification(dietitian.UserId,model.UserId,message,"Calendar");

                var user = await repository.AllAsReadOnly<ApplicationUser>().Where(x => x.Id == model.UserId).FirstOrDefaultAsync();
                await SendEmailAsync(user.Email, "Добавено събитие към календара", message);

                return calendarWorkout.EventId;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add calendar event", ex);
            }

        }

        public async Task<DetailsEventViewModel> GetModelForDetailsEvent(int id)
        {
            var workoutCalendar = await repository.AllAsReadOnly<CalendarWorkout>()
                 .Where(x => x.EventId == id)
                 .Include(x =>x.Workout)
                 .ThenInclude(x=>x.WorkoutsExercises)
                 .ThenInclude(x =>x.Exercise)
                 .Select(x => new DetailsEventViewModel
                 {
                   DateOnly = x.DateOnly.ToString("yyyy-MM-dd"),
                   StartEventTime = x.StartEventTime.ToString("hh:mm tt"),
                   EndEventTime = x.EndEventTime.ToString("hh:mm tt"),
                   WorkoutTitle = x.Workout.Title,
                   ExerciseCount = x.Workout.WorkoutsExercises.Count,
                   WorkoutDayOfWeek = x.Workout.DayOfWeek,
                   WorkoutDifficultyLevel = x.Workout.DificultyLevel,
                   WorkoutImage = x.Workout.ImageUrl,
                   WorkoutMuscleGroup = x.Workout.MuscleGroup,
                     Exercises = x.Workout.WorkoutsExercises.Select(x => new ExerciseViewModel
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
                 })
                 .FirstOrDefaultAsync();

            return workoutCalendar;

        }


            public async Task DeleteEvenetAndSendNotification(int eventId,TimeOnly timeOnly,string userId)
            {
            var user = await repository.AllAsReadOnly<ApplicationUser>()
             .Where(x => x.Id == userId)
             .FirstOrDefaultAsync();

            var calendar = await repository.AllAsReadOnly<Infrastructure.Data.Models.Calendar>()
              .Where(x => x.UserId == userId)
              .FirstOrDefaultAsync();

            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x => x.Id == calendar.TrainerId)
                .Include(x=>x.User)
                .FirstOrDefaultAsync();

                var calendarWorkout = await repository.All<CalendarWorkout>()
                     .Where(x => x.EventId == eventId)
                     .Include(x =>x.Workout)
                     .ThenInclude(x =>x.TrainingPlanWorkouts)
                     .ThenInclude(x =>x.TrainingPlan)
                     .ThenInclude(x =>x.Trainer)
                     .FirstOrDefaultAsync();

                repository.Delete(calendarWorkout);
                await repository.SaveChangesAsync();
            string message = $"Потребител {user.FirstName} {user.LastName} завърши успешно {calendarWorkout.Workout.Title} в {timeOnly}.";
            await _notificationService.AddNotification(user.Id,trainer.UserId,message, "Calendar");
            await SendEmailAsync(
       trainer.User.Email,
      "Успешно завършено събитие",
      message
  );
        }


        public async Task<UserCalendarViewModelForUserArea> GetModelForUserCalendarForUserArea(string userId)
        {
            var calendar = await repository.AllAsReadOnly<AIFitnessProject.Infrastructure.Data.Models.Calendar>()
                .Where(c => c.UserId == userId)
                .Include(x => x.CalendarWorkouts)
                .Include(x=>x.CalendarMeals)
                .Select(c => new
                {
                    c.Id,
                    Workouts = c.CalendarWorkouts.Select(cw => new
                    {
                        cw.EventId,
                        cw.WorkoutId,
                        cw.Workout.Title,
                        cw.Workout.ImageUrl,
                        ExerciseCount = cw.Workout.WorkoutsExercises.Count(),
                        MuscleGroup = cw.Workout.WorkoutsExercises.FirstOrDefault() != null
                            ? cw.Workout.WorkoutsExercises.First().Exercise.MuscleGroup
                            : "N/A",
                        cw.CalendarId,
                        cw.DateOnly,
                        cw.StartEventTime,
                        cw.EndEventTime,
                        
                    }).ToList(),
                    Meals = c.CalendarMeals.Select(x=> new
                    {
                      
                        x.EventId,
                        x.MealId,
                        x.Meal.Name,
                        x.Meal.ImageUrl,
                        x.Meal.Calories,
                        x.Meal.MealTime,
                        x.CalendarId,
                        x.DateOnly,
                        x.StartEventTime,
                        x.EndEventTime
                    })
                    
                })
                .FirstOrDefaultAsync();

           

            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userId)
                .Select(u => new
                {
                    u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    u.ProfilePicture
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var model = new UserCalendarViewModelForUserArea
            {
                CalendarId = calendar?.Id ?? 0,
                Email = user.Email,
                FullName = user.FullName,
                ProfilePictureUrl = user.ProfilePicture,
                Workouts = calendar?.Workouts.Select(cw => new WorkoutCalendarViewModel
                {
                    Id = cw.WorkoutId,
                    EventId = cw.EventId,
                    Name = cw.Title,
                    ImageUrl = cw.ImageUrl,
                    ExerciseCount = cw.ExerciseCount,
                    MuscleGroup = cw.MuscleGroup,
                    CalendarId = cw.CalendarId,
                    Date = cw.DateOnly,
                    StartEventTime = cw.StartEventTime,
                    EndEventTime = cw.EndEventTime
                }).ToList() ?? new List<WorkoutCalendarViewModel>(),
               Meals = calendar.Meals.Select(x=> new MealCalendarViewModel
               {
                       EventId = x.EventId,
                        Id = x.MealId,
                       Name = x.Name,
                        ImageUrl= x.ImageUrl,
                       Calories = x.Calories,
                       MealTime = x.MealTime,
                        CalendarId= x.CalendarId,
                        Date= x.DateOnly,
                        StartEventTime= x.StartEventTime,
                        EndEventTime= x.EndEventTime
               }).ToList() ?? new List<MealCalendarViewModel>(),
            };

            return model;
        }


        public async Task DeleteMealEvenetAndSendNotification(int eventId, TimeOnly timeOnly, string userId)
        {
            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            var calendar = await repository.AllAsReadOnly<Infrastructure.Data.Models.Calendar>()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Include(x=>x.User)
                .Where(x => x.Id == calendar.DietitianId)
                .FirstOrDefaultAsync();


            var calendarMeal = await repository.All<CalendarMeal>()
                    .Where(x => x.EventId == eventId)
                    .Include(x => x.Meal)
                    .ThenInclude(x => x.MealsDailyDietPlans)
                    .ThenInclude(x=>x.DailyDietPlans)
                    .ThenInclude(x=>x.Dietitian)
                    .FirstOrDefaultAsync();

            repository.Delete(calendarMeal);
            await repository.SaveChangesAsync();

            string message = $"Потребител {user.FirstName} {user.LastName} завърши успешно храненето \"{calendarMeal.Meal.Name}\" в {timeOnly}.";
            await _notificationService.AddNotification(user.Id, dietitian.UserId, message, "Calendar");

            await SendEmailAsync(dietitian.User.Email, "Успешно завършено събитие", message);

        }

        public async Task<DetailsMealViewModel> GetModelForDetailsMeal(int id)
        {
            var mealCalendar = await repository.AllAsReadOnly<CalendarMeal>()
                 .Where(x => x.EventId == id)
                 .Include(x => x.Meal)
                 .ThenInclude(x => x.MealsDailyDietPlans)
                 .ThenInclude(x => x.DailyDietPlans)
                 .Select(x => new DetailsMealViewModel
                 {
                     DateOnly = x.DateOnly.ToString("dd MMMM", new CultureInfo("bg-BG")),
                     StartEventTime = x.StartEventTime.ToString("hh:mm tt"),
                     EndEventTime = x.EndEventTime.ToString("hh:mm tt"),
                     MealDifficultyLevel = x.Meal.DificultyLevel,
                     MealImage = x.Meal.ImageUrl,
                     MealTime = x.Meal.MealTime,
                     MealName = x.Meal.Name,
                     MealCalories = x.Meal.Calories,
                     MealRecipe = x.Meal.Recipe,
                     MealVideoUrl = x.Meal.VideoUrl
                     
                 })
                 .FirstOrDefaultAsync();

            return mealCalendar;
        }

        public async Task DeleteEvent(int eventId)
        {
            var calendarWorkout = await repository.All<CalendarWorkout>()
              .Where(x => x.EventId == eventId)
              .FirstOrDefaultAsync();

            repository.Delete(calendarWorkout);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteMealEvenet(int eventId)
        {
            var calendarMeal = await repository.All<CalendarMeal>()
              .Where(x => x.EventId == eventId)
              .FirstOrDefaultAsync();

            repository.Delete(calendarMeal);
            await repository.SaveChangesAsync();
        }

        public async Task<TrainingPlan> GetTrainingPlanByTrainerId(string trainerId)
        {
            var trainingPlan = await repository.All<TrainingPlan>()
           .Include(x =>x.Trainer)
           .ThenInclude(X =>X.User)
          .Where(x => x.Trainer.UserId == trainerId)
          .Include(x => x.Trainer)
          .ThenInclude(x => x.User)
          .FirstOrDefaultAsync();

            return trainingPlan;
        }

        private async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            try
            {

                string smtpHost = _configuration["Smtp:Host"];
                int smtpPort = int.Parse(_configuration["Smtp:Port"]);
                string senderEmail = _configuration["Smtp:SenderEmail"];
                string senderPassword = _configuration["Smtp:SenderPassword"];
                string senderName = _configuration["Smtp:SenderName"];

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, senderName);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;


                using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);


                    await smtpClient.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при изпращане на имейл: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsClientOfDietitian(string id, string dietitianId)
        {
            var dietitian = await repository.All<Dietitian>()
                .Where(x=>x.UserId == dietitianId)
                .FirstOrDefaultAsync();


            var result = await repository.All<Infrastructure.Data.Models.Calendar>()
                .AnyAsync(x => x.DietitianId == dietitian.Id && x.UserId == id);
               

            return result;
        }
    }


    }




