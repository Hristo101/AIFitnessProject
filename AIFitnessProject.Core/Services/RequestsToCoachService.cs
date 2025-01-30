using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestsToCoach;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class RequestsToCoachService : IRequestsToCoach
    {
        private readonly IRepository repository;

        public RequestsToCoachService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> Add(string id, int trainerId, SurveyViewModel model)
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
            RequestsToCoach requestsToCoach = new RequestsToCoach()
            {
                TrainerId = trainerId,
                UserId = id,
                HealthStatus = model.HealthStatus,
                PicturesOfPersons = picturesList,
                TrainingBackground = model.TrainingBackground,
                TrainingCommitment = model.TrainingCommitment,
                TrainingPreferences = model.TrainingPreferences,
                Target = model.Target,
                IsAnswered = false,
            };

            var user = await repository.All<ApplicationUser>()
                .Where(x => x.Id == id)
                .FirstAsync();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Weight = model.Weight;
            user.Height = model.Height;

            await repository.AddAsync(requestsToCoach);
            await repository.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<RequestsToCoach>()
               .AnyAsync(x => x.TrainerId == id);
        }

        public async Task<IEnumerable<AllSurveyViewModel>> GetAllAsync(string Id)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x =>x.UserId == Id)
                .FirstAsync();

            var models = await repository.AllAsReadOnly<RequestsToCoach>()
                .Where(x => x.TrainerId == trainer.Id)
                .Where(x => x.IsAnswered == false)
                .Include(x =>x.User)
                .Select(x => new AllSurveyViewModel() 
                {
                    Id = x.Id,
                    ExperienceLevel = x.TrainingBackground,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ProfilePicture = x.User.ProfilePicture,
                    TargetOfTraining = x.Target,
                })
                .ToListAsync();

            return models;
        }

        public async Task<DetailsSurveyModel> GetViewModelForDetailsAsync(int id)
        {
           var model = await repository.AllAsReadOnly<RequestsToCoach>()
                .Where(x => x.Id == id)
                .Include(x => x.User)
                .Select(x => new DetailsSurveyModel()
                {
                    Email = x.User.Email,
                    ProfilePicture = x.User.ProfilePicture,
                    FirstName= x.User.FirstName,
                    LastName= x.User.LastName,
                    HealthStatus = x.HealthStatus,
                    Target = x.Target,
                    TrainingBackground = x.TrainingBackground,
                    TrainingCommitment = x.TrainingCommitment,
                    TrainingPreferences = x.TrainingPreferences,
                    PictureOfPersons = x.PicturesOfPersons
                })
                .FirstAsync();

            return model;
        }
    }
}
