using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLTeacher
    {
        DLTeacher objTeacher =new DLTeacher();
        public string SaveTeacher(int TeacherID, string TeacherName, string TeacherSurname, string TeacherShortName,  int MaxNoOfMovesInBranch, int MaxLecturePerDay, int MaxLectPerWeek, int IsMoreThanOneLecture, int MaxNoOfLectInRow, int IsFirstLecture, int IsLastLecture, string FreeTimeStart, string FreeTimeEnd, int UpdatedByUserID, string UpdatedDate, int Active, int IsDeleted)
        {
            string Result = objTeacher.SaveTeacher(TeacherID, TeacherName, TeacherSurname, TeacherShortName,  MaxNoOfMovesInBranch, MaxLecturePerDay, MaxLectPerWeek, IsMoreThanOneLecture, MaxNoOfLectInRow, IsFirstLecture, IsLastLecture, FreeTimeStart, FreeTimeEnd, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
            return Result;
        }

        public string SaveTeacherAvailibility(int TeacherID,string Day,string StartTime,string EndTime,int UpdatedByUserID,string UpdatedDate,int IsActive,int IsDeleted)
        {
            string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, StartTime, EndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            return Result;
        }

        public DataSet GetTeacher(int TeacherID)
        {
            DataSet ds = objTeacher.GetTeacher(TeacherID);
            return ds;
        
        }

        public string DeleteTeacher(int TeacherID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = objTeacher.DeleteTeacher(TeacherID, UpdatedByUserID, UpdatedDate);
            return Result;
        }

        public DataSet BindTeacher(int TeacherID)
        {
            DataSet ds = objTeacher.BindTeacher(TeacherID);
            return ds;

        }

        public DataSet BindTeacherAvail()
        {
            DataSet ds = objTeacher.BindTeacherAvail();
            return ds;
        }

        public DataSet GetTeacherAvailableDetail(int TeacherID)
        {
            DataSet ds = objTeacher.GetTeacherAvailableDetail(TeacherID);
            return ds;
        }

        public DataSet BindTeacherName()
        {
            DataSet ds = objTeacher.BindTeacherName();
            return ds;
        }

        public DataSet BindTeacherDropDown(int TeacherID)
        {
            DataSet ds = objTeacher.BindTeacherDropDown(TeacherID);
            return ds;
        }
    }
}
