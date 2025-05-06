using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestsToCoach;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    [Authorize]
    public class RequestsToCoachController : Controller
    {
        private readonly IRequestsToCoach requestsToCoachService;

        public RequestsToCoachController(IRequestsToCoach _requestsToCoachService)
        {
            requestsToCoachService = _requestsToCoachService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Survey(int id)
        {
            var model = new SurveyViewModel();
            model.TrainerId = id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitSurvey(int id,SurveyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isTrue = await requestsToCoachService.Add(GetUserId(),id,model);

            return RedirectToAction("All", "Trainer");
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
