using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService _trainerService)
        {
            trainerService = _trainerService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await trainerService.ShowAllTrainersAsync();

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsTrainerForUser(int id)
        {
            var model = await trainerService.GetViewModelForDetailsForUser(id,GetUserId());

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var models = await trainerService.GetViewModelForDetails(id);

            return View(models);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
