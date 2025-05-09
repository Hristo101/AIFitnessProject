using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    [Authorize]
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
            var model = await notificationService.GetAllNotificationsForUser(GetUserId());

            return View(model);
        }
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
        [HttpGet]
        public async Task<IActionResult> View(string userId, int notificationId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required.");
            }

            if (notificationId <= 0)
            {
                return BadRequest("Invalid notification ID.");
            }

            var currentUserId = GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var notification = await notificationService.GetNotificationById(notificationId);
            if (notification == null || notification.RecieverId != currentUserId)
            {
                return NotFound("Notification not found or you do not have access.");
            }

           
            await notificationService.MarkNotificationRead(notificationId);

       
            switch (notification.Source)
            {
                case "Calendar":
                    return RedirectToAction("UsersCalendar", "Calendar", new { id = userId });
                case "Diet":
                    return RedirectToAction("MyDiet", "UserDiet", new { id = userId });
                default:
                    return RedirectToAction("AllMyTrainingPlans", "UserTrainingPlan");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeNotificationStatus(int id)
        {
            await notificationService.MarkNotificationRead(id);
            return Json(new { success = true });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
