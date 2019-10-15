using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GroupActivitiesDAL
    {
        public int GroupID { get; set; }
        public int ActivityID { get; set; }
        public string Owner { get; set; }
        public override string ToString()
        {
            return $"{GroupID,5}{ActivityID,5}{Owner,5}";
        }
    }
}
