using AIFitnessProject.Core.Models.UserComments;
using AIFitnessProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Trainer
{
    public class DetailsTrainerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string SertificationImage { get; set; }
        public string Specialization { get; set; }
        public byte[] TrainerImage { get; set; }
        public List<UserCommentViewModel> Comments { get; set; } = new List<UserCommentViewModel>();
        public string SertificationDetails { get; set; }
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
    }
}
