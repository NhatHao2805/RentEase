using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace DAL
{
    public class HouseAccess
    {
        public static List<string> Load_HouseAddress()
        {
            List<string> address = new List<string>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return address;

                using (MySqlCommand command = new MySqlCommand("Select ADDRESS from house", conn))
                {                   

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address.Add(reader.GetString(0));
                            }
                        }
                        else
                        {
                            return address;
                        }
                    }
                }
            }
            return address;
        }

        public static string HouseAccess_TakePrice(string address)
        {
            string price = "";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return price;

                using (MySqlCommand command = new MySqlCommand("Select PRICE from house where ADDRESS = @addr", conn))
                {
                    command.Parameters.AddWithValue("@addr", address);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                price = reader.GetFloat(0).ToString("N0", new CultureInfo("vi-VN")) + " VND";
                            }
                        }
                    }
                }
            }
            return price;
        }
    }
}
