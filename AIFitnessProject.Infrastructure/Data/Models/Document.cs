using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Documents;
namespace AIFitnessProject.Infrastructure.Data.Models
{
    [Comment("Document Table")]
    public class Document
    {
        [Key]
        [Comment("Document Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Document User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [MaxLength(MaxPositionLength)]
        [Comment("Document User Position")]
        public string Position { get; set; } = string.Empty;

        [Required]
        [Comment("Document Is Accept")]
        public bool IsAccept { get; set; }

        [Required]
        [Comment("Documents User Experience In Years")]
        public int ExperienceYears { get; set; }

        [Required]
        [Comment("Document User Sertification Image")]
        public byte[] SertificateImage { get; set; } = null!;

        [Required]
        [MaxLength(MaxBioLength)]
        [Comment("Document User Bio")]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxSpecializationLength)]
        [Comment("Document User Specialization")]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxSertificationDetailsLength)]
        [Comment("Document User Sertification Details")]
        public string SertificationDetails { get; set; } = string.Empty;


    }
}
