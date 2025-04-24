using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL.honhathao
{
    public class TenantHistoryAccess
    {
        public static DataTable load_AllTenantHistory(string name)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_allTH", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if(name != null)
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
        public static string update_tenantHistory(string tenantHistoryid, string note)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("update_tenantHistory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_tenantHistoruid", tenantHistoryid);
                    command.Parameters.AddWithValue("@p_note", note);

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

        public static void auto_AddTenantHistory(string contractid, string tenantid, string roomid, string startdate, string enddate, string buildingid)
        {
            //try
            //{
            Console.WriteLine(contractid + " " + tenantid + " " + roomid + " " + startdate + " " + enddate);
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                using (MySqlCommand command = new MySqlCommand("auto_AddTenantHistory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_CONTRACTID", contractid);
                    command.Parameters.AddWithValue("@p_TENANTID", tenantid);
                    command.Parameters.AddWithValue("@p_ROOMID", roomid);
                    command.Parameters.AddWithValue("@p_STARTDATE",DateTime.Parse(startdate));
                    command.Parameters.AddWithValue("@p_ENDDATE", DateTime.Parse(enddate));
                    command.Parameters.AddWithValue("@p_buildingid", buildingid);
                    command.ExecuteNonQuery();
                }
            }

        //}
        //    catch (Exception ex)
        //    {
                
        //    }

        }


        public static DataTable count_TenantHistory(string buildingID)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_outdateContract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_buildingID", buildingID);
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






        //Của tenant
        public static DataTable load_Tenant(string buildingID, string name)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_lstn", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_buildingID", buildingID);
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
    }
}
