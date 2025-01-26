using AIFitnessProject.Core.Models.UserComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Dietitian
{
    public class DetailsDietitianViewModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public byte[] SertificationImage { get; set; } 

        public string Specialization { get; set; } = string.Empty;

        public byte[]? DietitianImage { get; set; }

        public List<UserCommentViewModel> Comments { get; set; } = new List<UserCommentViewModel>();

        public string SertificationDetails { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
