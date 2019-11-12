using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserGroupsBLL
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public int RoleID { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string GroupName { get; set; }
        public UserGroupsBLL(UserGroupsDAL userGroups)
        {
            UserID = userGroups.UserID;
            GroupID = userGroups.GroupID;
            RoleID = userGroups.RoleID;
            UserName = userGroups.UserName;
            RoleName = userGroups.RoleName;
            GroupName = userGroups.GroupName;
        }
        public UserGroupsBLL()
        {

        }

    }
}
