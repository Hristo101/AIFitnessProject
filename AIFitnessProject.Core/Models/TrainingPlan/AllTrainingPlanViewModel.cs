using AIFitnessProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.TrainingPlan
{
    public class AllTrainingPlanViewModel
    {
        public int Id { get; set; }
        public string ImageUrl {  get; set; }
        public string TitleOfTriningPlan { get; set; }
        public string DescriptionOfTriningPlan { get;set; }
    }
}
