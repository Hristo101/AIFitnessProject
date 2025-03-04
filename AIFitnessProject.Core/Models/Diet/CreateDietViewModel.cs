using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static AIFitnessProject.Infrastructure.Constants.DataConstants.Diet;
namespace AIFitnessProject.Core.Models.Diet
{
    public class CreateDietViewModel
    {

        [Required(ErrorMessage = "Снимката е задължителна.")]
        public IFormFile ImageUrl { get; set; }

        public int RequestId { get; set; }

        [Required(ErrorMessage = "Името на хранителния режим е задължителен.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Името на хранителния режим трябва да бъде по-голямо от 3 символа и по-малко от 500")]
        public string DietName { get; set; }

        [Required(ErrorMessage = "Описанието на хранителния режим е задължителен.")]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength, ErrorMessage = "Описанието на хранителния режим трябва да бъде по-голямо от 3 символа и по-малко от 2500")]
        public string DietDescription { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}
