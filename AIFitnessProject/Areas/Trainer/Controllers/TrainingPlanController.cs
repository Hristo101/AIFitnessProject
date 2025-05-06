using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.TrainingPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
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
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> Create(string userId, int surveyId)
        {
            if (string.IsNullOrEmpty(userId) || surveyId <= 0)
            {
                return BadRequest("Invalid user ID or survey ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            CreateTraingPlanViewModel model = new CreateTraingPlanViewModel
            {
                UserId = userId,
                SurveyId = surveyId
            };
            return View(model);
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> Send(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to send this training plan.");
            }

            var model = await trainingPlanService.GetTrainingPlanModelForSendView(id);
            if (model == null)
            {
                return NotFound("Training plan not found.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> SendConfrimed(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to send this training plan.");
            }

            await trainingPlanService.SendToUserAsync(id);
            return RedirectToAction("All");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> Create(CreateTraingPlanViewModel model, string userId, int surveyId)
        {
            if (string.IsNullOrEmpty(userId) || surveyId <= 0)
            {
                return BadRequest("Invalid user ID or survey ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            if (!ModelState.IsValid)
            {
                model.UserId = userId;
                return View(model);
            }

            await trainingPlanService.CreateTrainigPlan(userId, trainerId, model, surveyId);
            return RedirectToAction("All");
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }


            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to edit this training plan.");
            }

            var model = await trainingPlanService.GetTrainingPlanForEditAsync(id);
            if (model == null)
            {
                return NotFound("Training plan not found.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> Edit(EditTrainingPlanViewModel model, int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to edit this training plan.");
            }

            if (!await trainingPlanService.ExistAsync(id))
            {
                return BadRequest("Training plan does not exist.");
            }

            if (!ModelState.IsValid)
            {
                var trainingPlanData = await trainingPlanService.GetDietById(id);
                model.ImageUrl = trainingPlanData.ImageUrl;
                return View(model);
            }

            await trainingPlanService.EditAsync(id, model);
            return RedirectToAction("All");
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to view this training plan.");
            }

            var model = await trainingPlanService.GetTrainingPlanModelsForDetails(id);
            if (model == null)
            {
                return NotFound("Training plan details not found.");
            }

            return View(model);
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> All()
        {
            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var model = await trainingPlanService.GetAllTrainingPlanAsync(trainerId);
            if (model == null)
            {
                return NotFound("No training plans found.");
            }

            return View(model);
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> DetailsFromExercise(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to view this training plan.");
            }

            var model = await trainingPlanService.GetTrainingPlanModelsForDetailsFromExercise(id);
            if (model == null)
            {
                return NotFound("Training plan details not found.");
            }

            return View(model);
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> AllRejectedTrainingPlan()
        {
            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var models = await trainingPlanService.GetModelsForAllTrainingPlanAsync(trainerId);
            if (models == null)
            {
                return NotFound("No rejected training plans found.");
            }

            return View(models);
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> SendEditedPlan(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to send this training plan.");
            }

            var model = await trainingPlanService.GetTrainingPlanModelForSendView(id);
            if (model == null)
            {
                return NotFound("Training plan not found.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> SendEditTrainingPlanConfrimed(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to send this training plan.");
            }

            await trainingPlanService.SendToUserAsync(id);
            return RedirectToAction("AllRejectedTrainingPlan");
        }

        [HttpGet]
        [EnableRateLimiting("TrainingPlanAccess")]
        public async Task<IActionResult> DetailsRejectedTrainingPlan(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid training plan ID.");
            }

            var trainerId = GetUserId();
            if (string.IsNullOrEmpty(trainerId))
            {
                return Unauthorized("Trainer is not authenticated.");
            }

            var trainingPlan = await trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null || trainingPlan.Trainer.UserId != trainerId)
            {
                return Unauthorized("You are not authorized to view this training plan.");
            }

            var model = await trainingPlanService.GetRejectedTrainingPlanAsync(id, trainerId);
            if (model == null)
            {
                return NotFound("Rejected training plan not found.");
            }

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}