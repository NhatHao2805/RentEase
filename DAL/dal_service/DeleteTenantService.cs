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
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (MySqlCommand cmd = new MySqlCommand("DeleteTenantService", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Không cần CALL

                    cmd.Parameters.AddWithValue("p_TenantID", serviceUsage1.TenantID);
                    cmd.Parameters.AddWithValue("p_ServiceID", serviceUsage1.ServiceID);
                    cmd.Parameters.AddWithValue("p_RoomID", serviceUsage1.RoomID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu xóa thành công
                }
            }

        }
    }
}
