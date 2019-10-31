﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace Logger
{
    static public class Logger
    {
        // the connection string is only loaded one time, at the start of the application
        static string connectionstring;
        // this is a static constructor.  It is used to initialize the static connectionstring    
        static Logger()
        {
            try
            {
                connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while getting the DefaultConnectionString for Logger");
            }
        }
        // this method is static so that it will have semantics like Console.WriteLine
        public static void Log(Exception ex)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (var com = con.CreateCommand())
                    {
                        com.CommandText = "InsertLogItem";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@message", ex.Message);
                        com.Parameters.AddWithValue("@stacktrace", ex.StackTrace.ToString());
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                var p = HttpContext.Current.Server.MapPath("~");
                p += @"ErrorLog.Log";
                System.IO.File.AppendAllText(p,
"while attempting to record the original exception to the database, this exception occurred\r\n");
                System.IO.File.AppendAllText(p, exc.ToString());
                System.IO.File.AppendAllText(p,
"This is the Original Exception that was attempting to be written to the database\r\n");
                System.IO.File.AppendAllText(p, ex.ToString());

            }

        }
    }
}
