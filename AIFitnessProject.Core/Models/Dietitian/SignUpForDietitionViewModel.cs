using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;
namespace AIFitnessProject.Core.Models.Dietitian
{
    public class SignUpForDietitionViewModel
    {
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength, ErrorMessage = "Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Височината е задължителена.")]
        [Range(0,3,ErrorMessage = "Височината трябва да бъде между 0 и 3 метра")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Теглото е задължително")]
        [Range(0, 400, ErrorMessage = "Теглото трябва да бъде между 0 и 400 килограма")]
        public double Weight { get; set; } 

        [Required(ErrorMessage = "Опитът е задължителен.")]
        [StringLength(MaxExperienceLevelLength, MinimumLength = MinExperienceLevelLength, ErrorMessage = "Опитът трябва да бъде по-голям от 3 символ и по-малък от 1500")]
        public string ExperienceLevel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Снимката е задължителна.")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Детайлите за сертификата са задължителни.")]
        [StringLength(MaxAimLength, MinimumLength = MinAimLength, ErrorMessage = "Целта трябва да бъдат по-голяма от 3 символа и по-малка от 5000")]
        public string Aim { get; set; } = string.Empty;
    }
}
