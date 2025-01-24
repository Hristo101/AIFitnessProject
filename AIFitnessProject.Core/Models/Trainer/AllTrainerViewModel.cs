using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Trainer
{
    public class AllTrainerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ImageUrl { get; set; }
        public string Specialization {  get; set; }
        public int Experience { get; set; }
    }
}
