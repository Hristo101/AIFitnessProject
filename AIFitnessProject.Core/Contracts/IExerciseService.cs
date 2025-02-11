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
        Task<ExerciseViewModel> GetModelForDetails(int id);
        Task<EditExerciseViewModel> GetModelForEdit(int id);
        Task<EditExerciseFromWorkoutViewModel> GetModelFromWorkoutForEdit(int id);
        Task<DetailsExerciseViewModel> GetModelForDetailsFromWorkouts(int id);
        Task EditAsync(int id, EditExerciseViewModel model);
        Task EditAsyncFromWorkout(int id, EditExerciseFromWorkoutViewModel model);
        Task AddExercise(CreateExerciseViewModel model, string userId);
        Task<bool> ExistAsync(int id);
    }
}
