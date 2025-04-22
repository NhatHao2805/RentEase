using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.dto_service;
using System.Net;
using System.Net.Mail;
using System.Data;
using MySql.Data.MySqlClient;
namespace DAL.dal_service
{
    public class EmailDAL
    {
        public bool SendEmail(EmailDTO email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email.From);
                mail.To.Add(email.To);
                mail.Subject = email.Subject;
                mail.Body = email.Body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(email.From, email.Password); // Mật khẩu ứng dụng
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string LayChuoiEmailNguoiNhanSapHetHan(string buildingID)
        {
            List<string> emails = new List<string>();

            try
            {
                using (MySqlConnection conn = MySqlConnectionData.Connect())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (MySqlCommand cmd = new MySqlCommand("GetExpiringEmails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_buildingID", buildingID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    string email = reader.GetString("EMAIL");
                                    if (!string.IsNullOrEmpty(email))
                                    {
                                        emails.Add(email);
                                    }
                                }
                                catch (Exception itemEx)
                                {
                                    Console.WriteLine($"Lỗi đọc email: {itemEx.Message}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DAL - EmailDAL: {ex.Message}");
            }

            return string.Join(",", emails); // trả về chuỗi email ngăn cách bằng dấu phẩy
        }

    }

}
