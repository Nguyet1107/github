using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace QuanLyCuaHangGiayDep
{
    class Functions
    {
        
        public static SqlConnection con;
        public static void Connection()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN;Initial Catalog=CuaHangGiayDep;Integrated Security=True";
            con.Open();
        }
        public static void Disconnect()
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            adp.Fill(table);
            return table;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            adp.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            adp.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
        }
        public static void FillCombo1(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            adp.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static bool IsDate(string date)
        {
            string[] elements = date.Split('/');
            if ((Convert.ToInt32(elements[0]) >= 1) && (Convert.ToInt32(elements[0]) <= 31) &&
                (Convert.ToInt32(elements[1]) >= 1) && (Convert.ToInt32(elements[1]) <= 12) &&
                (Convert.ToInt32(elements[2]) >= 1900))
                return true;
            else
                return false;

        }
        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}, {1}, {2}", elements[0], elements[1], elements[2]);
            return dt;
        }
    }
}

