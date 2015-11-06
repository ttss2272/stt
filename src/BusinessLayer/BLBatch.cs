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
        public string saveBatch(int id, int ClassID, string BatchName, string BatchCode, int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDeleted)
        {
            string result = obj_Batch.saveBatch(id, ClassID, BatchName, BatchCode, UpdatedByUserID, UpdatedDate, IsActive,IsDeleted);
               return result;
        }

        public DataSet BindBatch(int BatchID)
        {
            DataSet ds = obj_Batch.BindBatch(BatchID);
                return ds;
        }

        public string DeleteBatch(int BatchID, int UpdatedByUserID, string UpdatedDate)
        {
            string result = obj_Batch.DeleteBatch(BatchID, UpdatedByUserID, UpdatedDate);
               return result;
        }

        public DataSet GetBatchDetail(string BatchName, string BatchCode)
        {
            DataSet ds = obj_Batch.GetBatchDetail(BatchName, BatchCode);
            return ds;

        }
    }
}
