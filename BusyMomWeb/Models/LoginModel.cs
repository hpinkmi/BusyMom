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
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }       
        public string Message { get; set; }
        public string ReturnURL { get; set; }
    }
}