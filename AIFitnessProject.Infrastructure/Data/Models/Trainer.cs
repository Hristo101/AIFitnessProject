using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Trainer;

namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Trainer Table")]
    public class Trainer
    {
        [Key]
        [Comment("Trainer Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxSpecializationLength)]
        [Comment("Trainer Specialization")]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [Comment("Trainer Experience")]
        public int Experience { get; set; }

        [Required]
        [Comment("Trainer Sertification Image")]
        public string SertificateImage { get; set; } = null!;

        [Required]
        [MaxLength(MaxSertificationDetailsLength)]
        [Comment("Trainer Sertification Details")]
        public string SertificationDetails { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxBioLength)]
        [Comment("Trainer Bio")]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [Comment("Trainer Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Trainer User Id")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public ICollection<RequestsToCoach> ReceivedRequests { get; set; } = new List<RequestsToCoach>();

    }
}
