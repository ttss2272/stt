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
        public string saveBatch(int id, int ClassID, string BatchName, string BatchCode)
        {
            string result = obj_Batch.saveBatch(id, ClassID, BatchName, BatchCode);
               return result;
        }
    }
}
