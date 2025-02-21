using AIFitnessProject.Core.Contracts;
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

            var plan = await repository.AllAsReadOnly<TrainingPlan>()
                .Include(tp => tp.TrainingPlanWorkouts)
                .ThenInclude(tpw => tpw.Workout)
                .FirstOrDefaultAsync(tp => tp.UserId == userId && tp.IsActive && tp.IsInCalendar);

            if (plan == null)
            {
                return null;
            }

            var model = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userId)
                .Select(x => new UserCalendarViewModel()
                {
                    Email = x.Email,
                    FullName = x.FirstName + " " + x.LastName,
                    ProfilePictureUrl = x.ProfilePicture,

                    Workouts = plan.TrainingPlanWorkouts.Select(tpw => new WorkoutCalendarViewModel()
                    {
                        Id = tpw.WorkoutId,
                        Name = tpw.Workout.Title,
                        ImageUrl = tpw.Workout.ImageUrl,
                        ExerciseCount = tpw.Workout.WorkoutsExercises.Count(),
                        MuscleGroup = tpw.Workout.MuscleGroup
                    }).ToList()
                }).FirstOrDefaultAsync();

            return model;
        }

       
    }
}
