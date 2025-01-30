using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestToDietitian;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class RequestToDietitianController : Controller
    {
        private readonly IRequestToDietitianSurvice requestsToDietitianService;

        public RequestToDietitianController(IRequestToDietitianSurvice _requestsToDietitianService)
        {
            requestsToDietitianService = _requestsToDietitianService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Survey(int id)
        {
            var model = new SurveyViewModel();
            model.DietitianId = id;
            return View(model);
        }
    }
}
