using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestsToCoach;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace AIFitnessProject.Core.Services
{
    public class RequestsToCoachService : IRequestsToCoach
    {
        private readonly IRepository repository;
        private readonly INotificationService service;
        private readonly IConfiguration _configuration;
        public RequestsToCoachService(IRepository _repository, INotificationService _service, IConfiguration configuration)
        {
            repository = _repository;
            this.service = _service;
            _configuration = configuration;
        }

        public async Task<bool> Add(string id, int trainerId, SurveyViewModel model)
        {
            var picturesList = new List<string>();

            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x => x.Id == trainerId)
                .Include(x=>x.User)
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

            await SendEmailAsync(trainer.User.Email, "Успешно записан потребител ✔", message);
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
        private async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            try
            {

                string smtpHost = _configuration["Smtp:Host"];
                int smtpPort = int.Parse(_configuration["Smtp:Port"]);
                string senderEmail = _configuration["Smtp:SenderEmail"];
                string senderPassword = _configuration["Smtp:SenderPassword"];
                string senderName = _configuration["Smtp:SenderName"];

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, senderName);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;


                using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);


                    await smtpClient.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при изпращане на имейл: {ex.Message}");
                throw;
            }
        }
    }
}
