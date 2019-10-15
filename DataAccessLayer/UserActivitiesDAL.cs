using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserActivitiesDAL
    {
        public int UserID { get; set; }
        public int ActivityID { get; set; }
        public override string ToString()
        {
            return $"{UserID,5}{ActivityID,5}";
        }
    }
}
