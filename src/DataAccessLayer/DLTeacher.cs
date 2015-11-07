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

        public string SaveTeacher(int TeacherID, string TeacherName, string TeacherSurname, string TeacherShortName,  int MaxNoOfMovesInBranch, int MaxLecturePerDay, int MaxLectPerWeek, int IsMoreThanOneLecture, int MaxNoOfLectInRow, int IsFirstLecture, int IsLastLecture, string FreeTimeStart, string FreeTimeEnd, int UpdatedByUserID, string UpdatedDate, int Active, int IsDeleted)
        {
            string Result = null;
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
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }
    }
}
