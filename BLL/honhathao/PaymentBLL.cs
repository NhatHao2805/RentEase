using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.honhathao;
namespace BLL.honhathao
{
    public class PaymentBLL
    {
        public static DataTable PaymentBLL_load_payment(string buildingID, string name, string tenantid)
        {           
            return PaymentAccess.load_payment(buildingID, name, tenantid);
        }
    }
}
