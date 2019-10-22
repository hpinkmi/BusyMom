using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserActivitiesDAL
    {
        #region colums from primary table
        public int UserID { get; set; }
        public int ActivityID { get; set; }
        #endregion
        public override string ToString()
        {
            return $"{UserID,5}{ActivityID,5}";
        }
    }
}
