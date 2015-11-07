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
    }
}
