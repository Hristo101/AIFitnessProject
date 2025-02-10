using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Add()
        {
            var model = new CreateExerciseViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await exerciseService.AddExercise(model, GetUserId());

            return RedirectToAction("Add","Workout");
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await exerciseService.GetModelForDetails(id);
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsTrainingPlan(int id)
        {
            var model = await exerciseService.GetModelForDetails(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await exerciseService.GetModelForEdit(id);
            return View(model);
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
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
