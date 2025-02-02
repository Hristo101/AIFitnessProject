using AIFitnessProject.Core.Models.Diet;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class DietController : DietitianBaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            CreateDietViewModel model = new CreateDietViewModel();

            return View(model);
        }
    }
}
