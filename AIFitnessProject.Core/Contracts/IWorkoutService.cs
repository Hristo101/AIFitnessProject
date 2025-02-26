using AIFitnessProject.Core.Models.Exercise;
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
        Task<ICollection<WorkoutViewModelForTrainer>> AllWorkousForTrainer(string userId);
        Task<WorkoutViewModel> GetModelForDetails(int id);
        Task AddWorkout(string selectedIds,int trainingPlanId);
        Task<int> CreateWorkout(AddWorkoutViewModel model, string userId);
        Task<AddWorkoutViewModel> GetModelForAdd(int trainingPlanId);
        Task<ICollection<ExerciseViewModel>> ReturnAllExerciseViewModel(string userId);
    }
}
