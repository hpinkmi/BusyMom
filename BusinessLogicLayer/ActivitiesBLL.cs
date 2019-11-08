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
        public DateTime TimeofActivity { get; set; }
        public int LocationID { get; set; }
        public ActivitiesBLL(ActivitiesDAL activities)
        {
            ActivityID = activities.ActivityID;
            ActivityName = activities.ActivityName;
            TimeofActivity = activities.TimeofActivity;
            LocationID = activities.LocationID;
        }
        public ActivitiesBLL()
        {
            //default ctor is Required for MVC
        }
    }
}
