using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Exercise;
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

        public async Task<MealViewModel> GetModelForDetails(int id)
        {
            var meal = await repository.AllAsReadOnly<Meal>()
                 .Where(x => x.Id == id)
                 .Include(x => x.MealsDailyDietPlans)
                 .ThenInclude(x => x.DailyDietPlans)
                 .ThenInclude(x => x.Diet)
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
                     DietId = x.MealsDailyDietPlans.Where(x => x.MealId == id).FirstOrDefault().DailyDietPlans.Diet.Id,
                    
                 }).FirstAsync();

            return meal;
        }
    }
}
