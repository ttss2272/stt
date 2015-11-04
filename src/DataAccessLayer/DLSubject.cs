using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLSubject
    {
        DBConnection  con = new DBConnection();
        SqlConnection conn = new SqlConnection();
        public string SaveSubject(int SubjectID, string SubjectName, string SubjectShortName, int UpdatedByUserID, string UpdatedDate, int IsActive)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("Usp_SaveSubject", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
            cmd.Parameters.AddWithValue("@SubjectShortName", SubjectShortName);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;

            
        }
    }
}
