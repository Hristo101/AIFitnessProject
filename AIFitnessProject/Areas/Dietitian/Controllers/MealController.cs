using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.MealFeedback;
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
        public async Task<IActionResult> Add(int id)
        {
            var model = new CreateMealViewModel();
            model.DietId = id;
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
        public async Task<IActionResult> AddFromRejectedDiet(int id)
        {
            var model = new CreateMealViewModel();
            model.DietId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFromRejectedDiet(CreateMealViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await mealService.AddMeal(model, GetUserId());

            return RedirectToAction("DetailsRejectedDiet", "Diet", new { id = model.DietId });
        }

        [HttpGet]
        public async Task<IActionResult> AddFromEditDailyDietPlan(int id,string userId)
        {
            var model = new CreateMealViewModelFromEditDailyDietPlan();
            model.UserId = userId;
            model.DailyDietPlanId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFromEditDailyDietPlan(CreateMealViewModelFromEditDailyDietPlan model, int id, string userId)
        {
            if (!ModelState.IsValid)
            {
                model.DailyDietPlanId = id;
                model.UserId = userId;
                return View(model);
            }
            await mealService.AddMeal(model, GetUserId());

            return RedirectToAction("EditDailyDietPlanForDietitian", "DailyDietPlan", new { id = id, userId = userId });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id,int dailyDietPlanId)
        {
            var model = await mealService.GetModelForDetailsFromDailyDietPlan(id, dailyDietPlanId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsDiet(int id, int dietId)
        {

            var model = await mealService.GetModelForDetails(id,dietId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsMealFromCalendar(int id)
        {

            var model = await mealService.DetailsMealFromCalendar(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id,int dietId)
        {
            var model = await mealService.GetModelForEdit(id,dietId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMealViewModel model, int id,int dietId)
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

            return RedirectToAction(nameof(DetailsDiet), new { id = model.Id , dietId = dietId});
        }
        [HttpGet]
        public async Task<IActionResult> EditFromDailyDietPlan(int id, int dailyDietPlanId)
        {
            var model = await mealService.GetModelFromDailyDiePlanForEdit(id, dailyDietPlanId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFromDailyDietPlan(EditMealFromDailyDietPlanViewModel model, int id, int dailyDietPlanId)
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

            await mealService.EditAsyncFromDailyDietPlan(id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id , dailyDietPlanId = dailyDietPlanId });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMeal(int dailyDietPlanId, int mealId, string userId)
        {
            var model = await mealService.GetModelFromDailyDiePlanForEdit(mealId, dailyDietPlanId);
            model.UserId = userId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMeal(EditMealFromDailyDietPlanViewModel model, int mealId, int dailyDietPlanId, string userId)
        {
            if (await mealService.ExistAsync(mealId) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var meal = await mealService.GetMealById(mealId);
                model.ExistingImageUrl = meal.ImageUrl;
                return View(model);
            }

            await mealService.EditAsyncFromDailyDietPlan(mealId, model);

            return RedirectToAction("EditDailyDietPlanForDietitian", "DailyDietPlan", new { id = dailyDietPlanId, userId = userId });
        }
        [HttpPost]
        public async Task<IActionResult> SwapMealInDailyDietPlan([FromBody] SwapMealRequest request)
        {
            if (request == null ||
                request.DietId <= 0 ||
                request.DailyDietPlanId <= 0 ||
                request.MealId<= 0 ||
                request.NewMealId <= 0)
            {
                return Json(new { success = false, message = "Невалидни данни." });
            }

            var result = await mealService.SwapMealInDailyDietPlan(request);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Възникна грешка при смяната на упражнението." });
            }
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
