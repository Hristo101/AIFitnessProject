using AIFitnessProject.Core.Models.Home;
using AIFitnessProject.Core.Models.Opinion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetModelsForHomePageAsync();
        Task<IEnumerable<AllOpinionViewModel>> GetModelsForHowWeWorkPageAsync();
        Task<IEnumerable<AllDietitianOpinionViewModel>> AllDietitianOpinionAsync();
    }
}
