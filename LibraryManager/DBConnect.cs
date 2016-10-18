using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LibraryManager
{
    public static class DBConnect
    {
        //private static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\node\DB\TTGDB.mdf;Integrated Security=True;Connect Timeout=30";
        private static string ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        public static string ErrorMessage = "";
        private static bool status = false;
        private static SqlConnection conn;
        private static SqlDataAdapter Adap;
        private static SqlCommand sqlcommand;
        public static bool Connect()
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                ErrorMessage = "";
                status = true;
                return true;
            }
            catch (Exception exc)
            {
                ErrorMessage = "Cant connect database";
                return false;
            }
        }

        public static bool Disconnect()
        {
            try
            {
                conn.Close();
                ErrorMessage = "";
                status = false;
                return true;
            }
            catch (Exception)
            {
                ErrorMessage = "Cant disconnect database";
                return false;
            }
        }

        public static bool isConnected()
        {
            return status;
        }
        public static int Insert(string command)
        {
            try
            {
                sqlcommand = new SqlCommand(command, conn);
                int numRows = sqlcommand.ExecuteNonQuery();
                ErrorMessage = "";
                return numRows;
            }
            catch (Exception)
            {
                ErrorMessage = "error on insertion";
                return 0;
            }
        }
        public static int Update(string command)
        {
            try
            {
                sqlcommand = new SqlCommand(command, conn);
                int numRows = sqlcommand.ExecuteNonQuery();
                ErrorMessage = "";
                return numRows;
            }
            catch (Exception)
            {
                ErrorMessage = "error on updation";
                return 0;
            }
        }
        public static int Delete(string command)
        {
            try
            {
                sqlcommand = new SqlCommand(command, conn);
                int numRows = sqlcommand.ExecuteNonQuery();
                ErrorMessage = "";
                return numRows;
            }
            catch (Exception)
            {
                ErrorMessage = "error on delete";
                return 0;
            }
        }
        public static bool Drop(string command)
        {
            try
            {
                sqlcommand = new SqlCommand(command, conn);
                sqlcommand.ExecuteNonQuery();
                ErrorMessage = "";
                return true;
            }
            catch (Exception)
            {
                ErrorMessage = "cant drop";
                return false;
            }
        }
        public static bool Create(string command)
        {
            try
            {
                sqlcommand = new SqlCommand(command, conn);
                sqlcommand.ExecuteNonQuery();
                ErrorMessage = "";
                return true;
            }
            catch (Exception)
            {
                ErrorMessage = "cant create";
                return false;
            }
        }
        public static DataTable Select(string command)
        {
            DataTable dt = new DataTable();
            try
            {
                Adap = new SqlDataAdapter(command, conn);
                Adap.Fill(dt);
                ErrorMessage = "";
            }
            catch (Exception)
            {
                ErrorMessage = "error on insertion";
            }
            return dt;
        }
    }
}
