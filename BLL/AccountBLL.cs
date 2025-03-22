using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic; 

namespace BLL
{
    public class AccountBLL
    {
        private bool checkPattern_0(string input)
        {
            string pattern = "^[a-zA-Z0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        private bool checkPattern_1(string input)
        {
            string pattern = "^[a-zA-Z0-9 ]+$";
            return Regex.IsMatch(input, pattern);
        }

        private bool checkPattern_2(string input)
        {
            string pattern = "^[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }

        private string RemoveDiacritics(string input)
        {
            string normalized = input.Normalize(System.Text.NormalizationForm.FormD);
            Regex regex = new Regex(@"\p{M}", RegexOptions.Compiled);
            string withoutDiacritics = regex.Replace(normalized, string.Empty);
            withoutDiacritics = withoutDiacritics.Replace('đ', 'd').Replace('Đ', 'D');
            return withoutDiacritics;
        }
        public string AccountBLL_CheckLogin(Account taikhoan)
        {
            // Kiểm tra nghiệp vụ
            if (taikhoan.taikhoan == "") return "requeid_taikhoan";
            if (taikhoan.matkhau == "") return "requeid_password";

            string info = AccountAccess.AccountAccess_CheckLogin(taikhoan);
            return info;
        }
        public string AccountBLL_CheckSignUp(Account taikhoan)
        {
            if (!checkPattern_0(taikhoan.taikhoan)) return "requeid_taikhoan";
            if (taikhoan.matkhau == "") return "requeid_password";
            if (!checkPattern_1(RemoveDiacritics(taikhoan.hovaten))) return "requeid_username";
            if (taikhoan.email == "") return "requeid_email";
            if (taikhoan.gioitinh == "") return "requeid_gender";
            if (!checkPattern_2(taikhoan.sdt)) return "requeid_phonenumber";
            if (taikhoan.diachi == "") return "requeid_address";
            return AccountAccess.AccountAccess_CheckSignUp(taikhoan);
        }
    }
}
