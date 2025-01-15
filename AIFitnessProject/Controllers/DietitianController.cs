using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class DietitianController : Controller
    {
        private readonly IDietitianService dietitianService;

        public DietitianController(IDietitianService _dietitianService)
        {
            dietitianService = _dietitianService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await dietitianService.AllDietitianAsync();

            return View(models);
        }
    }
}


