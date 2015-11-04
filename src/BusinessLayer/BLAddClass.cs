using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessLayer;

namespace BusinessLayer
{
    public class BLAddClass
    {
        DLAddClass obj_AddClass = new DLAddClass();
        public string saveAddClass(int id, string ClassName, string ShortName, int Board, string Color)
        {
            string result = obj_AddClass.saveAddClass(id, ClassName, ShortName, Board, Color);
            return result;
        }
    }
}
