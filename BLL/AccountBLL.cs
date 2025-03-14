using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class AccountBLL
    {
        AccountAccess tkAccess = new AccountAccess();
        public string CheckLogic(Account taikhoan)
        {
            // Kiểm tra nghiệp vụ
            if (taikhoan.taikhoan == "")
            {
                return "requeid_taikhoan";
            }

            if (taikhoan.matkhau == "")
            {
                return "requeid_password";
            }

            string info = tkAccess.CheckLogic(taikhoan);
            return info;
        }
        public string addAccountBLL(Account taikhoan)
        {
           return tkAccess.addAccount(taikhoan);
        }
    }
}
