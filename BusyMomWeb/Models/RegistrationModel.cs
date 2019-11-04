using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BusyMomWeb.Models
{
    public class RegistrationModel
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(MagicConstants.MaxPasswordLength,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = MagicConstants.MinPasswordLength)]
        [RegularExpression(MagicConstants.PasswordRequirements,
            ErrorMessage = MagicConstants.PasswordRequirementsMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Again")]
        public string PasswordAgain { get; set; }
        public string Message { get; set; }
    }
}