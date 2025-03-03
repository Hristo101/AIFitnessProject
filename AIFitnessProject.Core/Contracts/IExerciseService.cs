using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Core.Models.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IExerciseService
    {
        Task<ExerciseViewModel> GetModelForDetails(int id, string userId, int trainingPlanId);
        Task<EditExerciseViewModel> GetModelForEdit(int id, int trainingPlanId);
        Task<ExerciseViewModel> GetModelForDetailsForUser(int id, string userId);
        Task<EditExerciseFromWorkoutViewModel> GetModelFromWorkoutForEdit(int id, int workoutId);
        Task<DetailsExerciseViewModel> GetModelForDetailsFromWorkouts(int id,int workoutId);
        Task<bool> SwapExerciseInWorkoutAsync(SwapExerciseRequest request);
        Task EditAsync(int id, EditExerciseViewModel model);
        Task EditAsyncFromWorkout(int id, EditExerciseFromWorkoutViewModel model);
        Task AddExercise(CreateExerciseViewModel model, string userId);
        Task AddFromEditWorkoutExercise(CreateNewExerciseForTrainerViewModel model, string userId);
        Task<bool> ExistAsync(int id);
    }
}
