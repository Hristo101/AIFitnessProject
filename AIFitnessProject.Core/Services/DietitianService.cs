using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Dietitian;
using AIFitnessProject.Core.Models.Trainer;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class DietitianService : IDietitianService
    {
        private readonly IRepository repository;

        public DietitianService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AllDietitianViewModel>> AllDietitianAsync()
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Select(x => new AllDietitianViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Experience = x.Experience,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Specialization = x.Specialization,
                })
                .ToListAsync();

            return dietitian;


        }
    }
}
