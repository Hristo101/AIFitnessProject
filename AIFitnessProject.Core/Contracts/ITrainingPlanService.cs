using AIFitnessProject.Core.Models.TrainingPlan;
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
        Task<TrainingPlanDetailsViewModel> GetGetTrainingPlanModelsForDetailsFromExercise(int exerciseId);
        Task<TrainingPlanDetailsViewModel> GetTrainingPlanModelsForDetails(int id);
    }
}
