﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
namespace BusinessLayer
{
 public class BLAddBranch
    {
     DLAddBranch obj_AddBranch = new DLAddBranch();

     public string SaveBranch(int BranchID, string BranchName, string BranchCode, string InstituteName, string Logo, int CreatedByUserID,int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDelete)
        {
            string result = obj_AddBranch.SaveBranch(BranchID, BranchName, BranchCode, InstituteName, Logo, CreatedByUserID,UpdatedByUserID,UpdatedDate, IsActive,IsDelete);
            return result;
        }

        public DataSet BindBranch(int BranchID,string BranchName,string BranchCode)
        {
            DataSet getBranch = obj_AddBranch.GetBranchDetail(BranchID,BranchName, BranchCode);
            return getBranch;
        }

        public string DeleteBranch(int BranchID,int UpdatedByUserID,string Updateddate)
        {
            string result = obj_AddBranch.DeleteBranch(BranchID,UpdatedByUserID,Updateddate);
            return result;
        }
        public DataSet BindBranchName()
        {
            DataSet getBranchName = obj_AddBranch.BindBranchName();
            return getBranchName;
        }


        public DataSet SearchBranch(string BranchName)
        {
            DataSet ds = obj_AddBranch.SearchBranch(BranchName);
            return ds;
        }

        public DataSet BindInstituteName()
        {
            DataSet ds = obj_AddBranch.BindInsituteName();
            return ds;
        }

        public DataSet GetBranchCount()
        {
            DataSet ds = obj_AddBranch.GetBranchCount();
            return ds;
        }

        public string SaveDisatnce(int BranchDistanceID, int ToBranchID, int FromBranchID, int DistanceTime, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string Result = obj_AddBranch.SaveDistance(BranchDistanceID,ToBranchID,FromBranchID,DistanceTime,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted);
            return Result;
        }

        public DataSet BindDistance(int BranchDistanceID, int FromBranchID, int ToBranchID)
        {
            DataSet ds = obj_AddBranch.BindDistance(BranchDistanceID,FromBranchID,ToBranchID);
            return ds;
        }

        public DataSet BindToBranchName(int FromBranchID)
        {
            DataSet ds = obj_AddBranch.BindToBranchName(FromBranchID);
            return ds;
        }

        public string DeleteDistance(int BranchDistanceID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = obj_AddBranch.DeleteDistance(BranchDistanceID, UpdatedByUserID, UpdatedDate);
            return Result;
        }
    }
}
