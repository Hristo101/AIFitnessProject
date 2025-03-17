using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    public class NotificationController : TrainerBaseController
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService _notificationService)
        {
            this.notificationService = _notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await notificationService.GetAllNotifications(GetUserId());

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MarkAllAsRead()
        {
            try
            {
                await notificationService.MarkAllAsRead(GetUserId());
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
