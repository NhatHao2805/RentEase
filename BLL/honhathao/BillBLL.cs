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
        public static string BillBLL_calculate_bill()
        {
            return BillAccess.calculate_bill();
        }
        public static string BillBLL_load_BillID()
        {
            DataTable output = BillAccess.take_billid();

            foreach (DataRow row in output.Rows)
            {
                for (int i = 0; i < output.Columns.Count; i++)
                {
                    Console.WriteLine(row[i]);
                }
            }
            return output.Rows[0][0].ToString();
        }
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
