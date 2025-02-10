using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.Diet;
namespace AIFitnessProject.Core.Models.Diet
{
    public class EditDietViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Името трябва да е между {2} и {1} символа.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength, ErrorMessage = "Описанието трябва да е между {2} и {1} символа.")]
        public string Description { get; set; } = string.Empty;

        public string? ExistingImageUrl { get; set; }

        public IFormFile? NewImage { get; set; }

        
    }
}
