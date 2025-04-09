using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestsToCoach;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AIFitnessProject.Core.Services
{
    public class RequestsToCoachService : IRequestsToCoach
    {
        private readonly IRepository repository;
        private readonly INotificationService service;
        public RequestsToCoachService(IRepository _repository, INotificationService _service)
        {
            repository = _repository;
            this.service = _service;
        }

        public async Task<bool> Add(string id, int trainerId, SurveyViewModel model)
        {
            var picturesList = new List<string>();

            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x => x.Id == trainerId)
                .FirstOrDefaultAsync();

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
                Date = DateTime.Now,
                IsAnswered = false,
            };

            var user = await repository.All<ApplicationUser>()
                .Where(x => x.Id == id)
                .FirstAsync();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Weight = model.Weight;
            user.Height = model.Height;
            user.ExperienceLevel = model.ExpirienceLevel;

            await repository.AddAsync(requestsToCoach);
            await repository.SaveChangesAsync();

            string message = $"Потебител с име {user.FirstName} {user.LastName} с цел {user.Aim} успешно се записа при вас!";

            await service.AddNotification(user.Id,trainer.UserId,message, "RequestsToCoaches");
            
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
                    UserId = x.User.Id,
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
            var request = await repository.AllAsReadOnly<RequestsToCoach>()
                .Include(x => x.User)
                .FirstAsync(x => x.Id == id);

            var model = new DetailsSurveyModel
            {
                Id = request.Id,
                UserId = request.User.Id,
                Email = request.User.Email,
                ProfilePicture = request.User.ProfilePicture,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                HealthStatus = request.HealthStatus,
                Target = request.Target,
                TrainingBackground = request.TrainingBackground,
                TrainingCommitment = request.TrainingCommitment,
                TrainingPreferences = request.TrainingPreferences,
                PictureOfPersons = request.PicturesOfPersons
            };

            return model;
        }
    }
}
