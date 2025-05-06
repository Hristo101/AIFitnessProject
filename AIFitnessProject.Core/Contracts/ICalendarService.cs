using AIFitnessProject.Core.DTOs.Calendar;
using AIFitnessProject.Core.Models.Calendar;
using AIFitnessProject.Infrastructure.Data.Models;

namespace AIFitnessProject.Core.Contracts
{
    public interface ICalendarService
    {
        Task<UserCalendarViewModel> GetModeForUserCalendar(string userId, string trainerId);
        Task<UserCalendarViewModelForUserArea> GetModelForUserCalendarForUserArea(string userId);
        Task<UserCalendarViewModelForDietitianArea> GetModelForUserCalendarInDietitianArea(string userId);
        Task<int> AddCalendarEventAsync(AddEventViewModel model,string trainerId);
        Task<int> AddCalendarMealEventAsync(AddEventFromDietitianViewModel model,string dietitianId);
        Task DeleteEvent(int eventId);
        Task DeleteMealEvenet(int eventId);
        Task<TrainingPlan> GetTrainingPlanByTrainerId(string trainerId);
        Task DeleteEvenetAndSendNotification(int eventId,TimeOnly time, string userId);
        Task DeleteMealEvenetAndSendNotification(int eventId, TimeOnly time, string userId);
        Task<DetailsEventViewModel> GetModelForDetailsEvent(int id);
        Task<DetailsMealViewModel> GetModelForDetailsMeal(int id);
        Task<bool> IsClientOfDietitian(string id, string dietitianId);

    }
}
