using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Hubs;
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
    }
}
