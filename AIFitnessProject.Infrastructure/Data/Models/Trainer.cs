using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        public string Specialization { get; set; }
        public int Experience { get; set; }

        public string SertificationDetails { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")] 
        public ApplicationUser User { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Calendar> Calendars { get; set; }
        
    }
}
