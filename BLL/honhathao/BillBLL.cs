using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
namespace BLL.honhathao
{
    public class BillBLL
    {
        public static DataTable BillBLL_load_Bill(string usern, string name,string buildingid)
        {           
            return BillAccess.load_Bill(usern, name,buildingid); 
        }
        public static string BillBLL_Del_Bill(string billID)
        {
            return BillAccess.del_Bill(billID);
        }
    }
}
