using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class GroupRoleMapper:Mapper
    {
        int OffsetToGroupID;
        int OffsetToGroupName;
        int OffsetToUserID;
        int OffsetToRoleID;
        int OffsetToRoleName;

        public GroupRoleMapper(SqlDataReader reader)
        {
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            OffsetToGroupName = reader.GetOrdinal("GroupName");
            OffsetToUserID = reader.GetOrdinal("UserID");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            OffsetToRoleName = reader.GetOrdinal("RoleName");

            Assert(OffsetToGroupID == 0, $"offsetToGroupID is {OffsetToGroupID} not 0 as expected");
            Assert(OffsetToGroupName == 1, $"offsetToGroupID is {OffsetToGroupName} not 1 as expected");
            Assert(OffsetToUserID == 2, $"(OffsetToGroupID is {OffsetToUserID} not 2 as expected");
            Assert(OffsetToRoleID == 3, $"OffsetToGroupID is {OffsetToRoleID} not 3 as expected");
            Assert(OffsetToRoleName == 4, $"OffsetToGroupID is {OffsetToRoleName} not 4 as expected");
        }
        public GroupRoleDAL ToGroupRole (SqlDataReader reader)
        {
            GroupRoleDAL proposedRV = new GroupRoleDAL();

            proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
            proposedRV.GroupName = reader.GetString(OffsetToGroupName);
            proposedRV.UserID = reader.GetInt32(OffsetToUserID);
            proposedRV.RoleID = reader.GetInt32(OffsetToRoleID);
            proposedRV.RoleName = reader.GetString(OffsetToRoleName);

            return proposedRV;
        }

    }
}
