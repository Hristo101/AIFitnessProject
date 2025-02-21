using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> UsersCalendar(string Id)
        {
            var model = await calendarService.GetModeForUserCalendar(Id);

            return View(model);
        }
    }
}
