using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DLBatch
    {
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();
        public string saveBatch(int id, int ClassID, string BatchName, string BatchCode)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("Usp_SaveBatch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("ClassID", ClassID);
            cmd.Parameters.AddWithValue("BatchName", BatchName);
            cmd.Parameters.AddWithValue("BatchCode", BatchCode);
            conn.Open();
            result = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return result;
        }
    }
}
