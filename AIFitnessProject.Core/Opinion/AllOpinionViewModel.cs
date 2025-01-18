using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Opinion
{
    public class AllOpinionViewModel
    {
        public string FirstName {  get; set; } 
        public string LastName {  get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public string TrainerImageUrl { get; set; }
    }
}
