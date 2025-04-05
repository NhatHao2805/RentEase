using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL.honhathao
{
    public class TenantAccess
    {
        public static List<string> Load_TenantID()
        {
            List<string> name = new List<string>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return name;
                using (MySqlCommand command = new MySqlCommand("Select TENANTID from tenant", conn))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                name.Add(reader.GetString(0));
                            }
                        }
                        else
                        {
                            return name;
                        }
                    }
                }
            }
            return name;

        }
        public static DataTable load_Tenant(string username,string name)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_Tenant", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_username", username);
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
        public static String add_Tenant(string username, string FirstName,string LastName,string Birthday, string Gender ,string PhoneNumber ,string Email )
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("add_Tenant", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_username", username);
                        command.Parameters.AddWithValue("@p_FirstName", FirstName);
                        command.Parameters.AddWithValue("@p_LastName", LastName);
                        command.Parameters.AddWithValue("@p_Birthday", Birthday);
                        command.Parameters.AddWithValue("@p_Gender", Gender);
                        command.Parameters.AddWithValue("@p_PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@p_Email", Email);
                        command.ExecuteNonQuery();
                    }
                }

        }   
            catch (Exception ex)
            {
                return "Fail to Add Tenant";
            }
            return "Success to Add Tenant";
        }

        public static String update_Tenant(string TenantId, string FirstName, string LastName, string Birthday, string Gender, string PhoneNumber, string Email)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("update_Tenant", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_TenantID", TenantId);
                        command.Parameters.AddWithValue("@p_FirstName", FirstName);
                        command.Parameters.AddWithValue("@p_LastName", LastName);
                        command.Parameters.AddWithValue("@p_Birthday", Birthday);
                        command.Parameters.AddWithValue("@p_Gender", Gender);
                        command.Parameters.AddWithValue("@p_PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@p_Email", Email);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                return "Fail to update Tenant";
            }
            return "Success to update Tenant";
        }

        public static String del_Tenant(string TenantId)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("del_Tenant", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_TenantID", TenantId);
                        command.ExecuteNonQuery(); 
                    }
                }

            }
            catch (Exception ex)
            {
                return "Fail to delete Tenant";
            }
            return "Success to delete Tenant";
        }
    }
}
