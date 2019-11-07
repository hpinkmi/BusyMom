using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Logger;

namespace DataAccessLayer
{
    //stack
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
            try
            {
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<RoleDAL> RolesGetAll(int Skip, int Take)
        {
            List<RoleDAL> proposedReturnValue = new List<RoleDAL>();
            try
            {
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int RolesObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RolesObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            
            return proposedReturnValue;
        }

        public int RoleCreate(string RoleName)
        {
            int proposedReturnValue = 0;
            try
            {
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int RoleCreateIDReturned(string RoleName)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleCreateIDReturned", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", RoleName);


                    proposedReturnValue = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public void RoleDelete(int RoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("RoleDelete", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.ExecuteNonQuery();


                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
                {

            }

        }
        public void RoleUpdateJust(int RoleID, string RoleName)
        {
            try
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
            catch ( Exception ex) when (Logger.Logger.Log(ex))
            {

            }

        }
        #endregion role stuff
        #region users 

        public UsersDAL UserFindByID(int UserID)
        {
            UsersDAL proposedReturnValue = null;
                try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserFindByID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
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
                            throw new Exception($"{count} Multiple Users found for UserID {UserID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public UsersDAL UsersFindbyEmail(string Email)
        {
            UsersDAL proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersFindbyEmail", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);
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
                                    throw new Exception($"{count}Multiple Users found for Email {Email}");
                                }
                            }
                        }

                    }
                    return proposedReturnValue;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public UsersDAL UsersFindbyUserName(string UserName)
        {
            UsersDAL proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersFindbyUserName", _con))
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
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<UsersDAL> UsersGetAll(int Skip, int Take)
        {
            List<UsersDAL> proposedReturnValue = new List<UsersDAL>();
            try
            {
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<UsersDAL> UsersGetAllbyActivityID(int skip, int take, int ActivityID)
            {
                List<UsersDAL> proposedReturnValue = new List<UsersDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersGetAllActivityID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
                return proposedReturnValue;
            }
        public List<UsersDAL> UsersGetAllbyGroupID (int skip, int take, int GroupID)
        {
            List<UsersDAL> proposedReturnValue = new List<UsersDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersGetAllGroupID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@GroupID", GroupID);
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int UsersObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }

        public int UserCreate(string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@Salt", Salt);
                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = (int)command.Parameters["@UserID"].Value;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int UserCreateIDReturn(string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            int proposedReturnValue = 0;
            try
            {
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public void UsersDelete(int UserID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UsersDelete", _con))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserID", UserID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        public void UsersUpdateJust(int UserID, string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            try
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
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }

        #endregion
        #region Groups
        public GroupsDAL GroupsFindbyID(int GroupID)
        {
           
            GroupsDAL proposedReturnValue = null;
            try
            {
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<GroupsDAL> GroupsGetAll(int Skip, int Take)
                {
                List<GroupsDAL> proposedReturnValue = new List<GroupsDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsGetAll", _con))
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
                    return proposedReturnValue;
                }
        public List<GroupsDAL> GroupsGetAllbyActivityID(int ActivityID, int Skip,int Take)
        {
            List<GroupsDAL> proposedReturnValue = new List<GroupsDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsGetAllbyActivityID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", Skip);
                    command.Parameters.AddWithValue("@take", Take);
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
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
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int GroupsObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }

            return proposedReturnValue;
        }
        public int GroupsCreate(string GroupName)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupName", GroupName);
                    command.Parameters.AddWithValue("@GroupID",0);
                    command.Parameters["@GroupID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = (int)command.Parameters["@GroupID"].Value;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public void GroupsDelete(int GroupID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsDelete",_con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", GroupID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        public void GroupsUpdateJust(int GroupID, string GroupName)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsUpdateJust", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupId", GroupID);
                    command.Parameters.AddWithValue("@GroupName", GroupName);
                    object datareturned = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
          
        }

        #endregion Groups
        #region UserGroups
        public void UserGroupsCreate(int UserID, int GroupID, int RoleID )
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserGroupsCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@GroupID", GroupID);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            
        }
        public void UserGroupsDelete(int UserID, int GroupID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserGroupsDelete", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@GroupID", GroupID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }

        }
        public int UserGroupsObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserGroupsObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }

            return proposedReturnValue;
        }
        #endregion UserGroup
        #region GroupActivities
        public int GroupActivitiesCreate(int GroupID, int ActivityID, string ActivityOwner)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupActivitiesCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", GroupID);
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    command.Parameters.AddWithValue("@ActivityOwner", ActivityOwner);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int GroupActivitiesObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public void GroupActivitiesDelete(int GroupID, int ActivityID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupActivitiesDelete", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", GroupID);
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }

        #endregion GroupActivities
        #region UserActivies
        public void UserActivitiesCreate(int UserID, int ActivityID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserActivitiesCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        public void UserActivitiesDelete(int UserID, int ActivityID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserActivitiesDelete", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        public int UserActivitiesObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserActivitiesObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }

            return proposedReturnValue;
        }
        #endregion UserActivities
        #region Activities Stuff
        public ActivitiesDAL ActivitiesFindByID(int ActivityID)
        {
            ActivitiesDAL proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitiesFindByID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ActivitiesMapper rm = new ActivitiesMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            proposedReturnValue = rm.ToActivities(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple Activities found for ID {ActivityID}");
                        }

                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public ActivitiesDAL ActivitiesFindbyLocationID(int LocationID)
        {
            ActivitiesDAL proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitiesFindByLocationID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocationID", LocationID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ActivitiesMapper rm = new ActivitiesMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            proposedReturnValue = rm.ToActivities(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple Activities found for LocationID {LocationID}");
                        }

                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        
            return proposedReturnValue;
        }
        public List<ActivitiesDAL> ActivitiesGetAll(int Skip, int Take)
        {
            List<ActivitiesDAL> proposedReturnValue = new List<ActivitiesDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitiesGetAll", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", Skip);
                    command.Parameters.AddWithValue("@take", Take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ActivitiesMapper rm = new ActivitiesMapper(reader);

                        while (reader.Read())
                        {
                            ActivitiesDAL item = rm.ToActivities(reader);
                            proposedReturnValue.Add(item);

                        }
                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<ActivitiesDAL> ActivitiesGetAllbyGroupID(int Skip, int Take, int GroupID)
        {
            List<ActivitiesDAL> proposedReturnValue = new List<ActivitiesDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitiesGetAllbyGroupID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", Skip);
                    command.Parameters.AddWithValue("@take", Take);
                    command.Parameters.AddWithValue("@GroupID", GroupID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ActivitiesMapper rm = new ActivitiesMapper(reader);

                        while (reader.Read())
                        {
                            ActivitiesDAL item = rm.ToActivities(reader);
                            proposedReturnValue.Add(item);

                        }
                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<ActivitiesDAL> ActivitiesGetAllbyUserID(int Skip, int Take, int UserID)
        {
            List<ActivitiesDAL> proposedReturnValue = new List<ActivitiesDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitiesGetAllbyUserID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", Skip);
                    command.Parameters.AddWithValue("@take", Take);
                    command.Parameters.AddWithValue("@GroupID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ActivitiesMapper rm = new ActivitiesMapper(reader);

                        while (reader.Read())
                        {
                            ActivitiesDAL item = rm.ToActivities(reader);
                            proposedReturnValue.Add(item);

                        }
                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ActivitiesObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitiesObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when(Logger.Logger.Log(ex))
            {

            }

            return proposedReturnValue;
        }
        public int ActivitiesCreate(string ActivityName, string Approveby, DateTime TimeofActivity, int LocationID, DateTime ApproveTime)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitesCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ActivityID", 0);
                    command.Parameters.AddWithValue("@ActivityName", ActivityName);
                    command.Parameters.AddWithValue("@Approveby", Approveby);
                    command.Parameters.AddWithValue("@TimeofActivity", TimeofActivity);
                    command.Parameters.AddWithValue("@LocationID", LocationID);
                    command.Parameters.AddWithValue("@ApproveTime", ApproveTime);
                    command.Parameters["@ActivityID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = (int)command.Parameters["@ActivityID"].Value;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        // returns the new id as a scaler
        public void ActivitiesDelete(int ActivityID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ActivitesDelete", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    command.ExecuteNonQuery();


                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        public void ActivitiesUpdateJust(int ActivityID, string ActivityName, string Approveby, DateTime TimeofActivity, int LocationID, DateTime ApproveTime)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UserUpdateJust", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ActivityID", ActivityID);
                    command.Parameters.AddWithValue("@ActivityName", ActivityName);
                    command.Parameters.AddWithValue("@Approveby", Approveby);
                    command.Parameters.AddWithValue("@TimeofActivity", TimeofActivity);
                    command.Parameters.AddWithValue("@LocationID", LocationID);
                    command.Parameters.AddWithValue("@ApproveTime", ApproveTime);
                    object datareturned = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }

        }
        #endregion
        #region Locations Stuff
        public LocationsDAL LocationFindByID(int LocationID)
        {
            //try
            //{
                LocationsDAL proposedReturnValue = null;
            try
            { 
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationFindByID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocationID", LocationID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        LocationsMapper rm = new LocationsMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            proposedReturnValue = rm.ToLocations(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"{count} Multiple Locations found for ID {LocationID}");
                        }

                    }
                }
                return proposedReturnValue;
            }
            catch (Exception ex) when(Logger.Logger.Log(ex))
            {
                //Logger.Logger.Log(ex);
                //return View("Error", ex);
            }
            return proposedReturnValue;
        }
        public List<LocationsDAL> LocationGetAll(int Skip, int Take)
        {
            //try
            //{
                List<LocationsDAL> proposedReturnValue = new
                List<LocationsDAL>();
            try
            { 
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationGetAll", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", Skip);
                    command.Parameters.AddWithValue("@take", Take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        LocationsMapper rm = new LocationsMapper(reader);

                        while (reader.Read())
                        {
                            LocationsDAL item = rm.ToLocations(reader);
                            proposedReturnValue.Add(item);

                        }
                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int LocationsObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                //int proposedReturnValue = -1;
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationsObtainCount", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int LocationsCreate(string LocationName, string Address1, string Address2, string City, string State, string Zip)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationCreate", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocationID", 0);
                    command.Parameters.AddWithValue("@LocationName", LocationName);
                    command.Parameters.AddWithValue("@Address1", Address1);
                    command.Parameters.AddWithValue("@Address2", Address2);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@State", State);
                    command.Parameters.AddWithValue("@Zip", Zip);
                    command.Parameters["@LocationID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = (int)command.Parameters["@LocationID"].Value;
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }
        // returns the new id as a scaler
        public int LocationCreateIDReturned(string LocationName, string Address1, string Address2, string City, string State, string Zip)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationCreateIDReturned", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocationName", LocationName);
                    command.Parameters.AddWithValue("@Address1", Address1);
                    command.Parameters.AddWithValue("@Address2", Address2);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@State", State);
                    command.Parameters.AddWithValue("@Zip", Zip);

                    proposedReturnValue = Convert.ToInt32(command.ExecuteScalar());
                }
                //return proposedReturnValue;
            }
            catch (Exception ex) when(Logger.Logger.Log(ex))
            {
            }
            return proposedReturnValue;
        }
        public void LocationDelete(int LocationID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationDelete", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocationID", LocationID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        public void LocationUpdateJust(int LocationID, string LocationName, string Address1, string Address2, string City, string State, string Zip)
        {
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("LocationUpdateJust", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocationID", LocationID);
                    command.Parameters.AddWithValue("@LocationName", LocationName);
                    command.Parameters.AddWithValue("@Address1", Address1);
                    command.Parameters.AddWithValue("@Address2", Address2);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@State", State);
                    command.Parameters.AddWithValue("@Zip", Zip);
                    object datareturned = command.ExecuteNonQuery();


                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
        }
        #endregion Location Stuff
        #region GroupRole
        public List<GroupsDAL> GroupsFindbyUserID(int skip, int take, int UserID)
        {

            List<GroupsDAL> proposedReturnValue = new List<GroupsDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GroupsFindByUserID", _con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        GroupsMapper rm = new GroupsMapper(reader);
                        //int count = 0;
                        while (reader.Read())
                        {
                            GroupsDAL item= rm.ToGroups(reader);
                            proposedReturnValue.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex) when (Logger.Logger.Log(ex))
            {

            }
            return proposedReturnValue;
        }

        #endregion

    }
}









