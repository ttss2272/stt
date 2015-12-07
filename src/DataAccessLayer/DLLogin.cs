using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
  public class DLLogin
  {
      /*
         * Created By :- Pritesh D. Sortee
         * Created Date :-07 Dec 2015
         *  Purpose:- Declare Objects
         */
      #region----------------------------------Declare Objects-----------------------------------------
      SqlConnection con = new SqlConnection();
        DBConnection conn = new DBConnection();
      #endregion

        /*
         * Updated by :- Pritesh D. Sortee
         * Updated Date :-07 Dec 2015
         * Update Purpose:- send parameters
         */
        #region-------------------------------------GetLoginDetails----------------------------------------------
        public DataSet GetLoginDetails(string UserName,string Pass,string CurrentDate)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetLoginDetails_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Pass", Pass);
            cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }
        #endregion
    }
}
