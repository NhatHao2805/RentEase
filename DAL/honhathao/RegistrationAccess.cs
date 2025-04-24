using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL.honhathao
{
    public class RegistrationAccess
    {
        public static string del_registration(string p_registration_id)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("del_registration", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_registration_id", p_registration_id);
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
        public static DataTable load_registration(string buildingid,string name)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_registration", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new MySqlParameter("@p_building_id", buildingid));
                        if (name != null)
                        {
                            command.Parameters.AddWithValue("p_lastname", name);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("p_lastname", DBNull.Value);
                        }
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
        public static String add_Registration(string p_tenant_id, string RoomId, string registration_date, string expiration_date, string status, string buildingid)
        {
            try
            {
                Console.WriteLine(p_tenant_id);
            using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("add_Registration", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_tenant_id", p_tenant_id);
                        command.Parameters.AddWithValue("@p_room_id", RoomId);
                        command.Parameters.AddWithValue("@p_registration_date", registration_date);
                        command.Parameters.AddWithValue("@p_expiration_date", expiration_date);
                        command.Parameters.AddWithValue("@p_status", status);
                        command.Parameters.AddWithValue("@p_buildingid", buildingid);
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
        public static string update_registration(string registrationid,string state)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("update_registration", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_registration_id", registrationid);
                        command.Parameters.AddWithValue("@p_status", state);
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
    }
}
