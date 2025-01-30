using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestToDietitian;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class RequestToDietitianController : Controller
    {
        private readonly IRequestToDietitianSurvice requestsToDietitianService;

        public RequestToDietitianController(IRequestToDietitianSurvice _requestsToDietitianService)
        {
            requestsToDietitianService = _requestsToDietitianService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Survey(int id)
        {
            var model = new SurveyViewModel();
            model.DietitianId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Survey(int id, SurveyViewModel model)
        {
            if(model.MealPreparationPreference == "false")
            {
                ModelState.AddModelError("MealPreparationPreference", "Моля изберете избор за готвене");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await requestsToDietitianService.Add(GetUserId(), id, model);

            return RedirectToAction("All", "Dietitian");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
