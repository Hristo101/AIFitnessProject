using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using Microsoft.AspNetCore.Mvc;
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
            var model = await calendarService.GetModeForUserCalendar(id,GetUserId());

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

                var eventId = await calendarService.AddCalendarEventAsync(model,GetUserId());

                return Json(new { success = true, message = "Event added successfully", eventId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int eventId, string userId)
        {
            await calendarService.DeleteEvent(eventId);

            return RedirectToAction("UserCalendar", new { id = userId });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
