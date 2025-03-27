using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Notification
{
    public class MessagesOfNotificationsViewModel
    {
        public int Id { get; set; }
        public string SenderId { get;set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderProfilePicture { get; set; }
        public string Message { get; set; }
        public string Role { get; set; }
        public string NotificationDate { get; set; }
    }
}
