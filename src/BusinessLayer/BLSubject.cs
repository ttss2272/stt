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

        public string SaveSubject(int SubjectID, string SubjectName, string SubjectShortName, int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string Result = objSubject.SaveSubject(SubjectID, SubjectName, SubjectShortName, UpdatedByUserID, UpdatedDate, IsActive);
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
        public DataSet GetSubjectDetail(int SubjectID)
        {
            DataSet ds = objSubject.GetSubjectDetail(SubjectID);
            return ds;
        }
    }
}
