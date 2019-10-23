using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserActivitiesBLL
    {
        public int UserId { get; set; }
        public int ActivityID { get; set; }
        public UserActivitiesBLL(UserActivitiesDAL userActivities)
        {
            UserId = userActivities.UserID;
            ActivityID = userActivities.ActivityID;
        }
        public UserActivitiesBLL()
        {

        }
    }
}
