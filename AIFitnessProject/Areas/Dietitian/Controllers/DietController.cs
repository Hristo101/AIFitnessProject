using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Diet;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class DietController : DietitianBaseController
    {
        private readonly IDietService dietService;

        public DietController(IDietService _dietService)
        {
            dietService = _dietService;
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            CreateDietViewModel model = new CreateDietViewModel();

            model.UserId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDietViewModel model, string id)
        {
            if (!ModelState.IsValid)
            {
                model.UserId = id;
                return View(model);
            }
            await dietService.CreateDiet(id, GetUserId(), model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await dietService.GetAllDietsAsync(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await dietService.GetDietModelsForDetails(id);

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
