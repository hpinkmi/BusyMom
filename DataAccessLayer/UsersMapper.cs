﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class UsersMapper : Mapper
    {
        int OffsetToUserID;
        int OffsetToGroupID;
        int OffsetToLastName;
        int OffsetToFirstName;
        int OffsetToEmail;
        int OffsetToPhone;
        int OffsetToUserName;
        int OffsetToHash;
        int OffsetToSalt;

        public UsersMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            OffsetToGroupID = reader.GetOrdinal("GroupID");
            OffsetToLastName = reader.GetOrdinal("LastName");
            OffsetToFirstName = reader.GetOrdinal("FirstName");
            OffsetToEmail = reader.GetOrdinal("Email");
            OffsetToPhone = reader.GetOrdinal("Phone");
            OffsetToUserName = reader.GetOrdinal("UserName");
            OffsetToHash = reader.GetOrdinal("Hash");
            OffsetToSalt = reader.GetOrdinal("Salt");

            Assert(OffsetToUserID == 0, "OffsetToUserID is {OffsetToUserID} not 0 as expected");
            Assert(OffsetToGroupID == 2, "OffsetToGroupID is {OffsetToGroupID} not 2 as expected");
            Assert(OffsetToLastName == 3, "OffsetToLastName is {OffsetToLastName} not 3 as expected");
            Assert(OffsetToFirstName == 4, "OffsetToFirstName is {OffsetToFirstName} not 4 as expected");
            Assert(OffsetToEmail == 5, "OffsetToEmail is {OffsetToEmail} not 5 as expected");
            Assert(OffsetToPhone == 6, "OffsetToPhone is {OffsetToPhone} not 6 as expected");
            Assert(OffsetToUserName == 7, "OffsetToUserName is {OffsetToUserName} not 7 as expected");
            Assert(OffsetToHash == 8, "OffsetToHash is {OffsetToHash} not 8 as expected");
            Assert(OffsetToSalt == 9, "OffsetToSalt is {OffsetToSalt} not 9 as expected");
        }
        public UsersDAL ToUsers(SqlDataReader reader)
        {
            UsersDAL proposedRV = new UsersDAL();

            proposedRV.UserID = reader.GetInt32(OffsetToUserID);
            proposedRV.GroupID = reader.GetInt32(OffsetToGroupID);
            proposedRV.LastName = reader.GetString(OffsetToLastName);
            proposedRV.FirstName = reader.GetString(OffsetToFirstName);
            proposedRV.Email = reader.GetString(OffsetToEmail);
            proposedRV.Phone = reader.GetString(OffsetToPhone);
            proposedRV.UserName = reader.GetString(OffsetToUserName);
            proposedRV.Hash = reader.GetString(OffsetToHash);
            proposedRV.Salt = reader.GetString(OffsetToSalt);
        }
    }
}