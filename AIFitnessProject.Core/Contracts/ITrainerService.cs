using AIFitnessProject.Core.Models.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface ITrainerService
    {
        Task<IEnumerable<AllTrainerViewModel>> ShowAllTrainersAsync();
        Task<bool> ExistAsync(int id);
        Task<DetailsTrainerViewModel> GetViewModelForDetails(int trainerId);
    }
}
