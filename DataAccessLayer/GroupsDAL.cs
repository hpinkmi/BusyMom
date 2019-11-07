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
        //indirect properties
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public override string ToString()
        {
            return $"Groups: GroupID:{GroupID} GroupName:{GroupName,5}UserID:{UserID} Role:{RoleID} RoleName:{RoleName,5}";
        }
    }
}
