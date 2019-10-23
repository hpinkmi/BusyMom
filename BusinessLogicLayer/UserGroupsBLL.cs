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
        public UserGroupsBLL(UserGroupsDAL userActivities)
        {
            UserID = userActivities.UserID;
            GroupID = userActivities.GroupID;
            RoleID = userActivities.RoleID;
        }
        public UserGroupsBLL()
        {

        }

    }
}
