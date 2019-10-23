using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GroupsBLL
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public GroupsBLL(GroupsDAL groups)
        {
            GroupID = groups.GroupID;
            GroupName = groups.GroupName;
        }
        public GroupsBLL()
        {

        }
    }
}
