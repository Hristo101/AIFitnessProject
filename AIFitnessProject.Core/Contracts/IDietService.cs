using AIFitnessProject.Core.Models.Diet;
using AIFitnessProject.Infrastructure.Data.Models;

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
        Task<Diet> GetDietById(int id);
        Task<SendDietViewModel> GetDietModelForSendView(int id);
        Task SendToUserAsync(int id);
        Task<DietForUserViewModel?> GetDietForUserAsync(string userId);
        Task<DietDetailsViewModel> GetDietModelForUserForDetails(int id, string userId);
        Task<bool> UserHasDietAsync(int id ,string userId);
        Task SendEditDietAsync(int id, string userId);
        Task<ICollection<RejectedDietViewModel>> GetModelsForAllRejectedDietAsync(string userId);
    }
}
