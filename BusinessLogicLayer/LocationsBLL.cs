using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class LocationsBLL
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set;}
        public string State { get; set; }
        public string Zip { get; set; }
        public LocationsBLL(LocationsDAL location)
        {
            LocationID = location.LocationID;
            LocationName = location.LocationName;
            Address1 = location.Address1;
            Address2 = location.Address2;
            City = location.City;
            State = location.State;
            Zip = location.Zip;
        }
        public LocationsBLL()
        {

        }
    }
}
