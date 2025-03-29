using DAL.DAL_Service;
using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Service
{
    public class ServiceUsageBLL
    {
        private ServiceUsageDAL serviceUsageDAL = new ServiceUsageDAL();
        private DeleteTenantService deleteTS = new DeleteTenantService();
        public bool RegisterServiceUsage(string tenantID, string serviceID, string action)
        {
            ServiceUsageDTO newServiceUsage = new ServiceUsageDTO(tenantID, serviceID);

            if (action.Equals("delete", StringComparison.OrdinalIgnoreCase))
            {
                return deleteTS.DeleteTenant_Service(newServiceUsage);
            }
            else
            {
                return serviceUsageDAL.InsertServiceUsage(newServiceUsage);
            }
   
                
        }
    }

}
