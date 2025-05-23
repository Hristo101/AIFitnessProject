﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.RequestToDietitian;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;


namespace AIFitnessProject.Core.Services
{
    public class RequestToDietitianSurvice : IRequestToDietitianSurvice
    {
        private readonly IRepository repository;
        private readonly INotificationService service;
        private readonly IConfiguration _configuration;
        public RequestToDietitianSurvice(IRepository _repository, INotificationService _service, IConfiguration configuration)
        {
            repository = _repository;
            service = _service;
            _configuration = configuration;
        }

        public async Task Add(string id, int dietitianId, SurveyViewModel model)
        {
            var picturesList = new List<string>();

            var dietitian = await repository.AllAsReadOnly<Dietitian>()
              .Include(x=>x.User)
              .Where(x => x.Id == dietitianId)
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
                Date = DateTime.Now,
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

            string message = $"Потебител с име {user.FirstName} {user.LastName} с цел \"{user.Aim}\" успешно се записа при вас!";

            await service.AddNotification(user.Id, dietitian.UserId, message, "RequestToDietitian");

            await SendEmailAsync(dietitian.User.Email, "Успешно записан потребител ✔", message);
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
                  UserId = x.User.Id,
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
                    Id =x.Id,
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
                    ExperienceLevel = x.User.ExperienceLevel,
                    UserId = x.User.Id
                })
                .FirstAsync();

            return model;
        }

        public async Task<bool> IsMineAsync(int id, string dietitianId)
        {
          var request = await repository.All<RequestToDietitian>()
                .Where(x=>x.Id == id)
                .FirstAsync();

            var dietitian = await repository.All<Dietitian>()
                .Where(x=>x.UserId == dietitianId)
                .FirstOrDefaultAsync();

            if(request.DietitianId != dietitian.Id)
            {
                return false;
            }

            return true;
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
