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
        public DateTime TimeofActivity { get; set; }
        public int LocationID { get; set; }


        public override string ToString()
        {
            return $"ActivityID:{ActivityID}ActivityName:{ActivityName,5}TimeofActivity:{TimeofActivity,5}LocationID:{LocationID}";
        }
    }
}
