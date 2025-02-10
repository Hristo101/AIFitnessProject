using AIFitnessProject.Core.Models.Diet;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDietService
    {
        Task CreateDiet(string id, string dietitianId, CreateDietViewModel model);
        Task<ICollection<AllDietViewModel>> GetAllDietsAsync(string userId);
        Task<DietDetailsViewModel> GetDietModelsForDetails(int id);
        Task<EditDietViewModel> GetModelForEdit(int id);
        Task EditAsync(int id, EditDietViewModel model);
        Task<bool> ExistAsync(int id);
    }
}
