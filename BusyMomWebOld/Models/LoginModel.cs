using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusyMomWeb.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set;}
        [StringLength(MagicConstants.MaxPasswordLength,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = MagicConstants.MinPasswordLength)]
        [RegularExpression(MagicConstants.PasswordRequirements,
            ErrorMessage = MagicConstants.PasswordRequirementsMessage)]
        public string Message { get; set; }
        public string ReturnURL { get; set; }
    }
}