using AIFitnessProject.Core.Models.DailyDietPlan;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDailyDietPlanService
    {
        Task<ICollection<DailyDietPlanViewModel>> GetAllDailyDietPlans(string userId, int id);
        Task<DailyDietPlanViewModel> GetModelForDetails(int id);
        Task<bool> ExistAsync(int id);
    }
}
