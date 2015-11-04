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


        public string addRoom( string RoomName, string ShortName, int Capacity, string  Color, string IsActive, string IsDelete)
        {
            string result = obj_Room.addRoom( RoomName, ShortName , Capacity, Color, IsActive, IsDelete);
            return result;
        }
    }
}
