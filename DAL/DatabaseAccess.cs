using System;
using System.Data;
using MySql.Data.MySqlClient;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class MySqlConnectionData
    {
        // Connection string for MySQL
        private static readonly string connectString = "server=localhost;port=3306;database=rentease;user=root;password=;";

        public static MySqlConnection Connect()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectString);
                connection.Open();
                Console.WriteLine("Connected to MySQL successfully!");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Connection error: " + e.Message);
            }
            return connection;
        }


        public List<ContractDTO> GetAllContracts(String required)
        {
            List<ContractDTO> contractList = new List<ContractDTO>();
            string query = "SELECT * FROM CONTRACT";
            if (required == "All")
            {
                query = "SELECT * FROM CONTRACT"; ;
            }
            else if (required == "Active")
            {
                query = "SELECT * FROM CONTRACT WHERE STATUS = 'Đang hiệu lực'";
            }
            else if (required == "Inactive")
            {
                query = "SELECT * FROM CONTRACT WHERE STATUS = 'Đã chấm dứt'";
            }
                using (MySqlConnection conn = Connect())
                {
                    if (conn == null)
                    {
                        throw new Exception("Không thể kết nối đến cơ sở dữ liệu.");
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractDTO contract = new ContractDTO(
                                    reader.GetString("CONTRACTID"),
                                    reader.GetString("HOUSEID"),
                                    reader.GetString("TENANTID"),
                                    reader.GetDateTime("CREATEDATE"),
                                    reader.GetDateTime("STARTDATE"),
                                    reader.GetDateTime("ENDDATE"),
                                    reader.GetFloat("MONTHLYRENT"),
                                    reader.GetString("PAYMENTSCHEDULE"),
                                    reader.GetFloat("DEPOSIT"),
                                    reader.GetString("STATUS"),
                                    reader.GetString("NOTES"),
                                    reader.GetBoolean("AUTO_RENEW"),
                                    reader.IsDBNull(reader.GetOrdinal("TERMINATION_REASON")) ? "" : reader.GetString("TERMINATION_REASON"),
                                    reader.IsDBNull(reader.GetOrdinal("CONTRACT_FILE_PATH")) ? "" : reader.GetString("CONTRACT_FILE_PATH")
                                );

                                // In ra console để kiểm tra
                                Console.WriteLine($"Contract ID: {contract.ContractID}, House ID: {contract.HouseID}, Tenant ID: {contract.TenantID}");

                                contractList.Add(contract);
                            }
                        }
                    }
                }
            return contractList;
        }



    }

    public class DatabaseAccess
    {
        public static string CheckLoginDatabase(Account taikhoan)
        {
            string user = null;
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "Database connection failed!";

                using (MySqlCommand command = new MySqlCommand("proc_login", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@user", taikhoan.taikhoan);
                    command.Parameters.AddWithValue("@pass", taikhoan.matkhau);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user = reader.GetString(0);
                            }
                        }
                        else
                        {
                            return "Tài khoản hoặc mật khẩu không chính xác!";
                        }
                    }
                }
            }
            return user;
        }

        public static string AddAccountDatabase(Account taikhoan)
        {
            bool check = false;

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "Database connection failed!";

                using (MySqlCommand command2 = new MySqlCommand("SELECT check_account(@user)", conn))
                {
                    command2.Parameters.AddWithValue("@user", taikhoan.taikhoan);
                    object a = command2.ExecuteScalar();
                    if (a != null && Convert.ToInt32(a) == 1)
                    {
                        check = true;
                    }
                }

                if (!check)
                {
                    using (MySqlCommand command = new MySqlCommand("proc_addAccount", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@user", taikhoan.taikhoan);
                        command.Parameters.AddWithValue("@pass", taikhoan.matkhau);
                        command.ExecuteNonQuery();
                    }
                    return "Đăng ký thành công!";
                }
            }
            return "Tài khoản đã tồn tại!";
        }
    }

}
