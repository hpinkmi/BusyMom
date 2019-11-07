using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GroupRoleBLL
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public GroupRoleBLL(GroupRoleDAL grouprole)
        {
            GroupID = grouprole.GroupID;
            GroupName = grouprole.GroupName;
            UserID = grouprole.UserID;
            RoleID = grouprole.RoleID;
            RoleName = grouprole.RoleName;
        }
        public GroupRoleBLL()
        {

        }
    }
}
