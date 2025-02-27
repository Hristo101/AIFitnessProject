using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Data.Models;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface ITrainingPlanService
    {
        Task CreateTrainigPlan(string id, string trainerId, CreateTraingPlanViewModel model, int requestId);
        Task<ICollection<AllTrainingPlanViewModel>> GetAllTrainingPlanAsync(string userId);
        Task<ICollection<RejectedTrainingPlanViewModel>> GetModelsForAllTrainingPlanAsync(string userId);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetailsFromExercise(int exerciseId);
        Task<SendTrainingPlanViewModel> GetTrainingPlanModelForSendView(int id);
        Task AcceptTrainingPlanAsync(int id, string UserId);
        Task<AllTrainingPlanViewModel> GetAllTrainingPlanForUserAsync(string userId);
        Task<EditTrainingPlanViewModel> GetTrainingPlanForEditAsync(int id);
        Task<RejectedTrainingPlanDetails> GetRejectedTrainingPlanAsync(int id,string userId);
        Task SendToUserAsync(int id);
        Task SendEditTrainingPlanAsync(int id, string userId);
        Task<bool> ExistAsync(int id);
        Task EditAsync(int id, EditTrainingPlanViewModel model);
        Task<TrainingPlan> GetDietById(int id);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetails(int id);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForUserForDetails(int id,string userId);
    }
}
