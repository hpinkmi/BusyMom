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
            switch(_con.State)
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
            using (SqlCommand command = new SqlCommand("RoleFindByID",_con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    RoleMapper rm = new RoleMapper(reader);
                    int count = 0;
                    while(reader.Read())
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
        public List<RoleDAL> RoleGetAll(int Skip, int Take)
        {
            List<RoleDAL> proposedReturnValue = new List<RoleDAL>();
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleGetAll",_con))
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
        public int RolesObtainCount()
        {
            int proposedReturnValue = 0;
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RolesObtainCount", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                proposedReturnValue = (int)command.ExecuteScalar();
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
        public int RoleUpdateSafe(int RoleID, string OldRoleName, string NewRoleName)
        {

            EnsureConnected();
            using (SqlCommand command = new SqlCommand("RoleUpdateSafe", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@OldRoleName", OldRoleName);
                command.Parameters.AddWithValue("@NewRoleName", NewRoleName);
                return command.ExecuteNonQuery();


            }

        }
        #endregion role stuff


    }

}

