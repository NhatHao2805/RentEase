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

        //1

        public static string AddRoom(Room room)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    // 1. Kiểm tra dung lượng tầng
                    using (MySqlCommand capacityCheck = new MySqlCommand("SELECT checkFloorCapacity(@p_buildingid, @p_floor)", conn))
                    {
                        capacityCheck.Parameters.AddWithValue("@p_buildingid", room.BuildingId);
                        capacityCheck.Parameters.AddWithValue("@p_floor", room.Floor);

                        int capacityResult = Convert.ToInt32(capacityCheck.ExecuteScalar());
                        if (capacityResult != 1) return "Out range of number room of floor";
                    }

                    // 2. Thêm phòng
                    using (MySqlCommand command = new MySqlCommand("proc_addRoom", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_buildingid", room.BuildingId);
                        command.Parameters.AddWithValue("@p_floor", room.Floor);
                        command.Parameters.AddWithValue("@p_type", room.Type);
                        command.Parameters.AddWithValue("@p_convenient", room.Convenient);
                        command.Parameters.AddWithValue("@p_area", room.Area);
                        command.Parameters.AddWithValue("@p_price", room.Price);
                        command.Parameters.AddWithValue("@p_status", room.Status);

                        command.ExecuteNonQuery();
                        return "Add Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddRoom: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static string UpdateRoom(Room room)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_updateRoom", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_roomid", room.RoomId);
                        command.Parameters.AddWithValue("@p_buildingid", room.BuildingId);
                        command.Parameters.AddWithValue("@p_floor", room.Floor);
                        command.Parameters.AddWithValue("@p_type", room.Type);
                        command.Parameters.AddWithValue("@p_convenient", room.Convenient);
                        command.Parameters.AddWithValue("@p_area", room.Area);
                        command.Parameters.AddWithValue("@p_price", room.Price);
                        command.Parameters.AddWithValue("@p_status", room.Status);

                        command.ExecuteNonQuery();
                        return "Update Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateRoom: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static (bool success, string message) DeleteRoom(string roomId)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteRoom", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_roomid", roomId);
                        cmd.Parameters.Add("@p_result", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@p_message", MySqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        int result = Convert.ToInt32(cmd.Parameters["@p_result"].Value);
                        string message = cmd.Parameters["@p_message"].Value?.ToString() ?? "Không nhận được thông báo từ server";

                        return (result == 1, message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                return (false, $"Lỗi cơ sở dữ liệu: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public static DataTable LoadBuildingID(string username)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("load_buildingid", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_username", username);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static int LoadFloorByBuildingID(string buildingID)
        {
            int numOfFloors;
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("load_floor", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_buildingid", buildingID);

                    numOfFloors = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return numOfFloors;
        }

        public static DataTable LoadRoomIdByBuildingID(string buildingID)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("load_roomid", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_buildingid", buildingID);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable FilterRoomByStatus(string status, string UserName)
        {
            DataTable result = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand cmd = new MySqlCommand("filter_room", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_username", UserName);
                        cmd.Parameters.AddWithValue("@p_status_list", string.IsNullOrEmpty(status) ? null : status);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in FilterRoomByStatus: " + ex.Message);
            }
            return result;
        }
    }
}
