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
        public string saveBatch(int BatchID, int ClassID, string BatchName, string BatchCode, int LectureDuration, int IsLunchBreak, string LunchBreakStartTime, string LunchBreakEndTime, int MaxNoLecturesDay, int MaxNoLecturesWeek, int IsAllowMoreThanOneLectInBatch, int MaxNoOfLecureInRow, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
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

        public string SaveBatchSubject(int SubjectID, int BatchID, int NoLectPerDay, int NoLectPerWeek, int UpdatedByUserID, string UpdatedDate, int Active, int IsDeleted)
        {
            string Result = null;

            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveBatchSubject_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@NoLectPerDay", NoLectPerDay);
            cmd.Parameters.AddWithValue("@NoLectPerWeek", NoLectPerWeek);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", Active);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;

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
        public DataSet GetBatchDetail(string BatchName, string BatchCode)
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

        public DataSet BindBatchName()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindBatchName_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindBranchBatch(int BranchID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindBranchBatch_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet GetBatchSubject(int BatchID, int SubjectID)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetBatchSubject_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindBatchDropDown()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindBatchName_SP", conn);


           
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public string DeleteBatchSubject(int BatchID, int SubjectID, int UpdatedByUserID, string UpdatedDate)
        {
            throw new NotImplementedException();
        }

        public DataSet BindBatchAvail()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetNoOfDaysBatchAvailable_SP", conn);


            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public string SaveBatchAvailibility(int BatchID, string Day, string FinalStartTime, string FinalEndTime, int UpdatedByUserID, string UpdatedDate, int Active, int IsDeleted)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveBatchAvailable_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@Day", Day);
            cmd.Parameters.AddWithValue("@StartTime", FinalStartTime);
            cmd.Parameters.AddWithValue("@EndTime", FinalEndTime);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", Active);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
 
        }
    }
}
