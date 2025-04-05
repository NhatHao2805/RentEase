using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
namespace BLL.honhathao
{
    public class BillDetailBLL
    {
        public static DataTable load_BillDetail(string billid)
        {
            return BillDetailAccess.load_billdetail(billid); ;
        }
    }
}
