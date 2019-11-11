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
        int OffsetToTimeofActivity;
        int OffsetToLocationID;

        public ActivitiesMapper(SqlDataReader reader)
        {
            OffsetToActivityID = reader.GetOrdinal("ActivityID");
            Assert(0 == OffsetToActivityID, $"ActivityID is {OffsetToActivityID} instead of 0 as expected");
            OffsetToActivityName = reader.GetOrdinal("ActivityName");
            Assert(1 == OffsetToActivityName, $"ActivityName is {OffsetToActivityName} instead of 1 as expected");
            OffsetToTimeofActivity = reader.GetOrdinal("TimeofActivity");
            Assert(2 == OffsetToTimeofActivity, $"TimeofActivity is {OffsetToTimeofActivity} instead of 2 as expected"); 
            OffsetToLocationID = reader.GetOrdinal("LocationID");
            Assert(3 == OffsetToLocationID, $"LocationID is {OffsetToLocationID} instead of 3 as expected");
        }
        public ActivitiesDAL ToActivities(SqlDataReader reader)
        {
            ActivitiesDAL proposedRV = new ActivitiesDAL();
            proposedRV.ActivityID = reader.GetInt32(OffsetToActivityID);
            proposedRV.ActivityName = reader.GetString(OffsetToActivityName);
            proposedRV.TimeofActivity = reader.GetDateTime(OffsetToTimeofActivity);
            proposedRV.LocationID = reader.GetInt32(OffsetToLocationID);
            return proposedRV;
        }

    }
}
