using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserGroupsDAL
    {
        public int UserID { get; set;}
        public int GroupID { get; set; }
        public int RoleID { get; set; }
        public override string ToString()
        {
            return $"{UserID,5} {GroupID,5}{RoleID,5}";
        }
    }
}
