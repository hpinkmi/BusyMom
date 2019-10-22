using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ContextDAL : IDisposable
    {
        #region Context stuff
        SqlConnection _con = new SqlConnection();
        public void Dispose()
        {
            _con.Dispose();
        }
        void EnsureConnected()
        {
            switch (_con.State)
            {
                case (System.Data.ConnectionState.Closed):
                    _con.Open();
                    break;
                case (System.Data.ConnectionState.Broken):
                    _con.Close();
                    _con.Open();
                    break;
                case (System.Data.ConnectionState.Open):
                    break;
            }
        }
        public string ConnectionString
        {
            get
            {
                return _con.ConnectionString;
            }
            set
            {
                _con.ConnectionString = value;
            }
        }
        #endregion context stuff

        #region role stuff
        public RoleDAL RoleFindbyID(int RoleID)
        {
            RoleDAL proposedReturnValue = null;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleFindByID", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    RoleMapper rm = new RoleMapper(reader);
                    int count = 0;
                    while (reader.Read())
                    {
                        proposedReturnValue = rm.ToRole(reader);
                        count++;
                    }
                    if (count > 1)
                    {
                        throw new Exception($"{count} Mutiple Role found for ID {RoleID}");
                    }
                }
            }
            return proposedReturnValue;
        }
        public List<RoleDAL> RolesGetAll(int Skip, int Take)
        {
            List<RoleDAL> proposedReturnValue = new List<RoleDAL>();
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RolesGetAll", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@skip", Skip);
                command.Parameters.AddWithValue("@take", Take);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    RoleMapper rm = new RoleMapper(reader);

                    while (reader.Read())
                    {
                        RoleDAL item = rm.ToRole(reader);
                        proposedReturnValue.Add(item);

                    }
                }
            }
            return proposedReturnValue;



        }
        public int RoleCreate(string RoleName)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleCreate", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleName", RoleName);
                command.Parameters.AddWithValue("@RoleID", 0);
                command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();
                proposedReturnValue = (int)command.Parameters["@RoleID"].Value;
            }
            return proposedReturnValue;
        }
        public int RoleCreateIDReturned(string RoleName)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleCreateIDReturned", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleName", RoleName);


                proposedReturnValue = Convert.ToInt32(command.ExecuteScalar());
            }
            return proposedReturnValue;
        }
        public void RoleDelete(int RoleID)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleDelete", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.ExecuteNonQuery();


            }

        }
        public void RoleUpdateJust(int RoleID, string RoleName)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleUpdateJust", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@RoleName", RoleName);
                object datareturned = command.ExecuteNonQuery();


            }

        }
        #endregion role stuff



        #region users 
        public UsersDAL UsersFindByEmail(string Email)
        {
            UsersDAL proposedReturnValue = null;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserFindByEmail", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Email", Email);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    UsersMapper rm = new UsersMapper(reader);
                    int count = 0;
                    while (reader.Read())
                    {
                        proposedReturnValue = rm.ToUser(reader);
                        count++;
                    }

                    if (count > 1)
                    {
                        throw new Exception($"{count} Multiple Users found for Email {Email}");
                    }
                }
            }
            return proposedReturnValue;
        }
        public UsersDAL UserFindbyUserName(string UserName)
        {
            UsersDAL proposedReturnValue = null;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserFindbyUserName", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    UsersMapper rm = new UsersMapper(reader);
                    int count = 0;
                    while (reader.Read())
                    {
                        proposedReturnValue = rm.ToUser(reader);
                        count++;
                        {
                            if (count > 1)
                            {
                                throw new Exception($"{count}Multiple Users found for UserName {UserName}");
                            }
                        }
                    }

                }
                return proposedReturnValue;
            }
        }
        public List<UsersDAL> UserGetAll(int Skip, int Take)
        {
            List<UsersDAL> proposedReturnValue = new List<UsersDAL>();
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UsersGetAll", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@skip", Skip);
                command.Parameters.AddWithValue("@take", Take);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    UsersMapper rm = new UsersMapper(reader);

                    while (reader.Read())
                    {
                        UsersDAL item = rm.ToUser(reader);
                        proposedReturnValue.Add(item);

                    }
                }
            }
            return proposedReturnValue;
        }
        public int UserCreate(string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserCreate", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", 0);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("Phone", Phone);
                command.Parameters.AddWithValue("UserName", UserName);
                command.Parameters.AddWithValue("@Hash", Hash);
                command.Parameters.AddWithValue("@Salt", Salt);
                command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();
                proposedReturnValue = (int)command.Parameters["@UserID"].Value;
            }
            return proposedReturnValue;
        }
        public int UserCreateIDReturn(string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserCreateIDReturn", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Hash", Hash);
                command.Parameters.AddWithValue("@Salt", Salt);

                proposedReturnValue = Convert.ToInt32(command.ExecuteScalar());
            }
            return proposedReturnValue;
        }
        public void UsersDelete(int UserID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UsersDelete", _con))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("UserID", UserID);
                command.ExecuteNonQuery();
            }
        }
        public void UserUpdateJust(int UserID, string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("UserUpdateJust", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("UserID", UserID);
                command.Parameters.AddWithValue("LastName", LastName);
                command.Parameters.AddWithValue("FirstName", FirstName);
                command.Parameters.AddWithValue("Email", Email);
                command.Parameters.AddWithValue("Phone", Phone);
                command.Parameters.AddWithValue("UserName", UserName);
                command.Parameters.AddWithValue("Hash", Hash);
                command.Parameters.AddWithValue("Salt", Salt);
                object datareturned = command.ExecuteNonQuery();

            }
        }

        #endregion


        #region Groups
        public GroupsDAL GroupsFindbyID(int GroupID)
        {
            GroupsDAL proposedReturnValue = null;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("GroupsFindByID", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupID", GroupID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GroupsMapper rm = new GroupsMapper(reader);
                    int count = 0;
                    while (reader.Read())
                    {
                        proposedReturnValue = rm.ToGroups(reader);
                        count++;
                    }
                    if (count > 1)
                    {
                        throw new Exception($"{count}Multiple Groups found for ID {GroupID}");
                    }
                }
            }
            return proposedReturnValue;
        }
                public List<GroupsDAL> GroupsGetAll(int Skip, int Take)
                {
                List<GroupsDAL> proposedReturnValue = new List<GroupsDAL>();
                EnsureConnected();
                using (SqlCommand command = new SqlCommand ("GroupsGetAll", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", Skip);
                    command.Parameters.AddWithValue("@take", Take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                            GroupsMapper rm = new GroupsMapper(reader);
                            while (reader.Read())
                            {
                                GroupsDAL item = rm.ToGroups(reader);
                                proposedReturnValue.Add(item);
                            }
                    }
                }
                    return proposedReturnValue;
                }
        public 
        #endregion

    }
}









