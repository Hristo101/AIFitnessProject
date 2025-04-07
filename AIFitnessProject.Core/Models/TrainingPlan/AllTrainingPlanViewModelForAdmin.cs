using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class AllTrainingPlanViewModelForAdmin
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string TitleOfTriningPlan { get; set; }
        public string DescriptionOfTriningPlan { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUser {  get; set; }
        public string ProfileEmailUser { get; set; }


        public string FirstNameTrainer { get; set; }
        public string LastNameTrainer { get; set; }
        public string ProfilePictureTrainer { get; set; }
        public string ProfileEmailTrainer { get; set; }
    }
}
