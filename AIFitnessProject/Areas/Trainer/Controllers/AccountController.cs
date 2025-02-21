using AIFitnessProject.Core.Contracts;
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
