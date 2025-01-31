using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;
namespace AIFitnessProject.Core.Models.RequestsToCoach
{
    public class SurveyViewModel
    {
        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength, ErrorMessage = "Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; }
        public int TrainerId { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile[] ProfilePictures { get; set; }
        [Required(ErrorMessage = "Теглото е задължително")]
        [Range(MinWeight, MaxWeight, ErrorMessage = "Теглото не може да бъде по-малко от 3 килограма и по го-голямо от 450 килограма")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Височината е задължителена.")]
        [Range(MinHeight, MaxHeight, ErrorMessage = "Височината не може да бъде по - малка 120сm и не може да бъде по - голяма от 280сm")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Целта е задължителна.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Целта трябва да бъде по-голяма от 3 символа и по-малка от 200")]
        public string Target { get; set; }
        [Required(ErrorMessage = "Опитът с тренировките е задължителен.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Опитът с тренировките трябва да бъде по-голям от 3 символа и по-малък от 200")]
        public string TrainingBackground { get; set; }

        [Required(ErrorMessage = "Здравословните проблеми са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Здравословните проблеми трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string HealthStatus { get; set; }
        [Required(ErrorMessage = "Любимите тренировки са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Любимите тренировки трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string TrainingPreferences { get; set; }
        [Required(ErrorMessage = "Заетостта е задължителна.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Заетостта трябва да бъде по-голяма от 3 символа и по-малка от 200")]
        public string TrainingCommitment { get; set; }
        [Required(ErrorMessage = "Нивото на опит е задължително.")]
        [StringLength(MaxExperienceLevelLength, MinimumLength = MinExperienceLevelLength, ErrorMessage = "Опитът трябва да бъде по-голяям от 3 символа и по-малък от 1900")]
        public string ExpirienceLevel { get; set; }
    }
}
