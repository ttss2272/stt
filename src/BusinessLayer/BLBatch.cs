using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessLayer;

namespace BusinessLayer
{
    
    public class BLBatch
    {
        DLBatch obj_Batch = new DLBatch();
        public string saveBatch(int BatchID, int ClassID, string BatchName, string BatchCode, int LectureDuration, int IsLunchBreak, string LunchBreakStartTime, string LunchBreakEndTime, int MaxNoLecturesDay, int MaxNoLecturesWeek, int IsAllowMoreThanOneLectInBatch, int MaxNoOfLecureInRow, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string result = obj_Batch.saveBatch(BatchID, ClassID, BatchName, BatchCode, LectureDuration, IsLunchBreak, LunchBreakStartTime, LunchBreakEndTime, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
               return result;
        }

        //To Bind Gridview
        public DataSet BindBatch(int BatchID,string BatchName)
        {
            DataSet ds = obj_Batch.BindBatch(BatchID,BatchName);
                return ds;
        }

        public string DeleteBatch(int BatchID, int UpdatedByUserID, string UpdatedDate)
        {
            string result = obj_Batch.DeleteBatch(BatchID, UpdatedByUserID, UpdatedDate);
            return result;
        }

        //For Edit Details
        public DataSet GetBatchDetail(string BatchName, string BatchCode)
        {
            DataSet ds = obj_Batch.GetBatchDetail(BatchName, BatchCode);
            return ds;

        }

        public DataSet SearchBatch(string BatchName)
        {
            DataSet ds = obj_Batch.SearchBatch(BatchName);
            return ds;
        }
    }
}
