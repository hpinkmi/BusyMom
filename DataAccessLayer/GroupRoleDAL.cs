using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GroupRoleDAL
    {
        #region columns from primary table
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        #endregion
        #region colums from foreign table

        public int UserID { get; set; }
        public string ActivityOwner { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    #endregion


}
