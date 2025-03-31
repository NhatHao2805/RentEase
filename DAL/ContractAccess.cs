using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class ContractAccess
    {
        public static DataTable load_Contract(string Username)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_Contract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_username", Username);

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

        public static String add_Contract(string HouseAddress, string RoomId, string TenantName, string CreateDate, string StartDate, string EndDate, string PaymenSchedule, string Deposite, string Note)
        {
            //try
            //{
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("add_Contract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_address_room", HouseAddress);
                        command.Parameters.AddWithValue("@p_id_room", RoomId);
                        command.Parameters.AddWithValue("@p_fullname_user", TenantName);
                        command.Parameters.AddWithValue("@p_createddate", CreateDate);
                        command.Parameters.AddWithValue("@p_startdate", StartDate);
                        command.Parameters.AddWithValue("@p_enddate", EndDate);
                        command.Parameters.AddWithValue("@p_paymentschedule", PaymenSchedule);
                        command.Parameters.AddWithValue("@p_deposit", Deposite);
                        command.Parameters.AddWithValue("@p_note", Note);
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
        //alter_Contract
        public static string alter_Contract(string contractid)
        {
            StringBuilder output = new StringBuilder();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("alter_Contract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contract_id", contractid);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int columnCount = reader.FieldCount;
                                for (int i = 0; i < columnCount; i++)
                                {
                                    if (!reader.IsDBNull(i))
                                    {
                                        if (reader.GetFieldType(i) == typeof(DateTime))
                                        {
                                            DateTime dateValue = reader.GetDateTime(i);
                                            output.Append(dateValue.ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                        else if(reader.GetFieldType(i) == typeof(float))
                                        {
                                            output.Append(reader.GetFloat(i));
                                        }
                                        else
                                        {
                                            output.Append(reader.GetString(i));
                                        }
                                    }
                                    else
                                    {
                                        output.Append("[NULL]");
                                    }
                                    if (i < columnCount - 1)
                                    {
                                        output.Append("|");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);

            }
            return output.ToString();
        }
        public static string update_Contract(string contractid,string enddate,string paymentschedule, string deposit, string note)
        {

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("update_Contract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_contractId", contractid);
                        command.Parameters.AddWithValue("@p_endDate", enddate);
                        command.Parameters.AddWithValue("@p_paymentSchedule", paymentschedule);
                        command.Parameters.AddWithValue("@p_deposit", deposit);
                        command.Parameters.AddWithValue("@p_notes", note);
                        MySqlDataReader reader = command.ExecuteReader();
                    }
                }
        }
            catch (Exception ex)
            {
                return "Fail to update Contract";
            }
            return "Success to update Contract";

        }

        public static string delete_Contract(string contractid)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("del_Contract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contract_id", contractid);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Fail to delete Contract";
            }
            return "Success to delete Contract";

        }
    }
}
