using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Account;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRepository repository;
        private readonly IAccountService accountService;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, IRepository _repository, IAccountService _accountService)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.repository = _repository;
            this.accountService = _accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction(nameof(MoreInformation));
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> MyTrainer()
        {
            var model = await accountService.GetViewModelForMyTrainer(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyDietitian()
        {
            var model = await accountService.GetViewModelForMyDietitian(GetUserId());

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await repository.All<ApplicationUser>().FirstOrDefaultAsync(a => a.Email == model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (await userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("All", "AdminDocument", new { area = "Admin" });
                    }
                   else if (await userManager.IsInRoleAsync(user, "Trainer"))
                    {
                        return RedirectToAction("All", "MyRequests", new { area = "Trainer" });
                    }
                    else if(await userManager.IsInRoleAsync(user, "Dietitian"))
                    {
                        return RedirectToAction("All", "MyRequest", new { area = "Dietitian" });
                    }

                    return RedirectToAction("All", "Trainer");
                }
                else
                {
                    ModelState.AddModelError(nameof(model.Email), "Невалидни данни за вход");
                }
            }
            else
            {
                ModelState.AddModelError(nameof(model.Email), "Невалидни данни за вход");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            bool isInRole = false;
            if (User.IsInRole("Trainer") == true || User.IsInRole("Dietitian") == true)
            {
                isInRole = true;
            }
            var model = await accountService.GetMoldelForMyProfile(GetUserId(),isInRole);

            return View(model);
        }

        [HttpGet]
        public IActionResult MoreInformation()
        
        {
            var model = new MoreInformationViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MoreInformation(MoreInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string userId = GetUserId();
            await accountService.AddMoreInformationAsync(userId,model);

            return RedirectToAction("All", "Trainer");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model =await accountService.Edit(id);
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
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
