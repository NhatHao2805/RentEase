// DAL/FingerprintAccess.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using DTO;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DAL
{
    public class FingerprintAccess
    {
        // Lấy danh sách vân tay theo username (chủ trọ)
        public static DataTable GetFingerprints(string username)
        {
            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("GetFingerprints", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_username", username);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            conn.Close();
            return dataTable;
        }

        // Thêm vân tay mới
        public static bool AddFingerprint(FingerprintDTO fingerprint)
        {
            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("AddFingerprint", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Generate ID with format FP + random number
            string fingerprintID = "FP" + new Random().Next(100000, 999999).ToString();

            cmd.Parameters.AddWithValue("@p_fingerid", fingerprintID);
            cmd.Parameters.AddWithValue("@p_username", fingerprint.Username);
            cmd.Parameters.AddWithValue("@p_tenantid", fingerprint.TenantID);
            cmd.Parameters.AddWithValue("@p_areapermission", fingerprint.AreaPermission);
            cmd.Parameters.AddWithValue("@p_fingerprint_image", fingerprint.FingerprintImage);
            cmd.Parameters.AddWithValue("@p_image_name", fingerprint.ImageName);

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result > 0;
        }

        // Xóa vân tay 
        public static bool DeleteFingerprint(string fingerprintID)
        {
            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("DeleteFingerprint", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_fingerid", fingerprintID);

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result > 0;
        }

        // Cập nhật quyền truy cập khu vực
        public static bool UpdateAreaPermission(string fingerprintID, string areaPermission)
        {
            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("UpdateAreaPermission", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_fingerid", fingerprintID);
            cmd.Parameters.AddWithValue("@p_areapermission", areaPermission);

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result > 0;
        }

        // Cập nhật ảnh vân tay
        public static bool UpdateFingerprintImage(string fingerprintID, byte[] imageData, string imageName)
        {
            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("UpdateFingerprintImage", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_fingerid", fingerprintID);
            cmd.Parameters.AddWithValue("@p_fingerprint_image", imageData);
            cmd.Parameters.AddWithValue("@p_image_name", imageName);

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result > 0;
        }

        // Lấy ảnh vân tay
        public static byte[] GetFingerprintImage(string fingerprintID)
        {
            byte[] imageData = null;

            try
            {
                MySqlConnection conn = MySqlConnectionData.Connect();

                string query = "SELECT FINGERPRINT_IMAGE FROM FINGERPRINT WHERE FINGERID = @fingerid AND ISDELETED = 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fingerid", fingerprintID);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    imageData = (byte[])result;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving fingerprint image: {ex.Message}");
            }

            return imageData;
        }

        // Lấy danh sách người thuê
        // DAL/FingerprintAccess.cs
        public static List<TenantDTO> GetTenantsByUsername(string username, string buildingID)
        {
            List<TenantDTO> tenants = new List<TenantDTO>();

            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("GetTenantsByUsername", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_username", username);
            cmd.Parameters.AddWithValue("@p_buildingid", buildingID);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    TenantDTO tenant = new TenantDTO
                    {
                        TenantID = reader["TENANTID"].ToString(),
                        FirstName = reader["FIRSTNAME"].ToString(),
                        LastName = reader["LASTNAME"].ToString(),
                        PhoneNumber = reader["PHONENUMBER"].ToString()
                    };

                    tenants.Add(tenant);
                }
            }

            conn.Close();
            return tenants;
        }

        // Lấy danh sách khu vực có thể truy cập
        public static List<AreaPermissionDTO> GetAvailableAreas(string buildingID)
        {
            List<AreaPermissionDTO> areas = new List<AreaPermissionDTO>();

            MySqlConnection conn = MySqlConnectionData.Connect();
            MySqlCommand cmd = new MySqlCommand("GetAccessAreas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_buildingid", buildingID);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    AreaPermissionDTO area = new AreaPermissionDTO
                    {
                        AreaID = reader["AreaID"].ToString(),
                        AreaName = reader["AreaName"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    areas.Add(area);
                }
            }

            conn.Close();
            return areas;
        }


        // DAL/FingerprintAccess.cs

        // Lấy dữ liệu ảnh vân tay từ cơ sở dữ liệu
        //public static byte[] GetFingerprintImageData(string fingerprintID)
        //{
        //    byte[] imageData = null;

        //    try
        //    {
        //        MySqlConnection conn = MySqlConnectionData.Connect();

        //        string query = "SELECT FINGERPRINT_IMAGE FROM FINGERPRINTS WHERE FINGERID = @fingerid";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@fingerid", fingerprintID);

        //        object result = cmd.ExecuteScalar();
        //        if (result != null && result != DBNull.Value)
        //        {
        //            imageData = (byte[])result;
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error retrieving fingerprint image: {ex.Message}");
        //    }

        //    return imageData;
        //}
        // Giả định hàm gốc có thể không xử lý đúng BLOB hoặc trả về null
        public static byte[] GetFingerprintImageData(string fingerprintID)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if(conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    string query = "SELECT FINGERPRINT_IMAGE FROM fingerprints WHERE FingerID = @FingerprintID AND ISDELETED = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FingerprintID", fingerprintID);

                        object result = cmd.ExecuteScalar();

                        // Check for null - this can be a common issue
                        if (result == null || result == DBNull.Value)
                        {
                            Console.WriteLine($"No fingerprint image data found for ID: {fingerprintID}");
                            return null;
                        }

                        // Correctly handle BLOB data type
                        if (result is byte[] imageData)
                        {
                           
                            return imageData;
                        }
                        else
                        {
                         
                            // Some DBMS return BLOB as other than byte[]
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Read BLOB data through MySqlDataReader
                                    if (!reader.IsDBNull(0))
                                    {
                                        return (byte[])reader[0];
                                    }
                                }
                            }
                        }
                    }
                    conn.Close();
                }          
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting fingerprint image data: {ex.Message}");
                // Log error
                return null;
            }
        }


        public static string GetFingerprintImageName(string fingerprintID)
        {
            string imageName = null;

            try
            {
                MySqlConnection conn = MySqlConnectionData.Connect();

                string query = "SELECT IMAGE_NAME FROM FINGERPRINTS WHERE FINGERID = @fingerid AND ISDELETED = 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fingerid", fingerprintID);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    imageName = result.ToString();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving fingerprint image name: {ex.Message}");
            }

            return imageName;
        }


        // Thêm khu vực mới
        public static bool AddArea(string buildingID, string areaName, string description)
        {
            try
            {
                MySqlConnection conn = MySqlConnectionData.Connect();
                MySqlCommand cmd = new MySqlCommand("AddArea", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Generate ID with format AR + random number
                string areaID = "AR" + new Random().Next(100000, 999999).ToString();

                cmd.Parameters.AddWithValue("@p_areaid", areaID);
                cmd.Parameters.AddWithValue("@p_buildingid", buildingID);
                cmd.Parameters.AddWithValue("@p_areaname", areaName);
                cmd.Parameters.AddWithValue("@p_description", description ?? "");

                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding area: {ex.Message}");
                return false;
            }
        }

        // Cập nhật thông tin khu vực
        public static bool UpdateArea(string areaID, string areaName, string description)
        {
            try
            {
                MySqlConnection conn = MySqlConnectionData.Connect();
                MySqlCommand cmd = new MySqlCommand("UpdateArea", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_areaid", areaID);
                cmd.Parameters.AddWithValue("@p_areaname", areaName);
                cmd.Parameters.AddWithValue("@p_description", description ?? "");

                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating area: {ex.Message}");
                return false;
            }
        }

        // Xóa khu vực
        public static bool DeleteArea(string areaID)
        {
            try
            {
                MySqlConnection conn = MySqlConnectionData.Connect();
                MySqlCommand cmd = new MySqlCommand("DeleteArea", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_areaid", areaID);

                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting area: {ex.Message}");
                return false;
            }
        }

    }
}