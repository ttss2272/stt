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

        public string SaveBranch(int BranchID, string BranchName, string BranchCode, string InstituteName, string Logo, int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string result = obj_AddBranch.SaveBranch(BranchID,BranchName,BranchCode,InstituteName,Logo,UpdatedByUserID,UpdatedDate,IsActive);
            return result;
        }

        public DataSet BindBranch(int BranchID)
        {
            DataSet getBranch = obj_AddBranch.GetBranchDetail(BranchID);
            return getBranch;
        }
    }
}