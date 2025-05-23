﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class CalendarController : Controller
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
        public async Task<IActionResult> DetailsEvent(int id)
        {
            var model = await calendarService.GetModelForDetailsEvent(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsMeal(int id)
        {
            var model = await calendarService.GetModelForDetailsMeal(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MarkEventCompleted(int eventId)
        {
            var time = TimeOnly.FromDateTime(DateTime.Now);
            await calendarService.DeleteEvenetAndSendNotification(eventId,time,GetUserId());

            return RedirectToAction("UsersCalendar", new { id = GetUserId() });
        }
        [HttpPost]
        public async Task<IActionResult> MarkMealCompleted(int eventId)
        {
            var time = TimeOnly.FromDateTime(DateTime.Now);
            await calendarService.DeleteMealEvenetAndSendNotification(eventId,time,GetUserId());

            return RedirectToAction("UsersCalendar", new { id = GetUserId() });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UsersCalendar(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("User ID is required.");
            }

            

            var model = await calendarService.GetModelForUserCalendarForUserArea(GetUserId());
            if (model == null)
            {
                return NotFound("Calendar data not found.");
            }

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
