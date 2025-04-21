using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.hoaian;
using DTO;

namespace BLL.hoaian
{
    public class UserBLL
    {
        public static string CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "required_email";
            }
            return UserAccess.CheckEmail(email);
        }

    }
}
