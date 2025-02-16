using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Infrastructure.Data.Models;

namespace AIFitnessProject.Core.Contracts
{
    public interface IMealService
    {
        Task<MealViewModel> GetModelForDetails(int id);
        Task<MealDetailViewModel> GetModelForDetailsFromDailyDietPlan(int id);
        Task<EditMealViewModel> GetModelForEdit(int id);
        Task EditAsync(int id, EditMealViewModel model);
        Task EditAsyncFromDailyDietPlan(int id, EditMealFromDailyDietPlanViewModel model);
        Task<bool> ExistAsync(int id);
        Task<Meal> GetMealById(int id);
        Task AddMeal(CreateMealViewModel model, string userId);
        Task<EditMealFromDailyDietPlanViewModel> GetModelFromDailyDiePlanForEdit(int id);

    }
}
