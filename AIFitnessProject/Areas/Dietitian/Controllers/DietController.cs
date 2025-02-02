using AIFitnessProject.Core.Models.Diet;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class DietController : DietitianBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateDietViewModel model = new CreateDietViewModel();

            return View(model);
        }
    }
}
