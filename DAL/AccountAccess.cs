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
    public class AccountAccess:DatabaseAccess
    {
        public static string AccountAccess_CheckLogin(Account taikhoan)
        {
            string user = null;
            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "Database connection failed!";

                using (MySqlCommand command = new MySqlCommand("proc_login", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usern", taikhoan.taikhoan);
                    command.Parameters.AddWithValue("@passw", taikhoan.matkhau);

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
        public static string AccountAccess_CheckSignUp(Account taikhoan)
        {
            bool check = false;

            using (MySqlConnection conn = MySqlConnectionData.Connect())
            {
                if (conn == null) return "Database connection failed!";

                using (MySqlCommand command2 = new MySqlCommand("SELECT check_account(@usern)", conn))
                {
                    command2.Parameters.AddWithValue("@usern", taikhoan.taikhoan);
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
                        //usern,fulln, passw,emai,birthd,gender,phonen,addre
                        command.Parameters.AddWithValue("@usern", taikhoan.taikhoan);
                        command.Parameters.AddWithValue("@passw", taikhoan.matkhau);
                        command.Parameters.AddWithValue("@fulln", taikhoan.hovaten);
                        command.Parameters.AddWithValue("@emai", taikhoan.email);
                        command.Parameters.AddWithValue("@birthd", taikhoan.ngaysinh);
                        command.Parameters.AddWithValue("@gender", taikhoan.gioitinh);
                        command.Parameters.AddWithValue("@phonen", taikhoan.sdt);
                        command.Parameters.AddWithValue("@addre", taikhoan.diachi);
                        command.ExecuteNonQuery();
                        return "Đăng ký thành công!";
                    }

                }
            }
            return "Tài khoản đã tồn tại!";
        }
    }

    public partial class DatabaseAccess
    {
        
        
    }
}
