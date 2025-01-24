﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;
namespace AIFitnessProject.Core.Models.Account
{
    public class MoreInformationViewModel
    {
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength, ErrorMessage = "Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Първото име е задължително.")]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Височината е задължителена.")]
        [Range(MinHeight, MaxHeight, ErrorMessage = "Височината не може да бъде по - малка 1.20m и не може да бъде по - голяма от 2.8m")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Теглото е задължително")]
        [Range(MinWeight, MaxWeight, ErrorMessage = "Теглото не може да бъде по-малко от 3 килограма и по го-голямо от 450 килограма")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Опитът е задължителен.")]
        [StringLength(MaxExperienceLevelLength, MinimumLength = MinExperienceLevelLength, ErrorMessage = "Опитът трябва да бъде по-голям от 3 символ и по-малък от 1500")]
        public string ExperienceLevel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Снимката е задължителна.")]
        public IFormFile ProfilePicture { get; set; } 

        [Required(ErrorMessage = "Детайлите за сертификата са задължителни.")]
        [StringLength(MaxAimLength, MinimumLength = MinAimLength, ErrorMessage = "Целта трябва да бъдат по-голяма от 3 символа и по-малка от 5000")]
        public string Aim { get; set; } = string.Empty;

    }
}
