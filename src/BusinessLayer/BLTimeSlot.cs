using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;


namespace BusinessLayer
{
   public class BLTimeSlot
    {
        DLTimeSlot obj_TSlot = new DLTimeSlot();

        public string SaveUpdateSlot(int BranchLectureDetailID, int BranchID, string DayName, DateTime STime, DateTime ETime, DateTime SSTime, DateTime SETime, int IsActive, int IsDeleted, string UpdatedDate, int UpdatedByUserID)
        {
            string result = obj_TSlot.SaveUpdateSlot(BranchLectureDetailID,BranchID,DayName, STime,ETime, SSTime,SETime,IsActive, IsDeleted,UpdatedDate,UpdatedByUserID);
            return result;
        }

        public DataSet BindFullGrid(int BranchLectureDetailID , string BranchName, string DayName)
        {
            DataSet ds = obj_TSlot.BindFullGrid(BranchLectureDetailID, BranchName, DayName);
            return ds;
        }


    }
}
