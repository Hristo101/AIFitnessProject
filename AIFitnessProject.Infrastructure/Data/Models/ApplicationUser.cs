using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(2200)]
        [Comment("ApplicationUser Aim")]
        public string Aim { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxExperienceLevelLength)]
        [Comment("ApplicationUser ExperienceLevel")]
        public string ExperienceLevel { get; set; } = string.Empty;


        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public IEnumerable<UserComment> ReceivedComments { get; set; } = new List<UserComment>();
       public ICollection<UserComment> SentComments { get; set; } = new List<UserComment>();
       public ICollection<Opinion> SentOpinion { get; set; } = new List<Opinion>();
       public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<RequestsToCoach> ReceivedRequests { get; set; } = new List<RequestsToCoach>();
        public ICollection<RequestToDietitian> RequestsToDietitian { get; set; } = new List<RequestToDietitian>();
        public Trainer Trainer { get; set; }
        public Dietitian Dietitian { get; set; }
    }
}
