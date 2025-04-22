using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System.IO;

namespace DAL
{
    public class AccountAccess
    {
        public static string AccountAccess_CheckLogin(User taikhoan)
        {
            string user = null;
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "Database connection failed!";

                using (MySqlCommand command = new MySqlCommand("proc_login", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usern", taikhoan.Username);
                    command.Parameters.AddWithValue("@passw", taikhoan.Password);

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
        public static string AccountAccess_CheckSignUp(User taikhoan)
        {
            bool check = false;

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "Database connection failed!";

                using (MySqlCommand command2 = new MySqlCommand("SELECT check_account(@usern)", conn))
                {
                    command2.Parameters.AddWithValue("@usern", taikhoan.Username);
                    object a = command2.ExecuteScalar();
                    Console.WriteLine(Convert.ToInt32(a));
                    Console.WriteLine(a != null);
                    Console.WriteLine(a != null && Convert.ToInt32(a) == 1);
                    if (a != null && Convert.ToInt32(a) == 1)
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    using (MySqlCommand command = new MySqlCommand("proc_addAccount", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //usern,fulln, passw,emai,birthd,gender,phonen,addre
                        command.Parameters.AddWithValue("@usern", taikhoan.Username);
                        command.Parameters.AddWithValue("@passw", taikhoan.Password);
                        command.Parameters.AddWithValue("@fulln", taikhoan.FullName);
                        command.Parameters.AddWithValue("@emai", taikhoan.Email);
                        command.Parameters.AddWithValue("@birthd", taikhoan.Birth);
                        command.Parameters.AddWithValue("@gender", taikhoan.Gender);
                        command.Parameters.AddWithValue("@phonen", taikhoan.PhoneNumber);
                        command.Parameters.AddWithValue("@addre", taikhoan.Address);
                        command.ExecuteNonQuery();
                        return "Đăng ký thành công!";
                    }

                }
            }
            return "Tài khoản đã tồn tại!";
        }

        public static List<string> Load_TenantName()
        {
            List<string> name = new List<string>();
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return name;

                using (MySqlCommand command = new MySqlCommand("Select FIRSTNAME,LASTNAME from tenant", conn))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                name.Add(reader.GetString(0) + " " + reader.GetString(1));
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

        public static string UpdatePassword(string email, string password)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn == null) return "Database connection failed!";

                    //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

                    using (MySqlCommand command = new MySqlCommand("UpdatePassword", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("p_email", email);
                        command.Parameters.AddWithValue("p_password", password);

                        command.ExecuteNonQuery();
                        return "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"System error: {ex.GetType().Name}";
            }
        }

        public static string CheckEmail(string email)
        {
            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM USER WHERE EMAIL=@p_email;", conn))
                    {
                        command.Parameters.AddWithValue("p_email", email);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0 ? "Valid" : "Invalid";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckEmail: " + ex.Message);
                return "Error";
            }
        }
    }

}
