using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocationsDAL
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"{LocationID,5}{LocationName,50}{Address1,100}{Address2,100}{City,100}{State,5}{Zip,5}";
        }
    }
}
