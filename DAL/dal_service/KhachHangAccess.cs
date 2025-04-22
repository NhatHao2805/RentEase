using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTO_Service;
using System.Data;
using System.Data.SqlClient;

using MySql.Data.MySqlClient;
using DTO;
namespace DAL.DAL_Service
{


    public class KhachHangAccess
    {
        public static List<KhachHangDTO> Load_KhachHang(string buildingID)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return list;

                using (MySqlCommand cmd = new MySqlCommand("GetTenantsByBuilding", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@p_buildingID", buildingID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KhachHangDTO
                            {
                                ID = reader["TenantID"].ToString(),
                                Ho = reader["FIRSTNAME"].ToString(),
                                Ten = reader["LASTNAME"].ToString()
                            });
                        }
                    }
                }
            }
            return list;

        }
    }
    public class PhongAccess
    {
        public static List<PhongDTO> Load_Phong()
        {
            List<PhongDTO> list = new List<PhongDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return list;

                string query = "SELECT ROOMID FROM room";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PhongDTO
                            {
                                ID = reader["ROOMID"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
        public static List<PhongDTO> GetPhongByTenantID(string tenantID,string buildingID)
        {
            List<PhongDTO> rooms = new List<PhongDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return rooms;

                using (MySqlCommand cmd = new MySqlCommand("GetRoomsByTenantAndBuilding", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@p_tenantID", tenantID);
                    cmd.Parameters.AddWithValue("@p_buildingID", buildingID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new PhongDTO { ID = reader.GetString("ROOMID") });
                        }
                    }
                }
            }
            return rooms;

        }

    }
    public class DichVuAccess
    {
        public static List<DichVuDTO> Load_DichVu()
        {
            List<DichVuDTO> list = new List<DichVuDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return list;

                string query = "SELECT SERVICEID, SERVICENAME, UNITPRICE FROM service";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DichVuDTO
                            {
                                ID = reader["SERVICEID"].ToString(),
                                TenDichVu = reader["SERVICENAME"].ToString(),
                                GiaDichVu = reader.GetDecimal("UNITPRICE")
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static bool AddService(string tenantID, string roomID, string serviceID, int price)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return false;
                string query = "INSERT INTO servicecontract (TENANTID, ROOMID, SERVICEID, PRICE) VALUES (@tenantID, @roomID, @serviceID, @price)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenantID", tenantID);
                    cmd.Parameters.AddWithValue("@roomID", roomID);
                    cmd.Parameters.AddWithValue("@serviceID", serviceID);
                    cmd.Parameters.AddWithValue("@price", price);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }

            }
    }

}


