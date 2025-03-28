using DAL.DAL_Service;
using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Service
{
    public class ServiceBLL
    {
        private UpdatePriceDAL serviceDAL = new UpdatePriceDAL();

        public bool UpdateServicePrice(string serviceName, decimal newPrice)
        {
            return serviceDAL.UpdateServicePrice(serviceName, newPrice);
        }
    }
}
