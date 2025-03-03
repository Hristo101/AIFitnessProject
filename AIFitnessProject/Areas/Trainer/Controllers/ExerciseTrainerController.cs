using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Core.Models.Exercise;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    public class ExerciseTrainerController : TrainerBaseController
    {
        private readonly IExerciseService exerciseService;

        public ExerciseTrainerController(IExerciseService _exerciseService)
        {
            this.exerciseService = _exerciseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var model = new CreateExerciseViewModel();
            model.TrainingPlanId = id;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddFromRejectedPlan(int id)
        {
            var model = new CreateExerciseViewModel();
            model.TrainingPlanId = id;
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFromRejectedPlan(CreateExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await exerciseService.AddExercise(model, GetUserId());

            return RedirectToAction("DetailsRejectedTrainingPlan", "TrainingPlan", new { id = model.TrainingPlanId });
        }

        [HttpPost]
        public async Task<IActionResult> SwapExerciseInWorkout([FromBody] SwapExerciseRequest request)
        {
            if (request == null ||
                request.TrainingPlanId <= 0 ||
                request.WorkoutId <= 0 ||
                request.ExerciseId <= 0 ||
                request.NewExerciseId <= 0)
            {
                return Json(new { success = false, message = "Невалидни данни." });
            }

            var result = await exerciseService.SwapExerciseInWorkoutAsync(request);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Възникна грешка при смяната на упражнението." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await exerciseService.AddExercise(model, GetUserId());

            return RedirectToAction("Add","Workout", new { trainingPlanId = model.TrainingPlanId });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id,int workoutId)
        {
            var model = await exerciseService.GetModelForDetailsFromWorkouts(id, workoutId);
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsTrainingPlan(int id,int trainingPlanId)
        {
            var model = await exerciseService.GetModelForDetails(id,GetUserId(),trainingPlanId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditFromWorkout(int id,int workoutId)
        {
            var model = await exerciseService.GetModelFromWorkoutForEdit(id, workoutId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, int trainingPlanId)
        {
            var model = await exerciseService.GetModelForEdit(id, trainingPlanId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditFromWorkout(EditExerciseFromWorkoutViewModel model,int id,int workoutId)
        {
            if (await exerciseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var oldModel = await exerciseService.GetModelFromWorkoutForEdit(id, workoutId);
                model.ExistingImageUrl = oldModel.ExistingImageUrl;
                return View(model);
            }

            await exerciseService.EditAsyncFromWorkout(id, model);

            return RedirectToAction("Details",new { id = model.Id,workoutId = workoutId });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditExerciseViewModel model,int id,int trainingPlanId)
        {
            if (await exerciseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await exerciseService.EditAsync(id, model);

            return RedirectToAction("DetailsTrainingPlan", "ExerciseTrainer", new { id = model.Id, trainingPlanId = trainingPlanId });
        }
        [HttpGet]
        public async Task<IActionResult> AddFromEditWorkout()
        {
            var model = new CreateExerciseViewModel();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateExercise(int workoutId, int exerciseId,string userId)
        {
            var model = await exerciseService.GetModelFromWorkoutForEdit(exerciseId, workoutId);
            model.UserId = userId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExercise(EditExerciseFromWorkoutViewModel model,int exerciseId,int workoutId,string userId)
        {
            if (await exerciseService.ExistAsync(exerciseId) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await exerciseService.EditAsyncFromWorkout(exerciseId, model);

            return RedirectToAction("EditWorkoutForTrainer","Workout",new {id = workoutId,userId = userId});
        }
        [HttpPost]
        public async Task<IActionResult> AddFromEditWorkout(CreateExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await exerciseService.AddExercise(model, GetUserId());

            return RedirectToAction("DetailsRejectedTrainingPlan", "TrainingPlan", new { id = model.TrainingPlanId });
        }

        [HttpGet]
        public async Task<IActionResult> AddNewExerciseFromEditWorkout(int workoutId,string userId)
        {
            var model = new CreateNewExerciseForTrainerViewModel();
            model.UserId = userId;
            model.WorkoutId = workoutId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewExerciseFromEditWorkout(CreateNewExerciseForTrainerViewModel model,string userId,int workoutId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await exerciseService.AddFromEditWorkoutExercise(model, GetUserId());

            return RedirectToAction("EditWorkoutForTrainer", "Workout", new { id = workoutId, userId = userId });
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
