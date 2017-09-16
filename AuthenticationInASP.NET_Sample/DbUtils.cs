using AuthenticationInASP.NET_Sample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuthenticationInASP.NET_Sample
{
    public static class DbUtils
    {
        public static void InsertUser(User user)
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "uspInsertUser";
                command.Connection = connection;

                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public static int CheckIfUserExists(string username)
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            int rowCount = 0;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "uspGetUserByUsername";
                command.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                command.Connection = connection;

                try
                {
                    connection.Open();
                    int rows = (int)command.ExecuteScalar();
                   
                    if(rows == 0)
                    {
                        rowCount = 0;
                    }else
                    {
                        rowCount = 1;
                    }

                }
                catch (Exception e)
                {
                    
                }
                return rowCount;
            }
        }
    }
}