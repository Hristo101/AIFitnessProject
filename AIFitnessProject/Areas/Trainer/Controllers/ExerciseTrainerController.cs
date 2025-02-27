using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Core.Models.Exercise;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Details(int id)
        {
            var model = await exerciseService.GetModelForDetailsFromWorkouts(id);
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsTrainingPlan(int id)
        {
            var model = await exerciseService.GetModelForDetails(id,GetUserId());

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditFromWorkout(int id)
        {
            var model = await exerciseService.GetModelFromWorkoutForEdit(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await exerciseService.GetModelForEdit(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditFromWorkout(EditExerciseFromWorkoutViewModel model,int id)
        {
            if (await exerciseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await exerciseService.EditAsyncFromWorkout(id, model);

            return RedirectToAction("Details",new { id = model.Id });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditExerciseViewModel model,int id)
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

            return RedirectToAction("DetailsTrainingPlan", "ExerciseTrainer", new { id = model.Id });
        }
        [HttpGet]
        public async Task<IActionResult> AddFromEditWorkout()
        {
            var model = new CreateExerciseViewModel();
            return View(model);
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

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
