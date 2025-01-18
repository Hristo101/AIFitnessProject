﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Trainer;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService _trainerService)
        {
            trainerService = _trainerService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await trainerService.ShowAllTrainersAsync();

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var models = await trainerService.GetViewModelForDetails(id);

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> SendDocuments()
        {
            var model = new TrainerViewModelForWork();

            return View(model);
        }
    }
}
