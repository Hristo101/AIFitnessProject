using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Workout;

namespace AIFitnessProject.Core.Contracts
{
    public interface IWorkoutService 
    {
        Task<AllWorkoutViewModelForTrainer> All(string userId,int id);
        Task AttachNewExerciseToWorkoutAsync(int workoutId, string exerciseIds);
        Task DeleteWorkoutForTrainer(int id, int trainingPlanId);
        Task EditWourkout(int trainingPlanId, int workoutId, EditWorkoutViewModelForTrainer model);
        Task<EditWorkoutViewModel> GetViewModelForEdit(int id,int trainingPlanId);
        Task EditWourkoutAsync(int workoutId, EditWorkoutViewModel model);
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
