using AIFitnessProject.Core.Models.Diet;
using AIFitnessProject.Core.Models.Meal;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDietService
    {
        Task CreateDiet(string id, string dietitianId, CreateDietViewModel model);
        Task<ICollection<AllDietViewModel>> GetAllDietsAsync(string userId);
        Task<DietDetailsViewModel> GetDietModelsForDetails(int id);
        Task<EditDietViewModel> GetModelForEdit(int id);
        Task EditAsync(int id, EditMealViewModel model);
        Task<bool> ExistAsync(int id);
    }
}
