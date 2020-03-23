using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace csharp_concepts.mysql
{
    /* 1.download mysql connector for .net
     * 2.then use "add reference" option (right click on solution)
     * 3.navigate to the directory where the downloaded content is unzipped
     * 4.add them ,after that the libraries should be visibleunder "Assemblies"
     */
    public class MySQLConnection
    {
        private static readonly string host = "localhost";
        private static readonly string port = "3308";
        private static readonly string username = "root";
        private static readonly string password = "root";
        private static readonly string db = "northwind";
        private MySqlConnection setUpConnection() {
            string connStr = $"server={host};user={username};database={db};port={port};password={password}";
            MySqlConnection mySqlConnection = new MySqlConnection(connStr);
            return mySqlConnection;
        }

        public void executeQuery()
        {
            MySqlConnection mySqlConnection = setUpConnection();
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mySqlConnection.Open();
                string sql = "SELECT product_name,category FROM products where list_price > @price";
                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                cmd.Parameters.AddWithValue("@price", 20);
                MySqlDataReader reader = cmd.ExecuteReader();
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

            private void cleanUpConnection(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Close();
        }
    }
}
