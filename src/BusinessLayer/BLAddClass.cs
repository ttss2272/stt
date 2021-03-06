﻿using System;
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
        public string saveAddClass(int id, string ClassName, string ShortName, string Board, string Color,int BranchID, int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDeleted)        
           
            {
                string result = obj_AddClass.saveAddClass(id, ClassName, ShortName, Board, Color, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                return result;
            }
        

        //To Bind Gridview
        public DataSet BindClass(int BranchId)
        {
            DataSet ds = obj_AddClass.BindClass(BranchId);
            return ds;
        }

        public string DeleteClass(int ClassID, int UpdatedByUserID, string UpdatedDate)
        {
            string result =obj_AddClass.DeleteClass(ClassID,UpdatedByUserID,UpdatedDate);
            return result;
        }

        public DataSet GetClassDetail(string ClassName, string ShortName, string Board, string Color,int BranchID)
        {
            DataSet ds = obj_AddClass.GetClassDetail(ClassName, ShortName, Board, Color,BranchID);
            return ds;
        }

        public DataSet SearchClass(string ClassName)
        {
            DataSet ds = obj_AddClass.SearchClass(ClassName);
            return ds;
        }

        public DataSet BindClassName(int BranchID)
        {
            DataSet getClassName = obj_AddClass.BindClassName(BranchID);
            return getClassName;
        }

        public DataSet BindBranchClass(int BranchID)
        {
            DataSet ds = obj_AddClass.BindBranchClass(BranchID);
            return ds;
        }

        public DataSet GetBranchClassCount()
        {
            DataSet ds = obj_AddClass.GetBranchClassCount();
            return ds;
        }
        public DataSet loadClassName()
        {
            DataSet ds = obj_AddClass.loadClassName();
            return ds;
        }
    }
}
