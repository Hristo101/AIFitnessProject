using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.DailyDietPlan;
using AIFitnessProject.Core.Models.Diet;
using AIFitnessProject.Core.Models.Meal;
using AIFitnessProject.Core.Models.MealFeedback;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;




namespace AIFitnessProject.Core.Services
{
    public class DietService : IDietService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository repository;
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;

        public DietService(IHostingEnvironment hostingEnvironment, IRepository _repository, INotificationService notificationService, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            this.repository = _repository;
            _notificationService = notificationService;
            _configuration = configuration; 
        }

        public async Task AcceptDietAsync(int id, string userId)
        {
            var dietitian = await repository.All<Dietitian>()
                                          .Where(x => x.UserId == userId)
                                          .FirstOrDefaultAsync();

            var diet = await repository.All<Diet>()
                .Where(x => x.Id == id)
                .Where(x => x.UserId == userId)
                .Include(x => x.Dietitian)
                    .ThenInclude(x=>x.User)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            if (diet == null)
            {
                throw new ArgumentException("Diet not found or does not belong to the user.");
            }

            diet.IsInCalendar = true;
            await repository.SaveChangesAsync();

            var existingCalendar = await repository.All<Calendar>()
                .FirstOrDefaultAsync(c => c.UserId == userId);


            if (existingCalendar != null)
            {
                if (existingCalendar.TrainerId != null || existingCalendar.TrainerId != 0)
                {
                    existingCalendar.DietitianId = diet.CreatedById;
                    await repository.SaveChangesAsync();
                }
            }
            else
            {
                Calendar calendar = new Calendar
                {
                    DietitianId = diet.CreatedById,
                    UserId = diet.UserId
                };
                await repository.AddAsync(calendar);
                await repository.SaveChangesAsync();
            }
            string message = $"✔ Хранителен режим с име: {diet.Name} бе приет от {diet.User.FirstName} {diet.User.LastName}";
            await _notificationService.AddNotification(diet.UserId, diet.Dietitian.UserId, message, "DietDetails");

            await SendEmailAsync(diet.Dietitian.User.Email,"Хранителен режим приет ✔",message);
        }

        public async Task CreateDiet(string id, string dietitianId, CreateDietViewModel model, int requestId)
        {
            var dietitian = await repository.All<Dietitian>().Where(x => x.UserId == dietitianId).FirstAsync();
            Diet diet = new Diet()
            {
                Description = model.DietDescription,
                Name = model.DietName,
                CreatedById = dietitian.Id,
                UserId = id,
                IsActive = false,
            };

            if (model.ImageUrl != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageUrl.CopyToAsync(memoryStream);
                    string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                    diet.ImageUrl = base64Image;
                }
            }

            await repository.AddAsync(diet);
            await repository.SaveChangesAsync();

            var request = await repository.All<RequestToDietitian>()
                .Where(x=>x.Id == requestId)
                .FirstOrDefaultAsync();

            request.IsAnswered = true;
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditDietViewModel model)
        {


            var diet = await repository.All<Diet>()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

            if (diet != null)
            {
                diet.Name = model.Name;
                diet.Description = model.Description;

                if (model.NewImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/diet");

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
                    diet.ImageUrl = "/img/diet/" + uniqueFileName;
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Diet>()
               .AnyAsync(x => x.Id == id);
        }

        public async Task<ICollection<AllDietViewModel>> GetAllDietsAsync(string userId)
        {
            var dietitian = await repository.All<Dietitian>().Where(x => x.UserId == userId).FirstAsync();

            var models = await repository.AllAsReadOnly<Diet>().Include(x => x.User)
                .Where(x => x.Dietitian.Id == dietitian.Id)
                .Where(x => x.IsActive == false)
                .Select(x => new AllDietViewModel()
                {
                    Id = x.Id,
                    DietDescription = x.Description,
                    ImageUrl = x.ImageUrl,
                    DietName = x.Name,
                })
                .ToListAsync();

            return models;
        }

        public async Task<Diet> GetDietById(int id)
        {
            var diet = await repository.All<Diet>()
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();

            return diet;

        }

        public async Task<DietForUserViewModel?> GetDietForUserAsync(string userId)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
                .Where(x => x.UserId == userId && x.IsActive == true)
                .Where(x=>x.IsEdit == false)
                .Select(x => new DietForUserViewModel()
                {
                    DietDescription = x.Description,
                    DietName = x.Name,
                    ImageUrl = x.ImageUrl,
                    Id = x.Id

                })
                .FirstOrDefaultAsync();



            return diet;

        }

        public async Task<SendDietViewModel> GetDietModelForSendView(int id)
        {
            var countOfDailyDietPlan = await repository.AllAsReadOnly<DietDailyDietPlan>()
                .Where(x => x.DietId == id)
                .ToListAsync();

            var dietModel = await repository.AllAsReadOnly<Diet>()
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .Select(x => new SendDietViewModel()
                {
                    Id = id,
                    DescriptionDiet = x.Description,
                    ImageUrlDiet = x.ImageUrl,
                    UserProfilePicture = x.User.ProfilePicture,
                    Name = x.Name,
                    UserEmail = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    DailyDietPlanCount = countOfDailyDietPlan.Count(),
                }).FirstAsync();

            return dietModel;
        }

        public async Task<DietDetailsViewModel> GetDietModelForUserForDetails(int id, string userId)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
             .Include(x => x.DietDailyDietPlans)
                 .ThenInclude(x => x.DailyDietPlan)
                     .ThenInclude(x => x.MealsDailyDietPlans)
                         .ThenInclude(x => x.Meal)
                .Where(x => x.Id == id && x.UserId == userId)
                .FirstAsync();


            var viewModel = new DietDetailsViewModel
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                ImageUrl = diet.ImageUrl,
                IsInCalendar = diet.IsInCalendar,
                DailyDietPlans = diet.DietDailyDietPlans.Select(dailyDietPlan => new DailyDietPlanViewModel
                {
                    Id = dailyDietPlan.Id,
                    Title = dailyDietPlan.DailyDietPlan.Title,
                    DayOfWeek = dailyDietPlan.DailyDietPlan.DayOfWeel,
                    DificultyLevel = dailyDietPlan.DailyDietPlan.DificultyLevel,
                    ImageUrl = dailyDietPlan.DailyDietPlan.ImageUrl,
                    Meals = dailyDietPlan.DailyDietPlan.MealsDailyDietPlans.Select(mddp => new MealViewModel
                    {
                        Id = mddp.MealId,
                        Name = mddp.Meal.Name,
                        Recipe = mddp.Meal.Recipe,
                        ImageUrl = mddp.Meal.ImageUrl,
                        VideoUrl = mddp.Meal.VideoUrl,
                        DificultyLevel = mddp.Meal.DificultyLevel,
                        Calories = mddp.Meal.Calories,
                        MealTime = mddp.Meal.MealTime,
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }

        public async Task<DietDetailsViewModel> GetDietModelsForDetails(int id)
        {


            var diet = await repository.AllAsReadOnly<Diet>()
            .Include(tp => tp.DietDailyDietPlans)
                .ThenInclude(w => w.DailyDietPlan)
                    .ThenInclude(we => we.MealsDailyDietPlans)
                        .ThenInclude(x => x.Meal)
            .FirstOrDefaultAsync(tp => tp.Id == id);

            var viewModel = new DietDetailsViewModel
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                ImageUrl = diet.ImageUrl,
                DailyDietPlans = diet.DietDailyDietPlans.Select(dailyDietPlan => new DailyDietPlanViewModel
                {
                    Title = dailyDietPlan.DailyDietPlan.Title,
                    DayOfWeek = dailyDietPlan.DailyDietPlan.DayOfWeel,
                    DificultyLevel = dailyDietPlan.DailyDietPlan.DificultyLevel,
                    ImageUrl = dailyDietPlan.DailyDietPlan.ImageUrl,
                    Meals = dailyDietPlan.DailyDietPlan.MealsDailyDietPlans.Select(mddp => new MealViewModel
                    {
                        Id = mddp.MealId,
                        Name = mddp.Meal.Name,
                        Recipe = mddp.Meal.Recipe,
                        ImageUrl = mddp.Meal.ImageUrl,
                        VideoUrl = mddp.Meal.VideoUrl,
                        DificultyLevel = mddp.Meal.DificultyLevel,
                        Calories = mddp.Meal.Calories,
                        MealTime = mddp.Meal.MealTime,
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }

        public async Task<EditDietViewModel> GetModelForEdit(int id)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
               .Where(x => x.Id == id)
               .Select(x => new EditDietViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   ExistingImageUrl = x.ImageUrl,
                   Description = x.Description,

               })
               .FirstAsync();

            return diet;
        }

        public async Task<ICollection<RejectedDietViewModel>> GetModelsForAllRejectedDietAsync(string userId)
        {
            var dietitian = await repository.All<Dietitian>().Where(x => x.UserId == userId).FirstAsync();

            var models = await repository.AllAsReadOnly<Diet>()
                .Include(x => x.User)
                .Where(x => x.Dietitian.Id == dietitian.Id)
                .Where(x => x.IsActive == false)
                .Where(x=>x.IsEdit == true)
                .Include(x => x.User)
                .Select(x => new RejectedDietViewModel()
                {
                    DietId = x.Id,
                    DietDescription = x.Description,
                    Email = x.User.Email,
                    UserFirstName = x.User.FirstName,
                    UserLastName = x.User.LastName,
                    DietImageUrl = x.ImageUrl,
                    UserImageUrl = x.User.ProfilePicture,
                    DietTitle = x.Name
                })
                .ToListAsync();

            return models;
        }

        public async Task<RejectedDietDetails> GetRejectedDietAsync(int id, string userId)
        {

            var dietitian = await repository.All<Dietitian>()
                                           .Where(x => x.UserId == userId)
                                           .FirstOrDefaultAsync();

            var diet = await repository.AllAsReadOnly<Diet>()
                .Where(x => x.CreatedById == dietitian.Id)
                .Where(x => x.IsActive == false)
                .Include(tp => tp.DietDailyDietPlans)
                    .ThenInclude(tpw => tpw.DailyDietPlan)
                        .ThenInclude(w => w.MealsDailyDietPlans)
                            .ThenInclude(we => we.Meal)
                .Include(tp => tp.MealFeedbacks)
                    .ThenInclude(ef => ef.Meal)
                .Include(x => x.User)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            var viewModel = new RejectedDietDetails
            {
                Id = id,
                Name = diet.Name,
                FirstName = diet.User.FirstName,
                LastName = diet.User.LastName,
                UserEmail = diet.User.Email,
                UserProfilePicture = diet.User.ProfilePicture,
                Description = diet.Description,
                DailyDietPlans = diet.DietDailyDietPlans.Where(x => x.DietId == diet.Id).Select(tpw => new DailyDietPlanViewModelForRejectedDiet
                {
                    Id = tpw.DailyDietPlanId,
                    Title = tpw.DailyDietPlan.Title,
                    ImageUrl = tpw.DailyDietPlan.ImageUrl,
                    DayOfWeek = tpw.DailyDietPlan.DayOfWeel,
                    DifficultyLevel = tpw.DailyDietPlan.DificultyLevel,
                    Meals = tpw.DailyDietPlan.MealsDailyDietPlans.Select(we =>
                    {
                        var feedback = diet.MealFeedbacks
                                        .FirstOrDefault(ef => ef.MealId == we.MealId);

                        return new MealFeedbackViewModel
                        {
                            Id = we.MealId,
                            Name = we.Meal.Name,
                            Recipe = we.Meal.Recipe,
                            ImageUrl = we.Meal.ImageUrl,
                            MealTime = we.Meal.MealTime,
                            VideoUrl = we.Meal.VideoUrl,
                            Calories = we.Meal.Calories,
                            Feedback = feedback?.Feedback ?? string.Empty,
                        };
                    }).ToList()
                }).ToList()
            };

            var availableMeal = await repository.AllAsReadOnly<Meal>()
                .Select(e => new MealViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Recipe = e.Recipe,
                    ImageUrl = e.ImageUrl,
                    VideoUrl = e.VideoUrl,
                    MealTime = e.MealTime,
                    Calories = e.Calories,
                    DificultyLevel = e.DificultyLevel
                })
                .ToListAsync();

            viewModel.AvailableMeals = availableMeal;

            return viewModel;
        }

        public async Task SendEditDietAsync(int id, string userId)
        {
            var diet = await repository.All<Diet>()
                .Where(x => x.Id == id)
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.Dietitian)
                      .ThenInclude(x => x.User)
                .FirstAsync();

            diet.IsActive = false;
            diet.IsEdit = true;
            await repository.SaveChangesAsync();

            string message = $"✖ Хранителен режим с име: \"{diet.Name}\" бе отказан от {diet.User.FirstName} {diet.User.LastName}";
            await _notificationService.AddNotification(diet.UserId, diet.Dietitian.UserId, message, "RejectedDiet");

            await SendEmailAsync(
           diet.Dietitian.User.Email,
           "Хранителен режим отказан ✖",
           message);
        }

        public async Task SendToUserAsync(int id)
        {
            var diet = await repository.All<Diet>()
                .Where(x => x.Id == id)
                 .Include(x => x.User)
                .Include(x => x.Dietitian)
                .FirstAsync();

            diet.IsActive = true;
            diet.IsEdit = false;
            await repository.SaveChangesAsync();

            string message = $"Вашият хранителен режим: \"{diet.Name}\" е активен и готов за изпълнение!";
            await _notificationService.AddNotification(diet.Dietitian.UserId, diet.UserId, message, "Diet");

            await SendEmailAsync(diet.User.Email,"Хранителен режим активиран",message);
        }

        public async Task<bool> UserHasDietAsync(int id, string userId)
        {
            var diet = await repository.AllAsReadOnly<Diet>()
                .Where(x=>x.Id== id&& x.UserId == userId)
                .FirstOrDefaultAsync();

            if(diet == null)
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
