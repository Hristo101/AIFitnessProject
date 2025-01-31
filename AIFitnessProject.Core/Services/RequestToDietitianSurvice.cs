using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestToDietitian;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class RequestToDietitianSurvice : IRequestToDietitianSurvice
    {
        private readonly IRepository repository;

        public RequestToDietitianSurvice(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task Add(string id, int dietitianId, SurveyViewModel model)
        {
            var picturesList = new List<string>();

            if (model.ProfilePictures != null && model.ProfilePictures.Length > 0)
            {
                foreach (var file in model.ProfilePictures)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                            picturesList.Add(base64Image);
                        }
                    }
                }
            }
            RequestToDietitian requestsToDietitian = new RequestToDietitian()
            {
                
                Target = model.Target,
                UserId = id,
                DietitianId = dietitianId,
                UserPictures = picturesList,
                DietBackground = model.DietBackground,
                HealthIssues = model.HealthIssues,
                FoodAllergies = model.FoodAllergies,
                FavouriteFoods = model.FavouriteFoods,
                MealPreparationPreference = model.MealPreparationPreference,
                PreferredMealsPerDay = model.PreferredMealsPerDay,
                DislikedFoods = model.DislikedFoods,
                SupplementsUsed = model.SupplementsUsed,
                IsAnswered = false
               
            };

            var user = await repository.All<ApplicationUser>()
                .Where(x => x.Id == id)
                .FirstAsync();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Weight = model.Weight;
            user.Height = model.Height;
            user.ExperienceLevel = model.ExperienceLevel;

            await repository.AddAsync(requestsToDietitian);
            await repository.SaveChangesAsync();

        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<RequestToDietitian>()
               .AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AllSurveyViewModel>> GetAllAsync(string Id)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Where(x=>x.UserId == Id)
                .FirstAsync();


            var models = await repository.AllAsReadOnly<RequestToDietitian>()
              .Where(x => x.DietitianId == dietitian.Id && x.IsAnswered == false)
              .Include(x => x.User)
              .Select(x => new AllSurveyViewModel()
              {
                  Id = x.Id,
                  ExperienceLevel = x.User.ExperienceLevel,
                  FirstName = x.User.FirstName,
                  LastName = x.User.LastName,
                  ProfilePicture = x.User.ProfilePicture,
                  Target = x.Target,
                  DietBackground = x.DietBackground,
              })
              .ToListAsync();


            return models;
        }

        public async Task<DetailsSurveyModel> GetViewModelForDetailsAsync(int id)
        {
            var model = await repository.AllAsReadOnly<RequestToDietitian>()
                .Where(x => x.Id == id)
                .Include(x => x.User)
                .Select(x => new DetailsSurveyModel()
                {
                    Email = x.User.Email,
                    ProfilePicture = x.User.ProfilePicture,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    HealthIssues = x.HealthIssues,
                    Target = x.Target,
                    DietBackground = x.DietBackground,
                    MealPreparationPreference = x.MealPreparationPreference,
                    PreferredMealsPerDay = x.PreferredMealsPerDay,
                    UserPictures = x.UserPictures,
                    SupplementsUsed = x.SupplementsUsed,
                    DislikedFoods = x.DislikedFoods,
                    FavouriteFoods = x.FavouriteFoods,
                    FoodAllergies = x.FoodAllergies,
                    ExperienceLevel = x.User.ExperienceLevel
                })
                .FirstAsync();

            return model;
        }
    }
}
