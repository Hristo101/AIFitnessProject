using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "InvalidLength")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "InvalidLength")]

        public string Password { get; set; } = null!;
    }
}
