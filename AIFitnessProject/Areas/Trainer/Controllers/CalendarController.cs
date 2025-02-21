using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
    }
}
