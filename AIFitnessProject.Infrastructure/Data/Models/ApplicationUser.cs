using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MaxLength()]
       
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength()]
        public string LastName { get; set; } = string.Empty;

        public double Height { get; set; }

        public double Weight { get; set; }

        public string ExperienceLevel { get; set; } = string.Empty;


      
        public ICollection<PlanAssignment> PlanAssignments { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<UserComment> ReceivedComments { get; set; }
        public ICollection<UserComment> SentComments { get; set; }

        public Trainer Trainer { get; set; }
        public Dietitian Dietitian { get; set; }

        //public ICollection<TrainingPlan> CreatedTrainingPlans { get; set; }
        //public ICollection<Diet> CreatedDiets { get; set; }
        //public ICollection<Progress> ProgressEntries { get; set; }

        //public ICollection<AppComment> AppComments { get; set; }
        //public ICollection<AIRequest> AIRequests { get; set; }
    }
}
