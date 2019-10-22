using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class GroupActivitiesMapper : Mapper
    {
        int OffsetToGroupID;
        int OffsetToActivityID;
        int OffsetToActivityOwner;

        public GroupActivitiesMapper(SqlDataReader reader)
        {
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            Assert(OffsetToGroupID == 0, "OffsetToGroupID is {OffsetToGroupID} not 0 as expected");
            OffsetToActivityID = reader.GetOrdinal("ActivityID");
            Assert(OffsetToActivityID == 1, "OffsetToActivityID is {OffsetToActivityID} not 1 as expected");
            OffsetToActivityOwner = reader.GetOrdinal("ActivityOwner");
            Assert(OffsetToActivityOwner == 2, "OffsetToActivityOwner is{OffsetToActivityOwner} not 2 as expected");
        }

        public GroupActivitiesDAL GroupActivities(SqlDataReader reader)
        {
            GroupActivitiesDAL proposedRV = new GroupActivitiesDAL();

            proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
            proposedRV.ActivityID = reader.GetInt32(OffsetToActivityID);
            proposedRV.ActivityOwner = reader.GetString(OffsetToActivityOwner);

            return proposedRV;
        }
    }
}
