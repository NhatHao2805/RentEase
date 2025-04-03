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
    public class AssetAccess
    {
        public static DataTable LoadAssets(string Username, string buildingid)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    // Kiểm tra và mở kết nối nếu chưa mở
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (MySqlCommand command = new MySqlCommand("load_Assets", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_username", Username);
                        command.Parameters.AddWithValue("@p_buildingid", buildingid);

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
                Console.WriteLine("Error in LoadAsset: " + ex.Message);
            }
            return output;
        }

        public static DataTable LoadRoomID(string buildingid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_roomid", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_buildingid", buildingid);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddAsset: " + ex.Message);
            }
            return dt;
        }

        public static string addAsset(Assets assets)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_addAsset", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_roomid", assets.RoomId);
                        command.Parameters.AddWithValue("@p_assetname", assets.AssetName);
                        command.Parameters.AddWithValue("@p_price", assets.Price);
                        command.Parameters.AddWithValue("@p_usedate", assets.UseDate);
                        command.Parameters.AddWithValue("@p_status", assets.Status);

                        command.ExecuteNonQuery();
                        return "Add Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddAsset: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static string updateAsset(Assets assets)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    using (MySqlCommand command = new MySqlCommand("proc_updateAsset", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@p_roomid", assets.RoomId);
                        command.Parameters.AddWithValue("@p_assetid", assets.AssetId);
                        command.Parameters.AddWithValue("@p_assetname", assets.AssetName);
                        command.Parameters.AddWithValue("@p_price", assets.Price);
                        command.Parameters.AddWithValue("@p_usedate", assets.UseDate);
                        command.Parameters.AddWithValue("@p_status", assets.Status);

                        command.ExecuteNonQuery();
                        return "Update Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateAsset: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static (bool success, string message) DeleteAssets(string assetid)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteAssets", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_assetid", assetid);
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

        public static DataTable LoadAssetDetail(string username, string buildingid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("sp_AssetDetails", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_username", username);
                    command.Parameters.AddWithValue("@p_buildingid", buildingid);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable FilterAssets(string username, string priceSort, string nameSort, string buildingid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("sp_FilterAssets", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_username", username);
                        command.Parameters.AddWithValue("@p_sort_order", string.IsNullOrEmpty(priceSort) ? null : priceSort);
                        command.Parameters.AddWithValue("@p_asset_name", string.IsNullOrEmpty(nameSort) ? null : nameSort);
                        command.Parameters.AddWithValue("@p_buildingid", string.IsNullOrEmpty(buildingid) ? null : buildingid);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in FilterAssets: " + ex.Message);
            }
            return dt;
        }
    }
}
