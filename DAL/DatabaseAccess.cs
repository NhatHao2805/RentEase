using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Principal;
using DTO;
namespace DAL
{
    public class SqlConnectionData
    {
        //Tạo kết nối với csdl
        public static string connectString = @"Data Source=HONHATHAO\SQLEXPRESS;Initial Catalog=QuanLyThueNha;Integrated Security=True;Encrypt=False";
        public static SqlConnection sqlConnection = null;
        public static SqlConnection Connect()
        {
            try
            {
                if(sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(connectString);
                    sqlConnection.Close();
                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
            }
            Console.WriteLine(sqlConnection.State.ToString());
            return sqlConnection;
        }
    }
    public class DatabaseAccess
    {
        public static string checkLoginDatabase(Account taikhoan)
        {
            
            string user = null;
            SqlConnection conn = SqlConnectionData.Connect();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand command = new SqlCommand("proc_login", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user", taikhoan.taikhoan);
            command.Parameters.AddWithValue("@pass", taikhoan.matkhau);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                }
                //conn.Close();

                reader.Close();
            }
            else
            {
                conn.Close();

                return "Tài khoản hoặc mật khẩu không chính xác!";
            }
            conn.Close();
            return user;
        }

        public static string addAccountDatabase(Account taikhoan)
        {
            bool check = false;

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command2 = new SqlCommand("select dbo.check_account(@user)", conn))
                {
                    command2.Parameters.AddWithValue("@user", taikhoan.taikhoan);
                    object a = command2.ExecuteScalar();
                    if (a != null)
                    {
                        int result = Convert.ToInt32(a);
                        if(result == 1) check = true;
                    }
                }

                using (SqlCommand command = new SqlCommand("proc_addAccount", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@user", taikhoan.taikhoan);
                    command.Parameters.AddWithValue("@pass", taikhoan.matkhau);
                    command.ExecuteNonQuery();
                }
               
            }
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

