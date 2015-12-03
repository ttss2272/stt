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
        DLLogin obj_Login = new DLLogin();
        public DataSet GetLoginDetails()
        {
            DataSet ds = obj_Login.GetLoginDetails();
            return ds;
        }
    }
}
