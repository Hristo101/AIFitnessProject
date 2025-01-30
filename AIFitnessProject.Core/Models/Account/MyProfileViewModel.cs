using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Account
{
    public class MyProfileViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; } 
        public string ExperienceLevel { get; set; }
    }
}
