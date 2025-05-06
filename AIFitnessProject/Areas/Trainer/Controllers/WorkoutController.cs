using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
    public class WorkoutController : TrainerBaseController
    {
        private readonly IWorkoutService workoutService;
        private readonly ITrainingPlanService trainingPlanService;

        public WorkoutController(IWorkoutService _workoutService, ITrainingPlanService trainingPlanService)
        {
            this.workoutService = _workoutService;
            this.trainingPlanService = trainingPlanService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllUsersWorkouts(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID is required.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.AllWorkousForTrainer(id);

            if (model == null)
            {
                return NotFound("Workouts not found.");
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditWorkoutForTrainer(int trainingPlanId, int workoutId, string userId, EditWorkoutViewModelForTrainer model)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(trainingPlanId);

            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to edit this workout.");
            }

            if (workoutId <= 0 || string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid workout or user ID.");
            }


            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

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
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(trainingPlanId);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to edit this workout.");
            }

            if (id <= 0)
            {
                return BadRequest("Invalid workout ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.GetViewModelForEdit(id, trainingPlanId);

            if (model == null)
            {
                return NotFound("Workout not found.");
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditWorkoutViewModel model,int workoutId,int trainingPlanId)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(trainingPlanId);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to edit this workout.");
            }
            if (workoutId <= 0)
            {
                return BadRequest("Invalid workout ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

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
            if (id <= 0 || string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid workout or user ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.GetEditWorkoutViewModelForTrainer(id,userId,GetUserId());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewExercisesToWorkout(int workoutId,string exerciseIds,string userId)
        {
            if (workoutId <= 0 || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(exerciseIds))
            {
                return BadRequest("Invalid workout, exercise, or user ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            await workoutService.AttachNewExerciseToWorkoutAsync(workoutId, exerciseIds);

            TempData["Success"] = "Упражненията бяха успешно прикачени!";
            return RedirectToAction("EditWorkoutForTrainer", new { id = workoutId,userId = userId });
        }
        [HttpGet]
        public async Task<IActionResult> DetailsWorkoutForTrainer(int id,string userId)
        {
            if (id <= 0 || string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid workout or user ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

     
            var model = await workoutService.GetDetailsWorkoutViewModelForTrainer(id, userId);
            if (model == null)
            {
                return NotFound("Workout details not found.");
            }
            return View(model);
        }
        [HttpGet]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> All(int id)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to view these workouts.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.All(trainerId, id);
            if (model == null)
            {
                return NotFound("Workouts not found.");
            }

            return View(model);
        }

        [HttpGet]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> Add(int trainingPlanId)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(trainingPlanId);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to add a workout to this plan.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.GetModelForAdd(trainingPlanId);
            if (model == null)
            {
                return NotFound("Model for adding workout not found.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> Create(AddWorkoutViewModel model)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(model.TrainingPlanId);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to create a workout for this plan.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            if (!ModelState.IsValid)
            {
                var modelsExercises = await workoutService.ReturnAllExerciseViewModel(trainerId);
                model.Exercises = modelsExercises.ToList();
                return View(model);
            }

            var workoutId = await workoutService.CreateWorkout(model, trainerId);
            return RedirectToAction("All", new { id = model.TrainingPlanId });
        }

        [HttpGet]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> Details(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid workout ID.");
            }


            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.GetModelForDetails(id);
            if (model == null)
            {
                return NotFound("Workout details not found.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> AttachWorkouts(string selectedWorkoutIds, int trainingPlanId)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(trainingPlanId);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to attach workouts to this plan.");
            }

            if (string.IsNullOrEmpty(selectedWorkoutIds))
            {
                return BadRequest("No workouts selected.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            await workoutService.AddWorkout(selectedWorkoutIds, trainingPlanId);
            return RedirectToAction("Details", "TrainingPlan", new { id = trainingPlanId });
        }

        [HttpGet]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> WorkoutDetailsFromCalendar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid workout ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await workoutService.GetModelForDetails(id);
            if (model == null)
            {
                return NotFound("Workout details not found.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> DeleteWorkoutForTrainer(int id, int trainingPlanId, string userId)
        {
            var trainingPlan = await trainingPlanService.GetTrainingPlanById(trainingPlanId);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != GetUserId())
            {
                return Unauthorized("You are not authorized to delete this workout.");
            }

            if (id <= 0 || string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid workout or user ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            await workoutService.DeleteWorkoutForTrainer(id, trainingPlanId);
            return RedirectToAction("AllUsersWorkouts", new { id = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("WorkoutAccess")]
        public async Task<IActionResult> DeleteFromWorkout(int workoutId, int exerciseId, string userId)
        {
            if (workoutId <= 0 || exerciseId <= 0 || string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid workout, exercise, or user ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            await workoutService.DeleteExercise(workoutId, exerciseId);
            return RedirectToAction("EditWorkoutForTrainer", new { id = workoutId, userId = userId });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
