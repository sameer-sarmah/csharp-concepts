using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
namespace csharp_concepts.mysql
{
    /* 1.download msi mysql connector for ODBC and install it
     * 2. Open Control Panel and serch ODBC
     * 3.Add "MySQL ODBC 8.0 Unicode Driver" by specifying the params and test connection
 */
    class ODBCConnection
    {
        private static readonly string host = "localhost";
        private static readonly string port = "3308";
        private static readonly string username = "root";
        private static readonly string password = "root";
        private static readonly string db = "northwind";
        private static readonly string driver = "{MySQL ODBC 8.0 Unicode Driver}";
        private OdbcConnection setUpConnection()
        {
            string connStr = $"DRIVER={driver};SERVER={host};USER={username};DATABASE={db};PORT={port};PASSWORD={password}";
            OdbcConnection mySqlConnection = new OdbcConnection(connStr);
            return mySqlConnection;
        }
        
        public void executeQuery()
        {
            OdbcConnection mySqlConnection = setUpConnection();
            try
            {
                Console.WriteLine("Connecting to MySQL using ODBC...");
                mySqlConnection.Open();
                string sql = "SELECT product_name,category FROM products";
                OdbcCommand cmd = new OdbcCommand(sql, mySqlConnection);
                OdbcDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"product:{reader[0]} ,category: {reader[1]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            cleanUpConnection(mySqlConnection);
        }

        private void cleanUpConnection(OdbcConnection mySqlConnection)
        {
            mySqlConnection.Close();
        }
    }
}
