using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.honhathao;
namespace BLL.honhathao
{
    public class RegistrationBLL
    {
        public static string RegistratrionBLL_update_registration(string registrationid,string endDate, string state)
        {
            return RegistrationAccess.update_registration( registrationid, endDate, state);
        }
        public static string RegistrationBLL_del_registration(string p_registration_id)
        {
            return RegistrationAccess.del_registration(p_registration_id);
        }
        public static DataTable RegistrationBLL_load_registration(string buildingid, string name)
        {
            return RegistrationAccess.load_registration(buildingid,name);
        }
        public static string RegistrationBLL_add_Registration(string p_tenant_id, string RoomId, string registration_date, string expiration_date, string status, string buildingid)
        {
            if(DateTime.TryParse(registration_date, out DateTime parsedDate))
            {
                registration_date = parsedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                return "invalid_";
            }
            if (DateTime.TryParse(expiration_date, out parsedDate))
            {
                expiration_date = parsedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                return "invalid_";
            }
            if(registration_date.CompareTo(expiration_date) > 0)
            {
                return "invalid_";
            }

            return RegistrationAccess.add_Registration(p_tenant_id, RoomId, registration_date, expiration_date, status, buildingid);
        }
    }
}
