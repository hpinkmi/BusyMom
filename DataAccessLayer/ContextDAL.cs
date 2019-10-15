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
    }
}
