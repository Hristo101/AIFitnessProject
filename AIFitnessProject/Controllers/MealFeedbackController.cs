using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.MealFeedback;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class MealFeedbackController : Controller
    {
        private readonly IDietService dietService;
        private readonly IMealFeedbackService mealFeedbackService;

        public MealFeedbackController(IDietService _dietService, IMealFeedbackService _mealFeedbackService)
        {
            dietService = _dietService;
            mealFeedbackService = _mealFeedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitComment([FromBody] SubmitCommentRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Невалидни данни" });
            }

            try
            {
                await mealFeedbackService.AddMealFeedbackAsync(request);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
