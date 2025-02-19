using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class UserDietController : Controller
    {
        private readonly IDietService dietService;

        public UserDietController(IDietService _dietService)
        {
            dietService = _dietService;
        }

        [HttpGet]
        public async Task<IActionResult> MyDiet()
        {
            var models = await dietService.GetDietForUserAsync(GetUserId());

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = GetUserId();
            if(await dietService.UserHasDietAsync(id ,userId) == false)
            {
                return Unauthorized();
            }
            var model = await dietService.GetDietModelForUserForDetails(id, userId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> RejectedDiet(int id)
        {

            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = GetUserId();
            if (await dietService.UserHasDietAsync(id, userId) == false)
            {
                return Unauthorized();
            }
            var model = await dietService.GetDietModelForUserForDetails(id, userId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendEditDiet(int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var userId = GetUserId();
            if (await dietService.UserHasDietAsync(id, userId) == false)
            {
                return Unauthorized();
            }

            await dietService.SendEditDietAsync(id, userId);
            return RedirectToAction(nameof(MyDiet));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
