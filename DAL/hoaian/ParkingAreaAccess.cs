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
    public class ParkingAreaAccess
    {

        public static List<string> LoadAreaID()
        {
            List<string> name = new List<string>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return name;
                using (MySqlCommand command = new MySqlCommand("Select AREAID from PARKINGAREA", conn))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                name.Add(reader.GetString(0));
                            }
                        }
                        else
                        {
                            return name;
                        }
                    }
                }
            }
            return name;

        }

        public static string addParkingArea(ParkingArea area)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_addParkingArea", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_buildingid", area.BuildingId);
                        command.Parameters.AddWithValue("@p_address", area.Address);
                        command.Parameters.AddWithValue("@p_type", area.Type);
                        command.Parameters.AddWithValue("@p_capacity", area.Capacity);

                        command.ExecuteNonQuery();
                        return "Add Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddParkingArea: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static string updateParkingArea(ParkingArea area)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_updateParkingArea", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_areaid", area.AreaId);
                        command.Parameters.AddWithValue("@p_buildingid", area.BuildingId);
                        command.Parameters.AddWithValue("@p_address", area.Address);
                        command.Parameters.AddWithValue("@p_type", area.Type);
                        command.Parameters.AddWithValue("@p_capacity", area.Capacity);

                        command.ExecuteNonQuery();
                        return "Update Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateParkingArea: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static (bool success, string message) DeleteParkingArea(string areaId)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteParkingArea", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_areaid", areaId);
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

        public static DataTable FilterParkingArea(string buildingid, string type, string status)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("sp_FilterParkingArea", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_buildingid", string.IsNullOrEmpty(buildingid) ? null : buildingid);
                        command.Parameters.AddWithValue("@p_type", string.IsNullOrEmpty(type) ? null : type);
                        command.Parameters.AddWithValue("@p_status", string.IsNullOrEmpty(status) ? null : status);
                        

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in FilterParkingArea: " + ex.Message);
            }
            return dt;
        }

        public static DataTable GetAreaId(string type, string buildingid)
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

                    // Tạo thủ tục lưu trữ nếu chưa tồn tại
                    string createProcedure = @"
                                            DROP PROCEDURE IF EXISTS GetAreaIds;
                                            CREATE PROCEDURE GetAreaIds(IN p_type VARCHAR(50), IN p_buildingid VARCHAR(20))
                                            BEGIN
                                                SELECT pa.*
                                                FROM PARKINGAREA pa
                                                WHERE (pa.BUILDINGID = p_buildingid) AND
                                                    ((pa.TYPE = p_type) OR
                                                    (pa.TYPE = 'xemay/xedap' AND (p_type = 'xemay' OR p_type = 'xedap')) OR
                                                    (pa.TYPE = 'honhop' AND p_type IN ('xeoto', 'xemay', 'xedap')));
                                            END;";

                    using (MySqlCommand createCommand = new MySqlCommand(createProcedure, conn))
                    {
                        createCommand.ExecuteNonQuery(); // Thực thi lệnh tạo thủ tục
                    }

                    // Gọi thủ tục lưu trữ
                    using (MySqlCommand command = new MySqlCommand("GetAreaIds", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_type", type);
                        command.Parameters.AddWithValue("@p_buildingid", buildingid);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(output); // Điền dữ liệu vào DataTable
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAreaIdByType: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }

            return output; // Trả về DataTable chứa danh sách AREAID
        }

        public static DataTable GetAreaIdByVehicleId(string vehicleId)
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

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM PARKING WHERE VEHICLEID = @p_vehicleId;", conn))
                    {
                        command.Parameters.AddWithValue("p_vehicleId", vehicleId);
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
    }
}
