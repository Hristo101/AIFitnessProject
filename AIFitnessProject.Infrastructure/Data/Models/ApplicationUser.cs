using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("ApplicationUser Table")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("ApplicationUser ImageUrl")]
        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength()]
        [Comment("ApplicationUser FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength()]
        [Comment("ApplicationUser LastName")]
        public string LastName { get; set; } = string.Empty;

        public double Height { get; set; }

        public double Weight { get; set; }
        [Required]
        [MaxLength()]
        [Comment("ApplicationUser ExperienceLevel")]
        public string ExperienceLevel { get; set; } = string.Empty;


        public ICollection<PlanAssignment> PlanAssignments { get; set; } = new List<PlanAssignment>();
        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public IEnumerable<UserComment> ReceivedComments { get; set; } = new List<UserComment>();
       public ICollection<UserComment> SentComments { get; set; } = new List<UserComment>();
       public ICollection<Opinion> SentOpinion { get; set; } = new List<Opinion>();

        public Trainer Trainer { get; set; }
        public Dietitian Dietitian { get; set; }

        //public ICollection<TrainingPlan> CreatedTrainingPlans { get; set; }
        //public ICollection<Diet> CreatedDiets { get; set; }
        //public ICollection<Progress> ProgressEntries { get; set; }

        //public ICollection<AppComment> AppComments { get; set; }
        //public ICollection<AIRequest> AIRequests { get; set; }
    }
}
