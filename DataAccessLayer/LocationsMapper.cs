using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class LocationsMapper : Mapper
    {
        int OffsetToLocationID;
        int OffsetToLocationName;
        int OffsetToAddress1;
        int OffsetToAddress2;
        int OffsetToCity;
        int OffsetToState;
        int OffsetToZip;

        public LocationsMapper(SqlDataReader reader)
        {
            OffsetToLocationID = reader.GetOrdinal("LocationID");
            Assert(0 == OffsetToLocationID, $"LocationID is {OffsetToLocationID} instead of 0");
            OffsetToLocationName = reader.GetOrdinal("LocationName");
            Assert(1 == OffsetToLocationName, $"LocationName is {OffsetToLocationName} instead of 1");
            OffsetToAddress1 = reader.GetOrdinal("Address1");
            Assert(2 == OffsetToAddress1, $"OffsetToAddress1 is {OffsetToAddress1} instead of 2");
            OffsetToAddress2 = reader.GetOrdinal("Address2");
            Assert(3 == OffsetToAddress2, $"OffsetToAddress2 is {OffsetToAddress2} instead of 3");
            OffsetToCity = reader.GetOrdinal("City");
            Assert(4 == OffsetToCity, $"OffsetToCity is {OffsetToCity} instead of 4");
            OffsetToState = reader.GetOrdinal("State");
            Assert(5 == OffsetToState, $"OffsetToState is { OffsetToState } instead of 5");
            OffsetToZip = reader.GetOrdinal("Zip");
            Assert(6 == OffsetToZip, $"OffsetToZip is {OffsetToZip} instead of 6");
        }
        public LocationsDAL ToLocations(SqlDataReader reader)
        {
            LocationsDAL proposedReturnValue = new LocationsDAL();
            proposedReturnValue.LocationID = reader.GetInt32(OffsetToLocationID);
            proposedReturnValue.LocationName = reader.GetString(OffsetToLocationName);
            proposedReturnValue.Address1 = reader.GetString(OffsetToAddress1);
            proposedReturnValue.Address2 = reader.GetString(OffsetToAddress2);
            proposedReturnValue.City = reader.GetString(OffsetToCity);
            proposedReturnValue.State = reader.GetString(OffsetToState);
            proposedReturnValue.Zip = reader.GetString(OffsetToZip);

            return proposedReturnValue;
        }
    }
}
