using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusyMomWeb.Models
{
    public class OneView
    {
        //user
        public int UserID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
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
        public string NewUserName { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        //groups
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string NewGroupName { get; set; }

        //itemstuff Ask about that?

        //public string ItemDescription { get; set; }
    }
}