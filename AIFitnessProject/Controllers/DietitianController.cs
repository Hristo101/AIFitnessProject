using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Services;
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            if (await dietitianService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await dietitianService.DetailsDietitianAsync(id);

            return View(model);
           
        }
    }
}


