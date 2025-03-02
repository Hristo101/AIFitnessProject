using AIFitnessProject.Core.Models.Account;
using AIFitnessProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyProfileViewModel> GetMoldelForMyProfile(string id, bool isInRole);
        Task<MyTrainerViewModel> GetViewModelForMyTrainer(string userId);
        Task<ICollection<AllUsersViewModel>> GetAllUsers(string userId);
        Task<ICollection<AllUsersViewModel>> GetAllDietitianClients(string userId);
        Task<EditProfileViewModel> Edit(string id);
        Task<ApplicationUser> ChangeInformation(string id, EditProfileViewModel model);
        Task AddMoreInformationAsync(string id,MoreInformationViewModel model);
    }
}
