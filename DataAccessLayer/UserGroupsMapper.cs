using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class UserGroupsMapper : Mapper
    {
        int OffsetToUserID { get; set; }
        int OffsetToGroupID { get; set; }
        int OffsetToRoleID { get; set; }
        public UserGroupsMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(OffsetToUserID == 0, $"OffsetToUserID is {OffsetToUserID} not 0 as expected");
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            Assert(OffsetToGroupID == 1, $"OffsetToGroupID is {OffsetToGroupID} not 1 as expected");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(OffsetToRoleID == 2, $"OffsetToRoleID is {OffsetToRoleID} not 2 as expected");
        }
            public UserGroupsDAL ToUserGroups(SqlDataReader reader)
            {
                UserGroupsDAL proposedRV = new UserGroupsDAL();

                proposedRV.UserID = reader.GetInt32(OffsetToUserID);
                proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
                proposedRV.RoleID = reader.GetInt32(OffsetToRoleID);
                return proposedRV;

            }
        
    }
}
