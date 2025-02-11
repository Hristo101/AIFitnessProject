using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Meal;
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

        public async Task AttachDailyDietPlan(string selectedIds, int dietId)
        {
            var ids = selectedIds.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < ids.Count; i++)
            {
                var dailyDietPlan = await repository
                .All<DailyDietPlan>()
                .Where(x => x.Id == ids[i])
                .FirstAsync();

                dailyDietPlan.DietId = dietId;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<DailyDietPlan>()
              .AnyAsync(x => x.Id == id);
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
                     Id = x.Id,
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

        public async Task<DailyDietPlanViewModel> GetModelForDetails(int id)
        {
            var model = await repository.AllAsReadOnly<DailyDietPlan>()
                .Where(x => x.Id == id)
                .Select(x => new DailyDietPlanViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DayOfWeek = x.DayOfWeel,
                    ImageUrl = x.ImageUrl,
                    DificultyLevel = x.DificultyLevel,
                    Meals = x.MealsDailyDietPlans.Select(mddp => new MealViewModel
                    {
                        Id = mddp.Meal.Id,
                        Name = mddp.Meal.Name,
                        Recipe = mddp.Meal.Recipe,
                        ImageUrl = mddp.Meal.ImageUrl,
                        VideoUrl = mddp.Meal.VideoUrl,
                        DificultyLevel = mddp.Meal.DificultyLevel,
                        Calories = mddp.Meal.Calories,
                        MealTime = mddp.Meal.MealTime
                    }).ToList()
                })
                .FirstAsync();

            return model;
        }
    }
}
