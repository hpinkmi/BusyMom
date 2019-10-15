using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ActivitiesDAL
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string Approveby { get; set;}
        public string TimeofActivity { get; set; }
        public int LocationID { get; set; }
        public string ApproveTime { get; set; }
        public override string ToString()
        {
            return $"{ActivityID,5}{ActivityName,5}{Approveby,5}{TimeofActivity,5}{LocationID} {ApproveTime,5}";
        }
    }
}
