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

        public string SaveBatchSubject(int SubjectID, int BatchID, int NoLectPerDay, int NoLectPerWeek, int UpdatedByUserID, string UpdatedDate, int Active, int IsDeleted)
        {
            string Result = obj_Batch.SaveBatchSubject(SubjectID, BatchID, NoLectPerDay, NoLectPerWeek, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
            return Result;
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

        public DataSet BindBatchName()
        {
            DataSet ds = obj_Batch.BindBatchName();
            return ds;
        }

        public DataSet BindBranchBatch(int BranchID)
        {
            DataSet ds = obj_Batch.BindBranchBatch(BranchID);
            return ds;
        }

        public DataSet GetBatchSubject(int BatchID,int SubjectID)
        {
            DataSet ds = obj_Batch.GetBatchSubject(BatchID,SubjectID);
            return ds;
        }

        public string DeleteBatchSubject(int BatchID, int SubjectID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = obj_Batch.DeleteBatchSubject(BatchID, SubjectID, UpdatedByUserID, UpdatedDate);
            return Result;
        }

        public DataSet GetBatchSubjectCount()
        {
            DataSet ds = obj_Batch.GetBatchSubjectCount();
            return ds;
        }
    }
}
