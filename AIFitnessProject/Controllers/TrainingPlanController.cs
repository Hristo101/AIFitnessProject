using AIFitnessProject.Core.Models.TrainingPlan;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class TrainingPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateTraingPlanViewModel model = new CreateTraingPlanViewModel();

            return View(model);
        }
    }
}
