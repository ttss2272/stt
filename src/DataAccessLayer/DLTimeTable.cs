using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLTimeTable
    {
        DBConnection con = new DBConnection();
        SqlConnection conn = new SqlConnection();
        public DataSet BindTimeTable()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindGridTimeTable_SP", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
