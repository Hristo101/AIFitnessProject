using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    public class AccountController : TrainerBaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            this.accountService = _accountService;
        }
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            bool isInRole = false;
            if (User.IsInRole("Trainer") == true || User.IsInRole("Dietitian") == true)
            {
                isInRole = true;
            }
            var model = await accountService.GetMoldelForMyProfile(GetUserId(), isInRole);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DashBoard()
        {
            var model = accountService.DashboardForTrainer(GetUserId());
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await accountService.Edit(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.NewImageUrl.CopyToAsync(memoryStream);
                    string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                    model.ImageUrl = base64Image;
                }

                return View(model);
            }

            var user = await accountService.ChangeInformation(id, model);

            return RedirectToAction("MyProfile", "Account");
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllUsers()
        {
            var models = await accountService.GetAllUsers(GetUserId());

            return View(models);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
