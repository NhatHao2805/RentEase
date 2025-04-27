using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;
namespace DAL.honhathao
{
    public class BuildingAccess
    {
        public static string add_building(string buildingKey, string username, string address)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("add_building", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_BUILDING_KEY", buildingKey);
                        command.Parameters.AddWithValue("@p_USERNAME", username);
                        command.Parameters.AddWithValue("@p_ADDRESS", address);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            return "Success";
        }
        public static DataTable load_building_by_user(string usern)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_building_by_user", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new MySqlParameter("usern", usern));
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

        public static void change_building_key(string buidingid, string buidlingKey)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("change_building_key", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_building_id", buidingid);
                        command.Parameters.AddWithValue("@p_building_key", buidlingKey);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }

        public static DataTable LoadBuilding(string username)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (MySqlCommand command = new MySqlCommand("SELECT BUILDINGID, BUILDING_KEY, USERNAME, ADDRESS, NUMOFFLOORS, NUMOFROOMS FROM BUILDING WHERE USERNAME=@username AND ISDELETED = 0", conn))
                    {
                        command.Parameters.AddWithValue("username", username);
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
                Console.WriteLine("Error in GetAllVehicleUnitPrices: " + ex.Message);
            }
            return output;
        }

        public static string addBuilding(Building building)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("addBuilding", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_buildingkey", building.BuildingKey);
                        command.Parameters.AddWithValue("@p_username", building.Username);
                        command.Parameters.AddWithValue("@p_address", building.Address);
                        command.Parameters.AddWithValue("@p_numoffloors", building.NumOfFloors);
                        command.Parameters.AddWithValue("@p_numofrooms", building.NumOfRooms);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            return "Add Successfully";
        }
    }
}
