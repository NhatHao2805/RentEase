using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class AccountAccess:DatabaseAccess
    {
        public string CheckLogic(Account taikhoan)
        {
            string info = CheckLoginDatabase(taikhoan);
            return info;
        }
        public string addAccount(Account taikhoan)
        {
            return AddAccountDatabase(taikhoan);
        }


    }
}
