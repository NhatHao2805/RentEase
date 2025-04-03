using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.dto_service;
using MySql.Data.MySqlClient;
namespace DAL.dal_service
{


    public class ElectricWaterServiceDAL
    {


        public List<ElectricWaterServiceDTO> GetAllElectricWaterData(string buildingID)
        {
            List<ElectricWaterServiceDTO> dataList = new List<ElectricWaterServiceDTO>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("GetAllElectricWaterData", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số buildingID
                        cmd.Parameters.AddWithValue("@p_buildingID", buildingID);


                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ElectricWaterServiceDTO data = new ElectricWaterServiceDTO()
                            {
                                FigureID = reader["FIGUREID"].ToString(),
                                TenantID = reader["TENANTID"].ToString(),
                                OldFigure = Convert.ToInt32(reader["OLDFIGURE"]),
                                NewFigure = Convert.ToInt32(reader["NEWFIGURE"]),
                                Unit = reader["UNIT"].ToString(),
                                StartDate = Convert.ToDateTime(reader["START_DATE"]),
                                EndDate = Convert.ToDateTime(reader["END_DATE"]),
                                RecordDate = Convert.ToDateTime(reader["RECORD_DATE"]),
                                Type = reader["TYPE"].ToString()
                            };
                            dataList.Add(data);
                        }
                    }
                    
                       
                    
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Connection error: " + e.Message);
                }
               
            }

            return dataList;
        }

    }

}
