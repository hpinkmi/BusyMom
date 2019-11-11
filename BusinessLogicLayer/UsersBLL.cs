using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UsersBLL
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set;}
        public string UserName { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        //public int GroupID { get; set; }
        //public int ActivityID { get; set; }
        public UsersBLL(UsersDAL user)
        {
            UserID = user.UserID;
            LastName = user.LastName;
            FirstName = user.FirstName;
            Email = user.Email;
            Phone = user.Phone;
            UserName = user.UserName;
            Hash = user.Hash;
            Salt = user.Salt;
            // from foreign table
            RoleID = user.RoleID;
            RoleName = user.RoleName;
            //GroupID = user.GroupID;
            //ActivityID = user.ActivityID;
        }
        public UsersBLL()
        {
            
        }
    }
}
