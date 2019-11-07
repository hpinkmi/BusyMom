using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GroupsMapper : Mapper
    {
        int OffsetToGroupID;
        int OffsetToGroupName;
        int OffsetToUserID;
        int OffsetToRoleID;
        int OffsetToRoleName;

        public GroupsMapper(SqlDataReader reader)
        {
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            Assert(OffsetToGroupID == 0, $"offsetToGroupID is {OffsetToGroupID} not 0 as expected");
            OffsetToGroupName = reader.GetOrdinal("GroupName");
            Assert(OffsetToGroupName == 1, $"offsetToGroupID is {OffsetToGroupName} not 1 as expected");
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(OffsetToUserID == 2, $"(OffsetToUserID is {OffsetToUserID} not 2 as expected");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(OffsetToRoleID == 4, $"OffsetToRoleID is {OffsetToRoleID} not 4 as expected");
            OffsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(OffsetToRoleName == 5, $"OffsetToRoleName is {OffsetToRoleName} not 5 as expected");

        }
        public GroupsDAL ToGroups(SqlDataReader reader)
        {
            GroupsDAL proposedRV = new GroupsDAL();

            proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
            proposedRV.GroupName = reader.GetString(OffsetToGroupName);
            proposedRV.UserID = reader.GetInt32(OffsetToUserID);
            proposedRV.RoleID = reader.GetInt32(OffsetToRoleID);
            proposedRV.RoleName = reader.GetString(OffsetToRoleName);

            return proposedRV;
        }

    }
}
