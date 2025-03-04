using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.DTOs.MealFeedback;
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

        public async Task AddMeal(CreateMealViewModelFromEditDailyDietPlan model, string userId)
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

        public async Task<MealViewModel> DetailsMealFromCalendar(int id)
        {
            var model = await repository.AllAsReadOnly<Meal>()
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


          })
          .FirstOrDefaultAsync();

            return model;

        }

        public async Task EditAsync(int id, EditMealViewModel model)
        {
            var meal = await repository.All<Meal>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (meal != null)
            {
                meal.Name = model.Name;
                meal.DificultyLevel = model.DificultyLevel;
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

        public async Task EditAsyncFromDailyDietPlan(int id, EditMealFromDailyDietPlanViewModel model)
        {
            var meal = await repository.All<Meal>()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

            if (meal != null)
            {
                meal.Name = model.Name;
                meal.DificultyLevel = model.DificultyLevel;
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

        public async Task<MealViewModel> GetModelForDetails(int id,int dietId)
        {
            var mealDailyDietPlan = await repository.AllAsReadOnly<MealsDailyDietPlan>()
                .Where(x => x.MealId == id)
                .Include(x => x.DailyDietPlans)
                .ThenInclude(x => x.DietDailyDietPlans)
                .FirstOrDefaultAsync();

            if (mealDailyDietPlan == null)
            {
                return null;
            }

            var dietDailyDietPlan = mealDailyDietPlan.DailyDietPlans.DietDailyDietPlans
              .Where(x=>x.DietId == dietId)
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
                     DietId = dietDailyDietPlan.DietId,

                 }).FirstAsync();

            return meal;
        }

        public async Task<MealViewModel> GetModelForDetailsForUser(int id, string userId)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .FirstAsync();



            var mealDailyDietPlan = await repository.AllAsReadOnly<MealsDailyDietPlan>()
                .Where(x => x.MealId == id)
                .Include(x => x.DailyDietPlans)
                    .ThenInclude(w => w.DietDailyDietPlans)
                    .ThenInclude(w => w.Diet)
                .FirstOrDefaultAsync();

            if (mealDailyDietPlan == null)
            {
                return null;
            }


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
                     DietId = diet.Id,

                 }).FirstOrDefaultAsync();

            return meal;
        }

        public async Task<MealDetailViewModel> GetModelForDetailsFromDailyDietPlan(int id, int dailyDietPlanId)
        {
            var mealsDailyDietPlan = await repository.AllAsReadOnly<MealsDailyDietPlan>()
               .Where(x => x.MealId == id && x.DailyDietPlansId == dailyDietPlanId)
               .Include(x => x.DailyDietPlans)
                   .ThenInclude(w => w.DietDailyDietPlans)
                       .ThenInclude(tpw => tpw.Diet)
               .FirstOrDefaultAsync();

            if (mealsDailyDietPlan == null)
            {
                return null;
            }

            var meal = await repository.AllAsReadOnly<Meal>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (meal == null)
            {
                return null;
            }

            var viewModel = new MealDetailViewModel()
            {
                Id = meal.Id,
                DificultyLevel = meal.DificultyLevel,
                Calories = meal.Calories,
                ImageUrl = meal.ImageUrl,
                MealTime = meal.MealTime,
                Name = meal.Name,
                Recipe = meal.Recipe,
                VideoUrl = meal.VideoUrl,
                DailyDietPlanId = mealsDailyDietPlan.DailyDietPlansId,

            };

            return viewModel;
        }

        public async Task<EditMealViewModel> GetModelForEdit(int id, int dietId)
        {
            var meal = await repository.AllAsReadOnly<Meal>()
                .Where(x => x.Id == id)
                .Select(x => new EditMealViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DificultyLevel = x.DificultyLevel,
                    Calories = x.Calories,
                    MealTime = x.MealTime,
                    Recipe = x.Recipe,
                    VideoUrl = x.VideoUrl,
                    ExistingImageUrl = x.ImageUrl,
                    DietId = dietId,
                    
                })
                .FirstAsync();

            return meal;
        }

        public async Task<EditMealFromDailyDietPlanViewModel> GetModelFromDailyDiePlanForEdit(int id, int dailyDietPlanId)
        {
        
            var meal = await repository.AllAsReadOnly<Meal>()
                .Where(x => x.Id == id)
                .Include(x => x.MealsDailyDietPlans)
                .ThenInclude(x => x.DailyDietPlans)
                .Select(x => new EditMealFromDailyDietPlanViewModel()
                {
                    Id = x.Id,
                    DailyDietPlanId = dailyDietPlanId,
                    Name = x.Name,
                    DificultyLevel = x.DificultyLevel,
                    Calories = x.Calories,
                    MealTime = x.MealTime,
                    Recipe = x.Recipe,
                    VideoUrl = x.VideoUrl,
                    ExistingImageUrl = x.ImageUrl,
                  
                    
                    
                })
                .FirstAsync();

            return meal;
        }

        public async Task<bool> SwapMealInDailyDietPlan(SwapMealRequest request)
        {
            var diet = await repository.All<Diet>()
                 .Include(tp => tp.DietDailyDietPlans)
                     .ThenInclude(tpw => tpw.DailyDietPlan)
                         .ThenInclude(w => w.MealsDailyDietPlans)
                             .ThenInclude(we => we.Meal)
                                 .ThenInclude(e => e.MealFeedbacks)
                 .FirstOrDefaultAsync(tp => tp.Id == request.DietId);

            if (diet == null)
            {
                return false;
            }

            var mealDailyDietPlan = diet.DietDailyDietPlans
                .Where(tpw => tpw.DailyDietPlan.MealsDailyDietPlans
                    .Any(we => we.Meal.Id == request.MealId && we.DailyDietPlans.Id == request.DailyDietPlanId))
                .FirstOrDefault();


            if (mealDailyDietPlan == null)
            {
                return false;
            }

            var newMeal = await repository.GetByIdAsync<Meal>(request.NewMealId);
            if (newMeal == null)
            {
                return false;
            }

         
            var exerciseToReplace = mealDailyDietPlan.DailyDietPlan.MealsDailyDietPlans
                .FirstOrDefault(we => we.Meal.Id == request.MealId && we.DailyDietPlansId == request.DailyDietPlanId);

            if (exerciseToReplace != null)
            {
                exerciseToReplace.MealId = newMeal.Id;
                exerciseToReplace.Meal = newMeal;

                var x = diet.DietDailyDietPlans
                .Where(tpw => tpw.DailyDietPlan.MealsDailyDietPlans
                .Any(we => we.Meal.Id == request.MealId)).ToList();

                if (x.Count == 0)
                {
                    var mealFeedback = await repository.All<MealFeedback>
                      ().Where(x => x.DietId == request.DietId).ToListAsync();

                    var feedbackToDelete = mealFeedback.Where(x => x.MealId == request.MealId).FirstOrDefault();
                    if (feedbackToDelete != null)
                    {
                        repository.Delete(feedbackToDelete);
                    }
                }




            }
 

            var changes = await repository.SaveChangesAsync();
            return changes > 0;
        }
    }
}
