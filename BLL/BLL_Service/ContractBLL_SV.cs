using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_Service;
using DTO.DTO_Service;
namespace BLL.BLL_Service
{
  

    public class ContractBLL_SV
    {
        public static List<string> GetRoomsByTenant(string tenantID)
        {
            return ContractAccess.GetRoomsByTenantID(tenantID);
        }
    }


    
}
