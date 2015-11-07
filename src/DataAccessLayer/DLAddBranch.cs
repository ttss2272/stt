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
        public string SaveBranch(int BranchID, string BranchName, string BranchCode, string InstituteName, string Logo, int CreatedByUserID, int UpdatedByUserID, string UpdatedDate,int IsActive,int IsDelete)
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
            cmd.Parameters.AddWithValue("@IsDelete", IsDelete);

            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }

        public DataSet GetBranchDetail(int BranchID, string BranchName,string BranchCode)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetBranch_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
           
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public string DeleteBranch(int BranchID,int UpdatedByUserId,string UpdatedDate)
        {
            string Result = null;
            con = conn.getConnection();

            SqlCommand cmd = new SqlCommand("DeleteBranch_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@UpdatedByUserId", UpdatedByUserId);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

           
            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }

        public DataSet BindBranchName()
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("BindBranchName_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public DataSet SearchBranch(string BranchName)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SearchBranch_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public DataSet BindInsituteName()
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("BindInstituteName_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public DataSet GetBranchCount()
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetBranchCount_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }
    }
}
