﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Diet;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class DietController : DietitianBaseController
    {
        private readonly IDietService dietService;

        public DietController(IDietService _dietService)
        {
            dietService = _dietService;
        }

        [HttpGet]
        public IActionResult Create(string id, int requestId)
        {
            CreateDietViewModel model = new CreateDietViewModel();

            model.UserId = id;
            model.RequestId = requestId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDietViewModel model, string id, int requestId)
        {
            if (!ModelState.IsValid)
            {
                model.UserId = id;
                return View(model);
            }
            await dietService.CreateDiet(id, GetUserId(), model, requestId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await dietService.GetAllDietsAsync(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if(await dietService.IsMineAsync(id,GetUserId()) == false)
            {
                return Unauthorized();
            }
            var model = await dietService.GetDietModelsForDetails(id);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Send(int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }
            var model = await dietService.GetDietModelForSendView(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendConfirmed(int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }

            await dietService.SendToUserAsync(id);
            return RedirectToAction(nameof(All));
        }
  
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }

            var model = await dietService.GetModelForEdit(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDietViewModel model, int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                var diet = await dietService.GetDietById(id);
                model.ExistingImageUrl = diet.ImageUrl;
                return View(model);
            }

            await dietService.EditAsync(id, model);

            return RedirectToAction(nameof(All), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AllRejectedDiet()
        {
            var models = await dietService.GetModelsForAllRejectedDietAsync(GetUserId());

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsRejectedDiet(int id)
        {

            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }
            var model = await dietService.GetRejectedDietAsync(id, GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SendEditDiet(int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }
            var model = await dietService.GetDietModelForSendView(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendEditDietConfirmed(int id)
        {
            if (await dietService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await dietService.IsMineAsync(id, GetUserId()) == false)
            {
                return Unauthorized();
            }
            await dietService.SendToUserAsync(id);

            return RedirectToAction(nameof(AllRejectedDiet));
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
