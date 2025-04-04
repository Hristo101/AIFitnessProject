﻿using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;



namespace AIFitnessProject.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly INotificationService notificationService;
        public CommentService(IRepository _repository, INotificationService _notificationService)
        {
            this.repository = _repository;
            this.notificationService = _notificationService;
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
    }
}
