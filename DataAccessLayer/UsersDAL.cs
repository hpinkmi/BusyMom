using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UsersDAL
    {
        #region columns from primary table
        public int UserID { get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        #endregion

        #region colums from foreign tables
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int GroupID { get; set; }
        public int ActivityID { get; set; }


        #endregion

        public override string ToString()
        {
            return $"UserId:{UserID,5} GroupID: {GroupID,5} LastName: {LastName,15} FirstName {FirstName,15} Email: {Email,25} Phone {Phone,8} UserName: {UserName,15} Hash: {Hash} Salt: {Salt} RoleID: {RoleID} ";
        }
            
        }
    }
