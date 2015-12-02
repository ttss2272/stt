using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLTeacherSubject
    {
        DBConnection con = new DBConnection();
        SqlConnection conn = new SqlConnection();

        public DataSet GetBatchBySubject(int BranchID, int SubjectID,int TeacherID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetBatchOnSubject_SP", conn);


            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
        

        public string SaveTeacherSubject(int TeacherID, int BatchsubjectID, int UpdatedByUserID, string UpdatedDate, string IsActive, int IsDeleted)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveTeacherBatchSubject_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);

            cmd.Parameters.AddWithValue("@BatchsubjectID", BatchsubjectID);

            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }

        public DataSet GetBranchSubject(int BranchID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetBranchSubject_SP", conn);


            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
