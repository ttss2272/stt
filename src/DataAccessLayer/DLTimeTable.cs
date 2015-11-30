using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DLTimeTable
    {
        DBConnection con = new DBConnection();
        SqlConnection conn = new SqlConnection();
        public DataSet BindTimeTable()
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindGridTimeTable_SP", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindDay(int BatchID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindDay_SP", conn);
            cmd.Parameters.AddWithValue("@BatchID", BatchID);
            //cmd.Parameters.AddWithValue("@RoomID", RoomID);
            //cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet BindTimeSlot(int BatchAvailableID)
        {
            conn = con.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BindTimeSlotDropDown_SP", conn);
            cmd.Parameters.AddWithValue("@BatchAvailableID", BatchAvailableID);            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
