using AIFitnessProject.Core.Contracts;
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
            await calendarService.DeleteEvenet(eventId);

            return RedirectToAction("UsersCalendar", new { id = GetUserId() });
        }
        [HttpPost]
        public async Task<IActionResult> MarkMealCompleted(int eventId)
        {
            await calendarService.DeleteMealEvenet(eventId);

            return RedirectToAction("UsersCalendar", new { id = GetUserId() });
        }
        [HttpGet]
        public async Task<IActionResult> UsersCalendar(string Id)
        {
            var model = await calendarService.GetModelForUserCalendarForUserArea(Id);

            return View(model);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
