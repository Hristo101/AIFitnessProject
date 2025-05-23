﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.Calendar;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            string dietitianId = GetUserId();
            if (await calendarService.IsClientOfDietitian(id, dietitianId) == false)
            {
                return Unauthorized();
            }

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

                var eventId = await calendarService.AddCalendarMealEventAsync(model,GetUserId());

                return Json(new { success = true, message = "Event added successfully", eventId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int eventId,string userId)
        {
            string dietitianId = GetUserId();

            if (await calendarService.IsClientOfDietitian(userId, dietitianId) == false)
            {
                return Unauthorized();
            }

            await calendarService.DeleteMealEvenet(eventId);
            return RedirectToAction("UserCalendar", new { id = userId });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
