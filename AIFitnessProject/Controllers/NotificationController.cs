using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class NotificationController : Controller
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
        public async Task<IActionResult> All()
        {
            var model = await notificationService.GetAllNotifications(GetUserId());

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
