﻿using System;
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

        public string SaveTimeTable(int TimeTableID,DateTime TTStartTime, int BatchID,int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string Result = objTimeTable.SaveTimeTable(TimeTableID,TTStartTime,BatchID,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted);
            return Result;
        }

        public DataSet BindTimeTable()
        {
            DataSet ds = objTimeTable.BindTimeTable();
            return ds;
        }

        public DataSet BindDay(int BatchID,int RoomID,int TeacherID)
        {
            DataSet ds = objTimeTable.BindDay(BatchID,RoomID,TeacherID);
                return ds;
        }

        public DataSet BindTimeSlot(int BatchAvailableID,int BatchID,int Day,int RoomAvailableID,int RoomID, int Day1,int TeacherAvailableID, int TeacherID, int Day2)
        {
            DataSet ds = objTimeTable.BindTimeSlot(BatchAvailableID,BatchID,Day,RoomAvailableID,RoomID,Day1,TeacherAvailableID,TeacherID,Day2);
                return ds;
        }
    }
}
