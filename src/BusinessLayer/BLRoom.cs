using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class BLRoom
    {
        DLRoom obj_Room = new DLRoom();


        public string saveAddRoom(int RoomId, string RoomName, string ShortName, string Color1, int Capacity, int BranchID, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted,int MaxLectday,int MaxLectWeek,int MaxLectRow,DateTime STime,DateTime ETime,int IsAllow)
        {
            string result = obj_Room.saveAddRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted,MaxLectday,MaxLectWeek,MaxLectRow,STime,ETime,IsAllow);
            return result;
        }

        public string SaveRoomAvailibility(int RoomID, string Day, string StartTime, string EndTime, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string Result = obj_Room.SaveRoomAvailibility(RoomID, Day, StartTime, EndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            return Result;
        }

        public DataSet BindRoomAvail()
        {
            DataSet ds = obj_Room.BindRoomAvail();
            return ds;
        }

        public DataSet GetRoomAvailableDetail(int RoomID)
        {
            DataSet ds = obj_Room.GetRoomAvailableDetail(RoomID);
            return ds;
        }

        public DataSet BindFullGrid(int RoomId,string BranchName, string RoomName)
        {
            DataSet ds = obj_Room.BindFullGrid(RoomId,BranchName, RoomName);
            return ds;
        }

        public string DeleteRoom(int RoomID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = obj_Room.DeleteRoom(RoomID, UpdatedByUserID, UpdatedDate);
            return Result;
        }

        public DataSet BindRoomName()
        {
            DataSet ds = obj_Room.BindRoomName();
            return ds;
        }

        public DataSet BindRoomDropDown(int BranchID )
        {
            DataSet ds = obj_Room.BindRoomDropDown(BranchID);
            return ds;
        }
    }
}
