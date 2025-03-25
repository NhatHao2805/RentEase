using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class RoomAccess
    {
        public static DataTable LoadRoomByUser(string Username)
        {

            DataTable output = new DataTable();

            //try
            //{
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
            //}
            //catch (Exception ex)
            //{
            //    Console.Error.WriteLine("Error: " + ex.Message);

            //}
            return output;
        }

    }
}
