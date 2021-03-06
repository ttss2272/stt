﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLTeacherSubject
    {
        DLTeacherSubject objTeacherSubject = new DLTeacherSubject();
        public DataSet GetBatchBySubject(int BranchID, int SubjectID,int TeacherID)
        {
            DataSet ds = objTeacherSubject.GetBatchBySubject(BranchID, SubjectID,TeacherID);
            return ds;
        }

        public string SaveTeacherSubject(int TeacherID, int BatchsubjectID, int UpdatedByUserID, string UpdatedDate, string IsActive, int IsDeleted)
        {
            string Result = objTeacherSubject.SaveTeacherSubject(TeacherID, BatchsubjectID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            return Result;
        }

        public DataSet GetBranchSubject(int BranchID)
        {
            DataSet ds = objTeacherSubject.GetBranchSubject(BranchID);
            return ds;
        }

        public DataSet BindTeacherSubject(int TeacherID)
        {
            DataSet ds = objTeacherSubject.BindTeacherSubject(TeacherID);
            return ds;
        }
    }
}
