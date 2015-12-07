using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLLogin
    {
        /*
         * Created By:-
         * Created Date:- 
         * Purpose:- Declare Objects
         */
        #region-----------------------------Objects-----------------------
        DLLogin obj_Login = new DLLogin();
        #endregion

        /*
         * Updated by :- Pritesh D. Sortee
         * Updated Date :-07 Dec 2015
         * Update Purpose:- send parameters to Stored procedure
         */
        #region------------------------------------------GetloginDetails-----------------------------------------
        public DataSet GetLoginDetails(string UserName, string Pass,string CurrentDate)
        {
            DataSet ds = obj_Login.GetLoginDetails(UserName,Pass,CurrentDate);
            return ds;
        }
        #endregion
    }
}
