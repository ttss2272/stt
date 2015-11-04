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
    public class DLAddClass
    {
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();
        public string saveAddClass(int id, string ClassName, string ShortName, int Board, string Color)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("Usp_SaveAddClass", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("ClassName", ClassName);
            cmd.Parameters.AddWithValue("ShortName", ShortName);
            cmd.Parameters.AddWithValue("Board", Board);
            cmd.Parameters.AddWithValue("Color", Color);
            conn.Open();
            result = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return result;
        }
    }
}
