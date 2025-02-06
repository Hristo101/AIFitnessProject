using AIFitnessProject.Core.Models.Diet;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDietService
    {
        Task CreateDiet(string id, string dietitianId, CreateDietViewModel model);
    }
}
