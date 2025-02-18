using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class UserDietController : Controller
    {
        private readonly IDietService dietService;

        public UserDietController(IDietService _dietService)
        {
            dietService = _dietService;
        }

        [HttpGet]
        public async Task<IActionResult> MyDiet()
        {
            var models = await dietService.GetDietForUserAsync(GetUserId());

            return View(models);
        }
        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var model = await trainingPlanService.GetTrainingPlanModelsForUserForDetails(id, GetUserId());

        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<IActionResult> RejectedTrainingPlan(int id)
        //{
        //    var model = await trainingPlanService.GetTrainingPlanModelsForUserForDetails(id, GetUserId());

        //    return View(model);
        //}

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
