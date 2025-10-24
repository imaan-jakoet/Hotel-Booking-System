using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PhumlaKamnandi.Data
{
    // Manages database connections and provides SQL connection objects
    public class DatabaseManager
    {
        // Default connection string for LocalDB database
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\imaan\Music\PhumlaKamnandi\PhumlaKamnandi.mdf;Integrated Security=True;Connect Timeout=30";

        // Returns a new SQL connection using the stored connection string
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Allows updating the connection string at runtime
        public static void SetConnectionString(string connString)
        {
            connectionString = connString;
        }
    }
}