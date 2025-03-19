using AIFitnessProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Notification
{
    public class AllNotificationsViewModel
    {
        
        public string RecieverFirstName { get; set; }
        public string RecieverLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverProfilePicture { get; set; }

        public ICollection<MessagesOfNotificationsViewModel> UnReadNotifications { get; set; } = new List<MessagesOfNotificationsViewModel>();
        public ICollection<MessagesOfNotificationsViewModel> ReadNotifications { get; set; } = new List<MessagesOfNotificationsViewModel>();
    }
}
