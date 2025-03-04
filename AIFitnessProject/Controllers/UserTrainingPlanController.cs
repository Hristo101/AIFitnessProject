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
            var model = await trainingPlanService.GetTrainingPlanModelsForUserForDetails(id, GetUserId());

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> RejectedTrainingPlan(int id)
        {
            var model = await trainingPlanService.GetTrainingPlanModelsForUserForDetails(id, GetUserId());

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendEditTrainingPlan(int id)
        {
            if (await trainingPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            await trainingPlanService.SendEditTrainingPlanAsync(id,GetUserId());
            return RedirectToAction("AllMyTrainingPlans");
        }
        public async Task<IActionResult> AcceptPlan(int id)
        {
            await trainingPlanService.AcceptTrainingPlanAsync(id,GetUserId());

            return RedirectToAction("AllMyTrainingPlans");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
