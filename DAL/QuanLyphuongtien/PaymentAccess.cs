// DAL/PaymentAccess.cs
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class PaymentAccess
    {
        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return dt;

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM PAYMENT", conn))
                {
                    try
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}