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

        public static string connectString = @"Server=localhost;Database=rentease;Uid=root;Pwd=zxcvbnm;Pooling=false;Character Set=utf8";

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

        public static string connectString = @"Server=localhost;Database=rentease;Uid=root;Pwd=zxcvbnm;Pooling=false;Character Set=utf8";
        public DataTable LoadRoom()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectString))
            {
                connection.Open();
                using (MySqlDataAdapter adt = new MySqlDataAdapter("SELECT * FROM ROOM", connection))
                {
                    adt.Fill(dt);
                }
                connection.Close();
            }
            return dt;
        }

        public static string addRoomDatabase(Room room)
        {
            bool roomExists = false;
            using (MySqlConnection conn = SqlDataConnection.Connect())
            {
                try
                {
                    conn.Open();

                    // Kiểm tra nhà đã tồn tại chưa
                    using (MySqlCommand command2 = new MySqlCommand("SELECT check_Room(@new_roomid)", conn))
                    {
                        command2.Parameters.AddWithValue("@new_roomid", room.roomID);
                        object result = command2.ExecuteScalar();
                        if (result != null && Convert.ToInt32(result) == 0)
                        {
                            roomExists = true;
                        }
                    }

                    // Nếu nhà chưa tồn tại, thêm nhà mới
                    if (!roomExists)
                    {
                        using (MySqlCommand command = new MySqlCommand("proc_addRoom", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("new_roomid", room.roomID);
                            command.Parameters.AddWithValue("new_buildingid", room.buildingID);
                            command.Parameters.AddWithValue("new_type", room.type);
                            command.Parameters.AddWithValue("new_convenient", room.convenient);
                            command.Parameters.AddWithValue("new_area", room.area);
                            command.Parameters.AddWithValue("new_price", room.price);
                            command.Parameters.AddWithValue("new_status", room.status);
                            command.Parameters.AddWithValue("new_last_maintenance_date", room.lastMaintenanceDate);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Lỗi khi thêm: " + ex.Message);
                    Console.Error.WriteLine("Stack Trace: " + ex.StackTrace);
                    return "Đã xảy ra lỗi khi thêm!";
                }
            }

            // Trả về thông báo kết quả
            if (roomExists)
            {
                return "Phòng đã tồn tại!";
            }
            else
            {
                return "Thêm thành công!";
            }
        }
    }
}

