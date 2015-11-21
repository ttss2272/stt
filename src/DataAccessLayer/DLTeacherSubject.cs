using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLTeacherSubject
    {
        DBConnection con = new DBConnection();
        SqlConnection conn = new SqlConnection();

        public DataSet GetBatchBySubject(int BranchID, int SubjectID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetBatchOnSubject_SP", conn);


            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
