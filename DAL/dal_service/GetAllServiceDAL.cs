using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.DTO_Service;

namespace DAL.dal_service
{
    public class GetAllServiceDAL
    {
        public List<DichVuDTO> GetAllDichVu()
        {
            List<DichVuDTO> list = new List<DichVuDTO>();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetAllDichVu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    DichVuDTO item = new DichVuDTO
                                    {
                                        ID = reader.GetString("ServiceID"),
                                        TenDichVu = reader.GetString("ServiceName"),
                                        GiaDichVu = reader.GetInt32("UnitPrice")
                                    };

                                    list.Add(item);
                                }
                                catch (Exception itemEx)
                                {
                                    Console.WriteLine($"Lỗi đọc dòng dữ liệu: {itemEx.Message}");
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Lỗi MySQL: {ex.Message}");
                Console.WriteLine($"Chi tiết: {ex.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối hoặc xử lý: {ex.Message}");
            }

            return list;
        }
    }

}
