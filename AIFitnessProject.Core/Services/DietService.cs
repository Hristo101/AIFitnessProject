using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Diet;
using AIFitnessProject.Core.Models.TrainingPlan;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class DietService : IDietService
    {
        private readonly IRepository repository;

        public DietService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task CreateDiet(string id, string dietitianId, CreateDietViewModel model)
        {
            var dietitian = await repository.All<Dietitian>().Where(x => x.UserId == dietitianId).FirstAsync();
            Diet diet = new Diet()
            {
                Description = model.DietDescription,
                Name = model.DietName,
                CreatedById = dietitian.Id,
                UserId = id,
                IsActive = false,
            };

            if (model.ImageUrl != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageUrl.CopyToAsync(memoryStream);
                    string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                    diet.ImageUrl = base64Image;
                }
            }

            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();
        }

        public async Task<ICollection<AllDietViewModel>> GetAllDietsAsync(string userId)
        {
            var dietitian = await repository.All<Dietitian>().Where(x => x.UserId == userId).FirstAsync();

            var models = await repository.AllAsReadOnly<Diet>().Include(x => x.User)
                .Where(x => x.Dietitian.Id == dietitian.Id)
                .Where(x => x.IsActive == false)
                .Select(x => new AllDietViewModel()
                {
                    Id = x.Id,
                    DietDescription= x.Description,
                    ImageUrl = x.ImageUrl,
                    DietName = x.Name,
                })
                .ToListAsync();

            return models;
        }
    }
}
