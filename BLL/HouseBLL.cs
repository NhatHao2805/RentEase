using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{

    public class HouseBLL
    {
        public List<string> HouseBLL_Load_HouseAddress()
        {
            return HouseAccess.Load_HouseAddress();
        }
        public string HouseBLL_TakePrice(string address)
        {
            return HouseAccess.HouseAccess_TakePrice(address);
        }
    }
}
