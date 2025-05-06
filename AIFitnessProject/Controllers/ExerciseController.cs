using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService _exerciseService)
        {
            this.exerciseService = _exerciseService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await exerciseService.GetModelForDetailsForUser(id,GetUserId());

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
