using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class RoleBLL
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public RoleBLL(RoleDAL role)
        {
            RoleID = role.RoleID;
            RoleName = role.RoleName;
        }
            public RoleBLL()
        {
           
        }
    }
}
