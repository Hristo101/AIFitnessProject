using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Add(int dietId)
        {
            var model = new CreateMealViewModel();
            model.DietId = dietId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateMealViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await mealService.AddMeal(model, GetUserId());

            return RedirectToAction("Add", "DailyDietPlan", new { dietId = model.DietId });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await mealService.GetModelForDetails(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsDiet(int id)
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
                var meal = await mealService.GetMealById(id);
                model.ExistingImageUrl = meal.ImageUrl;
                return View(model);
            }

            await mealService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
