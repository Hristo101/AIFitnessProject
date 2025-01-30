using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace AIFitnessProject.Core.Models.RequestToDietitian
{
    public class SurveyViewModel
    {
        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength, ErrorMessage = "Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; } = string.Empty;

        public int DietitianId { get; set; }

        [Required(ErrorMessage = "Снимката е задължителна.")]
        [DataType(DataType.Upload)]
        public IFormFile[] ProfilePictures { get; set; }

        [Required(ErrorMessage = "Височината е задължителена.")]
        [Range(MinHeight, MaxHeight, ErrorMessage = "Височината не може да бъде по - малка 1.20m и не може да бъде по - голяма от 2.8m")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Теглото е задължително")]
        [Range(MinWeight, MaxWeight, ErrorMessage = "Теглото не може да бъде по-малко от 3 килограма и по го-голямо от 450 килограма")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Целта е задължителна.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Целта трябва да бъде по-голяма от 3 символа и по-малка от 200")]
        public string Target { get; set; } = string.Empty;

        [Required(ErrorMessage = "Опитът с диетите е задължителен.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Опитът с диетите трябва да бъде по-голям от 3 символа и по-малък от 200")]
        public string DietBackground { get; set; } = string.Empty;

        [Required(ErrorMessage = "Здравословните проблеми са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Здравословните проблеми трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string HealthIssues { get; set; } = string.Empty;

        [Required(ErrorMessage = "Хранителните алергии са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Хранителните алергии трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string FoodAllergies { get; set; } = string.Empty;

        [Required(ErrorMessage = "Любимите храни са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Любимите храни трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string FavouriteFoods { get; set; } = string.Empty;

        [Required(ErrorMessage = "Броят на храненията за ден е задължителен.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Броят на храненията за ден трябва да бъде по-голям от 3 символа и по-малък от 200")]
        public string PreferredMealsPerDay { get; set; } = string.Empty;

        [Required(ErrorMessage = "Начинът за приготвяне на храна е задължителен.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Начинът за приготвяне на храна трябва да бъдат по-голеям от 3 символа и по-малък от 200")]
        public string MealPreparationPreference { get; set; } 

        [Required(ErrorMessage = "Нехаресваните храни са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Нехаресваните храни трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string DislikedFoods { get; set; } = string.Empty;

        [Required(ErrorMessage = "Използваните добавки са задължителни.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Използваните добавки трябва да бъдат по-голели от 3 символа и по-малки от 200")]
        public string SupplementsUsed { get; set; } = string.Empty;

        [Required(ErrorMessage = "Нивото на опит е задължително.")]
        [StringLength(MaxExperienceLevelLength, MinimumLength = MinExperienceLevelLength, ErrorMessage = "Опитът трябва да бъде по-голяям от 3 символа и по-малък от 1900")]
        public string ExperienceLevel { get; set; } = string.Empty;
  
    }

}

