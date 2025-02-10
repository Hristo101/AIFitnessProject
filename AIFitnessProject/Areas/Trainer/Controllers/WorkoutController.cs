using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Workout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public async Task<IActionResult> All(int id)
        {
            var model = await workoutService.All(GetUserId(), id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await workoutService.GetModelForAdd();

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

            return RedirectToAction("All", new {id = workoutId});
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
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
