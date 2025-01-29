using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.RequestsToCoach
{
    public class AllSurveyViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string TargetOfTraining { get; set; }
        public string ExperienceLevel { get; set; }
    }
}
