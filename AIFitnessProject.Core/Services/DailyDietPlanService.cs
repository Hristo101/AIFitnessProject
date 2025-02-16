using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class DailyDietPlanService : IDailyDietPlanService
    {
        private readonly IRepository repository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DailyDietPlanService(IRepository _repository, IHostingEnvironment hostingEnvironment)
        {
            repository = _repository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task AttachDailyDietPlan(string selectedIds, int dietId)
        {
            var ids = selectedIds.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < ids.Count; i++)
            {
                var dailyDietPlan = await repository
                .All<DailyDietPlan>()
                .Where(x => x.Id == ids[i])
                .FirstAsync();

                //dailyDietPlan.DietId = dietId;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<int> CreateDailyDietPlan(AddDailyDietPlanViewModel model, string userId)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
               .Where(x => x.UserId == userId)
               .FirstOrDefaultAsync();

            DailyDietPlan dailyDietPlan = new DailyDietPlan()
            {
                CreatorId = dietitian.Id,
                DayOfWeel = model.DayOfWeek,
                DificultyLevel = model.DificultyLevel,
                Title = model.Title,
                //DietId = null,
            };

            List<int> mealsIds = model.SelectedMealIds.Split(",").Select(int.Parse).ToList();

            if (model.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/DailyDietPlan");

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
                dailyDietPlan.ImageUrl = "/img/DailyDietPlan/" + uniqueFileName;
            }
            await repository.AddAsync<DailyDietPlan>(dailyDietPlan);
            await repository.SaveChangesAsync();

            for (int i = 0; i < mealsIds.Count; i++)
            {
                var meal = await repository.AllAsReadOnly<Meal>()
                    .Where(x => x.Id == mealsIds[i])
                    .FirstAsync();

                MealsDailyDietPlan mealDailyDietPlan = new MealsDailyDietPlan()
                {
                    MealId = meal.Id,
                    DailyDietPlansId = dailyDietPlan.Id,
                };
                await repository.AddAsync(mealDailyDietPlan);
                await repository.SaveChangesAsync();
            }
            return model.DietId;
        }

        public async Task EditAsync(int id, EditDailyDietPlanViewModel model)
        {
            var dailyDietPlan = await repository.All<DailyDietPlan>()
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();

            if (dailyDietPlan != null)
            {
                dailyDietPlan.Title = model.Title;
                dailyDietPlan.DificultyLevel = model.DificultyLevel;
                dailyDietPlan.DayOfWeel = model.DayOfWeek;
               

                if (model.NewImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/DailyDietPlan");

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
                    dailyDietPlan.ImageUrl = "/img/DailyDietPlan/" + uniqueFileName;
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<DailyDietPlan>()
              .AnyAsync(x => x.Id == id);
        }

        public async Task<ICollection<DailyDietPlanViewModel>> GetAllDailyDietPlans(string userId, int id)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x => x.UserId == userId)
                .FirstAsync();

            var model = await repository.AllAsReadOnly<DailyDietPlan>()
                 .Where(x => x.CreatorId == dietitian.Id)
                 .Select(x => new DailyDietPlanViewModel()
                 {
                     Id = x.Id,
                     Title = x.Title,
                     DayOfWeek = x.DayOfWeel,
                     DificultyLevel = x.DificultyLevel,
                     DietId = id,
                     ImageUrl = x.ImageUrl,
                     Meals = x.MealsDailyDietPlans.Select(mddp => new MealViewModel
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
                 })
                 .ToListAsync();

            return model;
        }

        public async Task<DailyDietPlan> GetDailyDietPlanById(int id)
        {
            var dailyDietPlan = await repository.All<DailyDietPlan>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return dailyDietPlan;
        }

        public async Task<AddDailyDietPlanViewModel> GetModelForAdd(int dietId)
        {
            var model = new AddDailyDietPlanViewModel();

            model.DietId = dietId;

            model.Meals = await repository.AllAsReadOnly<Meal>()
                .Select(x => new MealViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Recipe = x.Recipe,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    DificultyLevel = x.DificultyLevel,
                    Calories = x.Calories,
                    MealTime = x.MealTime,
                }).ToListAsync();

            return model;
        }

        public async Task<DailyDietPlanViewModel> GetModelForDetails(int id)
        {
            var model = await repository.AllAsReadOnly<DailyDietPlan>()
                .Where(x => x.Id == id)
                .Select(x => new DailyDietPlanViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DayOfWeek = x.DayOfWeel,
                    ImageUrl = x.ImageUrl,
                    DificultyLevel = x.DificultyLevel,
                    Meals = x.MealsDailyDietPlans.Select(mddp => new MealViewModel
                    {
                        Id = mddp.Meal.Id,
                        Name = mddp.Meal.Name,
                        Recipe = mddp.Meal.Recipe,
                        ImageUrl = mddp.Meal.ImageUrl,
                        VideoUrl = mddp.Meal.VideoUrl,
                        DificultyLevel = mddp.Meal.DificultyLevel,
                        Calories = mddp.Meal.Calories,
                        MealTime = mddp.Meal.MealTime
                    }).ToList()
                })
                .FirstAsync();

            return model;
        }

        public async Task<EditDailyDietPlanViewModel> GetModelForEdit(int id)
        {
            var dailyDietPlan = await repository.AllAsReadOnly<DailyDietPlan>()
               .Where(x => x.Id == id)
               .Select(x => new EditDailyDietPlanViewModel()
               {
                   Id = x.Id,
                   DificultyLevel = x.DificultyLevel,
                   ExistingImageUrl = x.ImageUrl,
                   DayOfWeek = x.DayOfWeel,
                   Title = x.Title,
               })
               .FirstAsync();

            return dailyDietPlan;
        }

        public async Task<ICollection<MealViewModel>> ReturnAllMealViewModel(string userId)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            var models = await repository.AllAsReadOnly<Meal>()
                 .Where(x => x.CreatedById == dietitian.Id)
                 .Select(m => new MealViewModel()
                 {
                     Id = m.Id,
                     Name = m.Name,
                     ImageUrl = m.ImageUrl,
                     VideoUrl = m.VideoUrl,
                     DificultyLevel = m.DificultyLevel,
                     Calories = m.Calories,
                     MealTime = m.MealTime,
                 })
                 .ToListAsync();

            return models;
        }
    }
}
