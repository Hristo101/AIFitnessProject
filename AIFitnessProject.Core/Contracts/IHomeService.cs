using AIFitnessProject.Core.Models.Home;
using AIFitnessProject.Core.Models.Opinion;

namespace AIFitnessProject.Core.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetModelsForHomePageAsync();
        Task<IEnumerable<AllOpinionViewModel>> GetModelsForHowWeWorkPageAsync();
        Task<IEnumerable<AllDietitianOpinionViewModel>> AllDietitianOpinionAsync();
    }
}
