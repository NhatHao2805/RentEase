using DAL.dal_service;
using DTO.DTO_Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.bll_service
{
    public class GetAllServiceBLL
    {
        private GetAllServiceDAL dal;

        public GetAllServiceBLL()
        {
            dal = new GetAllServiceDAL();
        }

        public List<DichVuDTO> GetAllDichVu()
        {
            return dal.GetAllDichVu();
        }
    }
}
