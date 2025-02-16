using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class MealService : IMealService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository repository;

        public MealService(IHostingEnvironment hostingEnvironment, IRepository _repository)
        {
            _hostingEnvironment = hostingEnvironment;
            this.repository = _repository;
        }

        public async Task AddMeal(CreateMealViewModel model, string userId)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                 .Where(x => x.UserId == userId)
                  .FirstAsync();

            var meal = new Meal()
            {
                CreatedById = dietitian.Id,
                Recipe = model.Recipe,
                DificultyLevel = model.DificultyLevel,
                MealTime = model.MealTime,
                Name = model.Name,
                Calories = model.Calories,
                VideoUrl = model.VideoUrl,
            };

            if (model.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/meal");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageUrl.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageUrl.CopyToAsync(fileStream);
                }
                meal.ImageUrl = "/img/meal/" + uniqueFileName;
            }
            await repository.AddAsync(meal);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditMealViewModel model)
        {
            var meal = await repository.All<Meal>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (meal != null)
            { 
                meal.Name = model.Name;
                meal.DificultyLevel= model.DificultyLevel;
                meal.Calories = model.Calories;
                meal.MealTime = model.MealTime;
                meal.VideoUrl = model.VideoUrl;
                meal.Recipe = model.Recipe;

                if (model.NewImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/meals");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.NewImage.CopyToAsync(fileStream);
                    }
                    meal.ImageUrl = "/img/meals/" + uniqueFileName;
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Meal>()
               .AnyAsync(x => x.Id == id);
        }

        public async Task<Meal> GetMealById(int id)
        {
            var meal = await repository.All<Meal>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return meal;
        }

        public async Task<MealViewModel> GetModelForDetails(int id)
        {
            var mealDailyDietPlan = await repository.AllAsReadOnly<MealsDailyDietPlan>()
                .Where(x => x.MealId == id)
                .Include(x => x.DailyDietPlans)
                .ThenInclude(x => x.DietDailyDietPlans)
                .FirstOrDefaultAsync();
            
            if(mealDailyDietPlan == null)
            {
                return null;
            }

            var dietId = mealDailyDietPlan.DailyDietPlans.DietDailyDietPlans
                .Select(x=>x.DietId)
                .FirstOrDefault();


            var meal = await repository.AllAsReadOnly<Meal>()
                 .Where(x => x.Id == id)
                 .Select(x => new MealViewModel()
                 {
                     Id = x.Id,
                     DificultyLevel = x.DificultyLevel,
                     Calories = x.Calories,
                     ImageUrl = x.ImageUrl,
                     MealTime = x.MealTime,
                     Name = x.Name,
                     Recipe = x.Recipe,
                     VideoUrl = x.VideoUrl,
                     DietId = dietId,
                    
                 }).FirstAsync();

            return meal;
        }

        public async Task<EditMealViewModel> GetModelForEdit(int id)
        {
            var meal = await repository.AllAsReadOnly<Meal>()
                .Where(x => x.Id == id)
                .Select(x => new EditMealViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DificultyLevel = x.DificultyLevel,
                    Calories= x.Calories,
                    MealTime= x.MealTime,
                    Recipe= x.Recipe,
                    VideoUrl= x.VideoUrl,
                    ExistingImageUrl = x.ImageUrl
                })
                .FirstAsync();

            return meal;
        }
    }
}
