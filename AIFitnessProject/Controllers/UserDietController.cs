using AIFitnessProject.Core.Contracts;
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
       
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
