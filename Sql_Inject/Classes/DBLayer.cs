using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sql_Inject.Classes
{
    public class DBLayer
    {
        SqlConnection con;
        SqlCommand cmd;

        public DataTable executeQuery(String query, String Uid, String Passwd)
        {
            DataTable dt = null;
            using (con = new SqlConnection(ConfigurationManager.AppSettings["ConString"] + ""))
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpId", Uid);
                cmd.Parameters.AddWithValue("@Pswd", Passwd);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //sda.SelectCommand = cmd;
                dt = new DataTable();

                sda.Fill(dt);
                return dt;

            }
        }

        public DataTable executeQuery(String Uid, String Passwd)
        {
            DataTable dt = null;
            using (con = new SqlConnection(ConfigurationManager.AppSettings["ConString"] + ""))
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                cmd = new SqlCommand("proc_", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", Uid);
                cmd.Parameters.AddWithValue("@Pswd", Passwd);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //sda.SelectCommand = cmd;
                dt = new DataTable();

                sda.Fill(dt);
                return dt;

            }
        }

    }
}