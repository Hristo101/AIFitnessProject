using AIFitnessProject.Core.Models.RequestsToCoach;

namespace AIFitnessProject.Core.Contracts
{
    public interface IRequestsToCoach
    {
        Task<bool> Add(string id, int trainerId, SurveyViewModel model);
         Task<bool> ExistAsync(int id);
        Task<IEnumerable<AllSurveyViewModel>> GetAllAsync(string Id);

        Task<DetailsSurveyModel> GetViewModelForDetailsAsync(int id);
    }
}
