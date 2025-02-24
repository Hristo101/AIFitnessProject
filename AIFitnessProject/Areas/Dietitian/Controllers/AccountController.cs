using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class AccountController : DietitianBaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            this.accountService = _accountService;
        }

      
        public async Task<IActionResult> AllDietitianClients()
        {
            var models = await accountService.GetAllDietitianClients(GetUserId());

            return View(models);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
