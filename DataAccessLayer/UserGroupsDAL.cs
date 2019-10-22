using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserGroupsDAL
    {
        #region columns from primary table
        public int UserID { get; set;}
        public int GroupID { get; set; }
        public int RoleID { get; set; }

        #endregion


        public override string ToString()
        {
            return $"UserID:{UserID,5} GroupID:{GroupID,5} RoleID: {RoleID,5}";
        }
    }
}
