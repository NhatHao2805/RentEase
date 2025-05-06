using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.honhathao;
namespace BLL.honhathao
{
    public class TenantBLL
    {
       public static DataTable TenantBLL_load_Tenant(string buildingid, string name)
        {
            return TenantAccess.load_Tenant(buildingid,name);
        }
       public static (bool, string) TenantBLL_hodem(string FisrtName)
        {
            if (string.IsNullOrWhiteSpace(FisrtName))
                return (false, "Họ không được để trống");
            if (!Regex.IsMatch(FisrtName, @"^[\p{L}\s]+$"))
                return (false, "Họ chỉ được chứa chữ cái và dấu cách");
            return (true, "Success");
        }
        public static (bool, string) TenantBLL_hoten(string LastName)
        {
            if (string.IsNullOrWhiteSpace(LastName))
                return (false, "Tên không được để trống");
            if (!Regex.IsMatch(LastName, @"^[\p{L}\s]+$"))
                return (false, "Tên chỉ được chứa chữ cái và dấu cách");
            return (false, "Success");
        }

        public static (bool, string) TenantBLL_sdt(string PhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                return (false, "Số điện thoại không được để trống");
            if (PhoneNumber.Length != 10 || !PhoneNumber.All(char.IsDigit))
                return (false, "Số điện thoại phải có đúng 10 chữ số và không chứa ký tự khác");
            return (true, "Success");
        }

        public static (bool, string) TenantBLL_email(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
                return (false, "Email không được để trống");
            try
            {
                var mailAddress = new MailAddress(Email);
            }
            catch
            {
                return (false, "Email không đúng định dạng");
            }
            return (true, "Success");
        }

        private static (bool, string) checklogic(string FirstName, string LastName, string Birthday, string Gender, string PhoneNumber, string Email)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(FirstName))
            sb.AppendLine("Họ không được để trống\n");

            if (string.IsNullOrWhiteSpace(LastName))
                sb.AppendLine("Tên không được để trống\n");

            if (!Regex.IsMatch(FirstName, @"^[\p{L}\s]+$"))
                sb.AppendLine("Họ chỉ được chứa chữ cái và dấu cách\n");

            if (!Regex.IsMatch(LastName, @"^[\p{L}\s]+$"))
                sb.AppendLine("Tên chỉ được chứa chữ cái và dấu cách\n");

            if (string.IsNullOrWhiteSpace(Birthday))
                sb.AppendLine("Ngày sinh không được để trống\n");

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                sb.AppendLine("Số điện thoại không được để trống\n");

            if (PhoneNumber.Length != 10 || !PhoneNumber.All(char.IsDigit))
                sb.AppendLine("Số điện thoại phải có đúng 10 chữ số và không chứa ký tự khác\n");

            if (string.IsNullOrWhiteSpace(Email))
                sb.AppendLine("Email không được để trống\n");

            try
            {
                var mailAddress = new MailAddress(Email);
            }
            catch
            {
                sb.AppendLine("Email không đúng định dạng\n");
            }

            if(sb.Length > 0)
            {
                return (false, sb.ToString());
            }
            return (true, "Hợp lệ");
        }
        public static string TenantBLL_add_Tenant(string username, string FirstName, string LastName, string Birthday, string Gender, string PhoneNumber, string Email,string buildingid)
        {
            if (string.IsNullOrWhiteSpace(Email) && 
                string.IsNullOrWhiteSpace(FirstName) && 
                string.IsNullOrWhiteSpace(LastName) &&
                string.IsNullOrWhiteSpace(Birthday) &&
                string.IsNullOrWhiteSpace(Gender) &&
                string.IsNullOrWhiteSpace(PhoneNumber))
            {
                return "invalid_";
            }
            var result = checklogic(FirstName, LastName, Birthday, Gender, PhoneNumber, Email);
            if (result.Item1)
            {
                return TenantAccess.add_Tenant(username, FirstName, LastName, Birthday, Gender, PhoneNumber, Email, buildingid);
            }
            else
            {
                return result.Item2;
            }
            
        }
        public static string TenantBLL_update_Tenant(string TenantId, string FirstName, string LastName, string Birthday, string Gender, string PhoneNumber, string Email)
        {
            var result = checklogic(FirstName, LastName, Birthday, Gender, PhoneNumber, Email);
            if (result.Item1)
            {
                return TenantAccess.update_Tenant(TenantId, FirstName, LastName, Birthday, Gender, PhoneNumber, Email);
            }
            else
            {
                return "invalid_";
            }
            
        }

        public static string TenantBLL_del_Tenant(string TenantId)
        {
            return TenantAccess.del_Tenant(TenantId);
        }

        public static List<string> TenantBll_Load_TenantID()
        {
            return TenantAccess.Load_TenantID();
        }

        public static DataTable TenantBLL_load_Tenant_by_RoomID(string p_building_id, string roomID)
        {
            return TenantAccess.load_Tenant_by_Roomid(p_building_id,roomID);
        }

        public static List<string> Load_TenantID_By_Buildingid(string buildingid)
        {
            return TenantAccess.Load_TenantID_By_Buildingid(buildingid);
        }

    }
}
