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

        public DataSet BindTimeSlot(int BatchAvailableID, int BatchID, int Day, int RoomAvailableID, int RoomID, int Day1, int TeacherAvailableID, int TeacherID, int Day2)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTimeSlotDropDown_SP", conn);
            cmd.Parameters.AddWithValue("@BatchAvailableID", BatchAvailableID);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);           
            cmd.Parameters.AddWithValue("@Day", Day);

            cmd.Parameters.AddWithValue("@RoomAvailableID", RoomAvailableID);
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.Parameters.AddWithValue("@Day1", Day1);

            cmd.Parameters.AddWithValue("@TeacherAvailableID", TeacherAvailableID);
            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.Parameters.AddWithValue("@Day2", Day2);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }


        public string SaveTimeTable(int TimeTableID, int TimeTableDetailID, DateTime TTStartDate, int BatchID, int RoomID, string Day, string LectStartTime, string LectEndTime, int TeacherSubjectID, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string Result = null;

            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveTimeTable_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TimeTableID", TimeTableID);
            cmd.Parameters.AddWithValue("@TimeTableDetailID", TimeTableDetailID);
            cmd.Parameters.AddWithValue("@TimeTableStartDate", TTStartDate);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.Parameters.AddWithValue("@Day", Day);
            cmd.Parameters.AddWithValue("@LectStartTime", LectStartTime);
            cmd.Parameters.AddWithValue("@LectEndTime", LectEndTime);
            cmd.Parameters.AddWithValue("@TeacherSubjectID", TeacherSubjectID);
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
