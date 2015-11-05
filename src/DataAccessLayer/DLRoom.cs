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

        public string saveAddRoom(int RoomId,string RoomName, string ShortName,string Color1, int Capacity,int UpdatedByUserID, string UpdatedDate, int IsActive,int IsDeleted)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveRoom_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomID",RoomId);
            cmd.Parameters.AddWithValue("@RoomName", RoomName);
            cmd.Parameters.AddWithValue("@ShortName", ShortName);
            cmd.Parameters.AddWithValue("@Color", Color1);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
         //   cmd.Parameters.AddWithValue("@BranchId",BranchId);
          //  cmd.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserId);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
        //    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDelete", IsDeleted);
            conn.Open();
            result = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return result;

        }
        public string UpdateRoom(int RoomId,string RoomName, string ShortName, string Color1, int Capacity,int UpdatedByUserID,string UpdatedDate, int IsActive,int IsDeleted)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("SaveRoom_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomID", RoomId);
            cmd.Parameters.AddWithValue("@RoomName", RoomName);
            cmd.Parameters.AddWithValue("@ShortName", ShortName);
            cmd.Parameters.AddWithValue("@Color", Color1);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
           // cmd.Parameters.AddWithValue("@BranchId",BranchId);
            //  cmd.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserId);
            cmd.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            //    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            cmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDelete", IsDeleted);
            conn.Open();
            result = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return result;

        }
         // To Bind Grid 
        public DataSet BindFullGrid(int RoomID)
        {
            conn = con.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("BindRoom_SP", conn);
            cmd.Parameters.AddWithValue("@RoomID", RoomID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        
      /*      public int deleteRoom( EntRoom objent)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DelelteRoom_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@RoomID", objent.RoomName);
                int result = cmd.ExecuteNonQuery();
                
                con.Close();
            
                cmd.Dispose();
                con.Close();
                con.Dispose();
                return result;
            
        }*/
           

        
    }      
 }
