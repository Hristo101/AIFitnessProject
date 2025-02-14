using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class ExerciseFeedbackController : Controller
    {
        private readonly IRepository repository;

        public ExerciseFeedbackController(IRepository _repository)
        {
            this.repository =_repository;
        }
        [HttpPost]
       public async Task<IActionResult> SubmitComment(int exerciseId, TrainingPlanDetailsViewModel model,string content)
        {
            return RedirectToAction();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
