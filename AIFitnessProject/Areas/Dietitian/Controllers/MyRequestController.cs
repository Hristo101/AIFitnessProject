using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class MyRequestController : DietitianBaseController
    {
        private readonly IRequestToDietitianSurvice requestsToDietitianService;

        public MyRequestController(IRequestToDietitianSurvice _requestsToDietitianService)
        {
            requestsToDietitianService = _requestsToDietitianService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var userId = GetUserId();
            var model = await requestsToDietitianService.GetAllAsync(userId);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            if(await requestsToDietitianService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await requestsToDietitianService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }
            var model = await requestsToDietitianService.GetViewModelForDetailsAsync(id);

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
