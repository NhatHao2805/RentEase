using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Globalization;
using System.Runtime.Remoting.Messaging;

namespace DAL.hoaian
{
    public class UserAccess
    {
        public static string CheckEmail(string email)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM USER WHERE EMAIL=@p_email;", conn))
                    {
                        command.Parameters.AddWithValue("p_email", email);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0 ? "Valid" : "Invalid";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckEmail: " + ex.Message);
                return "Error";
            }
        }

    }
}
