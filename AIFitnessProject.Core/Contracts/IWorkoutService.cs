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
        Task<DetailsWorkoutViewModelForTrainer> GetDetailsWorkoutViewModelForTrainer(int id,string userId);
        Task<EditWorkoutViewModelForTrainer> GetEditWorkoutViewModelForTrainer(int id, string userId, string trainerId);
        Task<ICollection<ExerciseViewModel>> AllExercise();
        Task<WorkoutViewModel> GetModelForDetails(int id);
        Task AddWorkout(string selectedIds,int trainingPlanId);
        Task DeleteExercise(int workoutId, int exerciseId);
        Task<int> CreateWorkout(AddWorkoutViewModel model, string userId);
        Task<AddWorkoutViewModel> GetModelForAdd(int trainingPlanId);
        Task<ICollection<ExerciseViewModel>> ReturnAllExerciseViewModel(string userId);
    }
}
