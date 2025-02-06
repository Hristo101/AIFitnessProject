using AIFitnessProject.Core.Contracts;
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
        public async Task<IActionResult> All()
        {
            var model = await workoutService.All(GetUserId());

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model =


         return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
