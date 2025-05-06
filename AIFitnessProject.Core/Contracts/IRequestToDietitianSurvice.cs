using AIFitnessProject.Core.Models.RequestToDietitian;

namespace AIFitnessProject.Core.Contracts
{
    public interface IRequestToDietitianSurvice
    {
        Task Add(string id, int dietitianId, SurveyViewModel model);
        Task<bool> ExistAsync(int id);
        Task<IEnumerable<AllSurveyViewModel>> GetAllAsync(string Id);
        Task<DetailsSurveyModel> GetViewModelForDetailsAsync(int id);
        Task<bool> IsMineAsync(int id,string dietitianId);
    }
}
