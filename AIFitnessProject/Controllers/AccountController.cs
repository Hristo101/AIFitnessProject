using AIFitnessProject.Core.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
    }
}
