using System;
using System.Data;
using MySql.Data.MySqlClient;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class MySqlConnectionData
    {
        private static readonly string connectString = "server=localhost;port=3306;database=rentease;user=root;password=zxcvbnm;";

        public static MySqlConnection Connect()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectString);
                connection.Open();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Connection error: " + e.Message);
            }
            return connection;
        }

    }

}
