using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
using AIFitnessProject.Core.Models.Notification;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

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
        public async Task DeleteNotification(int id)
        {
            var model = await _repository.AllAsReadOnly<Notification>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

             _repository.Delete(model);
            await _repository.SaveChangesAsync();
        }
        public async Task AddNotification(string senderId, string receiverId, string message,string source)
        {
            var notification = new Notification
            {
                SenderId = senderId,
                RecieverId = receiverId,
                Message = message,
                CreatedAt = DateTime.Now,
                Source = source,
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
            if (model != null)
            {

            model.UnReadNotifications = await _repository.AllAsReadOnly<Notification>()
                .Include(x => x.Sender)
                .Where(x => x.RecieverId == userId).
                Where(x => x.ReadStatus == false)
                .Select(x => new MessagesOfNotificationsViewModel()
                {
                    Id = x.Id,
                    SenderId = x.Sender.Id,
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
             Id = x.Id,
             SenderId = x.Sender.Id,
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

            }

            return model;
        }
        public async Task<AllNotificationsViewModel> GetAllNotificationsForUser(string userId)
        {
            var user = await _repository.AllAsReadOnly<ApplicationUser>()
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            var model = await _repository.AllAsReadOnly<Notification>()
              .Where(x => x.RecieverId == userId)
            .Select(x => new AllNotificationsViewModel()
            {
                  ReceiverProfilePicture = user.ProfilePicture,
                  ReceiverEmail = user.Email,
                  RecieverFirstName = user.FirstName,
                  RecieverLastName = user.LastName,
              }).FirstOrDefaultAsync();
            if (model != null)
            {

                model.UnReadNotifications = await _repository.AllAsReadOnly<Notification>()
                    .Include(x => x.Sender)
                    .Where(x => x.RecieverId == userId).
                    Where(x => x.ReadStatus == false)
                    .Select(x => new MessagesOfNotificationsViewModel()
                    {
                        Id = x.Id,
                        SenderId = x.Sender.Id,
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
                        var trainer = await _repository.AllAsReadOnly<Trainer>()
                         .Where(x => x.UserId == notification.SenderId)
                         .FirstOrDefaultAsync();

                        if (trainer == null)
                        {
                            notification.Role = "Диетолог";
                        }
                        else
                        {
                            notification.Role = "Треньор";
                        }
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
                 Id = x.Id,
                 SenderId = x.Sender.Id,
                 Message = x.Message,
                 SenderEmail = x.Sender.Email,
                 SenderFirstName = x.Sender.FirstName,
                 SenderLastName = x.Sender.LastName,
                 SenderProfilePicture = x.Sender.ProfilePicture,
                 NotificationDate = x.CreatedAt.ToString("yyyy-MM-dd"),
             })
             .ToListAsync();

                foreach (var notification in model.ReadNotifications)
                {
                    
                    if (notification.SenderEmail != "hserev789@gmail.com")
                    {
                        var trainer = await _repository.AllAsReadOnly<Trainer>()
                            .Where(x => x.UserId == notification.SenderId)
                            .FirstOrDefaultAsync();

                        if (trainer == null)
                        {
                            notification.Role = "Диетолог";
                        }
                        else
                        {
                         notification.Role = "Треньор";
                        }
                    }
                    else
                    {
                        notification.Role = "Администратор";
                    }
                }

            }

            return model;
        }
        public async Task MarkAllAsRead(string userId)
        {
            var model = await _repository.All<Notification>()
                .Where(x =>x.RecieverId == userId)
                .Where(x =>x.ReadStatus == false)
                .ToListAsync();

            foreach (var item in model)
            {
                item.ReadStatus = true;
                await _repository.SaveChangesAsync();
            }

        }

        public async Task MarkNotificationRead(int notificationId)
        {
            var notification = await _repository.All<Notification>()
                 .Where(x => x.Id == notificationId)
                 .FirstOrDefaultAsync();

            notification.ReadStatus = true;
            await _repository.SaveChangesAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            var notification = await _repository.All<Notification>()
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();

            return notification;

        }

        public async Task<AllNotificationsViewModel> GetAllNotificationsForDietitian(string userId)
        {
            var dietitian = await _repository.AllAsReadOnly<Dietitian>()
                 .Where(x => x.UserId == userId)
                 .Include(x => x.User)
                 .FirstOrDefaultAsync();


            var model = await _repository.AllAsReadOnly<Notification>()
                 .Where(x => x.RecieverId == userId)
                 .Select(x => new AllNotificationsViewModel()
                 {
                     ReceiverProfilePicture = dietitian.User.ProfilePicture,
                     ReceiverEmail = dietitian.User.Email,
                     RecieverFirstName = dietitian.User.FirstName,
                     RecieverLastName = dietitian.User.LastName,
                 }).FirstOrDefaultAsync();
            if (model != null)
            {

                model.UnReadNotifications = await _repository.AllAsReadOnly<Notification>()
                    .Include(x => x.Sender)
                    .Where(x => x.RecieverId == userId).
                    Where(x => x.ReadStatus == false)
                    .Select(x => new MessagesOfNotificationsViewModel()
                    {
                        Id = x.Id,
                        SenderId = x.Sender.Id,
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
                 Id = x.Id,
                 SenderId = x.Sender.Id,
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

            }

            return model;
        }
    }
}
