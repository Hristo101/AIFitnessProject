using AIFitnessProject.Core.Models.Meal;

namespace AIFitnessProject.Core.Contracts
{
    public interface IMealService
    {
        Task<MealViewModel> GetModelForDetails(int id);
    }
}
