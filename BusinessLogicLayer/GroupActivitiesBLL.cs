using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GroupActivitiesBLL
    {
        public int GroupID { get; set; }
        public int ActivityID { get; set; }
        public string ActivityOwner { get; set; }
        public GroupActivitiesBLL(GroupActivitiesDAL groupActivities)
        {
            GroupID = groupActivities.GroupID;
            ActivityID = groupActivities.ActivityID;
            ActivityOwner = groupActivities.ActivityOwner;
        }
        public GroupActivitiesBLL()
        {

        }

    }
}
