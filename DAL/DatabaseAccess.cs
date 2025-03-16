using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Principal;
using MySql.Data.MySqlClient;
using DTO;
namespace DAL
{
    public class MySqlConnectionData
    {
        // Chuỗi kết nối
        public static string connectString = "server=localhost;user=root;pwd=zxcvbnm;database=rentease;port=3306";

        // Phương thức tạo và mở kết nối
        public static MySqlConnection Connect()
        {
            MySqlConnection conn = new MySqlConnection(connectString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Lỗi khi mở kết nối: " + ex.Message);
            }
            return conn;
        }
    }
    public class DatabaseAccess
    {
        // Phương thức kiểm tra đăng nhập
        public static string checkLoginDatabase(Account taikhoan)
        {
            string user = null;
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand("proc_login", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_user", taikhoan.taikhoan);
                        command.Parameters.AddWithValue("p_pass", taikhoan.matkhau);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    user = reader.GetString(0); // Lấy giá trị cột đầu tiên (username)
                                }
                            }
                            else
                            {
                                return "Tài khoản hoặc mật khẩu không chính xác!";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Lỗi khi đăng nhập: " + ex.Message);
                    return "Đã xảy ra lỗi khi đăng nhập!";
                }
            }
            return user;
        }

        // Phương thức thêm tài khoản
        public static string addAccountDatabase(Account taikhoan)
        {
            bool check = false;
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                try
                {
                    // Kiểm tra tài khoản đã tồn tại chưa
                    using (MySqlCommand command2 = new MySqlCommand("SELECT check_account(@p_user, @p_pass)", conn))
                    {
                        command2.Parameters.AddWithValue("@p_user", taikhoan.taikhoan);
                        command2.Parameters.AddWithValue("@p_pass", taikhoan.matkhau);
                        object result = command2.ExecuteScalar();
                        if (result != null && Convert.ToInt32(result) == 1)
                        {
                            check = true;
                        }
                        else
                        {
                            if (result != null && Convert.ToInt32(result) == 2)
                            {
                                return "Mật khẩu bao gồm tổi thiểu 6 kí tự";
                            }
                            else if (result != null && Convert.ToInt32(result) == 3)
                            {
                                return "Mật khẩu bao gồm tối đa 20 kí tự";
                            }
                            else
                            {
                                check = false;
                            }
                        }
                    }

                    // Nếu tài khoản chưa tồn tại, thêm tài khoản mới
                    if (!check)
                    {
                        
                        using (MySqlCommand command = new MySqlCommand("proc_addAccount", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("p_user", taikhoan.taikhoan);
                            command.Parameters.AddWithValue("p_pass", taikhoan.matkhau);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Lỗi khi đăng ký: " + ex.Message);
                    return "Đã xảy ra lỗi khi đăng ký!";
                }
            }

            // Trả về thông báo kết quả
            if (check)
            {
                return "Tài khoản đã tồn tại!";
            }
            else
            {
                return "Đăng ký thành công!";
            }
        }
    }
}