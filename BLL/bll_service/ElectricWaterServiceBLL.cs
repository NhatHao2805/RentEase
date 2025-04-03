using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.dto_service;
using DAL.dal_service;
namespace BLL.bll_service
{
    public class ElectricWaterServiceBLL
    {
        private ElectricWaterServiceDAL dal = new ElectricWaterServiceDAL();

        public List<ElectricWaterServiceDTO> GetAllElectricWaterData(string buildingID)
        {
            return dal.GetAllElectricWaterData(buildingID);
        }
    }

}
