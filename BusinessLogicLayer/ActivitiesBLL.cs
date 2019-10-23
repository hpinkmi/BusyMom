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
        public string TimeofActivity { get; set; }
        public int LocationID { get; set; }
        public string ApproveTime { get; set; }
        public ActivitiesBLL(ActivitiesBLL activities)
        {
            ActivityID = activities.ActivityID;
            ActivityName = activities.ActivityName;
            TimeofActivity = activities.TimeofActivity;
            LocationID = activities.LocationID;
            Approveby = activities.Approveby;
        }
        public ActivitiesBLL()
        {
            //default ctor is Required for MVC
        }
    }
}
