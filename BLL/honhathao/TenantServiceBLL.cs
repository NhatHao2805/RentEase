using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.honhathao
{
    public class TenantServiceBLL
    {
        public static DataTable TenantServiceBLL_load_registration_service_to_add(string tenant_id)
        {
            return DAL.honhathao.TenantServiceAccess.load_registration_service_to_add(tenant_id);
        }
        public static DataTable TenantServiceBLL_add_all_registration_Ser_into_billdetail(string billid, string ID, string AMOUNT)
        {
            return DAL.honhathao.TenantServiceAccess.add_all_registration_Ser_into_billdetail(billid, ID, AMOUNT);
        }
    }
}
