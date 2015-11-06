using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLSubject
    {
        DLSubject objSubject = new DLSubject();

        public string SaveSubject(int SubjectID, string SubjectName, string SubjectShortName, int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDeleted)
        {
            string Result = objSubject.SaveSubject(SubjectID, SubjectName, SubjectShortName, UpdatedByUserID, UpdatedDate, IsActive,IsDeleted);
                return Result;
        }

        //To Bind DropDown
        public DataSet GetSubject(int SubjectID)
        {
            DataSet ds = objSubject.GetSubject(SubjectID);
            return ds;
        }

         //To Bind Gridview
        public DataSet BindSubject(int SubjectID)
        {
            DataSet ds = objSubject.BindSubject(SubjectID);
            return ds;
        }
        //For Edit Details
        public DataSet GetSubjectDetail(string SubjectName,string ShortName)
        {
            DataSet ds = objSubject.GetSubjectDetail(SubjectName,ShortName);
            return ds;
        }

        public string DeleteSubject(int SubjectID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = objSubject.DeleteSubject(SubjectID, UpdatedByUserID, UpdatedDate);
            return Result;
        }

        public DataSet SearchSubject(string SubjectName)
        {
            DataSet ds = objSubject.SearchSubject(SubjectName);
            return ds;
        }

    }
}
