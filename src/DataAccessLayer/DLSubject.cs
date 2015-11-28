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
        DBConnection  conn = new DBConnection();
        SqlConnection con = new SqlConnection();
        
        public string SaveSubject(int SubjectID, string SubjectName, string SubjectShortName, int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDeleted)
        {
            string Result = null;
            con = conn.getConnection();
            SqlCommand cmd = new SqlCommand("SaveSubject_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
            cmd.Parameters.AddWithValue("@SubjectShortName", SubjectShortName);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);

            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;

            
        }
        //To Bind DropDown
        public DataSet GetSubject(int SubjectID)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetSubject_SP", con);
            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }
        //To Bind Gridview
        public DataSet BindSubject(int SubjectID)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("BindSubject_SP", con);
            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        //For Edit Details
        public DataSet GetSubjectDetail(string SubjectName, string ShortName)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("GetSubjectDetail_SP", con);
            cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
            cmd.Parameters.AddWithValue("@ShortName", ShortName);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }

        public string DeleteSubject(int SubjectID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = null;
            con = conn.getConnection();
            SqlCommand cmd = new SqlCommand("DeleteSubject_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

            con.Open();
            Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
 
        }
        public DataSet SearchSubject(string SubjectName)
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SearchSubject_SP", con);
            cmd.Parameters.AddWithValue("@SubjectName", SubjectName);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            con.Close();
            return ds;
 
        }

        public DataSet BindSubjectName()
        {
            con = conn.getConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("BindSubjectName_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            con.Close();
            return ds;
        }
    }
}
