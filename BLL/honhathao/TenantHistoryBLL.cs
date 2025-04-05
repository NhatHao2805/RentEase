using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
using System.Data;
namespace BLL.honhathao
{
    public class TenantHistoryBLL
    {
        public static DataTable TenantHistoryBLL_load_AllTenantHistory(string name)
        {
            return TenantHistoryAccess.load_AllTenantHistory(name);
        }
        public static string TenantHistoryBLL_update_tenantHistory(string tenantHistoryid, string note)
        {
            return TenantHistoryAccess.update_tenantHistory(tenantHistoryid, note);
        }
        public static void TenantHistoryBLL_auto_AddTenantHistory(string contractid, string tenantid, string roomid, string startdate, string enddate)
        {
            TenantHistoryAccess.auto_AddTenantHistory(contractid, tenantid, roomid, startdate, enddate);
        }
        public static DataTable TenantHistoryBLL_count_TenantHistory(string buildingID)
        {
            return TenantHistoryAccess.count_TenantHistory(buildingID);
        }

        public static DataTable TenantHistoryBLL_load_Tenant(string buildingID,string name)
        {
            return TenantHistoryAccess.load_Tenant(buildingID,name);
        }
    }
}
