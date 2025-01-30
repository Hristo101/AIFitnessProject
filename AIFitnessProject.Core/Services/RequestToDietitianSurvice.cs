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
    }
}
