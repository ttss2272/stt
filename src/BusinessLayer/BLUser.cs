using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLUser
    {
        DLUser obj_User = new DLUser();

        public string SaveUser(int UserID, string UserName, string ContactNo, string Address, string MailId, string LoginName, string Password, string UpdatedDate, int UserTypeID, int IsActive, int IsDeleted)
        {
            string result = obj_User.SaveUser(UserID,  UserName,  ContactNo,  Address,  MailId,  LoginName,  Password,   UpdatedDate,  UserTypeID,  IsActive,  IsDeleted);
            return result;
        }

        public DataSet GetUser(int UserID, string UserName)
        {
            DataSet getUser = obj_User.GetUser(UserID, UserName);
            return getUser;
        }

        public string DeleteUser(int UserID, string UpdatedDate)
        {
            string result = obj_User.DeleteUser(UserID, UpdatedDate);
            return result;
        }

        public DataSet GetUserType(int UserTypeID)
        {
            DataSet getUserType = obj_User.GetUserType(UserTypeID);
            return getUserType;
        }
    }
}
