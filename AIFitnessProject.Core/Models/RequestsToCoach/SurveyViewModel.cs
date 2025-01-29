using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.RequestsToCoach
{
    public class SurveyViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TrainerId { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile[] ProfilePictures { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Target { get; set; }
        public string TrainingBackground { get; set; }
        public string HealthStatus { get; set; }
        public string TrainingPreferences { get; set; }
        public string TrainingCommitment { get; set; }
        public string ExpirienceLevel { get; set; }
    }
}
