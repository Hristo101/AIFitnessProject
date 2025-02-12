using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class SendTrainingPlanViewModel
    {
        public string Name { get; set; }
        public string ImageUrlTrainingPlan { get; set; }
        public string DescriptionTrainingPlan { get; set; }
        public int WorkoutsCount { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; } 
        public string UserEmail { get; set; }
        public string UserProfilePicture { get; set; }
    }
}
