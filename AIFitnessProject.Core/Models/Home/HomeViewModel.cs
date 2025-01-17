using AIFitnessProject.Core.Models.Dietitian;
using AIFitnessProject.Core.Models.Trainer;
using AIFitnessProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Home
{
    public class HomeViewModel
    {
        public List<IndexDiatitianViewModel> Dietitians { get; set; }
        public List<IndexTrainerViewModel> Trainers { get; set; }
    }
}
