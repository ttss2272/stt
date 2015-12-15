using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLTeacher
    {
        DBConnection con = new DBConnection();
        SqlConnection conn = new SqlConnection();

        public int SaveTeacher(int TeacherID, string TeacherName, string TeacherSurname, string TeacherShortName,  int MaxNoOfMovesInBranch, int MaxLecturePerDay, int MaxLectPerWeek, int IsMoreThanOneLecture, int MaxNoOfLectInRow, int IsFirstLecture, int IsLastLecture, string FreeTimeStart, string FreeTimeEnd, int UpdatedByUserID, string UpdatedDate, int Active, int IsDeleted)
        {
            int Result = 0;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveTeacher_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.Parameters.AddWithValue("@TeacherName", TeacherName);
            cmd.Parameters.AddWithValue("@TeacherSurname", TeacherSurname);
            cmd.Parameters.AddWithValue("@TeacherShortName", TeacherShortName);
            
            cmd.Parameters.AddWithValue("@MaxNoOfMovesInBranch", MaxNoOfMovesInBranch);
            cmd.Parameters.AddWithValue("@MaxLecturePerDay", MaxLecturePerDay);
            cmd.Parameters.AddWithValue("@MaxLectPerWeek", MaxLectPerWeek);
            cmd.Parameters.AddWithValue("@IsMoreThanOneLecture", IsMoreThanOneLecture);
            cmd.Parameters.AddWithValue("@MaxNoOfLectInRow", MaxNoOfLectInRow);
            cmd.Parameters.AddWithValue("@IsFirstLecture", IsFirstLecture);
            cmd.Parameters.AddWithValue("@IsLastLecture", IsLastLecture);
            cmd.Parameters.AddWithValue("@FreeTimeStart", FreeTimeStart);
            cmd.Parameters.AddWithValue("@FreeTimeEnd", FreeTimeEnd);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);


            conn.Open();
            Result = Convert.ToInt32( cmd.ExecuteScalar().ToString());
            conn.Close();
            return Result;
        }

        public string SaveTeacherAvailibility(int TeacherID,string Day,string StartTime,string EndTime,int UpdatedByUserID,string UpdatedDate,int IsActive,int IsDeleted)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveTeacherAvailable_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.Parameters.AddWithValue("@Day", Day);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
 
        }

        public DataSet GetTeacher(int TeacherID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTeacher_SP", conn);
            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public string DeleteTeacher(int TeacherID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("DeleteTeacher_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
 
        }

        public DataSet BindTeacher(int TeacherID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTeacher_SP", conn);
            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindTeacherAvail()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetNoOfDaysTeacherAvailable_SP", conn);
            

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet GetTeacherAvailableDetail(int TeacherID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetTeacherAvailableDetail_SP", conn);


            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
 
        }
       
        public DataSet BindTeacherDropDown(int TeacherID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTeacherName_SP", conn);


            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindTeacherOnTimeTable(int SubjectID,int BatchID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTeacherDropDown_SP", conn);


            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public int GetMaxTeacherID()
        {
            int MaxBatchID;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("GetMaxTeacherID_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            MaxBatchID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            conn.Close();
            return MaxBatchID;
 
        }
    }
}
