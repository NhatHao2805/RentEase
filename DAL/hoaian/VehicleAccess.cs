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
    public class VehicleAccess
    {
        public static string addVehicle(Vehicle vehicle, string areaid)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_addVehicle", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_tenantid", vehicle.TenantID);
                        command.Parameters.AddWithValue("@p_vehicle_unitprice_id", vehicle.VehicleUnitPriceID);
                        command.Parameters.AddWithValue("@p_type", vehicle.Type);
                        command.Parameters.AddWithValue("@p_licenseplate", vehicle.LicensePlate);
                        command.Parameters.AddWithValue("@p_areaid", areaid);

                        command.ExecuteNonQuery();
                        return "Add Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddVehicle: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static string updateVehicle(Vehicle vehicle)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_updateVehicle", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_vehicleid", vehicle.VehicleID);
                        command.Parameters.AddWithValue("@p_tenantid", vehicle.TenantID);
                        command.Parameters.AddWithValue("@p_vehicle_unitprice_id", vehicle.VehicleUnitPriceID);
                        command.Parameters.AddWithValue("@p_type", vehicle.Type);
                        command.Parameters.AddWithValue("@p_licenseplate", vehicle.LicensePlate);

                        command.ExecuteNonQuery();
                        return "Update Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateVehicle: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static (bool success, string message) DeleteVehicle(string vehicleId)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteVehicle", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_vehicleid", vehicleId);
                        cmd.Parameters.Add("@p_result", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@p_message", MySqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        int result = Convert.ToInt32(cmd.Parameters["@p_result"].Value);
                        string message = cmd.Parameters["@p_message"].Value.ToString();

                        return (result == 1, message);
                    }
                }
                catch (Exception ex)
                {
                    return (false, $"Database error: {ex.Message}");
                }
            }
        }

        public static DataTable GetVehicleUnitPriceByType(string type)
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

                    using (MySqlCommand command = new MySqlCommand("sp_GetVehicleUnitPriceByType", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_type", type);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(output);
                            return output;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetVehicleUnitPriceByType: " + ex.Message);
                return null;
            }
        }

        public static DataTable GetAllVehicleUnitPrices()
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

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM VEHICLE_UNITPRICE", conn))
                    {
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

        public static DataTable GetVehicleUnitPriceById(string unitprice_id)
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

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM VEHICLE_UNITPRICE WHERE VEHICLE_UNITPRICE_ID=@p_unitprice", conn))
                    {
                        command.Parameters.AddWithValue("p_unitprice", unitprice_id);
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

        public static DataTable GetAllVehicle()
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

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM VEHICLE_UNITPRICE", conn))
                    {
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

        public static DataTable GetVehicleUnitPriceIdByType(string type)
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

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM VEHICLE_UNITPRICE WHERE TYPE=@p_type", conn))
                    {
                        command.Parameters.AddWithValue("p_type", type);
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

        public static DataTable FilterVehicle(string buildingid, string type)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("sp_FilterVehicle", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_buildingid", buildingid);
                        command.Parameters.AddWithValue("@p_vehicle_type", string.IsNullOrEmpty(type) ? null : type);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in FilterVehicle: " + ex.Message);
            }
            return dt;
        }
    }
}
