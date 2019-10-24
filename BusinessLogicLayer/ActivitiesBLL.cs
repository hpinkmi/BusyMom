using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class ActivitiesBLL
    {
       public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string Approveby { get; set; }
        public DateTime TimeofActivity { get; set; }
        public int LocationID { get; set; }
        public DateTime ApproveTime { get; set; }
        public ActivitiesBLL(ActivitiesDAL activities)
        {
            ActivityID = activities.ActivityID;
            ActivityName = activities.ActivityName;
            Approveby = activities.Approveby;
            TimeofActivity = activities.TimeofActivity;
            LocationID = activities.LocationID;
            ApproveTime = activities.ApproveTime;
        }
        public ActivitiesBLL()
        {
            //default ctor is Required for MVC
        }
    }
}
