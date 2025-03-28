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
    public class DeleteTenantService
    {
        public bool DeleteTenant_Service(ServiceUsageDTO serviceUsage1)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("DeleteTenantService", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Không cần CALL

                        cmd.Parameters.AddWithValue("p_TenantID", serviceUsage1.TenantID);
                        cmd.Parameters.AddWithValue("p_ServiceID", serviceUsage1.ServiceID);

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            return rowsAffected > 0; // Trả về true nếu xóa thành công (có dòng bị ảnh hưởng)
                        }
                        catch (MySqlException sqlEx)
                        {
                            Console.WriteLine("SQL Error when deleting: " + sqlEx.Message);
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
