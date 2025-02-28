using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;
using AIFitnessProject.Core.Models.Exercise;
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
    public class CalendarService : ICalendarService
    {
        private readonly IRepository repository;

        public CalendarService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<UserCalendarViewModel> GetModeForUserCalendar(string userId)
        {
            var calendar = await repository.AllAsReadOnly<Calendar>()
                .Where(c => c.UserId == userId)
                .Include(x => x.CalendarWorkouts)
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
                        cw.EndEventTime
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
                TrainingPlanWorkouts = trainingPlanWorkouts.Select(tpw => new WorkoutCalendarViewModel
                {
                    Id = tpw.WorkoutId,
                    Name = tpw.Title,
                    ImageUrl = tpw.ImageUrl,
                    ExerciseCount = tpw.ExerciseCount,
                    MuscleGroup = tpw.MuscleGroup
                }).ToList()
            };

            return model;
        }

        public async Task<bool> AddCalendarEventAsync(AddEventViewModel model)
        {
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

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<UserCalendarViewModelForDietitianArea> GetModelForUserCalendarInDietitianArea(string userId)
        {
            var calendar = await repository.AllAsReadOnly<Calendar>()
               .Where(c => c.UserId == userId)
               .Include(x => x.CalendarDiet)
               .Select(c => new
               {
                   c.Id,
                   Meals = c.CalendarDiet.Select(cw => new
                   {
                       cw.MealId,
                       cw.Meal.Name,
                       cw.Meal.ImageUrl,
                       cw.Meal.MealTime,
                       cw.Meal.Calories,
                       MealCount = cw.Meal.MealsDailyDietPlans.Count(),
                       cw.CalendarId,
                       cw.DateOnly,
                       cw.StartEventTime,
                       cw.EndEventTime
                   }).ToList()
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
                CalendarId = calendar?.Id ?? 0,
                Email = user.Email,
                FullName = user.FullName,
                ProfilePictureUrl = user.ProfilePicture,
                Meals = calendar?.Meals.Select(cw => new MealCalendarViewModel
                {
                    Id = cw.MealId,
                    Name = cw.Name,
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
                    ImageUrl = tpw.ImageUrl,
                    MealTime = tpw.MealTime,
                    MealCount = meals.Count,
                }).ToList()
            };

            return model;
        }

        public async Task<bool> AddCalendarMealEventAsync(AddEventFromDietitianViewModel model)
        {
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

                return true;
            }
            catch (Exception)
            {
                return false;
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

        public async Task DeleteEvenet(int workoutId, int calendarId)
        {
            var calendarWorkout = await repository.All<CalendarWorkout>()
                 .Where(x => x.WorkoutId == workoutId && x.CalendarId == calendarId)
                 .FirstOrDefaultAsync();

            repository.Delete(calendarWorkout);
            await repository.SaveChangesAsync();

        }
    }
}
