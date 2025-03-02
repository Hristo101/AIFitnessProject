using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    public class TrainingPlanController : TrainerBaseController
    {
        private readonly ITrainingPlanService trainingPlanService;

        public TrainingPlanController(ITrainingPlanService _trainingPlanService)
        {
            trainingPlanService = _trainingPlanService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create(string userId, int surveyId)
        {
            CreateTraingPlanViewModel model = new CreateTraingPlanViewModel();
            model.UserId = userId;
            model.SurveyId = surveyId;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Send(int id)
        {
            var model = await trainingPlanService.GetTrainingPlanModelForSendView(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendConfrimed(int id)
        {
            await trainingPlanService.SendToUserAsync(id);
            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTraingPlanViewModel model,string userId,int surveyId)
        {
            if (!ModelState.IsValid)
            {
                model.UserId = userId;
                return View(model);
            }
            await trainingPlanService.CreateTrainigPlan(userId, GetUserId(), model, surveyId);

            return RedirectToAction("All");
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await trainingPlanService.GetTrainingPlanForEditAsync(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditTrainingPlanViewModel model,int id)
        {
            if (await trainingPlanService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsInRole("Trainer") == false)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                var trainingPlan = await trainingPlanService.GetDietById(id);
                model.ImageUrl = trainingPlan.ImageUrl;
                return View(model);
            }

            await trainingPlanService.EditAsync(id, model);

            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await trainingPlanService.GetTrainingPlanModelsForDetails(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await trainingPlanService.GetAllTrainingPlanAsync(GetUserId());

            return View(model);
        }
    
        [HttpGet]
        public async Task<IActionResult> DetailsFromExercise(int id)
        {
            var model = await trainingPlanService.GetTrainingPlanModelsForDetailsFromExercise(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AllRejectedTrainingPlan()
        {
            var models = await trainingPlanService.GetModelsForAllTrainingPlanAsync(GetUserId());

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> SendEditedPlan(int id)
        {
            var model = await trainingPlanService.GetTrainingPlanModelForSendView(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendEditTrainingPlanConfrimed(int id)
        {
            await trainingPlanService.SendToUserAsync(id);

            return RedirectToAction("AllRejectedTrainingPlan");
        }
        [HttpGet]
        public async Task<IActionResult> DetailsRejectedTrainingPlan(int id)
       {
            var model = await trainingPlanService.GetRejectedTrainingPlanAsync(id, GetUserId());

            return View(model);
        }   
    }
}
