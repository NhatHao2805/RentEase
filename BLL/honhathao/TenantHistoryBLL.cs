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
        public static DataTable TenantHistoryBLL_load_Tenant(string buildingID)
        {
            return TenantHistoryAccess.load_Tenant(buildingID);
        }
    }
}
