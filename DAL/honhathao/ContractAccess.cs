using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class ContractAccess
    {
        public static bool Check_Contract(string BuildingID, string TenantID, string RoomName)
        {

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {

                string query = "" +
                    "SELECT Count(c.CONTRACTID) from Contract c " +
                    "JOIN ROOM r ON c.ROOMID = r.ROOMID " +
                    "JOIN BUILDING b ON b.BUILDINGID = r.BUILDINGID " + 
                    "JOIN Tenant t on t.TENANTID = c.TENANTID " + 
                    "WHERE c.TENANTID = @TenantID " +  
                    "AND r.ROOMNAME = @RoomName " +  
                    "AND b.BUILDINGID = @BuildingID " +  
                    "AND c.ISDELETED = 0";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenantID", TenantID);
                    cmd.Parameters.AddWithValue("@RoomName", RoomName);
                    cmd.Parameters.AddWithValue("@BuildingID", BuildingID);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("Count: " + count);
                    return count == 0;
                }
            }

        }
        public static List<string> GetRoomsByTenantID(string tenantID)
        {
            List<string> roomList = new List<string>();

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return roomList;

                string query = "SELECT r.ROOMNAME FROM Contract c JOIN ROOM r ON c.ROOMID = r.ROOMID WHERE TENANTID = @TenantID AND ISDELETED = 0";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenantID", tenantID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomList.Add(reader.GetString("ROOMID"));
                        }
                    }
                }
            }
            return roomList;
        }
        public static DataTable load_Contract(string buildingID,int control,string name)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_Contract_filter", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_buildingID", buildingID);
                        command.Parameters.AddWithValue("@control", control);
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
        public static DataTable load_Contract(string buildingID)
        {
            DataTable output = new DataTable();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("load_Contract", conn))
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

        public static String add_Contract(string buildingid, string RoomId, string Tenantid, string CreateDate, string StartDate, string EndDate, string PaymenSchedule, string Deposite, string Note)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    using (MySqlCommand command = new MySqlCommand("add_Contract", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_building_id", buildingid);
                        command.Parameters.AddWithValue("@p_id_room", RoomId);
                        command.Parameters.AddWithValue("@p_tenantid", Tenantid);
                        command.Parameters.AddWithValue("@p_createddate", CreateDate);
                        command.Parameters.AddWithValue("@p_startdate", StartDate);
                        command.Parameters.AddWithValue("@p_enddate", EndDate);
                        command.Parameters.AddWithValue("@p_paymentschedule", PaymenSchedule);
                        command.Parameters.AddWithValue("@p_deposit", Deposite);
                        command.Parameters.AddWithValue("@p_note", Note);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                return "Thêm thất bại";
            }
            return "Thêm thành công!";
        }
        //alter_Contract
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
                return "Cập nhật thất bại";
            }
            return "Cập nhật thành công!";

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
                return "fail_";
            }
            return "success_";

        }
    }
}
