using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLTimeTable
    {
        DLTimeTable objTimeTable = new DLTimeTable();

        public string SaveTimeTable(int TimeTableID, int BatchID, int RoomID, int TeacherSubjectID, string Day, string LectStartTime, string LectEndTime,int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string result = objTimeTable.SaveTimeTable(TimeTableID,BatchID,RoomID,TeacherSubjectID,Day,LectStartTime,LectEndTime,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted);
            return result;
        }

        public DataSet BindTimeTable()
        {
            DataSet ds = objTimeTable.BindTimeTable();
            return ds;
        }

        public DataSet BindDay(int BatchID)
        {
            DataSet ds = objTimeTable.BindDay(BatchID);
                return ds;
        }

        public DataSet BindTimeSlot(int BatchAvailableID,int BatchID, string Day)
        {
            DataSet ds = objTimeTable.BindTimeSlot(BatchAvailableID,BatchID,Day);
                return ds;
        }
    }
}
