using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GroupsDAL
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public override string ToString()
        {
            return $"{GroupID,5}{GroupName,5}";
        }
    }
}
