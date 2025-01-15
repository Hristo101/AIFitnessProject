using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.UserComments
{
    public class UserCommentViewModel
    {
        public int Rating { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
    }
}
