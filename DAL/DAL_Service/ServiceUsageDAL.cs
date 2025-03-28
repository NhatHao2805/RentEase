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
        public bool InsertServiceUsage(ServiceUsageDTO serviceUsage)
        {
            string query = "CALL INSERT_SERVICE_USAGE(@TenantID, @ServiceID, @StartDate, @EndDate)";

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
                        cmd.Parameters.AddWithValue("@StartDate", serviceUsage.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", serviceUsage.EndDate);

                        try {
                            return cmd.ExecuteNonQuery() > 0;
                        }
                        catch (MySqlException sqlEx)
                        {
                            // Nếu lỗi là duplicate key, nghĩa là tenant đã đăng ký dịch vụ này
                            if (sqlEx.Number == 1062) // Mã lỗi Duplicate Entry
                            {
                                Console.WriteLine("Duplicate entry: " + sqlEx.Message);
                                return false;
                            }
                            
                            // Các lỗi khác
                            Console.WriteLine("SQL Error: " + sqlEx.Message);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }



     
    

    }

}
