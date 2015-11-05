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


        public string saveAddRoom(int RoomId, string RoomName, string ShortName, string Color1, int Capacity,int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string result = obj_Room.saveAddRoom(RoomId,RoomName,ShortName,Color1,Capacity,UpdatedByUserID,UpdatedDate, IsActive);
            return result;
        }
        public string UpdateRoom( string RoomName, string ShortName, string Color1, int Capacity, string UpdatedDate, int IsActive)
        {
            string result = obj_Room.UpdateRoom(RoomName, ShortName, Color1, Capacity, UpdatedDate, IsActive);
            return result;
        }
        public DataSet BindFullGrid(int RoomId)
        {
            DataSet ds = obj_Room.BindFullGrid(RoomId);
            return ds;
        }
      /*  public int deleteDoctor(EntDoctor objent)
        {
            DLRoom objdl = new DLRoom();
            int result = objdl.deleteDoctor(objent);
            return result;
        }*/

    }
}
