using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Core.Models.Workout;
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
        public async Task<IActionResult> AllUserDailyDietPlans(string id)
        {
            var model = await dailyDietPlanService.GetAllUserDailyDietPlansForDietitian(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int dietId)
        {
            var model = await dailyDietPlanService.GetModelForAdd(dietId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDailyDietPlanViewModel model)
        {
            var modelsMeals = await dailyDietPlanService.ReturnAllMealViewModel(GetUserId());

            if (!ModelState.IsValid)
            {
                model.Meals = modelsMeals.ToList();
                return View(model);
            }
            var workoutId = await dailyDietPlanService.CreateDailyDietPlan(model, GetUserId());
            return RedirectToAction(nameof(All), new { id = model.DietId });
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
        public async Task<IActionResult> DetailsDailyDietPlanForDietitian(int id, string userId)
        {
            var model = await dailyDietPlanService.GetDetailsDailyDietPlanViewModelForDietitian(id, userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditDailyDietPlanForDietitian(int id, string userId)
        {
            var model = await dailyDietPlanService.GetEditDailyDietPlanViewModelForDietitian(id, userId, GetUserId());

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
        [HttpPost]
        public async Task<IActionResult> DeleteDailyDietPlanForDietitian(int id, int dietId, string userId)
        {
            await dailyDietPlanService.DeleteDailyDietPlanForDietitian(id, dietId);

            return RedirectToAction("AllUserDailyDietPlans", new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMealToDailyDietPlan(int dailyDietPlanId, string mealsIds, string userId)
        {
            await dailyDietPlanService.AttachNewMealToDailyDietPlanAsync(dailyDietPlanId, mealsIds);

            TempData["Success"] = "Храните бяха успешно прикачени!";
            return RedirectToAction(nameof(EditDailyDietPlanForDietitian), new { id = dailyDietPlanId, userId = userId });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

