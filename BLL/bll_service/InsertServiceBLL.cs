using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_Service;
using System.Runtime.Remoting.Messaging;
namespace BLL.BLL_Service
{
    public class InsertServiceBLL
    {
        private InsertServiceDAL serviceDAL = new InsertServiceDAL();

        public bool AddService(string serviceName, decimal unitPrice)
        {
            DichVuDTO newService = new DichVuDTO
            {
                ID = null,
                TenDichVu = serviceName,
                GiaDichVu = unitPrice
            };

            return serviceDAL.InsertService(newService);
        }
    }

}
