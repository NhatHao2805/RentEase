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
    public class InsertServiceDAL
    {
        public bool KiemTraTenDichVu(string tenDichVu)
        {
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "SELECT COUNT(*) FROM service WHERE SERVICENAME = @TenDichVu AND ISDELETED = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDichVu", tenDichVu);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0; // Trả về true nếu tên dịch vụ đã tồn tại
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }


        public bool InsertService(DichVuDTO service)
        {
            if (KiemTraTenDichVu(service.TenDichVu))
            {
                return false; // Nếu đã tồn tại, không thêm nữa
            }
            string insert = "CALL InsertService(@p_ServiceName, @p_UnitPrice)";
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(insert, conn))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_ServiceName", service.TenDichVu);
                        cmd.Parameters.AddWithValue("@p_UnitPrice", service.GiaDichVu);



                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }

}
