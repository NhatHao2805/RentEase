using DAL.dal_service;
using DTO.dto_service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.bll_service
{
    public class EmailBLL
    {
        private EmailDAL dal = new EmailDAL();

        //public bool GuiEmail(EmailDTO email)
        //{
        //    // Có thể kiểm tra dữ liệu ở đây nếu cần
        //    return dal.SendEmail(email);
        //}

        public string LayChuoiEmailNguoiNhan(string buildingID)
        {
            return dal.LayChuoiEmailNguoiNhanSapHetHan(buildingID);
        }

        public bool GuiEmail(EmailDTO email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email.From);

                foreach (string to in email.To.Split(','))
                {
                    if (!string.IsNullOrWhiteSpace(to))
                        mail.To.Add(to.Trim());
                }

                mail.Subject = email.Subject;
                mail.Body = email.Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(email.From, email.Password);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
