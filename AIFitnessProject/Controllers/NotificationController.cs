﻿using AIFitnessProject.Core.Contracts;
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
            await notificationService.MarkNotificationRead(notificationId);

            var notification = await notificationService.GetNotificationById(notificationId);

            switch (notification.Source)
            {
                case "Calendar":
                    return RedirectToAction("UsersCalendar", "Calendar", new { id = GetUserId() });
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
