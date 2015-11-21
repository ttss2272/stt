using System;
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
        public DataSet GetBatchBySubject(int BranchID, int SubjectID)
        {
            DataSet ds = objTeacherSubject.GetBatchBySubject(BranchID, SubjectID);
            return ds;
        }
    }
}
