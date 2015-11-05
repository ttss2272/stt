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
        public string saveAddClass(int id, string ClassName, string ShortName, string Board, string Color,int BranchID, int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string result = obj_AddClass.saveAddClass(id, ClassName, ShortName, Board, Color,BranchID, UpdatedByUserID, UpdatedDate, IsActive);
            return result;
        }

        //To Bind Gridview
        public DataSet BindClass(int ClassID)
        {
            DataSet ds = obj_AddClass.BindClass(ClassID);
                return ds;
        }
    }
}
