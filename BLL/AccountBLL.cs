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
        public string AccountBLL_CheckLogin(User taikhoan)
        {
            // Kiểm tra nghiệp vụ
            if (taikhoan.Username == "") return "requeid_taikhoan";
            if (taikhoan.Password == "") return "requeid_password";

            string info = AccountAccess.AccountAccess_CheckLogin(taikhoan);
            return info;
        }
        public string AccountBLL_CheckSignUp(User taikhoan)
        {
            if (!checkPattern_0(taikhoan.Username)) return "requeid_taikhoan";
            if (taikhoan.Password == "") return "requeid_password";
            if (!checkPattern_1(RemoveDiacritics(taikhoan.FullName))) return "requeid_username";
            if (taikhoan.Email == "") return "requeid_email";
            if (taikhoan.Gender == "") return "requeid_gender";
            if (!checkPattern_2(taikhoan.PhoneNumber)) return "requeid_phonenumber";
            if (taikhoan.Address == "") return "requeid_address";
            return AccountAccess.AccountAccess_CheckSignUp(taikhoan);
        }

        public List<string> AccountBLL_Load_TenantName()
        {
            return AccountAccess.Load_TenantName();
        }

        public static string UpdatePassword(string email, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty";
            }
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                return "Please enter both password fields!";
            }

            if (newPassword != confirmPassword)
            {
                return "Passwords do not match!";
            }
            if (newPassword.Length < 8)
            {
                return "Password must be at least 8 characters long";
            }

            return AccountAccess.UpdatePassword(email, newPassword);
        }

        public static string CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "required_email";
            }
            return AccountAccess.CheckEmail(email);
        }
    }
}
