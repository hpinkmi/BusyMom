using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyMomWeb.Models
{
    public class MagicConstants
    {
        //Admin
        public const int AdminRole = 1;
        public const string AdminRoleName = "Administrator";
        //Parent who is not an admin
        public const int PowerRole = 2;
        public const string PowerRoleName = "Parent";
        //nonparent ex. Grandparent, Aunt, Uncle, family friend
        public const int NormalRole = 3;
        public const string NormalRoleName = "NonParent";
        //the child
        public const int ChildRole = 4;
        public const string ChildRoleName = "Child";

        public const int DefaultDefaultPageSize = 3;
        public const int DefaultPageNumber = 0;
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 18;
        public const int SaltSize = 20;
        public const string PasswordRequirementsMessage = "The Password must contain at Least One Capital letter, One Lowercase letter and One Number";
        public const string PasswordRequirements = @"^((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])).+$";


    }
}