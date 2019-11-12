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
        int OffsetToUserName { get; set; }
        int OffsetToGroupName { get; set; }
        int OffsetToRoleName { get; set; }
        public UserGroupsMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(OffsetToUserID == 0, $"OffsetToUserID is {OffsetToUserID} not 0 as expected");
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            Assert(OffsetToGroupID == 1, $"OffsetToGroupID is {OffsetToGroupID} not 1 as expected");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(OffsetToRoleID == 2, $"OffsetToRoleID is {OffsetToRoleID} not 2 as expected");
            OffsetToUserName = reader.GetOrdinal("UserName");
            Assert(OffsetToUserName == 3, $"OffsetToUser is {OffsetToUserName} not 3 as expected");
            OffsetToGroupName = reader.GetOrdinal("GroupName");
            Assert(OffsetToGroupName == 4, $"OffsetToGroupName is {OffsetToGroupName} not 4 as expected");
            OffsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(OffsetToRoleName == 5, $"OffsetToRoleName is {OffsetToRoleName} not 5 as expected");
        }

        public UserGroupsDAL ToUserGroups(SqlDataReader reader)
        {
            UserGroupsDAL proposedRV = new UserGroupsDAL();

            proposedRV.UserID = reader.GetInt32(OffsetToUserID);
            proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
            proposedRV.RoleID = reader.GetInt32(OffsetToRoleID);
            proposedRV.UserName = reader.GetString(OffsetToUserName);
            proposedRV.RoleName = reader.GetString(OffsetToRoleName);
            proposedRV.GroupName = reader.GetString(OffsetToGroupName);
            return proposedRV;


        }
        
    }
}
