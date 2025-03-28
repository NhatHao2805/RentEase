using DAL.DAL_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Service
{
    public class DeleteDichVuBLL
    {

        private DichVuDAL dichVuDAL = new DichVuDAL();

        public bool XoaDichVu(string id)
        {
            return dichVuDAL.XoaDichVu(id);
        }


    }
}
