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

        public GroupsMapper(SqlDataReader reader)
        {
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            Assert(OffsetToGroupID == 0, $"GroupID is {OffsetToGroupID} instead of 0 as expected");
            OffsetToGroupName = reader.GetOrdinal("GroupName");
            Assert(OffsetToGroupName == 1, $"GroupName is {OffsetToGroupName} instead of 1 as expected");
        }
        public GroupsDAL ToGroups(SqlDataReader reader)
        {
            GroupsDAL proposedRV = new GroupsDAL();

            proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
            proposedRV.GroupName = reader.GetString(OffsetToGroupName);
            return proposedRV;
        }
    }
}
