using AIFitnessProject.Core.Models.Notification;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface INotificationService
    {
        Task AddNotification(string senderId, string receiverId, string message, string source);
        Task MarkAllAsRead(string userId);
        Task MarkNotificationRead(int notificationId);
        Task<Notification> GetNotificationById(int id);
        Task DeleteNotification(int id);
        Task<AllNotificationsViewModel> GetAllNotifications(string userId);
        Task<AllNotificationsViewModel> GetAllNotificationsForUser(string userId);
        Task<AllNotificationsViewModel> GetAllNotificationsForDietitian(string userId);
        
    }
}
