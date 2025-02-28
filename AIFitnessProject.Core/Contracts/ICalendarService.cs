using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface ICalendarService
    {
        Task<UserCalendarViewModel> GetModeForUserCalendar(string userId);
        Task<UserCalendarViewModelForDietitianArea> GetModelForUserCalendarInDietitianArea(string userId);
        Task<bool> AddCalendarEventAsync(AddEventViewModel model);
        Task<bool> AddCalendarMealEventAsync(AddEventFromDietitianViewModel model);

        Task DeleteEvenet(int workoutId, int calendarId);
        Task<bool> AddCalendarEventAsync(AddEventViewModel model);
        Task<DetailsEventViewModel> GetModelForDetailsEvent(int id);

    }
}
