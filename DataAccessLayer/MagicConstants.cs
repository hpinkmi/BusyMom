using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MagicConstants
    {
        
            //Admin
            public const int AdminRole = 1;
            public const string Admin = "Admins";
            //Parent who is not an admin
            public const int PowerRole = 2;
            public const string PowerRoleName = "Parent";
            //nonparent ex. Grandparent, Aunt, Uncle, family friend
            public const int NormalRole = 3;
            public const string NormalRoleName = "NonParent";
            //the child
            public const int ChildRole = 4;
            public const string ChildRoleName = "Child";
            //NonUser
            public const int Unknown = 6;
            public const string NoneName = "Unknown";

            //public const int NonUser = 5;
            //public const string NonUser = "None";
            public const int ParentAbove = 5;
            public const string ParentAboveName = "Admins,Parent";
            public const int ChildAbove = 6;
            public const string ChildAboveName = "Child,Parent,Admins";

            public const int DefaultDefaultPageSize = 3;
            public const int DefaultPageNumber = 0;
            public const int MinPasswordLength = 6;
            public const int MaxPasswordLength = 18;
            public const int SaltSize = 20;
            public const string PasswordRequirementsMessage = "The Password must contain at Least One Capital letter, One Lowercase letter and One Number";
            public const string PasswordRequirements = @"^((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])).+$";

        
    }
}
