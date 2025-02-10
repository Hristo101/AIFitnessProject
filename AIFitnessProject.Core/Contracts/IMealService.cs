using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Meal;

namespace AIFitnessProject.Core.Contracts
{
    public interface IMealService
    {
        Task<MealViewModel> GetModelForDetails(int id);
        Task<EditMealViewModel> GetModelForEdit(int id);
        Task EditAsync(int id, EditMealViewModel model);
        Task<bool> ExistAsync(int id);
    }
}
