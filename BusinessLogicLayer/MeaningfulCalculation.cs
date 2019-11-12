using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer
{


    public class UserGroupStats
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int CountofUser { get; set; }
        public int CountofParents { get; set; }
        public int CountOfChild { get; set; }
        public int CountofNonParent { get; set; }
    }
    //How Many Users Are In A Group
    public class HowManyUsersInAGroup
    {
        public List<UserGroupStats> GroupCal(List<UserGroupsBLL> UserGroups,
            Dictionary<int, GroupsBLL> groups)
        {
            List<UserGroupStats> proposedReturnValue = new List<UserGroupStats>();
            IOrderedEnumerable<UserGroupsBLL> groupsort = UserGroups.OrderBy(u => u.GroupID);
            var group = groupsort.GroupBy(u => u.GroupID);
            foreach (var u in group)
            {
                UserGroupStats ugs = new UserGroupStats();
                ugs.GroupID = u.Key;
                ugs.GroupName = groups[u.Key].GroupName;
                ugs.CountofUser = u.Count();
                ugs.CountofParents = u.Count(x => x.RoleID == 2);
                ugs.CountOfChild = u.Count(x => x.RoleID == 4);
                ugs.CountofNonParent = u.Count(x => x.RoleID == 3);
                proposedReturnValue.Add(ugs);
            }
            return proposedReturnValue;
        }

    }

}


