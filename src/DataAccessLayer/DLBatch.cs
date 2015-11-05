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
        public string saveBatch(int id, int ClassID, string BatchName, string BatchCode, int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("Usp_SaveBatch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("ClassID", ClassID);
            cmd.Parameters.AddWithValue("BatchName", BatchName);
            cmd.Parameters.AddWithValue("BatchCode", BatchCode);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            conn.Open();
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;
        }

        //To Bind Gridview
        public DataSet BindBatch(int BatchID)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("BindBatch_SP", conn);
            cmd.Parameters.AddWithValue("BatchID", BatchID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
