using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class UserTrainingPlanController : Controller
    {
        private readonly ITrainingPlanService trainingPlanService;

        public UserTrainingPlanController(ITrainingPlanService _trainingPlanService)
        {
            this.trainingPlanService = _trainingPlanService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllMyTrainingPlans()
        {
            var models = await trainingPlanService.GetAllTrainingPlanForUserAsync(GetUserId());

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            throw new NotImplementedException();
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
