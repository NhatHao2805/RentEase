using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTO_Service;
using MySql.Data.MySqlClient;
namespace DAL.DAL_Service
{
    public class ContractAccess
    {
        public static List<string> GetRoomsByTenantID(string tenantID)
        {
            List<string> roomList = new List<string>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return roomList;

                string query = "SELECT ROOMID FROM Contract WHERE TENANTID = @TenantID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenantID", tenantID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomList.Add(reader.GetString("ROOMID"));
                        }
                    }
                }
            }
            return roomList;
        }
    }
    
}
