using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Details(int id)
        {
            var model = await exerciseService.GetModelForDetails(id);
            
            return View(model);
        }
    }
}
