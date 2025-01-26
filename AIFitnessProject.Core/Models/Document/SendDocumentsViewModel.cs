using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Documents;

namespace AIFitnessProject.Core.Models.Document
{
    public class SendDocumentsViewModel
    {
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Позицията е задължителна.")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength, ErrorMessage = "Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Стажът е задължителен.")]
        [Range(MinExperience,MaxExperience, ErrorMessage = "Опитът трябва да бъде по-голям от 3 години и по-малка от 100")]
        public int ExperienceYears { get; set; }

        [Required(ErrorMessage = "Сертификата е задължителен")]
        public IFormFile CertificateImage { get; set; } 

        [Required(ErrorMessage = "Биографията е задължителна.")]
        [StringLength(MaxBioLength, MinimumLength = MinBioLength, ErrorMessage = "Биографията трябва да бъде по-голяма от 3 и по малка от 4500")]
        public string Bio { get; set; } = string.Empty;

        [Required(ErrorMessage = "Специализацията е задължителна.")]
        [StringLength(MaxSpecializationLength, MinimumLength = MinSpecializationLength, ErrorMessage = "Специализацията трябва да бъде по-голяма от 3 символа и по малка от 1500")]
        public string Specialization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Детайлите за сертификата са задължителни.")]
        [StringLength(MaxSertificationDetailsLength, MinimumLength = MinSertificationDetailsLength, ErrorMessage = "Детайлите по сертификата трябва да бъдат по-големи от 3 и по малки от 2500")]
        public string CertificationDetails { get; set; } = string.Empty;
    }
}
