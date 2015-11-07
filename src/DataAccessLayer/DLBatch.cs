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
        public string saveBatch(int BatchID, int ClassID, string BatchName, string BatchCode, int LectureDuration, int IsLunchBreak, int LunchBreakStartTime, int LunchBreakEndTime, int MaxNoLecturesDay, int MaxNoLecturesWeek, int IsAllowMoreThanOneLectInBatch, int MaxNoOfLecureInRow, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveBatch_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@BatchName", BatchName);
            cmd.Parameters.AddWithValue("@BatchCode", BatchCode);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            cmd.Parameters.AddWithValue("@LectureDuration", LectureDuration);
            cmd.Parameters.AddWithValue("@IsLunchBreak", IsLunchBreak);
            cmd.Parameters.AddWithValue("@LunchBreakStartTime", LunchBreakStartTime);
            cmd.Parameters.AddWithValue("@LunchBreakEndTime", LunchBreakEndTime);
            cmd.Parameters.AddWithValue("@MaxNoLecturesDay", MaxNoLecturesDay);
            cmd.Parameters.AddWithValue("@MaxNoLecturesWeek", MaxNoLecturesWeek);
            cmd.Parameters.AddWithValue("@IsAllowMoreThanOneLectInBatch", IsAllowMoreThanOneLectInBatch);
            cmd.Parameters.AddWithValue("@MaxNoOfLecureInRow", MaxNoOfLecureInRow);
            conn.Open();
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;
        }

        //To Bind Gridview
        public DataSet BindBatch(int BatchID, string BatchName)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("BindBatch_SP", conn);
            cmd.Parameters.AddWithValue("BatchID", BatchID);
            cmd.Parameters.AddWithValue("BatchName", BatchName);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public string DeleteBatch(int BatchID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("DeleteBatch_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }

        //For Edit Details
        public DataSet GetBatchDetail(string BatchName, string BatchCode )
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetBatchDetail_SP", conn);
            cmd.Parameters.AddWithValue("@BatchName", BatchName);
            cmd.Parameters.AddWithValue("@BatchCode", BatchCode);
            //cmd.Parameters.AddWithValue("@ClassID", ClassID);           

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet SearchBatch(string BatchName)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SearchBatch_SP", conn);
            cmd.Parameters.AddWithValue("BatchName", BatchName);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;

        }
    }
}
