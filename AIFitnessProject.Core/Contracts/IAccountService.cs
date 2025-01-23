using AIFitnessProject.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyProfileViewModel> GetMoldelForMyProfile(string id);
    }
}
