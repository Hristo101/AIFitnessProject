using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.RequestsToCoach
{
    public class DetailsSurveyModel
    {
        public byte[] ProfilePicture { get; set; }
        public string Target { get; set; }
        public List<byte[]> PictureOfPersons {  get; set; }
        public string TrainingBackground { get; set; }
        public string HealthStatus { get; set; }
        public string TrainingPreferences { get; set; }
        public string TrainingCommitment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
