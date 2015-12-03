using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLTimeTable
    {
       
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();
        public DataSet BindTimeTable()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindGridTimeTable_SP", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindDay(int BatchID, int RoomID, int TeacherID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindDay_SP", conn);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindTimeSlot(int BatchAvailableID, int BatchID, int Day)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTimeSlotDropDown_SP", conn);
            cmd.Parameters.AddWithValue("@BatchAvailableID", BatchAvailableID);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@Day", Day);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }


        public string SaveTimeTable(int TimeTableID, DateTime TTStartTime, int BatchID, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string Result = null;

            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveTimeTable_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TimeTableID", TimeTableID);
            cmd.Parameters.AddWithValue("@TimeTableStartDate", TTStartTime);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }
    }
}
