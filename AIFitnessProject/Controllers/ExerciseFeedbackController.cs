using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class ExerciseFeedbackController : Controller
    {

        private readonly ITrainingPlanService trainingPlanService;
        private readonly IExerciseFeedbackService exerciseFeedbackService;

        public ExerciseFeedbackController(ITrainingPlanService _trainingPlanService, IExerciseFeedbackService _exerciseFeedbackService)
        {
            this.trainingPlanService = _trainingPlanService;
            this.exerciseFeedbackService = _exerciseFeedbackService;
        }

        [HttpPost]
       public async Task<IActionResult> SubmitComment([FromBody] SubmitCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Невалидни данни" });
            }

            try
            {
                await exerciseFeedbackService.AddExerciseFeedbackAsync(request);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
