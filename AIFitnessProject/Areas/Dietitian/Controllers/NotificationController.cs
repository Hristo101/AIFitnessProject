using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class NotificationController : DietitianBaseController
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService _notificationService)
        {
            this.notificationService = _notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await notificationService.GetAllNotificationsForDietitian(GetUserId());

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
                    return RedirectToAction("UserCalendar", "Calendar", new { id = userId });
                case "RequestToDietitian":
                    return RedirectToAction("All", "MyRequest");
                case "TrainingPlanDetails":
                    return RedirectToAction("AllUsersWorkouts", "Workout", new { id = userId });
                case "Comments":
                    return RedirectToAction("DashBoard", "Account");
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
        [HttpPost]
        public async Task<IActionResult> ChangeNotificationStatus(int id)
        {
            await notificationService.MarkNotificationRead(id);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await notificationService.DeleteNotification(id);
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
