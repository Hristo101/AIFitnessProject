using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Trainer;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace AIFitnessProject.Core.Models.Trainer
{
    public class TrainerViewModelForWork
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxFirstNameLength,MinimumLength =MinFirstNameLength,ErrorMessage ="Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxLastNameLength,MinimumLength =MinLastNameLength,ErrorMessage ="Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Стажът е задължителен.")]
        public int ExperienceYears { get; set; }
        [Required(ErrorMessage ="Сертификата е задължителен")]
        public string Certificate { get; set; }
        [Required(ErrorMessage = "Биографията е задължителна.")]
        [StringLength(MaxBioLength,MinimumLength =MinBioLength,ErrorMessage = "Биографията трябва да бъде по-голяма от 3 и по малка от 4500")]
        public string Biography {  get; set; }
        [Required(ErrorMessage = "Специализацията е задължителна.")]
        [StringLength(MaxSpecializationLength,MinimumLength =MinSpecializationLength,ErrorMessage = "Специализацията трябва да бъде по-голяма от 3 и по малка от 1500")]
        public string Specialization {  get; set; }
        [Required(ErrorMessage = "Детайлите за сертификата са задължителни.")]
        [StringLength(MaxSertificationDetailsLength,MinimumLength =MinSertificationDetailsLength,ErrorMessage = "Детайлите по сертификата трябва да бъдат по-големи от 3 и по малки от 1500")]
        public string CertificationDetails { get; set; }
    }
}
