using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserActivitiesMapper : Mapper
    {
        int OffsetToUserID;
        int OffsetToActivityID;

        public UserActivitiesMapper(SqlDataReader reader)
            {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, $"UserID is {OffsetToUserID} instead of 0");
            OffsetToActivityID = reader.GetOrdinal("ActivityID");
            Assert(1 == OffsetToActivityID, $"ActivityID is {OffsetToActivityID} instead of 1");

            }
        public UserActivitiesDAL ToUserActivities(SqlDataReader reader)
        {
            UserActivitiesDAL propossedReturnValue = new UserActivitiesDAL();
            propossedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            propossedReturnValue.ActivityID = reader.GetInt32(OffsetToActivityID);

            return propossedReturnValue;
        }
            
    }
}
