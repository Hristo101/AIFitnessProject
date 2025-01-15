using AIFitnessProject.Core.Models.Dietitian;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDietitianService
    {
        Task<IEnumerable<AllDietitianViewModel>> AllDietitianAsync();
    }
}
