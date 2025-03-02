using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;

namespace AIFitnessProject.Core.Contracts
{
    public interface ICalendarService
    {
        Task<UserCalendarViewModel> GetModeForUserCalendar(string userId);
        Task<UserCalendarViewModelForUserArea> GetModelForUserCalendarForUserArea(string userId);
        Task<UserCalendarViewModelForDietitianArea> GetModelForUserCalendarInDietitianArea(string userId);
        Task<bool> AddCalendarEventAsync(AddEventViewModel model);
        Task<bool> AddCalendarMealEventAsync(AddEventFromDietitianViewModel model);
        Task DeleteEvenet(int workoutId, int calendarId);
        Task DeleteMealEvenet(int mealId, int calendarId);
        Task<DetailsEventViewModel> GetModelForDetailsEvent(int id);

    }
}
