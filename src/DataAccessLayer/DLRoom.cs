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
        public string addRoom(string RoomName, string ShortName, int Capacity, string Color, string IsActive, string IsDelete)
        {
            string result = null;
            conn = con.getConnection();
            SqlCommand cmd = new SqlCommand("Usp_AddRoom", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomName", RoomName);
            cmd.Parameters.AddWithValue("@ShortName", ShortName );
            cmd.Parameters.AddWithValue("@Capacity", Capacity );
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IsDelete", IsDelete);
            conn.Open();
            result = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return result;

    }
}
