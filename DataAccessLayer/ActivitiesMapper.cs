using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class ActivitiesMapper : Mapper
    {
        int OffsetToActivityID;
        int OffsetToActivityName;
        int OffsetToApproveby;
        int OffsetToTimeofActivity;
        int OffsetToLocationID;
        int OffsetToApproveTime;

        public ActivitiesMapper(SqlDataReader reader)
        {
            OffsetToActivityID = reader.GetOrdinal("ActivityID");
            Assert(0 == OffsetToActivityID, $"ActivityID is {OffsetToActivityID} instead of 0 as expected");
            OffsetToActivityName = reader.GetOrdinal("ActivityName");
            Assert(1 == OffsetToActivityID, $"ActivityName is {OffsetToActivityName} instead of 1 as expected");
            OffsetToApproveby = reader.GetOrdinal("Approveby");
            Assert(2 == OffsetToApproveby, $"Approveby is {OffsetToApproveby} instead of 2 as expected");
            OffsetToTimeofActivity = reader.GetOrdinal("TimeofActivity");
            Assert(3 == OffsetToTimeofActivity, $"TimeofActivity is {OffsetToTimeofActivity} instead of 3 as expected"); 
            OffsetToLocationID = reader.GetOrdinal("LocationID");
            Assert(4 == OffsetToLocationID, $"LocationID is {OffsetToLocationID} instead of 4 as expected");
            OffsetToApproveTime = reader.GetOrdinal("ApproveTime");
            Assert(5 == OffsetToApproveTime, $"ApproveTime is {OffsetToApproveTime} instead of 5 as expected");
        }
        public ActivitiesDAL ToActivities(SqlDataReader reader)
        {
            ActivitiesDAL proposedRV = new ActivitiesDAL();
            proposedRV.ActivityID = reader.GetInt32(OffsetToActivityID);
            proposedRV.ActivityName = reader.GetString(OffsetToActivityName);
            proposedRV.Approveby = reader.GetString(OffsetToApproveby);
            proposedRV.TimeofActivity = reader.GetString(OffsetToTimeofActivity);
            proposedRV.LocationID = reader.GetInt32(OffsetToLocationID);
            proposedRV.ApproveTime = reader.GetString(OffsetToApproveTime);
            return proposedRV;
        }

    }
}
