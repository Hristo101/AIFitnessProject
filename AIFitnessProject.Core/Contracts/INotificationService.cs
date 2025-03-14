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
        Task AddNotification(string senderId, string receiverId, string message);
    }
}
