using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GroupsBLL
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int UserID { get; set; }
        public string ActivityOwner { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public GroupsBLL(GroupsDAL groups)
        {
            GroupID = groups.GroupID;
            GroupName = groups.GroupName;
            //Outside of Groups Table
            UserID = groups.UserID;
            ActivityOwner = groups.ActivityOwner;
            RoleID = groups.RoleID;
            RoleName = groups.RoleName;
        }
        public GroupsBLL()
        {
            
        }
    }
}
