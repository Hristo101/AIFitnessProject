using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Core.Models.Workout;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class DailyDietPlanService : IDailyDietPlanService
    {
        private readonly IRepository repository;

        public DailyDietPlanService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ICollection<DailyDietPlanViewModel>> GetAllDailyDietPlans(string userId, int id)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x => x.UserId == userId)
                .FirstAsync();

            var model = await repository.AllAsReadOnly<DailyDietPlan>()
                 .Where(x => x.CreatorId == dietitian.Id)
                 .Select(x => new DailyDietPlanViewModel()
                 {
                     Title = x.Title,
                     DayOfWeek = x.DayOfWeel,
                     DificultyLevel = x.DificultyLevel,
                     DietId = id,
                     ImageUrl = x.ImageUrl,
                     Meals = x.MealsDailyDietPlans.Select(mddp => new MealViewModel
                     {
                         Id = mddp.Id,
                         Name = mddp.Meal.Name,
                         Recipe = mddp.Meal.Recipe,
                         ImageUrl = mddp.Meal.ImageUrl,
                         VideoUrl = mddp.Meal.VideoUrl,
                         DificultyLevel = mddp.Meal.DificultyLevel,
                         Calories = mddp.Meal.Calories,
                         MealTime = mddp.Meal.MealTime,
                     }).ToList()
                 })
                 .ToListAsync();

            return model;
        }
    }
}
