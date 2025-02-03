using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class TrainingPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateTraingPlanViewModel model = new CreateTraingPlanViewModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTraingPlanViewModel model,string userId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            TrainingPlan plan = new TrainingPlan()
            {
                Description =model.TrainingPlanDescription,
                ImageUrl = model.ImageUrl,
                Name = model.TrainingPlanName,
                CreatedById = GetUserId(),             
            };
            return RedirectToAction("All", "TrainingPlanController");
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
