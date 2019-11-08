using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class UsersMapper : Mapper
    {
        int OffsetToUserID;
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
            OffsetToLastName = reader.GetOrdinal("LastName");
            OffsetToFirstName = reader.GetOrdinal("FirstName");
            OffsetToEmail = reader.GetOrdinal("Email");
            OffsetToPhone = reader.GetOrdinal("Phone");
            OffsetToUserName = reader.GetOrdinal("UserName");
            OffsetToHash = reader.GetOrdinal("Hash");
            OffsetToSalt = reader.GetOrdinal("Salt");
            
            Assert(OffsetToUserID == 0, $"OffsetToUserID is {OffsetToUserID} not 0 as expected");
            Assert(OffsetToLastName == 1, $"OffsetToLastName is {OffsetToLastName} not 1 as expected");
            Assert(OffsetToFirstName == 2, $"OffsetToFirstName is {OffsetToFirstName} not 2 as expected");
            Assert(OffsetToEmail == 3, $"OffsetToEmail is {OffsetToEmail} not 3 as expected");
            Assert(OffsetToPhone == 4, $"OffsetToPhone is {OffsetToPhone} not 4 as expected");
            Assert(OffsetToUserName == 5, $"OffsetToUserName is {OffsetToUserName} not 5 as expected");
            Assert(OffsetToHash == 6, $"OffsetToHash is {OffsetToHash} not 6 as expected");
            Assert(OffsetToSalt == 7, $"OffsetToSalt is {OffsetToSalt} not 7 as expected");
        }
        public UsersDAL ToUser(SqlDataReader reader)
        {
            UsersDAL proposedRV = new UsersDAL();

            proposedRV.UserID = reader.GetInt32(OffsetToUserID);
            proposedRV.LastName = reader.GetString(OffsetToLastName);
            proposedRV.FirstName = reader.GetString(OffsetToFirstName);
            proposedRV.Email = reader.GetString(OffsetToEmail);
            proposedRV.Phone = reader.GetString(OffsetToPhone);
            proposedRV.UserName = reader.GetString(OffsetToUserName);
            proposedRV.Hash = reader.GetString(OffsetToHash);
            proposedRV.Salt = reader.GetString(OffsetToSalt);



            return proposedRV;
        }
    }
}
