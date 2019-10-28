using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyMomWeb.Models
{
    public class RegistrationModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
    }
}