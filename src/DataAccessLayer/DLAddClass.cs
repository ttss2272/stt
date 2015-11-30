using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DLAddClass
    {
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();
        public string saveAddClass(int id, string ClassName, string ShortName, string Board, string Color,int BranchID, int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDeleted)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveClass_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClassID", id);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassShortName", ShortName);
            cmd.Parameters.AddWithValue("@Board", Board);
            cmd.Parameters.AddWithValue("@Color", Color);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            conn.Open();
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;
        }

        //To Bind Gridview
        public DataSet BindClass(int BranchId)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindClass_SP", conn);
            cmd.Parameters.AddWithValue("@BranchID", BranchId);
         //   cmd.Parameters.AddWithValue("@ClassName", ClassName);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public string DeleteClass(int ClassID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("DeleteClass_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClassID", ClassID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;
        }

        //For Edit Details
        public DataSet GetClassDetail(string ClassName, string ShortName, string Board, string Color)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetClassDetail_SP", conn);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ShortName", ShortName);
            cmd.Parameters.AddWithValue("@Board", Board);
            cmd.Parameters.AddWithValue("@Color", Color);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet SearchClass(string ClassName)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SearchClass_SP", conn);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindClassName(int BranchID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindClassName_SP", conn);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindBranchClass(int BranchID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindBranchClass_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchId", BranchID);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }


        public DataSet GetBranchClassCount()
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetBranchClassCount_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            conn.Close();
            return ds;
        }


        public DataSet loadClassName()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("LoadClassName_SP", conn);            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
>>>>>>> .r394
    }
}
