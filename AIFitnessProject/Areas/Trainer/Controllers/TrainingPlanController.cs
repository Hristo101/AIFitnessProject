﻿using AIFitnessProject.Core.Contracts;
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
        public async Task<IActionResult> Create(string id)
        {
            CreateTraingPlanViewModel model = new CreateTraingPlanViewModel();
            model.UserId = id;  
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTraingPlanViewModel model,string id)
        {
            if (!ModelState.IsValid)
            {
                model.UserId = id;
                return View(model);
            }
            await trainingPlanService.CreateTrainigPlan(id, GetUserId(), model);

            return RedirectToAction("All");
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await trainingPlanService.GetAllTrainingPlanAsync(GetUserId());

            return View(model);
        }
    }
}
