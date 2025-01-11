using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AIFitnessProject.Infrastructure.Data.Models
{



    public class Dietitian
    {
        public int Id { get; set; }

        public string Specialization { get; set; }

        public int Experience { get; set; }

        public string SertificationDetails { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public ICollection<Calendar> Calendars { get; set; }

    }
}
