using AIFitnessProject.Core.Models.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IWorkoutService 
    {
        Task<ICollection<WorkoutViewModel>> All(string userId,int id);
        Task<WorkoutViewModel> GetModelForDetails(int id);
        Task AddWorkout(string selectedIds,int trainingPlanId);
    }
}
