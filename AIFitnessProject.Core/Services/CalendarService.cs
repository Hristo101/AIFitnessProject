using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;
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
                .Select(c => new
                {
                    c.Id,
                    Workouts = c.CalendarWorkouts.Select(cw => new
                    {
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
    }
}
