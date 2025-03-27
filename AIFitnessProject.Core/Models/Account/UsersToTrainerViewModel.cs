using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Account
{
    public class UsersToTrainerViewModel
    {
        public  string FullName { get; set; }
        public string UserProfilePicture { get; set; }
        public string Aim { get; set; }
        public string TrainingPreferences { get; set; }
        public string Date { get; set; }
    }
}
