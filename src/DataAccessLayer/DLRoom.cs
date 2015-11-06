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
    public class DLRoom
    {
        SqlConnection conn = new SqlConnection();
        DBConnection con = new DBConnection();

        public string saveAddRoom(int RoomId, string RoomName, string ShortName, string Color1, int Capacity, int BranchID, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveRoom_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomID", RoomId);
            cmd.Parameters.AddWithValue("@RoomName", RoomName);
            cmd.Parameters.AddWithValue("@RoomShortName", ShortName);
            cmd.Parameters.AddWithValue("@Color", Color1);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            //  cmd.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserId);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            //    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            conn.Open();
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;

        }
        public string UpdateRoom(int RoomId, string RoomName, string ShortName, string Color1, int Capacity, int BranchID, int UpdatedByUserID, string UpdatedDate, int IsActive, int IsDeleted)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveRoom_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomID", RoomId);
            cmd.Parameters.AddWithValue("@RoomName", RoomName);
            cmd.Parameters.AddWithValue("@RoomShortName", ShortName);
            cmd.Parameters.AddWithValue("@Color", Color1);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            //  cmd.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserId);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            //    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            conn.Open();
            result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return result;

        }
        // To Bind Grid 
        public DataSet BindFullGrid(int RoomID,string RoomName)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("BindRoom_SP", conn);
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.Parameters.AddWithValue("@RoomName", RoomName);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

       
        public string DeleteRoom(int RoomID, int UpdatedByUserID, string UpdatedDate)
        {
            string Result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("DeleteRoom_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

            conn.Open();
            Result = cmd.ExecuteScalar().ToString();
            conn.Close();
            return Result;

        }
        
    }      
 }
