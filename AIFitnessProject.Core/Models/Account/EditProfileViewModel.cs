using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AIFitnessProject.Infrastructure.Constants.DataConstants.ApplicationUser;
namespace AIFitnessProject.Core.Models.Account
{
    public class EditProfileViewModel
    {
        public string ImageUrl { get; set; }
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength, ErrorMessage = "Първото име трябва да бъде по-голямо от 3 символа и по-малко от 1900")]
        public string FirstName { get; set; }
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Фамилията трябва да бъде по-голяма от 3 символа и по-малка от 1900")]
        public string LastName { get; set; }
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "Email-а трябва да бъде по-голям от 3 символа и по-малък от 1900")]
        public string Email { get; set; }
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength, ErrorMessage = "UserName-а трябва да бъде по-голям от 3 символа и по-малък от 1900")]
        public string UserName { get; set; }
        [Range(MinHeight,MaxHeight,ErrorMessage ="Височината не може да бъде по-малка 1.20m и не може да бъде по-голяма от 2.8m")]
        public double Height { get; set; }
        [Range(MinWeight,MaxWeight,ErrorMessage ="Теглото не може да бъде по-малко от 3 килограма и по го-голямо от 450 килограма")]
        public double Weight { get; set; }

        public string ExperienceLevel { get; set; }
    }
}
