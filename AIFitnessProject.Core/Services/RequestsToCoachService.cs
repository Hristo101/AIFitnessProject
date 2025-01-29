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
            var picturesList = new List<byte[]>();

            if (model.ProfilePictures != null && model.ProfilePictures.Length > 0)
            {
                foreach (var file in model.ProfilePictures)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            picturesList.Add(memoryStream.ToArray());
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

            await repository.AddAsync(requestsToCoach);
            await repository.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<RequestsToCoach>()
               .AnyAsync(x => x.TrainerId == id);
        }
    }
}
