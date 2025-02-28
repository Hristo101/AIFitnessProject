using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    public class CalendarController : DietitianBaseController
    {
        private readonly ICalendarService calendarService;

        public CalendarController(ICalendarService _calendarService)
        {
            this.calendarService = _calendarService;
        }


        [HttpGet]
        public async Task<IActionResult> UserCalendar(string id)
        {
            var model = await calendarService.GetModelForUserCalendarInDietitianArea(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] AddEventFromDietitianViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Invalid data provided" });
                }

                var success = await calendarService.AddCalendarMealEventAsync(model);

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

        public async Task<IActionResult> Delete(int calendarId, int workoutId)
        {
            return View();
        }
    }
}
