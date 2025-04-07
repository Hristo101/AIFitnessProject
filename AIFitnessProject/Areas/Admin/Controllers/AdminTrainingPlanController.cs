using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Admin.Controllers
{
    public class AdminTrainingPlanController : AdminBaseController
    {
        private readonly ITrainingPlanService trainingPlanService;

        public AdminTrainingPlanController(ITrainingPlanService _trainingPlanService)
        {
            trainingPlanService = _trainingPlanService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await trainingPlanService.AllTrainingPlanAsync();

            return View(model);
        }
    }
}
