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
                        if (conn == null)
                        {
                            Console.WriteLine("Cannot connect to database");
                            return list;
                        }
                        
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        // Kiểm tra xem stored procedure có tồn tại không
                        bool procedureExists = false;
                        using (MySqlCommand checkCmd = new MySqlCommand("SHOW PROCEDURE STATUS WHERE Db = 'rentease' AND Name = 'GetServiceUsage'", conn))
                        {
                            using (MySqlDataReader checkReader = checkCmd.ExecuteReader())
                            {
                                procedureExists = checkReader.HasRows;
                            }
                        }

                        if (!procedureExists)
                        {
                            Console.WriteLine("Stored procedure 'GetServiceUsage' does not exist");
                            // Sử dụng câu truy vấn SQL trực tiếp thay vì stored procedure
                            string sql = @"
                                SELECT 
                                    @row_num := @row_num + 1 AS STT,
                                    R.ROOMID, 
                                    CONCAT(T.FIRSTNAME, ' ', T.LASTNAME) AS TENANTNAME,
                                    S.SERVICENAME, 
                                    S.UNITPRICE,
                                    US.START_DATE,
                                    US.END_DATE
                                FROM USE_SERVICE US
                                JOIN TENANT T ON US.TENANTID = T.TENANTID
                                JOIN SERVICE S ON US.SERVICEID = S.SERVICEID
                                JOIN CONTRACT C ON C.TENANTID = T.TENANTID
                                JOIN ROOM R ON C.ROOMID = R.ROOMID";
                            
                            using (MySqlCommand initCmd = new MySqlCommand("SET @row_num = 0", conn))
                            {
                                initCmd.ExecuteNonQuery();
                            }
                            
                            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                            {
                                ProcessResults(cmd, list);
                            }
                        }
                        else
                        {
                            using (MySqlCommand cmd = new MySqlCommand("GetServiceUsage", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                ProcessResults(cmd, list);
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
        
        private void ProcessResults(MySqlCommand cmd, List<UserServiceDTO> list)
        {
            try 
            {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xử lý kết quả: {ex.Message}");
            }
        }
    }
}
