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
        [HttpGet]
        public async Task<IActionResult> View(string userId, int notificationId)
        {
            await notificationService.MarkNotificationRead(notificationId);

            var notification = await notificationService.GetNotificationById(notificationId);

            switch (notification.Source)
            {
                case "Calendar":
                    return RedirectToAction("UserCalendar" , "Calendar", new { id = userId });
                case "RequestsToCoaches":
                    return RedirectToAction("All", "MyRequests");
                case "TrainingPlanDetails":
                    return RedirectToAction("AllUsersWorkouts", "Workout",new { id = userId });
                default:
                    return RedirectToAction("AllRejectedTrainingPlan", "TrainingPlan");
            }
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
