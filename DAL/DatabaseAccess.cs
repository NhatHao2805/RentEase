using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Principal;
using DTO;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class SqlDataConnection
    {
        //Tạo kết nối với csdl
        private static MySqlConnection conn = null;
        
        private static string connectString = @"Server = localhost; Database = rentease; Uid = root; pwd = ; Pooling = false; Character Set = utf8";
        
        public static MySqlConnection Connect()
        {
            try
            {
                conn = new MySqlConnection(connectString);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
            }
            return conn;

        }
    }
    public class DatabaseAccess
    {
        public static string checkLoginDatabase(User taikhoan)
        {
            string query = "proc_login";
            string user = null;
            MySqlConnection conn = SqlDataConnection.Connect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("username", taikhoan.username);
            cmd.Parameters.AddWithValue("password", taikhoan.password);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                }
                reader.Close();
            }
            else
            {
                user = "Tài khoản hoặc mật khẩu không chính xác!";
            }
            conn.Close();
            return user;
        }

        //public static string addAccountDatabase(User taikhoan)
        //{
        //    //bool check = false;

        //    //using (SqlConnection conn = SqlConnectionData.Connect())
        //    //{
        //    //    conn.Open();
        //    //    using (SqlCommand command2 = new SqlCommand("select dbo.check_account(@user)", conn))
        //    //    {
        //    //        command2.Parameters.AddWithValue("@user", taikhoan.taikhoan);
        //    //        object a = command2.ExecuteScalar();
        //    //        if (a != null)
        //    //        {
        //    //            int result = Convert.ToInt32(a);
        //    //            if(result == 1) check = true;
        //    //        }
        //    //    }

        //    //    using (SqlCommand command = new SqlCommand("proc_addAccount", conn))
        //    //    {
        //    //        command.CommandType = CommandType.StoredProcedure;
        //    //        command.Parameters.AddWithValue("@user", taikhoan.taikhoan);
        //    //        command.Parameters.AddWithValue("@pass", taikhoan.matkhau);
        //    //        command.ExecuteNonQuery();
        //    //    }

        //    //}
        //    //if (check)
        //    //{
        //    //    return "Tài khoản đã tồn tại!";
        //    //}
        //    //else
        //    //{
        //    //    return "Đăng ký thành công!";
        //    //}
        //}
    }
}

