using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class MealController : DietitianBaseController
    {
        private readonly IMealService mealService;

        public MealController(IMealService _mealService)
        {
            mealService = _mealService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await mealService.GetModelForDetails(id);

            return View(model);
        }
    }
}
