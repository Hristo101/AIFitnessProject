using AIFitnessProject.Core.Models.Dietitian;

namespace AIFitnessProject.Core.Contracts
{
    public interface IDietitianService
    {
        Task<IEnumerable<AllDietitianViewModel>> AllDietitianAsync();

        Task<bool> ExistAsync(int id);
        Task<DetailsDietitianForUserViewModel> GetDetailsDietitianViewModelForUser(int dietitianId, string userId);
        Task<DetailsDietitianViewModel> DetailsDietitianAsync(int id);
    }
}
