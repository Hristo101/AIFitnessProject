using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Infrastructure.Data.Models;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDailyDietPlanService
    {
        Task<ICollection<DailyDietPlanViewModel>> GetAllDailyDietPlans(string userId, int id);
        Task<ICollection<DailyDietPlanViewModelForDietitian>> GetAllUserDailyDietPlansForDietitian(string userId);
        Task<DailyDietPlanViewModel> GetModelForDetails(int id);
        Task<bool> ExistAsync(int id);
        Task AttachDailyDietPlan(string selectedIds, int dietId);
        Task<EditDailyDietPlanViewModel> GetModelForEdit(int id);
        Task EditAsync(int id, EditDailyDietPlanViewModel model);
        Task<DailyDietPlan> GetDailyDietPlanById(int id);
        Task<AddDailyDietPlanViewModel> GetModelForAdd(int dietId);
        Task<int> CreateDailyDietPlan(AddDailyDietPlanViewModel model, string userId);
        Task<ICollection<MealViewModel>> ReturnAllMealViewModel(string userId);
        Task<DetailsDailyDietPlanViewModelForDietitian> GetDetailsDailyDietPlanViewModelForDietitian(int id, string userId);
        Task<EditDailyDietPlanViewModelForDietitian> GetEditDailyDietPlanViewModelForDietitian(int id, string userId, string dietitianId);
        Task<ICollection<MealViewModel>> AllMeal();
        Task DeleteDailyDietPlanForDietitian(int id, int dietId);
        Task AttachNewMealToDailyDietPlanAsync(int dailyDietPlanId, string mealIds);
        Task EditDailyDietPlan(int dietId, int dailyDietPlanId, EditDailyDietPlanViewModelForDietitian model);
        Task DeleteMeal(int dailyDietPlanId, int mealId);
    }
}
