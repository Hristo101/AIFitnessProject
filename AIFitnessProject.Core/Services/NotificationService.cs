using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Models.Notification;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IRepository _repository;

        public NotificationService(IHubContext<NotificationHub> hubContext, IRepository repository)
        {
            _hubContext = hubContext;
            _repository = repository;
        }

        public async Task AddNotification(string senderId, string receiverId, string message)
        {
            var notification = new Notification
            {
                SenderId = senderId,
                RecieverId = receiverId,
                Message = message,
                CreatedAt = DateTime.Now,
                ReadStatus = false
            };
            await _repository.AddAsync(notification);
            await _repository.SaveChangesAsync();

            await _hubContext.Clients.User(receiverId).SendAsync("ReceiveNotification", message);
        }

        public async Task<AllNotificationsViewModel> GetAllNotifications(string userId)
        {
            var trainer = await _repository.AllAsReadOnly<Trainer>()
                .Where(x => x.UserId == userId)
                .Include(x =>x.User)
                .FirstOrDefaultAsync();


           var model = await _repository.AllAsReadOnly<Notification>()
                .Where(x =>x.RecieverId == userId)
                .Select(x => new AllNotificationsViewModel()
                {
                    ReceiverProfilePicture =trainer.User.ProfilePicture,
                    ReceiverEmail = trainer.User.Email,
                    RecieverFirstName = trainer.User.FirstName,
                    RecieverLastName = trainer.User.LastName,
                }).FirstOrDefaultAsync();

            model.UnReadNotifications = await _repository.AllAsReadOnly<Notification>()
                .Include(x => x.Sender)
                .Where(x => x.RecieverId == userId).
                Where(x => x.ReadStatus == false)
                .Select(x => new MessagesOfNotificationsViewModel()
                {
                    Message = x.Message,
                    SenderEmail = x.Sender.Email,
                    SenderFirstName = x.Sender.FirstName,
                    SenderLastName = x.Sender.LastName,
                    SenderProfilePicture = x.Sender.ProfilePicture,
                    NotificationDate = x.CreatedAt.ToString("yyyy-MM-dd"),
                })
                .ToListAsync();

            foreach (var notification in model.UnReadNotifications)
            {
                if (notification.SenderEmail != "hserev789@gmail.com")
                {
                    notification.Role = "Потребител";
                }
                else
                {
                    notification.Role = "Администратор";
                }
            }

            model.ReadNotifications = await _repository.AllAsReadOnly<Notification>()
         .Include(x => x.Sender)
         .Where(x => x.RecieverId == userId).
         Where(x => x.ReadStatus == true)
         .Select(x => new MessagesOfNotificationsViewModel()
         {
             Message = x.Message,
             SenderEmail = x.Sender.Email,
             SenderFirstName = x.Sender.FirstName,
             SenderLastName = x.Sender.LastName,
             SenderProfilePicture = x.Sender.ProfilePicture,
             NotificationDate = x.CreatedAt.ToString("yyyy-MM-dd"),
         })
         .ToListAsync();

            foreach (var notification in model.UnReadNotifications)
            {
                if (notification.SenderEmail != "hserev789@gmail.com")
                {
                    notification.Role = "Потребител";
                }
                else
                {
                    notification.Role = "Администратор";
                }
            }

            return model;
        }
    }
}
