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
        public string ActivityOwner { get; set; }

      
        public override string ToString()
        {
            return $"GroupID:{GroupID,5}ActivityID:{ActivityID,5}ActivityOwner:{ActivityOwner,20}";
        }
    }
}
