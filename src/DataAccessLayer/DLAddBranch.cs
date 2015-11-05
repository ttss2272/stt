using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public  class DLAddBranch
    {
      SqlConnection con = new SqlConnection();
      DBConnection conn = new DBConnection();
        public string SaveBranch(int BranchID, string BranchName, string BranchCode, string InstituteName, string Logo, int CreatedByUserID, int UpdatedByUserID, string UpdatedDate,int IsActive)
        {
            string Result = null;
            con = conn.getConnection();
            SqlCommand cmd = new SqlCommand("SaveBranch_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
            cmd.Parameters.AddWithValue("@InstituteName", InstituteName);
            cmd.Parameters.AddWithValue("@Logo", Logo);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@UpdateByUserId", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }

        public DataSet GetBranchDetail(int BranchID)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetBranch_SP", con);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public string DeleteBranch(string BranchName)
        {
            string Result = null;
            con = conn.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteBranch_SP", con);
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }
    }
}
