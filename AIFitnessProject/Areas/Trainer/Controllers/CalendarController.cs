using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Trainer.Controllers
{
    public class CalendarController : TrainerBaseController
    {
        private readonly ICalendarService calendarService;

        public CalendarController(ICalendarService _calendarService)
        {
            this.calendarService = _calendarService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UserCalendar(string id)
        {
            var model = await calendarService.GetModeForUserCalendar(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] AddEventViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Invalid data provided" });
                }

                var success = await calendarService.AddCalendarEventAsync(model);

                if (success)
                {
                    return Json(new { success = true, message = "Event added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to add event" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int calendarId,int workoutId,string userId)
        {
            await calendarService.DeleteEvenet(workoutId, calendarId);

            return RedirectToAction("UserCalendar", new { id = userId });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
