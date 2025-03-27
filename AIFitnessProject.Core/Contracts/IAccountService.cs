using AIFitnessProject.Core.Models.Account;
using AIFitnessProject.Infrastructure.Data.Models;

namespace AIFitnessProject.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyProfileViewModel> GetMoldelForMyProfile(string id, bool isInRole);
        Task<MyTrainerViewModel> GetViewModelForMyTrainer(string userId);
        Task<MyDietitianViewModel> GetViewModelForMyDietitian(string userId);
        Task<ICollection<AllUsersViewModel>> GetAllUsers(string userId);
        Task<DashBoardViewModel> DashboardForTrainer(string userId);
        Task<DashBoardViewModelForDietitian> DashboardForDietitian(string userId);
        Task<ICollection<AllUsersViewModel>> GetAllDietitianClients(string userId);
        Task<EditProfileViewModel> Edit(string id);
        Task<ApplicationUser> ChangeInformation(string id, EditProfileViewModel model);
        Task AddMoreInformationAsync(string id,MoreInformationViewModel model);
    }
}
