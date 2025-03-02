using AIFitnessProject.Core.Models.Trainer;

namespace AIFitnessProject.Core.Contracts
{
    public interface ITrainerService
    {
        Task<IEnumerable<AllTrainerViewModel>> ShowAllTrainersAsync();
        Task<bool> ExistAsync(int id);
        Task<DetailsTrainerViewModel> GetViewModelForDetails(int trainerId);
        Task<DetailsTrainerForUserViewModel> GetViewModelForDetailsForUser(int trainerId,string userId);
        
    }
}
