using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class DailyDietPlanController : DietitianBaseController
    {
        private readonly IDailyDietPlanService dailyDietPlanService;

        public DailyDietPlanController(IDailyDietPlanService _dailyDietPlanService)
        {
            dailyDietPlanService = _dailyDietPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            var model = await dailyDietPlanService.GetAllDailyDietPlans(GetUserId(), id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await dailyDietPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await dailyDietPlanService.GetModelForDetails(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await dailyDietPlanService.GetModelForEdit(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDailyDietPlanViewModel model, int id)
        {
            if (await dailyDietPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var meal = await dailyDietPlanService.GetDailyDietPlanById(id);
                model.ExistingImageUrl = meal.ImageUrl;
                return View(model);
            }

            await dailyDietPlanService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> AttachDailyDietPlan(string selectedDailyDietPlanIds, int dietId)
        {
            await dailyDietPlanService.AttachDailyDietPlan(selectedDailyDietPlanIds, dietId);

            return RedirectToAction("Details", "Diet", new { id = dietId });
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

