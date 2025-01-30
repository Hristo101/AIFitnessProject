using AIFitnessProject.Core.Models.RequestToDietitian;

namespace AIFitnessProject.Core.Contracts
{
    public interface IRequestToDietitianSurvice
    {
        Task Add(string id, int dietitianId, SurveyViewModel model);
    }
}
