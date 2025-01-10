using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "InvalidLength")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "InvalidLength")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "InvalidLength")]

        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [Compare(nameof(Password), ErrorMessage = "DifferentPasswordMessage")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "InvalidLength")]
        public string PasswordRepeat { get; set; } = null!;
    }
}
