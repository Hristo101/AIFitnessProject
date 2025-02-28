using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealService;

        public MealController(IMealService _mealService)
        {
            mealService = _mealService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await mealService.GetModelForDetailsForUser(id, GetUserId());

            return View(model);
        }
        public async Task<IActionResult> DetailsFromRejectedDiet(int id)
        {
            var model = await mealService.GetModelForDetailsForUser(id, GetUserId());

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
