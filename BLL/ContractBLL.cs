using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ContractBLL
    {
        public static DataTable ContractBLL_load_Contract(string Username)
        {
            return ContractAccess.load_Contract(Username);
        } 
    }
}
