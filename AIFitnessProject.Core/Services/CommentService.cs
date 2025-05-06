using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;



namespace AIFitnessProject.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly INotificationService notificationService;
        private readonly IConfiguration _configuration;
        public CommentService(IRepository _repository, INotificationService _notificationService,IConfiguration configuration)
        {
            this.repository = _repository;
            this.notificationService = _notificationService;
            _configuration = configuration;
        }

        public async Task AddNewComment(string senderId, int trainerId, string content, int rating)
        {
            var trainer = await repository.AllAsReadOnly<Trainer>()
                .Where(x =>x.Id == trainerId)
                .FirstOrDefaultAsync();

            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == senderId)
                .FirstOrDefaultAsync();

            var comment = new UserComment()
            {
                SenderId = senderId,
                ReceiverId = trainer.UserId,
                Content = content,
                Rating = rating
            };
            
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            string message = $"Потребител с име {user.FirstName} {user.LastName} ви постави коментар с оценка: {comment.Rating} и със следния отзив:{comment.Content}";
            await notificationService.AddNotification(senderId, trainer.UserId, message, "Comments");
        }

        public async Task AddNewCommentForDietitian(string senderId, int dietitianId, string content, int rating)
        {
            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .Include(x=>x.User)
               .Where(x => x.Id == dietitianId)
               .FirstOrDefaultAsync();

            var user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == senderId)
                .FirstOrDefaultAsync();

            var comment = new UserComment()
            {
                SenderId = senderId,
                ReceiverId = dietitian.UserId,
                Content = content,
                Rating = rating
            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            string message = $"Потребител с име {user.FirstName} {user.LastName} ви постави коментар с оценка: {comment.Rating} и със следния отзив: {comment.Content}";
            await notificationService.AddNotification(senderId, dietitian.UserId, message, "Comments");

            await SendEmailAsync(dietitian.User.Email, "Успешно добавен коментар ✔", message);


        }

        public async Task DeleteComment(int commentId)
        {
            var model = await repository.All<UserComment>()
                .Where(x =>x.Id == commentId)
                .FirstOrDefaultAsync();

             repository.Delete(model);
            await repository.SaveChangesAsync();
        }

        public async Task EditComment(int commentId, string content, int rating)
        {
           var comment = await repository.All<UserComment>()
                .Where(x =>x.Id == commentId)
                .FirstOrDefaultAsync();

            comment.Content = content;
            comment.Rating = rating;
            await repository.SaveChangesAsync();
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
