using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLayer
{
     public class BLBoard
    {
         DLBoard ObjBoard = new DLBoard();

         public string SaveBoard(int BoardID, string BoardName, int UpDatedByUserID, string UpDatedDate, int IsActive, int IsDeleted)
         {
             string Result = ObjBoard.SaveBoard(BoardID,BoardName,UpDatedByUserID,UpDatedDate,IsActive,IsDeleted);
             return Result;
         }

         public DataSet BindBoard(int BoardID, string BoardName)
         {
             DataSet ds = ObjBoard.BindBoard(BoardID, BoardName);
             return ds;
         }

         public string DeleteBoard(int BoardID, int UpDatedByUserID, string UpDatedDate)
         {
            string Result = ObjBoard.DeleteBoard(BoardID, UpDatedByUserID, UpDatedDate);
            return Result;
         }
    }
}
