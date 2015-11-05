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
        public string saveAddClass(int ClassID, string ClassName, string ShortName, int Board, string Color, int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("Usp_SaveClass", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ClassID", ClassID);
            cmd.Parameters.AddWithValue("ClassName", ClassName);
            cmd.Parameters.AddWithValue("ShortName", ShortName);
            cmd.Parameters.AddWithValue("Board", Board);
            cmd.Parameters.AddWithValue("Color", Color);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            conn.Open();
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;
        }

        //To Bind Gridview
        public DataSet BindClass(int ClassID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindClass_SP", conn);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
