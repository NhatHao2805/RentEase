using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Service
{
    public class UpdatePriceDAL
    {
      
        public bool UpdateServicePrice(string serviceName, decimal newPrice)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("UpdateServicePrice", conn))
                    {
                      
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_ServiceID", serviceName);
                        cmd.Parameters.AddWithValue("p_NewPrice", newPrice);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                 

                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
