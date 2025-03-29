using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Service
{
    public class DichVuDAL
    {
      

        public bool XoaDichVu(string id)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                Console.WriteLine(id);
                try
                {

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("DeleteDichVu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_serviceID", id);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
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
