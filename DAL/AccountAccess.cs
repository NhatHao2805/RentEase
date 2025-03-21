using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class AccountAccess : DatabaseAccess
    {
        public string CheckLogic(User taikhoan)
        {
            string info = CheckLoginDatabase(taikhoan);
            return info;
        }
<<<<<<< HEAD
        //public string addAccount(User taikhoan)
        //{
        //    return addAccountDatabase(taikhoan);
        //}
=======
        public string addAccount(Account taikhoan)
        {
            return AddAccountDatabase(taikhoan);
        }
>>>>>>> 6eb7bf71ccfcf093d01505c8501d25f943368f94


    }
}
