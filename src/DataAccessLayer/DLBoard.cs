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
     public class DLBoard
    {
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();


        public string SaveBoard(int BoardID, string BoardName, int UpDatedByUserID, string UpDatedDate, int IsActive, int IsDeleted)
        {
            string Result = null;

            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveBoard_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BoardID", BoardID);
            cmd.Parameters.AddWithValue("@BoardName",BoardName);
            cmd.Parameters.AddWithValue("@UpDatedByUserID",UpDatedByUserID);
            cmd.Parameters.AddWithValue("@UpDatedDate",UpDatedDate);
            cmd.Parameters.AddWithValue("@IsActive",IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted",IsDeleted);
            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }

        public DataSet BindBoard(int BoardID, string BoardName)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindBoard_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BoardID",BoardID);
            cmd.Parameters.AddWithValue("@BoardName",BoardName);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public string DeleteBoard(int BoardID, int UpDatedByUserID, string UpDatedDate)
        {
            string Result = null;

            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("DeleteBoard_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BoardID",BoardID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpDatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpDatedDate);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }

        public DataSet GetBoard()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetBoard_SP",conn);
            cmd.CommandType= CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            conn.Close();

            return ds;
        }
    }
}
