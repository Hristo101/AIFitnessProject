using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class DailyDietPlanController : DietitianBaseController
    {
        private readonly IDailyDietPlanService dailyDietPlanService;
        private readonly IDietService dietService;
 
        public DailyDietPlanController(IDailyDietPlanService _dailyDietPlanService, IDietService _dietService)
        {
            dailyDietPlanService = _dailyDietPlanService;
            dietService = _dietService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            if(await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if(await dietService.IsDietitianCreatedDietAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }
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
        [HttpPost]
        public async Task<IActionResult> EditDailyDietPlanForDietitian(int dietId, int dailyDietPlanId, string userId, EditDailyDietPlanViewModelForDietitian model)
        {
            if (!ModelState.IsValid)
            {
                var oldViewModel = await dailyDietPlanService.GetEditDailyDietPlanViewModelForDietitian(dailyDietPlanId, userId, GetUserId());
                model.ImageUrl = oldViewModel.ImageUrl;
                model.AllMeals = oldViewModel.AllMeals;
                model.Meals = oldViewModel.Meals;
                return View(model);
            }
            await dailyDietPlanService.EditDailyDietPlan(dietId, dailyDietPlanId, model);
            return RedirectToAction(nameof(AllUserDailyDietPlans), new { id = userId });
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

            return RedirectToAction(nameof(All), new { id = model.Id });
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

        [HttpPost]
        public async Task<IActionResult> DeleteFromDailyDietPlan(int dailyDietPlanId, int mealId, string userId)
        {
            await dailyDietPlanService.DeleteMeal(dailyDietPlanId, mealId);
            return RedirectToAction(nameof(EditDailyDietPlanForDietitian), new { id = dailyDietPlanId, userId = userId });
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

