using AIFitnessProject.Core.Contracts;
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

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

