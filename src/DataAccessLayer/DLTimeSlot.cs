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
    public class DLTimeSlot
    {
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();

        public string SaveUpdateSlot(int BranchLectureDetailID, int BranchID, string DayName, DateTime STime, DateTime ETime, DateTime SSTime, DateTime SETime, int IsActive, int IsDeleted, string UpdatedDate,int UpdatedByUserID)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveUpdateTimeSlot_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchLectureDetailID", BranchLectureDetailID);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@DayName", DayName);
            cmd.Parameters.AddWithValue("@STime", STime);
            cmd.Parameters.AddWithValue("@ETime", ETime);
            cmd.Parameters.AddWithValue("@SSTime", SSTime );
            cmd.Parameters.AddWithValue("@SETime", SETime );
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }

        // To Bind Grid 
        public DataSet BindFullGrid(int BranchLectureDetailID, string BranchName, string DayName)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("BindTimeSlot_SP", conn);
            cmd.Parameters.AddWithValue("@BranchLectureDetailID", BranchLectureDetailID);
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            cmd.Parameters.AddWithValue("@DayName", DayName);


            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
