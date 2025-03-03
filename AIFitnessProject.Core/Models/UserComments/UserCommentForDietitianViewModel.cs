using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.UserComments
{
    public class UserCommentForDietitianViewModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public bool IsMine { get; set; }

        public string ProfilePicture { get; set; }

        public string Email { get; set; }
    }
}
