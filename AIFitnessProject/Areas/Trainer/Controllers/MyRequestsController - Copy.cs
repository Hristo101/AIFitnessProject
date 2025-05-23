﻿using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
    public class MyRequestsController : TrainerBaseController
    {
        private readonly IRequestsToCoach requestsToCoachService;

        public MyRequestsController(IRequestsToCoach _requestsToCoachService)
        {
            requestsToCoachService = _requestsToCoachService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await requestsToCoachService.GetAllAsync(GetUserId());

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await requestsToCoachService.GetViewModelForDetailsAsync(id);

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
