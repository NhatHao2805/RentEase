using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAL_Service;
using DTO;
using DTO.DTO_Service;
using MySql.Data.MySqlClient;

namespace DAL.DAL_Service
{
    public class UserServiceDAL
    {
        public List<UserServiceDTO> GetServiceUsage()
        {
            List<UserServiceDTO> list = new List<UserServiceDTO>();
        
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        using (MySqlCommand cmd = new MySqlCommand("GetServiceUsage", conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {

                                    try
                                    {
                                        UserServiceDTO item = new UserServiceDTO
                                        {
                                            STT = reader.GetInt32("STT"),
                                            RoomID = reader.GetString("ROOMID"),
                                            TenantName = reader.GetString("TENANTNAME"),
                                            ServiceName = reader.GetString("SERVICENAME"),
                                            ServicePrice = reader.GetDecimal("UNITPRICE"),
                                            Start = reader.GetDateTime("START_DATE"),
                                            End = reader.GetDateTime("END_DATE")
                                        };
                                        list.Add(item);
                                    }
                                    catch (Exception itemEx)
                                    {
                                        // Log chi tiết lỗi khi đọc từng dòng
                                        Console.WriteLine($"Lỗi đọc dòng dữ liệu: {itemEx.Message}");
                                    }
                                }
                            }
                        }
                    }

                    catch (MySqlException ex)
                    {
                        // In ra chi tiết lỗi
                        Console.WriteLine($"Lỗi MySQL: {ex.Message}");
                        Console.WriteLine($"Mã lỗi: {ex.Number}");
                        Console.WriteLine($"Chi tiết: {ex.ToString()}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi chi tiết
                Console.WriteLine($"Lỗi kết nối hoặc truy vấn: {ex.Message}");
            }
           
            return list;
        }
    }
}
