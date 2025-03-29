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

namespace DAL
{
    public class RoomAccess
    {
        public static string RoomAccess_TakePrice(string roomid)
        {
            string price = "";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return price;

                using (MySqlCommand command = new MySqlCommand("Select PRICE from room where ROOMID = @roomid", conn))
                {
                    command.Parameters.AddWithValue("@roomid", roomid);

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
        public static List<string> RoomAccess_Load_RoomInBuilding(string addressBuilding)
        {
            List<string> listRoom = new List<string>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return listRoom;

                using (MySqlCommand command = new MySqlCommand("" +
                    "Select ROOMID from room r " +
                    "join building b on b.BUILDINGID = r.BUILDINGID " +
                    "where b.ADDRESS = @addr", conn))
                {
                    command.Parameters.AddWithValue("@addr", addressBuilding);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                listRoom.Add(reader.GetString(0));
                            }
                        }
                        else
                        {
                            return listRoom;
                        }
                    }
                }
            }
            return listRoom;
        }
        public static List<string> RoomAccess_Load_RoomAddress(string username)
        {
            List<string> address = new List<string>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return address;
                using (MySqlCommand command = new MySqlCommand("" +
                    "Select ADDRESS from building " +
                    "where USERNAME = @usern", conn))
                {
                    
                    command.Parameters.AddWithValue("@usern", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.HasRows + " " + "\'" + username + "\'");
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
        public static DataTable LoadRoomByUser(string Username)
        {

            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_Room", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_username", Username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                output.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                            }

                            while (reader.Read())
                            {
                                DataRow row = output.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[i] = reader.IsDBNull(i) ? DBNull.Value : reader.GetValue(i);
                                }
                                output.Rows.Add(row);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);

            }
            return output;
        }

    }
}
