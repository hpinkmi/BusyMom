﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserGroupsDAL
    {
        #region columns from primary table
        public int UserID { get; set;}
        public int GroupID { get; set; }
        public int RoleID { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set;}
        public string GroupName { get; set; }

        #endregion


        public override string ToString()
        {
            return $"UserID:{UserID} GroupID:{GroupID} RoleID: {RoleID}";
        }
    }
}
