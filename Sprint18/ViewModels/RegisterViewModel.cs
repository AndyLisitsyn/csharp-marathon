using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAuthenticationAuthorization.ViewModels
{

    public class RegisterViewModel
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password),ErrorMessage ="Password don't match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
