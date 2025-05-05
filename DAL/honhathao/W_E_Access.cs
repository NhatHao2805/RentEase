using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.dto_service;
using MySql.Data.MySqlClient;
namespace DAL.dal_service
{


    public class W_E_Access
    {
        public static string del_W_E(string tenantID,string startdate, string enddate)
        {
          

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("del_W_E", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_tenantID", tenantID);
                        command.Parameters.AddWithValue("@p_startdate", DateTime.Parse(startdate).Date);
                        command.Parameters.AddWithValue("@p_enddate", DateTime.Parse(enddate).Date);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                return "Fail";

            }
            return "Success";
        }

        public static DataTable load_W_E(string usern,string buildingid)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_W_E", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_user", usern);
                        command.Parameters.AddWithValue("p_buildingid", buildingid);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {


                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                output.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                            }


                            while (reader.Read())
                            {
                                DataRow row = output.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[i] = reader.IsDBNull(i) ? DBNull.Value : reader.GetValue(i);
                                }
                                output.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);

            }
            return output;
        }
        public static string add_W_E(string buildingID, string roomName, string tenantID, string o_w, string n_w, string o_e, string n_e, string month)
        {
            //try
            //{
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("add_w_e", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_buildingID", buildingID);
                    command.Parameters.AddWithValue("@p_roomname", roomName);
                    command.Parameters.AddWithValue("@p_tenantid", tenantID);
                    command.Parameters.AddWithValue("@p_o_w", o_w);
                    command.Parameters.AddWithValue("@p_n_w", n_w);
                    command.Parameters.AddWithValue("@p_o_e", o_e);
                    command.Parameters.AddWithValue("@p_n_e", n_e);
                    command.Parameters.AddWithValue("@p_month", month);
                    command.ExecuteNonQuery();
                }
            }

            //}
            //catch (Exception ex)
            //{
            //    return "Fail to Add Contract";
            //}
            return "Success to Add Contract";
        }   

    }

}
