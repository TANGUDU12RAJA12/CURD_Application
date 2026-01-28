using DemoCURD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCURD.Data
{
    public class DbAccess
    {
        public static string ConnString = ConfigurationManager.AppSettings["DbConnection"];
        // ✅ This works perfectly with appSettings!

        //public static string ConnString = ConfigurationManager.AppSettings["DbConnection"];
        // ✅ Change this line in DbAccess class
       // public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public static SqlConnection conn; 
        public static SqlCommand cmd ;
        public static DataTable GetData(string query)
        {
            try
            {
                using (conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                   // cmd.CommandTimeout = 0;
                    cmd = new SqlCommand(query, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }          
        }
        public static DataTable GetDataById(string query  , int id)
        {
            try
            {
                using(conn = new SqlConnection(ConnString))
                {
                   cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID" ,id);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertData(string query)
        {
            int count = 0;
            try
            {
                using(conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine("Data Inserted SuccessFully..");
                    }
                    else
                    {
                        Console.WriteLine("Data not Inserted....");
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void UpdateData(string query , int id)
        {
            int count = 0;
            try
            {
                using(conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    cmd =new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", id);
                    count =  cmd.ExecuteNonQuery();
                    if(count > 0)
                    {
                        Console.WriteLine($"Data Updated Successfully at id :{id}");
                    }
                    else
                    {
                        Console.WriteLine("Data Not Updated....");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void DeleteRecord(string query ,int id)
        {
            int count = 0;
            try
            {
                using (conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", id);
                    count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Console.WriteLine($"Data Removed  Successfully of id :{id}");
                    }
                    else
                    {
                        Console.WriteLine("Data Not Removed...");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
