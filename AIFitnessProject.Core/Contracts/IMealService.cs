using AIFitnessProject.Core.DTOs.MealFeedback;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Infrastructure.Data.Models;

namespace AIFitnessProject.Core.Contracts
{
    public interface IMealService
    {
        Task<MealViewModel> GetModelForDetails(int id,int dietId);
        Task<MealDetailViewModel> GetModelForDetailsFromDailyDietPlan(int id, int dailyDietPlanId);
        Task<MealViewModel> GetModelForDetailsForUser(int id, string userId);
        Task<EditMealViewModel> GetModelForEdit(int id,int dietId);
        Task EditAsync(int id, EditMealViewModel model);
        Task EditAsyncFromDailyDietPlan(int id, EditMealFromDailyDietPlanViewModel model);
        Task<bool> ExistAsync(int id);
        Task<Meal> GetMealById(int id);
        Task AddMeal(CreateMealViewModel model, string userId);
        Task<EditMealFromDailyDietPlanViewModel> GetModelFromDailyDiePlanForEdit(int id ,int dailyDietPlanId);
        Task<bool> SwapMealInDailyDietPlan(SwapMealRequest request);

    }
}
