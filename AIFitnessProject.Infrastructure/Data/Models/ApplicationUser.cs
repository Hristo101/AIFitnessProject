using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("ApplicationUser Table")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("Profile Picture stored as byte array")]
        public string? ProfilePicture { get; set; }

        [Required]
        [MaxLength(MaxFirstNameLength)]
        [Comment("ApplicationUser FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLastNameLength)]
        [Comment("ApplicationUser LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Comment("ApplicationUser Height")]
        public double Height { get; set; }

        [Required]
        [Comment("ApplicationUser Weight")]
        public double Weight { get; set; }

        [Required]
        [MaxLength(200)]
        [Comment("ApplicationUser Aim")]
        public string Aim { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxExperienceLevelLength)]
        [Comment("ApplicationUser ExperienceLevel")]
        public string ExperienceLevel { get; set; } = string.Empty;


        public ICollection<PlanAssignment> PlanAssignments { get; set; } = new List<PlanAssignment>();
        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public IEnumerable<UserComment> ReceivedComments { get; set; } = new List<UserComment>();
       public ICollection<UserComment> SentComments { get; set; } = new List<UserComment>();
       public ICollection<Opinion> SentOpinion { get; set; } = new List<Opinion>();
       public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<RequestsToCoach> ReceivedRequests { get; set; } = new List<RequestsToCoach>();
        public Trainer Trainer { get; set; }
        public Dietitian Dietitian { get; set; }

        //public ICollection<TrainingPlan> CreatedTrainingPlans { get; set; }
        //public ICollection<Diet> CreatedDiets { get; set; }
        //public ICollection<Progress> ProgressEntries { get; set; }

        //public ICollection<AppComment> AppComments { get; set; }
        //public ICollection<AIRequest> AIRequests { get; set; }
    }
}
