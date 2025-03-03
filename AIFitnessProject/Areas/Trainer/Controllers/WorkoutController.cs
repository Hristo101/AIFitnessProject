using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Workout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    public class WorkoutController : TrainerBaseController
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService _workoutService)
        {
            this.workoutService = _workoutService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllUsersWorkouts(string id)
        {
            var model = await workoutService.AllWorkousForTrainer(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditWorkoutForTrainer(int trainingPlanId, int workoutId, string userId, EditWorkoutViewModelForTrainer model)
        {
            if (!ModelState.IsValid)
            {
                var oldViewModel = await workoutService.GetEditWorkoutViewModelForTrainer(workoutId, userId, GetUserId());
                model.ImageUrl = oldViewModel.ImageUrl;
                model.AllExercises = oldViewModel.AllExercises;
                model.Exercises = oldViewModel.Exercises;
                return View(model);
            }
            await workoutService.EditWourkout(trainingPlanId, workoutId, model);
            return RedirectToAction("AllUsersWorkouts", new {id =userId});
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id,int trainingPlanId)
        {
            var model = await workoutService.GetViewModelForEdit(id, trainingPlanId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditWorkoutViewModel model,int workoutId,int trainingPlanId)
        {
            if (!ModelState.IsValid)
            {
                var oldModel = await workoutService.GetViewModelForEdit(workoutId, trainingPlanId);
                model.ImageUrl = oldModel.ImageUrl;
                return View(model);
            }
            await workoutService.EditWourkoutAsync(workoutId,model);
            return RedirectToAction("All", new { id = trainingPlanId });
        }
        [HttpGet]
        public async Task<IActionResult> EditWorkoutForTrainer(int id,string userId)
        {
            var model = await workoutService.GetEditWorkoutViewModelForTrainer(id,userId,GetUserId());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewExercisesToWorkout(int workoutId,string exerciseIds,string userId)
        {
            await workoutService.AttachNewExerciseToWorkoutAsync(workoutId, exerciseIds);

            TempData["Success"] = "Упражненията бяха успешно прикачени!";
            return RedirectToAction("EditWorkoutForTrainer", new { id = workoutId,userId = userId });
        }
        [HttpGet]
        public async Task<IActionResult> DetailsWorkoutForTrainer(int id,string userId)
        {
            var model = await workoutService.GetDetailsWorkoutViewModelForTrainer(id, userId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            var model = await workoutService.All(GetUserId(), id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int trainingPlanId)
        {
            var model = await workoutService.GetModelForAdd(trainingPlanId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddWorkoutViewModel model)
        {
            var modelsExercises = await workoutService.ReturnAllExerciseViewModel(GetUserId());
            if (!ModelState.IsValid) 
            {
                model.Exercises = modelsExercises.ToList();
                return View(model);
            }
           var workoutId = await workoutService.CreateWorkout(model, GetUserId());
            return RedirectToAction("All", new {id = model.TrainingPlanId });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await workoutService.GetModelForDetails(id);

         return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AttachWorkouts(string selectedWorkoutIds,int trainingPlanId)
        {
            await workoutService.AddWorkout(selectedWorkoutIds,trainingPlanId);

            return RedirectToAction("Details", "TrainingPlan", new { id = trainingPlanId });
        }
        [HttpGet]
        public async Task<IActionResult> WorkoutDetailsFromCalendar(int id)
        {
            var model = await workoutService.GetModelForDetails(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteWorkoutForTrainer(int id, int trainingPlanId,string userId)
        {
            await workoutService.DeleteWorkoutForTrainer(id, trainingPlanId);

            return RedirectToAction("AllUsersWorkouts", new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromWorkout(int workoutId,int exerciseId,string userId)
        {
            await workoutService.DeleteExercise(workoutId, exerciseId);
            return RedirectToAction("EditWorkoutForTrainer", "Workout", new { id = workoutId, userId = userId });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
