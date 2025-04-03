// File: DAL/QuanLyphuongtien/ParkingAreaAccess.cs
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ParkingAreaAccess
    {
        public static DataTable GetAllParkingAreas(string buildingID)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return dt;

                // Sử dụng tham số trong câu lệnh SQL
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM PARKINGAREA WHERE BuildingID = @BuildingID", conn))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@BuildingID", buildingID);

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
    
        
        // Thêm vào file DAL/QuanLyphuongtien/ParkingAreaAccess.cs
        public static DataTable GetAllBuildings()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return dt;

                using (MySqlCommand command = new MySqlCommand("CALL sp_GetAllBuildings()", conn))
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

        public static DataTable GetParkingAddresses()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return dt;

                using (MySqlCommand command = new MySqlCommand("CALL sp_GetParkingAddresses()", conn))
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
        public static DataTable GetParkingAreasByBuildingId(string buildingId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return dt;

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM PARKINGAREA WHERE BUILDINGID = @p_buildingId", conn))
                {
                    command.Parameters.AddWithValue("@p_buildingId", buildingId);
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

        public static string GenerateNewParkingAreaId()
        {
            string newId = "";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "PA001";

                using (MySqlCommand command = new MySqlCommand("SELECT fn_GenerateNewParkingAreaId()", conn))
                {
                    try
                    {
                        newId = command.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error: " + ex.Message);
                        newId = "PA001";
                    }
                }
            }
            return newId;
        }
        public static bool AddParkingArea(string buildingId, string address, string type, int capacity)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;

                using (MySqlCommand command = new MySqlCommand("sp_AddParkingArea", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_buildingId", buildingId);
                    command.Parameters.AddWithValue("@p_address", address);
                    command.Parameters.AddWithValue("@p_type", type);
                    command.Parameters.AddWithValue("@p_capacity", capacity);
                    command.Parameters.Add("@p_message", MySqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@p_success", MySqlDbType.Bit).Direction = ParameterDirection.Output;

                    try
                    {
                        command.ExecuteNonQuery();
                        return Convert.ToBoolean(command.Parameters["@p_success"].Value);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public static bool UpdateParkingArea(string areaId, string buildingId, string address, string type, int capacity, out string message)
        {
            message = "";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null)
                {
                    message = "Không thể kết nối đến cơ sở dữ liệu!";
                    return false;
                }

                using (MySqlCommand command = new MySqlCommand("sp_UpdateParkingArea", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_areaId", areaId);
                    command.Parameters.AddWithValue("@p_buildingId", buildingId);
                    command.Parameters.AddWithValue("@p_address", address);
                    command.Parameters.AddWithValue("@p_type", type);
                    command.Parameters.AddWithValue("@p_capacity", capacity);
                    command.Parameters.Add("@p_message", MySqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@p_success", MySqlDbType.Bit).Direction = ParameterDirection.Output;

                    try
                    {
                        command.ExecuteNonQuery();
                        message = command.Parameters["@p_message"].Value.ToString();
                        return Convert.ToBoolean(command.Parameters["@p_success"].Value);
                    }
                    catch (Exception ex)
                    {
                        message = "Lỗi: " + ex.Message;
                        return false;
                    }
                }
            }
        }
        public static string GenerateNewBuildingId()
        {
            string newId = "";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "BD001";

                using (MySqlCommand command = new MySqlCommand("SELECT fn_GenerateNewBuildingId()", conn))
                {
                    try
                    {
                        newId = command.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error: " + ex.Message);
                        newId = "BD001";
                    }
                }
            }
            return newId;
        }
        public static bool DeleteParkingArea(string areaId, out string message)
        {
            message = "";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null)
                {
                    message = "Không thể kết nối đến cơ sở dữ liệu!";
                    return false;
                }

                using (MySqlCommand command = new MySqlCommand("sp_DeleteParkingArea", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_areaId", areaId);
                    command.Parameters.Add("@p_message", MySqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@p_success", MySqlDbType.Bit).Direction = ParameterDirection.Output;

                    try
                    {
                        command.ExecuteNonQuery();
                        message = command.Parameters["@p_message"].Value.ToString();
                        return Convert.ToBoolean(command.Parameters["@p_success"].Value);
                    }
            catch(Exception ex)
            {
                        message = "Lỗi: " + ex.Message;
                        return false;
                    }
                }
            }
        }


    }
}