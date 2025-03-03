using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;

namespace AIFitnessProject.Core.Contracts
{
    public interface ICalendarService
    {
        Task<UserCalendarViewModel> GetModeForUserCalendar(string userId, string trainerId);
        Task<UserCalendarViewModelForUserArea> GetModelForUserCalendarForUserArea(string userId);
        Task<UserCalendarViewModelForDietitianArea> GetModelForUserCalendarInDietitianArea(string userId);
        Task<int> AddCalendarEventAsync(AddEventViewModel model);
        Task<int> AddCalendarMealEventAsync(AddEventFromDietitianViewModel model);
        Task DeleteEvenet(int eventId);
        Task DeleteMealEvenet(int eventId);
        Task<DetailsEventViewModel> GetModelForDetailsEvent(int id);
        Task<DetailsMealViewModel> GetModelForDetailsMeal(int id);

    }
}
