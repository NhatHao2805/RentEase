using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
namespace BLL.honhathao
{
    public class TenantBLL
    {
       public static DataTable TenantBLL_load_Tenant()
        {
            return TenantAccess.load_Tenant();
        }
        public static string TenantBLL_add_Tenant( string FirstName, string LastName, string Birthday, string Gender, string PhoneNumber, string Email)
        {
            return TenantAccess.add_Tenant(FirstName,  LastName,  Birthday,  Gender,  PhoneNumber, Email);
        }
        public static string TenantBLL_update_Tenant(string TenantId, string FirstName, string LastName, string Birthday, string Gender, string PhoneNumber, string Email)
        {
            return TenantAccess.update_Tenant( TenantId,  FirstName,  LastName,  Birthday,  Gender,  PhoneNumber,  Email);
        }

        public static string TenantBLL_del_Tenant(string TenantId)
        {
            return TenantAccess.del_Tenant(TenantId);
        }
    }
}
