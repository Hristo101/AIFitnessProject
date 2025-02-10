using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Diet;
using AIFitnessProject.Core.Models.Meal;
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

        public Task EditAsync(int id, EditMealViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Diet>()
               .AnyAsync(x => x.Id == id);
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

        public async Task<DietDetailsViewModel> GetDietModelsForDetails(int id)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
            .Include(tp => tp.DailyDietPlans)
                .ThenInclude(w => w.MealsDailyDietPlans)
                    .ThenInclude(we => we.Meal)
            .FirstOrDefaultAsync(tp => tp.Id == id);

            var viewModel = new DietDetailsViewModel
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                ImageUrl = diet.ImageUrl,
                DailyDietPlans = diet.DailyDietPlans.Select(dailyDietPlan => new DailyDietPlanViewModel
                {
                    Title = dailyDietPlan.Title,
                    DayOfWeek = dailyDietPlan.DayOfWeel,
                    DificultyLevel = dailyDietPlan.DificultyLevel,
                    ImageUrl = dailyDietPlan.ImageUrl,
                    Meals = dailyDietPlan.MealsDailyDietPlans.Select(mddp => new MealViewModel
                    {
                        Id = mddp.Id,
                        Name = mddp.Meal.Name,
                        Recipe = mddp.Meal.Recipe,
                        ImageUrl = mddp.Meal.ImageUrl,
                        VideoUrl = mddp.Meal.VideoUrl,
                        DificultyLevel = mddp.Meal.DificultyLevel,
                        Calories = mddp.Meal.Calories,
                        MealTime = mddp.Meal.MealTime,
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }

        public async Task<EditDietViewModel> GetModelForEdit(int id)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
               .Where(x => x.Id == id)
               .Select(x => new EditDietViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   ExistingImageUrl = x.ImageUrl,
                   Description = x.Description,
                   
               })
               .FirstAsync();

            return diet;
        }
    }
}
