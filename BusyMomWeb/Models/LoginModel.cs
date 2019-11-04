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
        //[DataType(DataType.)]
        //[Display(Name ="UserName")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Message { get; set; }
        public string ReturnURL { get; set; }
    }
}