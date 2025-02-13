using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface ITrainingPlanService
    {
        Task CreateTrainigPlan(string id, string trainerId, CreateTraingPlanViewModel model);
        Task<ICollection<AllTrainingPlanViewModel>> GetAllTrainingPlanAsync(string userId);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetailsFromExercise(int exerciseId);
        Task<SendTrainingPlanViewModel> GetTrainingPlanModelForSendView(int id);
        Task<AllTrainingPlanViewModel> GetAllTrainingPlanForUserAsync(string userId);
        Task<EditTrainingPlanViewModel> GetTrainingPlanForEditAsync(int id);
        Task SendToUserAsync(int id);
        Task<bool> ExistAsync(int id);
        Task EditAsync(int id, EditTrainingPlanViewModel model);
        Task<TrainingPlan> GetDietById(int id);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetails(int id);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForUserForDetails(int id,string userId);
    }
}
