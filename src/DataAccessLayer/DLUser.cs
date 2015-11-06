using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLUser
    {
        SqlConnection con = new SqlConnection();
        DBConnection conn = new DBConnection();

        public string SaveUser(int UserID, string UserName, string ContactNo, string Address, string MailId, string LoginName, string Password,  string UpdatedDate, int UserTypeID, int IsActive, int IsDeleted)
        {
            string Result = null;
            con = conn.getConnection();
            SqlCommand cmd = new SqlCommand("SaveUser_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@MailId", MailId);
            cmd.Parameters.AddWithValue("@LoginName", LoginName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@UserTypeID", UserTypeID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }

        public DataSet GetUser(int UserID, string UserName)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetUser_SP", con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public string DeleteUser(int UserID, string UpdatedDate)
        {
            string Result = null;
            con = conn.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteUser_SP", con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
             
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }
    }
}
