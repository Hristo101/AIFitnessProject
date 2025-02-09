using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Meal;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await mealService.GetModelForEdit(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMealViewModel model, int id)
        {
            if (await mealService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            await mealService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
    }
}
