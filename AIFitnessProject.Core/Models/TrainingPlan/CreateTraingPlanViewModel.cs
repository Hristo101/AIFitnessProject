using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class CreateTraingPlanViewModel
    {
        public string UserId { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string TrainingPlanName { get; set; }
        public string TrainingPlanDescription { get; set; }
    }
}
