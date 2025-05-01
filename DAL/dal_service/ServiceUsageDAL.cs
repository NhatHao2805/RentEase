using DTO.DTO_Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.DAL_Service
{
    public class ServiceUsageDAL
    {
        public bool     InsertServiceUsage(ServiceUsageDTO serviceUsage)
        {
            string query = "CALL INSERT_SERVICE_USAGE(@TenantID, @ServiceID, @RoomID, @StartDate, @EndDate)";

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenantID", serviceUsage.TenantID);
                        cmd.Parameters.AddWithValue("@ServiceID", serviceUsage.ServiceID);
                        cmd.Parameters.AddWithValue("@RoomID", serviceUsage.RoomID);
                        cmd.Parameters.AddWithValue("@StartDate", serviceUsage.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", serviceUsage.EndDate);

                        // Đọc kết quả trả về từ stored procedure
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("success") == 1;
                            }
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false; // Nếu có lỗi, cứ cho là đã tồn tại để tránh insert sai
                }
            }
        }



     
    

    }

}
